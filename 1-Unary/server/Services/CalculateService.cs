using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace serverCalculate
{
    public class CalculateService : Calculate.CalculateBase
    {
        public override async Task<SumResponse> Sum(SumRequest request, ServerCallContext context)
        {
            var task = await Task.Run(() =>
            {
                var response = new SumResponse();
                response.Result = request.S1 + request.S2;
                return response;
            });

            return task;
        }
    }
}
