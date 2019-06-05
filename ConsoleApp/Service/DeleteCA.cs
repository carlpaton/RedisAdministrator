using RedisRepository.Interfaces;

namespace ConsoleApp.Service
{
    public class DeleteCA
    {
        private readonly IRedisRepository _redisService;

        public DeleteCA(IRedisRepository redisService)
        {
            _redisService = redisService;
        }

        public void Delete(string key)
        {
            _redisService.Delete(key);
        }
    }
}
