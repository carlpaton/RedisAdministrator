namespace IntegrationTests
{
    class InsertTests
    {
        //TODO ~ flesh these tests out, abit backwards as they are not really needed anymore and focus should be on unit tests / new functionality.

            //// Insert with TTL/Timespan
            //double cacheMinuteTimeout = 1;
            //redisRepositorySet.Insert("123:456:foo_bar_2", InsertDummyData.GetListWithTenValues(), cacheMinuteTimeout);

            //// Insert without TTL, then set TTL
            //redisRepositorySet.Insert("123:456:foo_bar_3", InsertDummyData.GetOneValue());
            //redisRepository.SetTimeToLive("123:456:foo_bar_3", cacheMinuteTimeout);

            //// Check Exists, Select, Insert, Exists, Select on the same record
            //Console.WriteLine(redisRepository.Exists("123:456:foo_bar_4"));
            //Console.WriteLine(redisRepositorySet.Select("123:456:foo_bar_4"));
            //redisRepositorySet.Insert("123:456:foo_bar_4", InsertDummyData.GetOneValue());
            //Console.WriteLine(redisRepository.Exists("123:456:foo_bar_4"));
            //Console.WriteLine(redisRepositorySet.Select("123:456:foo_bar_4"));

            ////***** REDIS TYPE: `Sorted Set` methods below

            //// Insert
            //redisRepositorySortedSet.Insert("123:456:foo_bar_5", InsertDummyData.GetListWithTenValues());

            //// Insert then SelectList
            //redisRepositorySortedSet.Insert("123:456:foo_bar_6", InsertDummyData.GetListWithTenValues());
            //Console.WriteLine(string.Join(" ", redisRepositorySortedSet.SelectList("123:456:foo_bar_6")));

            //// SelectListOfKeysLike
            //Console.WriteLine(string.Join(" ", redisRepository.SelectListOfKeysLike("123:*")));

            //// Insert, SelectRecordWithScore
            //redisRepositorySortedSet.Insert("1:2:foo_bar_7", InsertDummyData.GetListWithTenValues());
            //redisRepositorySortedSet.Insert("1:2:foo_bar_7", InsertDummyData.GetListWithTenValues());
            //var responseTuple = redisRepositorySortedSet.SelectListRecordWithScore("1:2:foo_bar_7");
    }
}
