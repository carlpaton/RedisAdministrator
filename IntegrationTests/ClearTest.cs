using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedisRepository.Interfaces;

namespace IntegrationTests
{
    [TestClass]
    public class ClearTest
    {
        readonly string connection = "localhost:6379,allowAdmin=true";
        IRedisRepositoryBase redisRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            var options = Microsoft.Extensions.Options.Options.Create(
                new RedisRepository.DatabaseOptions { ConnectionString = connection }
            );
            redisRepository = new RedisRepository.RedisRepositoryBase(options);
        }

        [TestMethod]
        public void Clear()
        {
            // Arrange
            // Act
            redisRepository.Clear();

            // Assert
            // Could probably do a key count and check its zero, this was really just helpful when I was building the repository / figuring out the red commands
        }
    }
}
