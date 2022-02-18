using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedisRepository.Interfaces;

namespace IntegrationTests
{
    [TestClass]
    public class ClearTest
    {
        readonly string connection = "localhost:6379,allowAdmin=true";
        IRedisRepository redisRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            redisRepository = new RedisRepository.RedisRepository(connection);
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
