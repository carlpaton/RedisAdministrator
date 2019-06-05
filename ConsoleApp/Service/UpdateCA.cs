using System;
using System.Collections.Generic;
using ConsoleApp.Models;
using Newtonsoft.Json;
using RedisRepository.Interfaces;

namespace ConsoleApp.Service
{
    public class UpdateCA
    {
        private readonly IRedisRepository _redisService;
        private readonly string _value;

        public UpdateCA(IRedisRepository redisService)
        {
            _redisService = redisService;
            _value = CreateDummyListWithOneRecord();
        }

        public bool Update(string key)
        {
            return _redisService.Update(key, _value);
        }

        private string CreateDummyListWithOneRecord()
        {
            var list = new List<DummyClass>
            {
                new DummyClass()
                {
                    Id = new Random().Next(1, 9999),
                    SomeGuid = Guid.NewGuid().ToString(),
                    DateTime = DateTime.Now,
                }
            };
            return JsonConvert.SerializeObject(list);
        }
    }
}
