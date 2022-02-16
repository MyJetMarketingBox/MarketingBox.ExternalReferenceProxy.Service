using System;
using System.Linq;
using System.Threading.Tasks;
using MarketingBox.ExternalReferenceProxy.Service.Domain.Models;
using Microsoft.Extensions.Logging;
using MyNoSqlServer.Abstractions;
using Newtonsoft.Json;

namespace MarketingBox.ExternalReferenceProxy.Service.Engine
{
    public class ExternalReferenceProxyEngine
    {
        private readonly ILogger<ExternalReferenceProxyEngine> _logger;
        private readonly IMyNoSqlServerDataWriter<RegistrationProxyEntityNoSql> _myNoSqlServerDataWriter;

        public ExternalReferenceProxyEngine(IMyNoSqlServerDataWriter<RegistrationProxyEntityNoSql> myNoSqlServerDataWriter, 
            ILogger<ExternalReferenceProxyEngine> logger)
        {
            _myNoSqlServerDataWriter = myNoSqlServerDataWriter;
            _logger = logger;
        }

        public async Task<string> GetProxyRefAsync(string brandLink, long registrationId, string registrationUId, string tenantId)
        {
            var url = Program.Settings.ExternalReferenceProxyApiUrl;
            var path = Program.Settings.ExternalReferenceProxyApiUrlPath;
            var token = Guid.NewGuid().ToString("N");
            var proxyLink = url + path + token;
            
            var expirationDate = DateTime.UtcNow.AddHours(Program.Settings.ProxyLinkLifetimeInHours);

            var proxyEntity = new RegistrationProxyEntity()
            {
                BrandLink = brandLink,
                ExpirationDate = expirationDate,
                ProxyLink = proxyLink,
                RegistrationId = registrationId,
                RegistrationUId = registrationUId,
                TenantId = tenantId,
                Token = token
            };
            await _myNoSqlServerDataWriter.InsertOrReplaceAsync(RegistrationProxyEntityNoSql.Create(proxyEntity));
            _logger.LogInformation($"Finish saving to NoSql entity: {JsonConvert.SerializeObject(proxyEntity)}");
            
            await CleanNoSql();
            
            return proxyLink;
        }

        private async Task CleanNoSql()
        {
            var expiredEntities = (await _myNoSqlServerDataWriter.GetAsync())
                .Where(e => e.Entity.ExpirationDate < DateTime.UtcNow)
                .ToList();
            
            _logger.LogInformation($"Find and start removing {expiredEntities.Count} expired entities in NoSql.");
            
            foreach (var elem in expiredEntities)
            {
                await _myNoSqlServerDataWriter.DeleteAsync(elem.PartitionKey, elem.RowKey);
            }
        }
    }
}