using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {


            /* void processFileProxy()
             {
                 string filePath = "C:\\Users\\Pc\\Downloads\\37269.txt";
                 string filePath2 = "C:\\Users\\Pc\\Downloads\\37268.txt";

                 string[] readFile(string filePath)
                 {
                     string content = "";
                     using (StreamReader sr = new StreamReader(filePath))
                     {
                         content = sr.ReadToEnd();
                     }
                     string[] proxyArr = content.Split("\n");
                     return proxyArr;
                 }

                 string[] proxyArr1 = readFile(filePath);
                 string[] proxyArr2 = readFile(filePath2);
                 List<string> arr = new List<string>() { };
                 int arrLength = proxyArr1.Length + proxyArr2.Length;
                 for (int index = 0; index < arrLength; index++)
                 {
                     if (index % 2 != 0 && index > 2)
                     {
                         arr.Add(proxyArr1[index / 2]);
                     }
                     else if (index % 2 == 0 && index > 2)
                     {
                         arr.Add(proxyArr2[index / 2]);
                     }
                 }
                 string fileS = "C:\\Users\\Pc\\source\\repos\\ConsoleApp1\\ConsoleApp1\\proxyS.txt";

                 using (StreamWriter sw = new StreamWriter(fileS))
                 {
                     foreach (string element in arr)
                     {
                         sw.WriteLine(element.Trim());
                     }
                 }
             }*/
            /*void processFileData(int count)
            {
                string filePath = "C:\\Users\\Pc\\Desktop\\checkFB\\selenium\\listacc.txt";
                List<string> newArr = new List<string>();
                string[] readFile(string filePath)
                {
                    string content = "";
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        content = sr.ReadToEnd();
                    }
                    string[] dataArr = content.Split("\n");
                    return dataArr;
                }
                string[] data = readFile(filePath);
                int space = data.Length / count;
                int residual = data.Length - (space * count);
                for (int inx = 0; inx < count; inx++)
                {
                    string fileS = $"C:\\Users\\Pc\\source\\repos\\ConsoleApp1\\ConsoleApp1\\data{inx}.txt";
                    if (inx < count)
                    {
                        Console.WriteLine(inx);
                        List<string> list = new List<string>();
                        for (int j = (space * inx); j < space * (inx + 1); j++)
                        {
                            list.Add(data[j]);
                        }

                        using (StreamWriter sw = new StreamWriter(fileS))
                        {
                            foreach (string item in list)
                            {
                                sw.WriteLine(item.Trim());
                            }
                        }

                    }
                }

            }*/


            /*string proxyAddress = "http://198.211.96.231:12004";
            var httpClientHandler = new HttpClientHandler()
            {
                Proxy = new WebProxy(proxyAddress),
                UseProxy = true
            };*/
            /*
                        for(int x =0;x<100;x++)
                        {
                            Login login = new Login("trove.catbui.1996", "Khongdong1", userAgent, "datr=dV1LZMfVOpE9o19zSgZ309hP", httpClientHandler, j);
                            await login.main();
                        }   */

            /*Thread tr = new Thread(async () =>
            {
                HttpClient httpClient = new HttpClient(httpClientHandler);
                string url = "https://mbasic.facebook.com";
                 httpClient.DefaultRequestHeaders.Add("accept-language", "en-US,en;q=0.9");
                httpClient.DefaultRequestHeaders.Add("sec-fetch-site", "none");
                httpClient.DefaultRequestHeaders.Add("authority", "mbasic.facebook.com");
                httpClient.DefaultRequestHeaders.Add("scheme", "https");
                httpClient.DefaultRequestHeaders.Add("cookie", "datr=dV1LZMfVOpE9o19zSgZ309hP");
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                HttpResponseMessage response = httpClient.SendAsync(request).GetAwaiter().GetResult();
                string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Console.WriteLine(response);
            });
            tr.Start();*/
            // Send the request X times in parallel

          /*  async Task start()
            {
                string proxyAddress = "http://198.211.96.231:12004";
                var httpClientHandler = new HttpClientHandler()
                {
                    Proxy = new WebProxy(proxyAddress),
                    UseProxy = false
                };
                string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36";
                string[] cookies = { "datr=dV1LZMfVOpE9o19zSgZ309hP", "datr=C15LZOX2iVTi_001xvnooIPQ", "datr=R15LZM6z_vq6kmQEvf0iWP4z", "datr=dV5LZDG_dbIbyuO3nRQtxDR2", "datr=mV5LZNzLf3WemdjBOAxeJIx2", "datr=rl5LZOwhtAXTQiMYKDX7u0hi", "datr=yF5LZKPNpG1NMBfKLyL8zfS_", "datr=7l5LZF1GQxrs6fMuJf1Q_g-U", "datr=EF9LZB9wx8hy1XkAmOW1pfF5", "datr=J19LZD07RgSBOyaJXrT4CB4U", "datr=RV9LZOKCH2B1Ec7jbyulExKC", "datr=fF9LZKjGp8I2sVrTG1t7Z4Kk" };

                Login login = new Login("trove.catbui.1996", "Khongdong1", userAgent, "datr=dV1LZMfVOpE9o19zSgZ309hP", httpClientHandler,1);
                await login.main();
            }*/

            string[] readFile(string filePath)
            {
                string content = "";
                using (StreamReader sr = new StreamReader(filePath))
                {
                    content = sr.ReadToEnd();
                }
                string[] dataArr = content.Split("\n");
                return dataArr;
            }

            async Task RunAsync(int idThread)
            {
                string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36";
                string[] cookies = { "datr=dV1LZMfVOpE9o19zSgZ309hP", "datr=C15LZOX2iVTi_001xvnooIPQ", "datr=R15LZM6z_vq6kmQEvf0iWP4z", "datr=dV5LZDG_dbIbyuO3nRQtxDR2", "datr=mV5LZNzLf3WemdjBOAxeJIx2", "datr=rl5LZOwhtAXTQiMYKDX7u0hi", "datr=yF5LZKPNpG1NMBfKLyL8zfS_", "datr=7l5LZF1GQxrs6fMuJf1Q_g-U", "datr=EF9LZB9wx8hy1XkAmOW1pfF5", "datr=J19LZD07RgSBOyaJXrT4CB4U", "datr=RV9LZOKCH2B1Ec7jbyulExKC", "datr=fF9LZKjGp8I2sVrTG1t7Z4Kk" };
                string path = "C:\\Users\\Pc\\source\\repos\\ConsoleApp1\\ConsoleApp1\\37461.txt";
                string[] proxyList = readFile(path);
                    string filePath = $"C:\\Users\\Pc\\source\\repos\\ConsoleApp1\\ConsoleApp1\\data{idThread}.txt";
                    string[] dataList = readFile(filePath);
                    int i = 0;
                    int countCookie = idThread;
                    int countProxy = idThread;
                Console.WriteLine("Thread Start " + idThread);
                foreach (string item in dataList)
                    {
                    try {
                    Console.WriteLine("check:"+i);
                        if (countCookie > cookies.Length - 1)
                        {
                            countCookie = idThread;
                        }
                        if (countProxy > proxyList.Length - 1)
                        {
                            countProxy = idThread;
                        }
                        string proxy = proxyList[countProxy].Trim();
                        
                        string str = item.Trim();
                        string[] strL = str.Split(":");
                        string proxyAddress = $"http://{proxy}";
                        var httpClientHandler = new HttpClientHandler()
                        {
                            Proxy = new WebProxy(proxyAddress),
                            UseProxy = true
                        };
                        Login login = new Login(strL[0], strL[1], userAgent, cookies[countCookie], httpClientHandler, idThread);
                        await login.main();
                        countCookie = countCookie + 11;
                        countProxy = countProxy + 11;
                        Console.WriteLine("thread:" + idThread);
                        i++;
                    }catch (Exception ex) { Console.WriteLine("End Thread"); };
                }

            }
            Task.WhenAll(Enumerable.Range(0, 10).Select(i => RunAsync(i))).GetAwaiter().GetResult();


            /*foreach (int idThread in threadArr)
            {
                string filePath = $"C:\\Users\\Pc\\source\\repos\\ConsoleApp1\\ConsoleApp1\\data{idThread}.txt";
                string[] dataList = readFile(filePath);
                int i = 0;
                    int countCookie = idThread;
                    int countProxy = idThread;
                    foreach (string item in dataList)
                    {
                        if (countCookie > cookies.Length - 1)
                        {
                            countCookie = 0;
                        }
                        if (countProxy > proxyList.Length - 1)
                        {
                            countProxy = 0;
                        }
                        string proxy = proxyList[countProxy].Trim();
                        Console.WriteLine(countCookie + "thread"+ idThread);
                        string str = item.Trim();
                        string[] strL = str.Split(":");
                        string proxyAddress = $"http://{proxy}";
                        var httpClientHandler = new HttpClientHandler()
                        {
                            Proxy = new WebProxy(proxyAddress),
                            UseProxy = true
                        };
                        Login login = new Login(strL[0], strL[1], userAgent, cookies[countCookie], httpClientHandler, idThread);
                        login.main();
                        countCookie = countCookie + 5;
                        countProxy = countProxy + 5;
                }
                
            }*/

        }
    }
}
