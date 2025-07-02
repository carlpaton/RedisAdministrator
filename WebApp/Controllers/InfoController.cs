using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using RedisRepository;
using RedisRepository.enums;
using RedisRepository.Interfaces;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class InfoController : Controller
    {
        private readonly IRedisRepositoryBase _redisRepository;
        private readonly DatabaseOptions _databaseOptions;

        public InfoController(IRedisRepositoryBase redisRepository, IOptions<DatabaseOptions> options)
        {
            _redisRepository = redisRepository;
            _databaseOptions = options.Value;
        }

        public IActionResult Index()
        {
            var viewModel = new InfoViewModel()
            {
                Info = _redisRepository.Info(InfoEnum.Info.All),
                Filter = SetDropDownList(),
                Connection = _databaseOptions.ConnectionString
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(InfoViewModel viewModel)
        {
            Enum.TryParse(viewModel.SelectedFilter, out InfoEnum.Info infoParameter);

            viewModel.Info = _redisRepository.Info(infoParameter);
            viewModel.Filter = SetDropDownList();
            viewModel.Connection = _databaseOptions.ConnectionString;
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