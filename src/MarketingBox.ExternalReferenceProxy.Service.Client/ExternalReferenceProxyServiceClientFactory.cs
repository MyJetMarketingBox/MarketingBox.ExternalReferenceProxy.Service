using JetBrains.Annotations;
using MyJetWallet.Sdk.Grpc;
using MarketingBox.ExternalReferenceProxy.Service.Grpc;

namespace MarketingBox.ExternalReferenceProxy.Service.Client
{
    [UsedImplicitly]
    public class ExternalReferenceProxyServiceClientFactory: MyGrpcClientFactory
    {
        public ExternalReferenceProxyServiceClientFactory(string grpcServiceUrl) : base(grpcServiceUrl)
        {
        }

        public IExternalReferenceProxyService GetHelloService() => CreateGrpcService<IExternalReferenceProxyService>();
    }
}
