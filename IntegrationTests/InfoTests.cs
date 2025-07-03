using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedisRepository.Interfaces;

namespace IntegrationTests
{
    [TestClass]
    public class InfoTest
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
