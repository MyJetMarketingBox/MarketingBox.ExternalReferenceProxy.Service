using Autofac;
using MarketingBox.ExternalReferenceProxy.Service.Grpc;

// ReSharper disable UnusedMember.Global

namespace MarketingBox.ExternalReferenceProxy.Service.Client
{
    public static class AutofacHelper
    {
        public static void RegisterExternalReferenceProxyServiceClient(this ContainerBuilder builder, string grpcServiceUrl)
        {
            var factory = new ExternalReferenceProxyServiceClientFactory(grpcServiceUrl);

            builder.RegisterInstance(factory.GetHelloService()).As<IExternalReferenceProxyService>().SingleInstance();
        }
    }
}
