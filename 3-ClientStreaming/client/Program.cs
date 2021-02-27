using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using server;

namespace client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5000");
            var client = new Greeter.GreeterClient(channel);

            var request = client.SayHello();

            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(1000);
                await request.RequestStream.WriteAsync(new HelloRequest
                {
                    Name = $"Düzgün {i}"
                });
            }

            await request.RequestStream.CompleteAsync();
            Console.WriteLine(await request.ResponseAsync);
        }
    }
}
