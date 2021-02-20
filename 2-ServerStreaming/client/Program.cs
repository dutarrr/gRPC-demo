using System;
using System.Threading;
using server;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //*****************************************
            var channel = GrpcChannel.ForAddress("http://localhost:5000");

            var client = new Greeter.GreeterClient(channel);

            var response = client.SayHello(new HelloRequest { Name = "Düzgün Tutar" });
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            while (await response.ResponseStream.MoveNext(cancellationTokenSource.Token))
            {
                System.Console.WriteLine(response.ResponseStream.Current.Message);
            }
        }
    }
}
