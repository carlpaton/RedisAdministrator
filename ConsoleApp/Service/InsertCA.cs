using ConsoleApp.Models;
using Newtonsoft.Json;
using RedisRepository.Interfaces;
using System;
using System.Collections.Generic;

namespace ConsoleApp.Service
{
    public class InsertCA
    {
        private readonly IRedisRepository _redisService;
        private readonly string _value;

        public InsertCA(IRedisRepository redisService)
        {
            _redisService = redisService;
            _value = CreateDummyList();
        }

        public void Insert(string key)
        {
            _redisService.Insert(key, _value);
        }

        private string CreateDummyList()
        {
            var list = new List<DummyClass>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new DummyClass()
                {
                    Id = i,
                    SomeGuid = Guid.NewGuid().ToString(),
                    DateTime = DateTime.Now.AddDays(i),
                });
            }
            return JsonConvert.SerializeObject(list);
        }
    }
}
