using Common.DummyData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedisRepository.Interfaces;
using System;

namespace IntegrationTests
{
    [TestClass]
    public class DeleteTest
    {
        readonly string connection = "localhost:6379,allowAdmin=true";
        IRedisRepositoryBase redisRepository;
        IRedisRepositoryString redisRepositoryString;

        [TestInitialize]
        public void TestInitialize()
        {
            var options = Microsoft.Extensions.Options.Options.Create(
                new RedisRepository.DatabaseOptions { ConnectionString = connection }
            );
            redisRepository = new RedisRepository.RedisRepositoryBase(options);
            redisRepositoryString = new RedisRepository.RedisRepositoryString(options);
        }

        [TestMethod]
        public void Delete_insert_a_new_record_then_delete_it_then_confirm_its_gone()
        {
            // Arrange
            string expected = null;
            var key = $"123:delete:{Guid.NewGuid()}";
            var value = DummyObjects.GetListWithNValues(10);
            redisRepositoryString.Insert(key, value);

            // Act
            var insertedValue = redisRepositoryString.Select(key);
            redisRepository.Delete(key);
            var actual = redisRepositoryString.Select(key);

            // Assert
            Assert.AreEqual(insertedValue, value);
            Assert.AreEqual(actual, expected);
        }
    }
}
