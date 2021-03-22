using NLog;
using System;

namespace WorkTelegramBot
{
    public class MainLogic
    {
        readonly Logger log = LogManager.GetCurrentClassLogger();

        public string MessageProcess(string inputText)
        {
            string textOut = "";
            AvailableCurrency allCurrency = new AvailableCurrency();
            WorkWithText wordProccess = new WorkWithText();
            ReceiveRate receiveRate = new ReceiveRate();
            Request request;
            try { 
                if (inputText != null)
                {
                    request = wordProccess.delimeterInputText(inputText);

                    if (allCurrency.CompareCurrency(request.Currency))
                    {
                        if (wordProccess.CheckDate(request.Date))
                        {
                            double rate = receiveRate.GetValueCurrency(request);
                            if (rate != -1)
                            {
                                textOut = $"{request.Date.ToShortDateString()}\n1 {request.Currency} = {rate} UAH";
                            }
                            else
                            {
                                textOut = "No data available for this date!";
                            }
                        }
                        else
                        {
                            textOut = "Date entered incorrectly!";
                        }
                    }
                    else
                    {
                        textOut = "The selected currency is not available:\n" + request.Currency;
                    }
                }
                else
                {
                    textOut = "Internal error";
                }
                return textOut;
            }
            catch(Exception ex)
            {
                log.Error(ex);
                return "Error!";
            }
        }
    }
}
