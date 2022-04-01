using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NISD_Wick_Bypass
{
    internal class Utils
    {
        public static string path = Environment.CurrentDirectory + @"\SavedInfo";
        public static string logs = Environment.CurrentDirectory + @"\SavedInfo\CaptchaLogs.txt";

        public static string Time()
        {
            DateTime time = DateTime.Now;
            return time.ToString();
        }
        public static void Leave()
        {
            Console.WriteLine($"[{Utils.Time()}] Press enter to leave...");
            Console.ReadLine();
            Process.GetCurrentProcess().Kill();
        }
        public static void DirectoryPath()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(Utils.path);
            }
            else
            {
                //
            }
        }
        public static void SaveInfo(string url, string result)
        {
            if (File.Exists(logs))
            {
                string content = File.ReadAllText(logs);
                File.WriteAllText(logs, content + $"\n[{Utils.Time()}] {url} - {result}"); 
            }
            else
            {
                File.WriteAllText(logs, $"[{Utils.Time()}] {url} - {result}");
            }
        }
        public static byte[] ReadImage_Translate(Stream EmbedUrl)
        {
            using (MemoryStream MemStream = new MemoryStream())
            {
                try
                {
                    EmbedUrl.CopyTo(MemStream);
                    return MemStream.ToArray();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //if there are errors, then it will not work L
                    return MemStream.ToArray();
                }
            }
            
        }
    }
}
