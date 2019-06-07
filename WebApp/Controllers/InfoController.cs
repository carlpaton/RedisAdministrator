using Microsoft.AspNetCore.Mvc;
using RedisRepository.enums;
using RedisRepository.Interfaces;
using WebApp.Models;

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
            var viewModel = new InfoViewModel()
            {
                Info = _redisRepository.Info(InfoEnum.Info.all)
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(InfoViewModel viewModel)
        { 
            if (viewModel.MemoryOnly)
            {
                viewModel.Info = _redisRepository.Info(InfoEnum.Info.Memory);
            }
            return View(viewModel);          
        }
    }
}