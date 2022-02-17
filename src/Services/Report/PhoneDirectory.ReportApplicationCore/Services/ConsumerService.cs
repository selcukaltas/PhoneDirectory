using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
    public class ConsumerService
    {
        private readonly IServiceProvider _serviceProvider;
        ConnectionFactory factory { get; set; }
        IConnection connection { get; set; }
        IModel channel { get; set; }


        public ConsumerService(IServiceProvider serviceProvider)

        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json")
.Build();
            var conn = configuration["RabbitMq"];
            this.factory = new ConnectionFactory() { Uri = new Uri(conn) };
            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
            _serviceProvider = serviceProvider;
        }

        public  void Register()
        {

            channel.QueueDeclare(queue: "create-document", durable: false, exclusive: false, autoDelete: false, arguments: null);
            var message = "";
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                message = Encoding.UTF8.GetString(body);
                int m = 0;

            };
            var _reportService = _serviceProvider.GetRequiredService<IReportService>();
            _reportService.PrepareReportDetail(new Guid(message)).ConfigureAwait(false);
            channel.BasicConsume(queue: "create-document", autoAck: true, consumer: consumer);
        }

        public void Deregister()
        {
            this.connection.Close();
        }


    }
    public static class ApplicationBuilderExtentions
    {
        private static ConsumerService _listener { get; set; }

        public static IApplicationBuilder UseRabbitListener(this IApplicationBuilder app)
        {
            _listener = app.ApplicationServices.GetService<ConsumerService>();

            var lifetime = app.ApplicationServices.GetService<IApplicationLifetime>();

            lifetime.ApplicationStarted.Register(OnStarted);

            lifetime.ApplicationStopping.Register(OnStopping);

            return app;
        }

        private static void OnStarted()
        {
            _listener.Register();
        }

        private static void OnStopping()
        {
            _listener.Deregister();
        }
    }
}

