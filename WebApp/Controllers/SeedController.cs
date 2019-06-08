using Common.DummyData;
using Microsoft.AspNetCore.Mvc;
using RedisRepository.Interfaces;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class SeedController : Controller
    {
        private readonly IRedisRepositoryString _redisRepositoryString;

        public SeedController(IRedisRepositoryString redisRepositoryString)
        {
            _redisRepositoryString = redisRepositoryString;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StringType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StringType(SeedStringTypeViewModel viewModel)
        { 
            if (ModelState.IsValid) 
            {
                for (int i = 1; i <= viewModel.NumberOfKeys; i++)
                {
                    var key = $"{i}:{i+1}:seed_string";
                    var value = DummyObjects.GetOneValue();
                    _redisRepositoryString.Insert(key, value);
                }

                new SetTempDataMessage()
                    .Display(TempData, "OK", "Seed has complete.");
            }

            return View(viewModel);          
        }
    }
}