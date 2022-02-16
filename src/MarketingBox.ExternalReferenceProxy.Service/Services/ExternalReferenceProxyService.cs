using System;
using System.Threading.Tasks;
using MarketingBox.ExternalReferenceProxy.Service.Engine;
using Microsoft.Extensions.Logging;
using MarketingBox.ExternalReferenceProxy.Service.Grpc;
using MarketingBox.ExternalReferenceProxy.Service.Grpc.Models;
using Newtonsoft.Json;

namespace MarketingBox.ExternalReferenceProxy.Service.Services
{
    public class ExternalReferenceProxyService: IExternalReferenceProxyService
    {
        private readonly ILogger<ExternalReferenceProxyService> _logger;
        private readonly ExternalReferenceProxyEngine _externalReferenceProxyEngine;

        public ExternalReferenceProxyService(ILogger<ExternalReferenceProxyService> logger, 
            ExternalReferenceProxyEngine externalReferenceProxyEngine)
        {
            _logger = logger;
            _externalReferenceProxyEngine = externalReferenceProxyEngine;
        }

        public async Task<GetProxyRefResponse> GetProxyRefAsync(GetProxyRefRequest request)
        {
            _logger.LogInformation($"ExternalReferenceProxyService.GetProxyRefAsync reveive request : {JsonConvert.SerializeObject(request)}");
            try
            {
                var proxyLink = await _externalReferenceProxyEngine
                    .GetProxyRefAsync(request.BrandLink, request.RegistrationId, request.RegistrationUId, request.TenantId);

                return new GetProxyRefResponse()
                {
                    Success = true,
                    ProxyLink = proxyLink
                };
            }
            catch (Exception ex)
            {
                return new GetProxyRefResponse()
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
