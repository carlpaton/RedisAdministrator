using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RedisRepository.enums;
using RedisRepository.Interfaces;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class InfoController : Controller
    {
        private readonly IRedisRepository _redisRepository;
        private readonly IAppSettings _appSettings;

        public InfoController(IRedisRepository redisRepository, IAppSettings appSettings)
        {
            _redisRepository = redisRepository;
            _appSettings = appSettings;
        }

        public IActionResult Index()
        {
            var viewModel = new InfoViewModel()
            {
                Info = _redisRepository.Info(InfoEnum.Info.All),
                Filter = SetDropDownList(),
                Connection = _appSettings.Connection
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(InfoViewModel viewModel)
        {
            Enum.TryParse(viewModel.SelectedFilter, out InfoEnum.Info infoParameter);

            viewModel.Info = _redisRepository.Info(infoParameter);
            viewModel.Filter = SetDropDownList();
            viewModel.Connection = _appSettings.Connection;
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