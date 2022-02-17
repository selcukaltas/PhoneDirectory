using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.ReportApplicationCore.Services
{
    public static class ConsumerService
    {
      
        public static IApplicationBuilder UseRabbitMq(this IApplicationBuilder app)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
            var conn = configuration["RabbitMq"];

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

            var consumerEvent = new EventingBasicConsumer(channel);

            consumerEvent.Received += (ch, ea) =>
            {
                var reportService = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IReportService>();
                var reportId = JsonConvert.DeserializeObject<Guid>(Encoding.UTF8.GetString(ea.Body.ToArray()));
                Console.WriteLine("Data received");
                Console.WriteLine($"Received Id: {reportId}");
                reportService.PrepareReportDetail(reportId);
            };

            channel.BasicConsume(createDocumentQueue, true, consumerEvent);

            return app;
        }
    }
}
