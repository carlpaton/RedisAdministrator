using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedisRepository.Interfaces;

namespace IntegrationTests
{
    [TestClass]
    public class InfoTest
    {
        readonly string connection = "localhost:6379,allowAdmin=true";
        IRedisRepository redisRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            redisRepository = new RedisRepository.RedisRepository(connection);
        }

        [TestMethod]
        public void Info_atleast_one_hundred_characters_are_returned()
        {
            // Arrange
            // Act
            var response = redisRepository.Info();

            // Assert
            Assert.IsTrue(response.Length > 100);
        }
    }
}
