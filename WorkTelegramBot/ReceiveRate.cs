using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace WorkTelegramBot
{
    class ReceiveRate
    {
        private double GetNecessaryRate(string allCourse, string currency)
        {
            double noValue = -1;

            try
            {
                List<Course> listCourse = JsonSerializer.Deserialize<List<Course>>(allCourse);
                var requiredCourse = from value in listCourse
                                     where value.currency == currency.ToUpper()
                                     select value.saleRateNB;

                return requiredCourse.First();
            }
            catch
            {
                return noValue;
            }
        }

        private string TransformAnswerFromSite(string allCourse)
        {
            allCourse = allCourse.Split(new char[] { '[' })[1];
            allCourse = allCourse.Split(new char[] { ']' })[0];
            allCourse = "[" + allCourse + "]";
            return allCourse;
        }

        public double GetValueCurrency(Request request)
        {
            WorkWithApiSite answerFromSite = new WorkWithApiSite();
            string allRateOnDate = answerFromSite.GetData(request.Date);
            string transformAllRate = TransformAnswerFromSite(allRateOnDate);
            double rate = GetNecessaryRate(transformAllRate, request.Currency);
            return rate;
        }
    }
}
