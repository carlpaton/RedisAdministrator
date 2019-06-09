using Microsoft.AspNetCore.Mvc;
using RedisRepository.Interfaces;
using System;
using System.Collections.Generic;
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
                var keyList = _redisRepository
                    .SelectListScan(viewModel.SearchOnKey, 1000)
                    .ToList();

                var newList = new List<string>();
                foreach (var key in keyList)
                {
                    newList.Add("<span class='keyResult' data-toggle='modal' data-target='#myModal' data-key='"+key+"'>"+key+"</span>");
                }

                viewModel.Result = string.Join(Environment.NewLine, newList);
                viewModel.ResultCount = keyList.Count();
            }

            return View(viewModel);
        }

        public ActionResult ZoomOnKey(string key)
        {
            var keyType = _redisRepository.GetType(key).ToString();

            var viewModel = new ZoomViewModels()
            {
                Key = key,
                Type = keyType
            };
            return PartialView("_ZoomOnKey", viewModel);
        }
    }
}