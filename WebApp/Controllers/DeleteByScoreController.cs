using Microsoft.AspNetCore.Mvc;
using RedisRepository.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DeleteByScoreController : Controller
    {
        private readonly IRedisRepository _redisRepository;
        private readonly IRedisRepositorySortedSet _redisRepositorySortedSet;
        private readonly int _defaultMaxResults = 1000;

        public DeleteByScoreController(IRedisRepository redisRepository, IRedisRepositorySortedSet redisRepositorySortedSet)
        {
            _redisRepository = redisRepository;
            _redisRepositorySortedSet = redisRepositorySortedSet;
        }

        public IActionResult Index()
        {
            var viewModel = new DeleteByScoreViewModel()
            {
                MaxResults = _defaultMaxResults
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(DeleteByScoreViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var sortedSetKeys = LookUpSortedSetKeys(viewModel);
                var sortedSetKeysWithScoresMatching = new List<string>();

                foreach (var sortedSetKey in sortedSetKeys)
                {
                    var sortedSet = _redisRepositorySortedSet.SelectListRecordWithScore(sortedSetKey);
                    foreach (var member in sortedSet)
                    {
                        if (viewModel.ScoreField.Equals("greaterThan") 
                            && member.Item1 > viewModel.ScoreFilter)
                        {
                            sortedSetKeysWithScoresMatching.Add(Display(sortedSetKey, member.Item1, member.Item2));
                            break;
                        }
                        else if (viewModel.ScoreField.Equals("lessThan")
                            && member.Item1 < viewModel.ScoreFilter)
                        {
                            sortedSetKeysWithScoresMatching.Add(Display(sortedSetKey, member.Item1, member.Item2));
                            break;
                        }
                    }
                }

                // Loop through
                // "<div class='keyResult' data-toggle='modal' data-target='#myModal' data-key='" + key + "'>" + key + "</div>"

                viewModel.Result = string.Join(Environment.NewLine, sortedSetKeysWithScoresMatching);
                viewModel.ResultCount = sortedSetKeysWithScoresMatching.Count();
            }

            return View(viewModel);
        }

        private string Display(string key, double sore, string value)
        {
            var sb = new StringBuilder();
            sb.Append("<div class='row'>");
            sb.AppendFormat("<div class='col-sm-4'>{0}</div>", key);
            sb.AppendFormat("<div class='col-sm-4'>{0}</div>", sore);
            sb.AppendFormat("<div class='col-sm-4'>{0}</div>", value);
            sb.Append("</div>");
            return sb.ToString();
        }

        private List<string> LookUpSortedSetKeys(DeleteByScoreViewModel viewModel)
        {
            // SHIM 
            // When users pass low (less than 1000) `MaxResults` values the `SelectListScan` method may only return `String` types
            // In this method we only display `SortedSet` types so this shim will force the code to try find `SortedSet` values
            var newList = new List<string>();
            var keyList = new List<string>();
            var maxResultsSoftLimit = viewModel.MaxResults;
            while (newList.Count < viewModel.MaxResults)
            {
                keyList = _redisRepository
                    .SelectListScan(viewModel.SearchOnKey, maxResultsSoftLimit)
                    .ToList();

                foreach (var key in keyList)
                {
                    if (newList.Count >= viewModel.MaxResults)
                        break;

                    if (_redisRepository.GetType(key).Equals(RedisType.SortedSet))
                        newList.Add(key);

                    maxResultsSoftLimit++;
                }

                if (newList.Count >= viewModel.MaxResults)
                    break;

                // If the code gets this far and this condition is true there are fewer records in redis than the `viewModel.MaxResults` value
                if (viewModel.MaxResults >= _defaultMaxResults)
                    break;

                newList = new List<string>();
            }

            return newList;
        }
    }
}