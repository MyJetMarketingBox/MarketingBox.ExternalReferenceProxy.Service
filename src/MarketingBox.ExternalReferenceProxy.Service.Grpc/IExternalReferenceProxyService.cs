using System.ServiceModel;
using System.Threading.Tasks;
using MarketingBox.ExternalReferenceProxy.Service.Grpc.Models;

namespace MarketingBox.ExternalReferenceProxy.Service.Grpc
{
    [ServiceContract]
    public interface IExternalReferenceProxyService
    {
        [OperationContract]
        Task<GetProxyRefResponse> GetProxyRefAsync(GetProxyRefRequest request);
    }
}