using System;
using System.Collections.Generic;
using System.Text;

namespace WorkTelegramBot
{
    class WorkWithText
    {
        public Request delimeterInputText(string inpuText)
        {
            Request localRequest = new Request();


            try
            {
                localRequest.Currency = inpuText.Split(new char[] { ' ' })[0].ToUpper();
                localRequest.Date = Convert.ToDateTime(inpuText.Split(new char[] { ' ' })[1]);
            }
            catch
            {
                localRequest.Date = Convert.ToDateTime("01.01.0001 0:00:00");
            }
            return localRequest;
        }

        public bool CheckDate(DateTime inputDate)
        {
            if (inputDate != Convert.ToDateTime("01.01.0001 0:00:00"))
                return true;
            return false;
        }
    }
}
