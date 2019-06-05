using RedisRepository.Interfaces;

namespace ConsoleApp.Service
{
    public class ExistsCA
    {
        private readonly IRedisRepository _redisService;

        public ExistsCA(IRedisRepository redisService)
        {
            _redisService = redisService;
        }

        public bool Exists(string key)
        {
            return _redisService.Exists(key);
        }
    }
}
