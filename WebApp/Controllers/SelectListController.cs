using Microsoft.AspNetCore.Mvc;
using RedisRepository.Interfaces;
using System;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SelectListController : Controller
    {
        private readonly IRedisRepository _redisRepository;

        public SelectListController(IRedisRepository redisRepository)
        {
            _redisRepository = redisRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SelectListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var resultList = _redisRepository
                    .SelectListScan(viewModel.SearchOnKey, 1000)
                    .ToList();

                viewModel.Result = string.Join(Environment.NewLine, resultList);
                viewModel.ResultCount = resultList.Count();
            }

            return View(viewModel);
        }
    }
}