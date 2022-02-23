using System.ServiceModel;
using System.Threading.Tasks;
using MarketingBox.ExternalReferenceProxy.Service.Grpc.Models;
using MarketingBox.Sdk.Common.Models.Grpc;

namespace MarketingBox.ExternalReferenceProxy.Service.Grpc
{
    [ServiceContract]
    public interface IExternalReferenceProxyService
    {
        [OperationContract]
        Task<Response<string>> GetProxyRefAsync(GetProxyRefRequest request);
    }
}