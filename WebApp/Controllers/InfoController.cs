using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                Info = _redisRepository.Info(InfoEnum.Info.All),
                Filter = SetDropDownList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(InfoViewModel viewModel)
        {
            Enum.TryParse(viewModel.SelectedFilter, out InfoEnum.Info infoParameter);

            viewModel.Info = _redisRepository.Info(infoParameter);
            viewModel.Filter = SetDropDownList();
            return View(viewModel);          
        }

        private List<SelectListItem> SetDropDownList()
        {
            var returnList = new List<SelectListItem>();
            var infoEnumList = Enum.GetValues(typeof(InfoEnum.Info));

            foreach (var infoEnum in infoEnumList)
            {
                returnList.Add(new SelectListItem() {
                    Value = infoEnum.ToString(),
                    Text = infoEnum.ToString()
                });
            }

            return returnList;
        }
    }
}