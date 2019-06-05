using RedisRepository.Interfaces;

namespace ConsoleApp.Service
{
    public class ClearCA
    {
        private readonly IRedisRepository _redisService;

        public ClearCA(IRedisRepository redisService)
        {
            _redisService = redisService;
        }

        public void Clear()
        {
            _redisService.Clear();
        }
    }
}
