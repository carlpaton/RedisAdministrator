using ConsoleApp.Service;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // The port `6379` will be added by the framework
            var connection = "localhost:6379,allowAdmin=true";
            var key = "hoe_key";

            var redisService = new RedisRepository.RedisRepository(connection);

            // Exists
            Console.WriteLine(new ExistsCA(redisService).Exists(key));

            // Insert
            new InsertCA(redisService).Insert(key);

            // Select
            Console.WriteLine(new SelectCA(redisService).Select(key));

            // Delete
            new DeleteCA(redisService).Delete(key);

            // Update
            var keyForUpdate = "123:456:hoe";
            Console.WriteLine(new UpdateCA(redisService).Update(keyForUpdate));

            // Set `TTL` on key used above in `Update` above
            Console.WriteLine(new SetTTLCA(redisService).SetTTL(keyForUpdate));

            // Clear
            new ClearCA(redisService).Clear();

            // I forget to CTRL-F5 -_-
            Console.Read();
        }
    }
}
