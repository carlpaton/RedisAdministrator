using RedisRepository.Interfaces;

namespace ConsoleApp.Service
{
    public class SetTTLCA
    {
        private readonly IRedisRepository _redisService;

        public SetTTLCA(IRedisRepository redisService)
        {
            _redisService = redisService;
        }

        public bool SetTTL(string key)
        {
            return _redisService.SetTTL(key);
        }
    }
}
