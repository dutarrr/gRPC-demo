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
        public override async Task SayHello(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(1000);
                await responseStream.WriteAsync(new HelloReply
                {
                    Message = $"{i} - {request.Name}"
                });
            }
        }
    }
}
