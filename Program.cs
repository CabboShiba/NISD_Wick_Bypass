using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;


namespace NISD_Wick_Bypass

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = $"[{Utils.Time()}] NISD_Wick_Bypass by Cabbo";
            Utils.DirectoryPath();
            Console.WriteLine($"[{Utils.Time()}] Please insert a valid https://2captcha.com/ API Key:");
            Console.Write($"[{Utils.Time()}] ");
            string key = Console.ReadLine();
            Console.WriteLine($"[{Utils.Time()}] Checking your 2Captcha.com Key Balance...");
            string balance = CheckApiKey.CheckKeyAsync(key).Result;
            //Thread.Sleep(3000); //use some delay if you want
            Console.WriteLine($"[{Utils.Time()}] Your 2Captcha.com Key Balance is: {balance}");
            Console.WriteLine($"[{Utils.Time()}] Please insert a valid Captcha Url:");
            Console.Write($"[{Utils.Time()}] ");
            string url = Console.ReadLine();
            string result = Bypass.BypassCaptchaAsync(key, url).Result;
            Console.WriteLine($"[{Utils.Time()}] Captcha result: {result}");
            Utils.SaveInfo(url, result);
            Utils.Leave();
        }
    }
}
