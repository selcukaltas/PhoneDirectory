using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhoneDirectory.DirectoryApplicationCore.Config;
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
        private readonly ConfigHelper _configHelper;
        public CommunicationService(IHttpClientFactory httpClientFactory, ConfigHelper configHelper)
        {
            _httpClientFactory = httpClientFactory;
            _configHelper = configHelper;
        }
        public async Task<Response<NoContent>> Publish()
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:5001/api/Report/ReportRequest/");
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return Response<NoContent>.Fail("Something went wrong", 500);

            var responseStream = await response.Content.ReadAsStringAsync();


            var reportId = (JObject)JsonConvert.DeserializeObject(responseStream);

            var conn = _configHelper.RabbitMqCon;

            //var createDocumentQueue = "create_document_queue";
            //var documentCreateExchange = "document_create_exchange";

            //ConnectionFactory connectionFactory = new()
            //{
            //    Uri = new Uri(conn)
            //};

            //var connection = connectionFactory.CreateConnection();

            //var channel = connection.CreateModel();
            //channel.ExchangeDeclare(documentCreateExchange, "direct");

            //channel.QueueDeclare(createDocumentQueue, false, false, false);
            //channel.QueueBind(createDocumentQueue, documentCreateExchange, createDocumentQueue);

            //channel.BasicPublish(documentCreateExchange, createDocumentQueue, null, Encoding.UTF8.GetBytes(reportId["data"].ToString()));
            var factory = new ConnectionFactory() { Uri= new Uri(conn) };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue:"create-document", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var body = Encoding.UTF8.GetBytes(reportId["data"].ToString());

                channel.BasicPublish(exchange:"", routingKey:"create-document", basicProperties: null, body: body);
                Console.WriteLine(" [x] Sent {0}", reportId["data"].ToString());
            }

          

            return Response<NoContent>.Success(202);
        }
    }
}
