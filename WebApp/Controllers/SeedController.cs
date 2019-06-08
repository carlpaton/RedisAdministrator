using Common.DummyData;
using Microsoft.AspNetCore.Mvc;
using RedisRepository.Interfaces;
using WebApp.Models;

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

                // TODO, 
                // move this into an injectable class, CssClassName can be enums
                // TempData read in .cshtml must also go to a partial view
                // https://getbootstrap.com/docs/4.0/components/alerts/
                TempData["seed-index-post-ok"] = new MessageViewModel()
                {
                    CssClassName = "alert-primary",
                    Message = "Seed has complete.",
                    Title = "OK"
                };
            }

            return View(viewModel);          
        }
    }
}