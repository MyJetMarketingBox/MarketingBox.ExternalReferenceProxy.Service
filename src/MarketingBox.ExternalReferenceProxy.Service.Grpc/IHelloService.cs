using System.ServiceModel;
using System.Threading.Tasks;
using MarketingBox.ExternalReferenceProxy.Service.Grpc.Models;

namespace MarketingBox.ExternalReferenceProxy.Service.Grpc
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        Task<HelloMessage> SayHelloAsync(HelloRequest request);
    }
}