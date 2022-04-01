using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
////////////////////////////
using _2CaptchaAPI; /////// LIBRARIES MADE BY https://github.com/Zaczero/2Captcha
using _2CaptchaAPI.Enums;// LIBRARIES MADE BY https://github.com/Zaczero/2Captcha
///////////////////////////


namespace NISD_Wick_Bypass
{
    internal class Bypass
    {
        public static async Task<string> BypassCaptchaAsync(string key, string url)
        {
            try
            {
                var captchaclient = new _2Captcha(key);
                var image = (HttpWebRequest)WebRequest.Create(url);
                image.Method = "GET";
                var getimage = image.GetResponse();
                string base64 = Convert.ToBase64String(Utils.ReadImage_Translate(getimage.GetResponseStream()));
                getimage.Close();
                var captchasolved = await captchaclient.SolveImage(base64, FileType.Png, new KeyValuePair<string, string>("regsense", "1"));
                return captchasolved.Response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{Utils.Time()} Error detected during Captcha Bypass process.\n{ex.Message}");
                return "No captcha result";
            }
        }
    }
}
