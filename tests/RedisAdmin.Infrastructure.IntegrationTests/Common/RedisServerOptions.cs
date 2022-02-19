namespace RedisAdmin.Infrastructure.IntegrationTests.Common
{
    public class RedisServerOptions
    {
        public const string RedisServer = "RedisServer";

        public string ConnectionString { get; set; }

        /// <summary>
        /// The clear method will flush all keys on ALL endpoints.
        /// This needs its own instance to test as this will cause race conditions / un-expected failure of other tests.
        /// </summary>
        public string ConnectionStringForClearTests { get; set; }
    }
}
