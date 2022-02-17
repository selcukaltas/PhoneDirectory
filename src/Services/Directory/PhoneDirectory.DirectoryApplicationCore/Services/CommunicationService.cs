using Newtonsoft.Json;
using PhoneDirectory.DirectoryApplicationCore.Interfaces;
using PhoneDirectory.Shared.Result;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.DirectoryApplicationCore.Services
{
    public class CommunicationService : ICommunicationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CommunicationService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Response<NoContent>> Publish()
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:5001/api/ReportRequest/");
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return Response<NoContent>.Fail("Something went wrong",500);

            var responseStream = await response.Content.ReadAsStringAsync();

            
             var reportId = JsonConvert.DeserializeObject<Guid>(responseStream)

            var conn = _phoneBookSettings.RabbitMqCon;

            var createDocumentQueue = "create_document_queue";
            var documentCreateExchange = "document_create_exchange";

            ConnectionFactory connectionFactory = new()
            {
                Uri = new Uri(conn)
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();
            channel.ExchangeDeclare(documentCreateExchange, "direct");

            channel.QueueDeclare(createDocumentQueue, false, false, false);
            channel.QueueBind(createDocumentQueue, documentCreateExchange, createDocumentQueue);

            channel.BasicPublish(documentCreateExchange, createDocumentQueue, null, Encoding.UTF8.GetBytes(reportId.ToString()));
        }
    }
}
