using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

////////////////////////////
using _2CaptchaAPI; /////// LIBRARIES MADE BY https://github.com/Zaczero/2Captcha
using _2CaptchaAPI.Enums;// LIBRARIES MADE BY https://github.com/Zaczero/2Captcha
///////////////////////////

namespace NISD_Wick_Bypass
{
    internal class CheckApiKey
    {
        public static async Task<string> CheckKeyAsync(string key)
        {
            try
            {
                var captcha = new _2Captcha(key);
                var balance = await captcha.GetBalance();
                if (balance.Response.Contains("WRONG"))
                {
                    Console.WriteLine($"[{Utils.Time()}] Your 2Captcha Key is not valid. Please try again.");
                    Utils.Leave();
                    return ""; //useless
                }
                else
                {
                    return balance.Response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Utils.Leave();
                return ""; //useless
            }         
        }
    }
}
