using System;
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

            HelloReply response = await client.SayHelloAsync(new HelloRequest { Name = "Düzgün Tutar" });

            Console.WriteLine(response.Message);
        }
    }
}
