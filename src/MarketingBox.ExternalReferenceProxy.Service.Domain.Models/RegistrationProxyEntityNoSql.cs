using MyNoSqlServer.Abstractions;

namespace MarketingBox.ExternalReferenceProxy.Service.Domain.Models
{
    public class RegistrationProxyEntityNoSql : MyNoSqlDbEntity
    {
        public const string TableName = "marketingbox-registrationproxy-entity";
        public static string GeneratePartitionKey(string token) => $"token:{token}";
        private static string GenerateRowKey() => "registrationproxy";
        
        public RegistrationProxyEntity Entity { get; set; }
        
        public static RegistrationProxyEntityNoSql Create(RegistrationProxyEntity entity)
        {
            return new RegistrationProxyEntityNoSql()
            {
                PartitionKey = GeneratePartitionKey(entity.Token),
                RowKey = GenerateRowKey(),
                Entity = entity
            };
        }
    }
}
