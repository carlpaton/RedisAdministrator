using ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsoleApp.Service
{
    public static class InsertDummyData
    {
        public static string GetOneValue()
        {
            var value = new DummyClass()
            { 
                Id = new Random().Next(1, 9999),
                SomeGuid = Guid.NewGuid().ToString(),
                DateTime = DateTime.Now       
            };
            
            return JsonConvert.SerializeObject(value);
        }

        public static string GetListWithTenValues()
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
