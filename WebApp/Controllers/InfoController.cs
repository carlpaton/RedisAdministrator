using Microsoft.AspNetCore.Mvc;
using RedisRepository.enums;
using RedisRepository.Interfaces;

namespace WebApp.Controllers
{
    public class InfoController : Controller
    {
        private readonly IRedisRepository _redisRepository;

        public InfoController(IRedisRepository redisRepository)
        {
            _redisRepository = redisRepository;
        }

        public IActionResult Index()
        {
            var redisServerInformation = _redisRepository.Info(InfoEnum.Info.all);
            return View();
        }
    }
}