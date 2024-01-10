using MailKit.Net.Smtp;
using MimeKit;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using TK_Project.Application.Interfaces.Services;
using TK_Project.Domain.Entities;

namespace TK_Project.Infrastructure.Services
{
    public class MailService : IMailService
    {
        public async Task SendMail(Mail mailModel)
        {
            var mailPassenger = new MimeMessage();
            
            //mail adresi girisleri
            MailboxAddress mailFrom = new MailboxAddress("Service Provider", "testtraversaltesttraversal@gmail.com");
            MailboxAddress mailTo = new MailboxAddress("Consumer", mailModel.To);
            mailPassenger.From.Add(mailFrom);
            mailPassenger.To.Add(mailTo);

            //Mesaj icerigi
            mailPassenger.Subject = mailModel.Subject;
            mailPassenger.Body = new TextPart { Text = mailModel.Body };

            //smtp client
            SmtpClient client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, false);
            await client.AuthenticateAsync("testtraversaltesttraversal@gmail.com", "kecw lzqd ddoo wnsm");
            await client.SendAsync(mailPassenger);
            //error
            await client.DisconnectAsync(true);
        }

        public async Task WriteQueue(Mail mailModel)
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
            };

            using (var connection = connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "mail-queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var mailMessage = new Mail() {To = mailModel.To, From = mailModel.From , Body = mailModel.Body, Subject = mailModel.Subject};

                string mailMessageJson = JsonSerializer.Serialize(mailMessage);

                var body = Encoding.UTF8.GetBytes(mailMessageJson);

                channel.BasicPublish(exchange: "",
                                     routingKey: "mail-queue",
                                     basicProperties: null,
                                     body: body);
                await Console.Out.WriteLineAsync("kuyruğa eklendi");
            }
        }

        public async Task ReceiveQueueAndSendMail()
        {
            
            string response ="bos";
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
            };

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "mail-queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                
                consumer.Received += async (model, mq) =>
                {
                    var body = mq.Body.ToArray();
                    var mailMessageString = Encoding.UTF8.GetString(body);
                    
                    
                    Mail mail = new Mail();
                    mail = JsonSerializer.Deserialize<Mail>(mailMessageString);
                    //Console.WriteLine("To:"+mail.To+"From:"+mail.From + "Subject:" + mail.Subject + "Body:" + mail.Body);
                    await SendMail(mail);
                    await Console.Out.WriteLineAsync("received: " + mailMessageString);
                };        
                
                channel.BasicConsume(queue: "mail-queue",
                                     autoAck: true,
                                     consumer: consumer);
                await Task.Delay(3000);
            }
            await Task.CompletedTask;
        }

    }
}