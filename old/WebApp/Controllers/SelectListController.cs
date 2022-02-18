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
        private readonly IRedisRepositoryString _redisRepositoryString;
        private readonly IRedisRepositorySortedSet _redisRepositorySortedSet;

        public SelectListController(IRedisRepository redisRepository, IRedisRepositoryString redisRepositoryString, IRedisRepositorySortedSet redisRepositorySortedSet)
        {
            _redisRepository = redisRepository;
            _redisRepositoryString = redisRepositoryString;
            _redisRepositorySortedSet = redisRepositorySortedSet;
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
                    newList.Add("<div class='keyResult' data-toggle='modal' data-target='#myModal' data-key='"+key+"'>"+key+"</div>");
                }

                viewModel.Result = string.Join(Environment.NewLine, newList);
                viewModel.ResultCount = keyList.Count();
            }

            return View(viewModel);
        }

        // TODO ~ move these private methods into a service

        public ActionResult ZoomOnKey(string key)
        {
            var keyType = _redisRepository.GetType(key).ToString();

            var viewModel = new ZoomViewModels()
            {
                Key = key,
                Type = keyType,
                ValueData = ReadValue(key, keyType)
            };
            return PartialView("_ZoomOnKey", viewModel);
        }

        private ValueDataViewModel ReadValue(string key, string keyType)
        {
            if (keyType == "String")
            { 
                return new StringTypeViewModel()
                {
                    Value = _redisRepositoryString.Select(key)
                };
            }

            if (keyType == "SortedSet")
            {
                var valueData = new SortedSetWithScoreViewModel()
                {
                    Data = new List<List<string>>()
                };

                var counter = 0;
                foreach (var member in _redisRepositorySortedSet.SelectListRecordWithScore(key))
                {
                    valueData.Data.Add(new List<string>(){
                        counter.ToString(),
                        member.Item1.ToString(),
                        member.Item2
                        });


                    counter++;
                }
                return valueData;
            }

            return new ValueDataViewModel();
        }
    }
}