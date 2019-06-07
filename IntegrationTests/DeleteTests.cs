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
        IRedisRepository redisRepository;
        IRedisRepositorySet redisRepositorySet;

        [TestInitialize]
        public void TestInitialize()
        {
            redisRepository = new RedisRepository.RedisRepository(connection);
            redisRepositorySet = new RedisRepository.RedisRepositorySet(connection);
        }

        [TestMethod]
        public void Delete_insert_a_new_record_then_delete_it_then_confirm_its_gone()
        {
            // Arrange
            string expected = null;
            var key = $"123:delete:{Guid.NewGuid()}";
            var value = DummyObjects.GetListWithNValues(10);
            redisRepositorySet.Insert(key, value);

            // Act
            var insertedValue = redisRepositorySet.Select(key);
            redisRepository.Delete(key);
            var actual = redisRepositorySet.Select(key);

            // Assert
            Assert.AreEqual(insertedValue, value);
            Assert.AreEqual(actual, expected);
        }
    }
}
