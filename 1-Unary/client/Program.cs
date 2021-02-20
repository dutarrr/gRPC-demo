using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using server;
using serverCalculate;

namespace client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //*****************************************
            // var channel = GrpcChannel.ForAddress("http://localhost:5000");

            // var client = new Greeter.GreeterClient(channel);

            // HelloReply response = await client.SayHelloAsync(new HelloRequest { Name = "Düzgün Tutar" });

            // Console.WriteLine(response.Message);


            //*******************************************
            var channel = GrpcChannel.ForAddress("http://localhost:5000");

            var client = new Calculate.CalculateClient(channel);

            SumResponse response = await client.SumAsync(new SumRequest { S1 = 12, S2 = 15 });

            Console.WriteLine(response.Result);
        }
    }
}
