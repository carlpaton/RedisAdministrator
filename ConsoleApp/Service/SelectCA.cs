using RedisRepository.Interfaces;

namespace ConsoleApp.Service
{
    public class SelectCA
    {
        private readonly IRedisRepository _redisService;

        public SelectCA(IRedisRepository redisService)
        {
            _redisService = redisService;
        }

        public string Select(string key)
        {
            return _redisService.Select(key);
        }
    }
}
