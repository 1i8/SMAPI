using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SMAPI
{
    public class SManager
    {
        public string GetElement(string a2, string a1)
        {
            string key = a1;
            int qq = 1;

            string realpath = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Growtopia\save.dat";
            System.IO.FileInfo info = new System.IO.FileInfo(realpath);
            long fSize = info.Length;
            for (int aa = 1000; qq < fSize; qq++)
            {
                if (System.IO.File.ReadAllText(realpath).Substring(qq, key.Length) == key)
                {
                    if (a2 == "")
                    {
                        try
                        {
                            string ffs = System.IO.File.ReadAllText(realpath).Substring(qq, key.Length + 20);
                            return ffs.Replace("-", " ").Replace("swearFi", "").Replace(a1, "").Replace("§", "").Replace("role", "").Replace(" ", "");
                        }
                        catch
                        {
                            string ffs = System.IO.File.ReadAllText(realpath).Substring(qq, key.Length + 14);
                            return ffs.Replace("-", " ").Replace("swearFi", "").Replace(a1, "").Replace("§", "").Replace("role", "").Replace(" ", "");
                        }

                    }
                    else
                    {
                        try
                        {
                            string ffs = System.IO.File.ReadAllText(realpath).Substring(qq, key.Length + 20);
                            return a2 + ": " + ffs.Replace("-", " ").Replace("swearFi", "").Replace(a1, "").Replace("§", "").Replace("role", "");
                        }
                        catch
                        {
                            string ffs = System.IO.File.ReadAllText(realpath).Substring(qq, key.Length + 14);
                            return a2 + ": " + ffs.Replace("-", " ").Replace("swearFi", "").Replace(a1, "").Replace("§", "").Replace("role", "");
                        }

                    }


                    qq = 0;
                }
            }
            return "";
        }
        public string TraceElement(string Element, string original)
        {
            int timesChanges = 0;
            bool found = false;
            string tracetest = GetElement("", Element);
            Console.WriteLine("[SaveManager] cnt your user data -> {0}", timesChanges);
            for (; ; )
            {
                if (found == true)
                {
                    System.IO.File.AppendAllText("trace.ini", "\n[" + TimeZone.CurrentTimeZone.ToString() + "][Account] -> " + tracetest);
                }
                Thread.Sleep(1000);
                if (found == false)
                {
                    if (tracetest == original)
                    {
                        Console.Clear();

                        Console.WriteLine("[SaveManager API 1.0] user data looks the same... \norig >> " + original + "\ncurrent >>" + tracetest);
                        TraceElement(Element, original);
                    }
                    else
                    {
                        Console.WriteLine("[SaveManager API 1.0] Creds changed!\norig >> " + original + "\ncurrent >>" + tracetest);
                        found = true;
                        timesChanges += 1;

                        System.IO.File.AppendAllText("trace.ini", "\n[" + DateTime.Now + "]\n[Old Account] ->" + original + "\n[New Account] -> " + tracetest);
                        tracetest = "none";
                        return "[SaveManager API 1.0] Creds changed!\norig >> " + original + "\ncurrent >>" + tracetest;





                    }


                }
                else
                {
                    Console.ReadKey();
                }


            }
        }

    }
}
