using System;

namespace WebApp.Services
{
    public interface IScoreCalculator 
    {
        double ScoreYear1970();
        double ScoreYearOne();
        double ScoreByDate(DateTime dateTime);
        DateTime DateByScore(double score);
    }

    public class ScoreCalculator : IScoreCalculator
    {
        /// <summary>
        /// This is the default used by this application
        /// </summary>
        public DateTime Year1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();

        /// <summary>
        /// Included for example only, some old farts were coding at this point in time :D
        /// </summary>
        public DateTime YearOne = new DateTime(1, 1, 1, 0, 0, 0, 0).ToLocalTime();

        public double ScoreYear1970()
        {
            var span = (DateTime.Now.ToLocalTime() - Year1970);
            return span.TotalSeconds;
        }

        public double ScoreYearOne()
        {
            var span = (DateTime.Now.ToLocalTime() - YearOne);
            return span.TotalSeconds;
        }

        public double ScoreByDate(DateTime dateTime)
        {
            var span = (dateTime.ToLocalTime() - Year1970);
            return span.TotalSeconds;
        }

        public DateTime DateByScore(double score)
        {
            // assume Year1970
            return Year1970.AddSeconds(score);
        }
    }
}
