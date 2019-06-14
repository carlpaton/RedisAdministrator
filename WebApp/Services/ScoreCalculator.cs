using System;

namespace WebApp.Services
{
    public static class ScoreCalculator
    {
        public static double ScoreYear1970()
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            var span = (DateTime.Now.ToLocalTime() - epoch);
            var score = span.TotalSeconds;

            return score;
        }

        public static double ScoreYearOne()
        {
            var epoch = new DateTime(1, 1, 1, 0, 0, 0, 0).ToLocalTime();
            var span = (DateTime.Now.ToLocalTime() - epoch);
            var score = span.TotalSeconds;

            return score;
        }

        public static double ScoreByDate(DateTime dateTime)
        {
            var epoch = dateTime.ToLocalTime();
            var span = (DateTime.Now.ToLocalTime() - epoch);
            var score = span.TotalSeconds;

            return score;
        }
    }
}
