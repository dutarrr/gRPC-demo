using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace server
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }
        public override async Task<HelloReply> SayHello(Grpc.Core.IAsyncStreamReader<HelloRequest> requestStream, Grpc.Core.ServerCallContext context)
        {
            while (await requestStream.MoveNext(context.CancellationToken))
            {
                Console.WriteLine($"Gelen İsim: {requestStream.Current.Name}");
            }
            
            return new HelloReply
            {
                Message = "Mesaj alındı gardaş.. :)"
            };
        }
    }
}
