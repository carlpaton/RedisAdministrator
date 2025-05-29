using System.Text.Json;
using System;
using System.Collections.Generic;

namespace Common.DummyData
{
    public class DummyObjects
    {
        public static string GetOneValue()
        {
            var value = new DummyClass()
            { 
                Id = new Random().Next(1, 9999),
                SomeGuid = Guid.NewGuid().ToString(),
                DateTime = DateTime.Now       
            };
            
            return JsonSerializer.Serialize(value);
        }

        public static string GetListWithNValues(int numberOfObjects)
        {
            var list = new List<DummyClass>();
            
            for (int i = 1; i <= numberOfObjects; i++)
            {
                list.Add(new DummyClass()
                {
                    Id = i,
                    SomeGuid = Guid.NewGuid().ToString(),
                    DateTime = DateTime.Now.AddDays(i),
                });
            }  
            
            return JsonSerializer.Serialize(list);
        }
    }
}
