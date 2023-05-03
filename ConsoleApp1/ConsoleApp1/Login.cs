using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Login
    {

        private string email;
        private string password;
        private string userAgent;
        private string cookies;
        private HttpClientHandler httpClientHandler;
        private int idThread;
        
        public Login() { }
       public Login(string email, string password, string? userAgent, string? cookies, HttpClientHandler httpClientHandler, int idThread)
        {
            this.email = email;
            this.password = password;
            this.userAgent = userAgent;
            this.cookies = cookies;
            this.httpClientHandler = httpClientHandler;
            this.idThread = idThread;
        }

        public async Task<HttpResponseMessage> getLogin(HttpClientHandler httpClientHandler, string? cookie, string? userAgent, int idThread)
        {
            try
            {
                HttpClient httpClient = new HttpClient(httpClientHandler);
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                string url = "https://mbasic.facebook.com";
                httpClient.DefaultRequestHeaders.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
                httpClient.DefaultRequestHeaders.Add("accept-language", "en-US,en;q=0.9");
                httpClient.DefaultRequestHeaders.Add("sec-fetch-site", "none");
                httpClient.DefaultRequestHeaders.Add("authority", "mbasic.facebook.com");
                httpClient.DefaultRequestHeaders.Add("scheme", "https");
               // httpClient.DefaultRequestHeaders.Add("cookie", cookie);
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36");
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                HttpResponseMessage response = httpClient.SendAsync(request).GetAwaiter().GetResult();
                string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return response;
            }
            catch (HttpRequestException ex)
            {
               await getLogin(httpClientHandler, cookie, userAgent, idThread);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insite GET", ex.Message);
                await getLogin(httpClientHandler, cookie, userAgent, idThread);
            }

            return null;
        }


        public async Task<HtmlDocument> doc(HttpResponseMessage response)
        {
            try
            {
                if (response != null)
                {
                    HtmlDocument document = new HtmlDocument();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    document.LoadHtml(responseBody);
                    return document;
                }
                else return null; 
                
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return null;
            }
            catch (Exception ex) {
                Console.WriteLine("doc"+response);
                return null;
            }
            return null;
        }

        public string coookieColdP(HttpResponseMessage response,string cookieDatr)
        {
            try
            {
                string cookieSb = "";
                if (response.Headers.TryGetValues("Set-Cookie", out var setCookieValues))
                {
                    foreach (string cookies in setCookieValues)
                    {
                        cookieSb = cookies.Split(';')[0];
                    }
                }
                string cookieStr = $"{cookieDatr};{cookieSb}";
                return cookieStr;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cookie");
                return null;

            }


        }
        private string cookie(HttpResponseMessage response)
        {
            string[] cookieDatrArr;
            string[] cookieSbArr;
            List<string> cookiesArr = new List<string>();
            if (response.Headers.TryGetValues("Set-Cookie", out var setCookieValues))
            {
                foreach (var cookie in setCookieValues)
                {
                    cookiesArr.Add(cookie);
                }

            }
            cookieSbArr = cookiesArr[1].Split(";", StringSplitOptions.RemoveEmptyEntries);
            cookieDatrArr = cookiesArr[0].Split(";", StringSplitOptions.RemoveEmptyEntries);
            string datr = cookieDatrArr[0];
            string sb = cookieSbArr[0];
            string cookies = $"{datr};{sb}";
            return cookies;
        }

        private string cookieTest(HttpResponseMessage response,string cookieDatr)
        {
            string[] cookieSbArr;
            List<string> cookiesArr = new List<string>();
            if (response.Headers.TryGetValues("Set-Cookie", out var setCookieValues))
            {
                foreach (var cookie in setCookieValues)
                {
                    cookiesArr.Add(cookie);
                }

            }
            cookieSbArr = cookiesArr[0].Split(";", StringSplitOptions.RemoveEmptyEntries);
            string sb = cookieSbArr[0];
            string cookies = $"{cookieDatr};{sb}";
            return cookies;
        }


        public StringContent payLoad(HtmlDocument document,string username,string password)
        {
            if(document != null)
            {
                try
                {
                    HtmlNode lsdD = document.DocumentNode.SelectSingleNode("//input[@name='lsd']");
                    HtmlNode jazoestD = document.DocumentNode.SelectSingleNode("//input[@name='jazoest']");
                    HtmlNode m_tsD = document.DocumentNode.SelectSingleNode("//input[@name='m_ts']");
                    HtmlNode liD = document.DocumentNode.SelectSingleNode("//input[@name='li']");

                    if (lsdD != null && jazoestD != null && m_tsD != null && liD != null)
                    {
                        string lsd = lsdD.Attributes["value"].Value;
                        string jazoest = jazoestD.Attributes["value"].Value;
                        string m_ts = m_tsD.Attributes["value"].Value;
                        string li = liD.Attributes["value"].Value;
                        string try_number = "0";
                        string unrecognized_tries = "0";
                        string email = username;
                        string pass = password;
                        string login = "Log In";
                        string bi_xrwh = "0";
                        string payloadStr = $"lsd={lsd}&jazoest={jazoest}&m_ts={m_ts}&li={li}&try_number=0&unrecognized_tries=0&email={email}&pass={pass}&login=Log+In&bi_xrwh=0";
                        var content = new StringContent(payloadStr, Encoding.UTF8, "application/x-www-form-urlencoded");
                        return content;
                    }
                    else return null;
                    
                }
                catch (Exception ex) {
                    Console.WriteLine("co loi");
                        return null;
                    }
            }
            else
            {
                return null;
            }
            
        }


        public async Task<HttpResponseMessage> postLogin(HttpClientHandler httpClientHandler,StringContent content,string cookies, string? userAgent)
        {
            try
            {
                string urlPost = "https://mbasic.facebook.com/login/device-based/regular/login/?refsrc=deprecated&lwv=100&refid=8";
                HttpClient httpClientPost = new HttpClient(httpClientHandler);
                httpClientPost.Timeout = TimeSpan.FromSeconds(10);
                httpClientPost.DefaultRequestHeaders.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
                httpClientPost.DefaultRequestHeaders.Add("accept-language", "en-US,en;q=0.9");
                httpClientPost.DefaultRequestHeaders.Add("sec-fetch-site", "same-origin");
                httpClientPost.DefaultRequestHeaders.Add("authority", "mbasic.facebook.com");
                httpClientPost.DefaultRequestHeaders.Add("cookie", cookies);
                httpClientPost.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36");
                var resPost = await httpClientPost.PostAsync(urlPost, content);
                var responseContent = await resPost.Content.ReadAsStringAsync();
                return resPost;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Disconnect");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insite POST",ex.Message);
                return null;
                
            }
            return null;
        }


        public string checkLogin(HtmlDocument document, HttpResponseMessage response)
        {
            try
            {
                HtmlNode errId = document.GetElementbyId("login_error");
                HtmlNode und = document.GetElementbyId("login_form");
                HtmlNode indentify = document.DocumentNode.SelectSingleNode("//a[@href='/login/identify/']");
                HtmlNode incorrect = document.DocumentNode.SelectSingleNode("//a[@aria-label='Have you forgotten your password?']");
                HtmlNode initiate = document.DocumentNode.SelectSingleNode("//a[@href='/recover/initiate/?ars=facebook_login_pw_error']");
                HtmlNode resetPass = document.DocumentNode.SelectSingleNode("//div[@title='Reset Your Password']");
                
                HtmlNode block = document.DocumentNode.SelectSingleNode("//div[@title='You’re Temporarily Blocked']");
                HtmlNode titleNode = document.DocumentNode.SelectSingleNode("//title");
                HtmlNode live = document.DocumentNode.SelectSingleNode("//form[@method='post' and @action='/login/checkpoint/']");
                if (live != null)
                {
                    return "live";
                }else if (indentify != null || resetPass != null || incorrect!=null || initiate !=null || und !=null)
                {
                    return "die";
                }
                else if(titleNode != null)
                {
                    string title = titleNode.InnerHtml;
                    if(title == "You’re Temporarily Blocked")
                    {
                        return "block";
                    }else if(title == "Reset Your Password")
                    {
                        return "die";
                    }
                }
                else if (errId != null)
                {
                    HtmlNodeCollection die = errId.SelectNodes(".//div");
                    foreach (HtmlNode node in die)
                    {
                        if (node.InnerText == "Invalid username or password")
                        {
                            return "die";
                        }
                        else if (node.InnerText.IndexOf("You used an old password") != -1)
                        {
                            return "die";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "undefined";
            }

            return "undefined";
         
        }

        public void exportData(string check,string email,string password,int idThread)
        {
            if(check == "die")
            {
                string filePath = $"C:\\Users\\Pc\\source\\repos\\ConsoleApp1\\ConsoleApp1\\die{idThread}.txt";
                string content = $"{email}:{password}";
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(content);
                }
            }
            else if(check == "live")
            {
                string filePath = $"C:\\Users\\Pc\\source\\repos\\ConsoleApp1\\ConsoleApp1\\live{idThread}.txt";
                string content = $"{email}:{password}";
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(content);
                }
            }
            else if(check == "block")
            {
                string filePath = $"C:\\Users\\Pc\\source\\repos\\ConsoleApp1\\ConsoleApp1\\block{idThread}.txt";
                string content = $"{email}:{password}";
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(content);
                }
            }
            else
            {
                string filePath = $"C:\\Users\\Pc\\source\\repos\\ConsoleApp1\\ConsoleApp1\\undefined{idThread}.txt";
                string content = $"{email}:{password}";
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(content);
                }
            }
        }
        public async Task main()
        {
            try
            {
                while (true) {
                    HttpResponseMessage resGet = await getLogin(httpClientHandler, cookies, userAgent, idThread);
                    if (resGet != null)
                    {
                        
                        HtmlDocument documentGet = await doc(resGet);
                        
                        StringContent content = payLoad(documentGet, email, password);
                        /*string cookieStr = coookieColdP(resGet, cookies);*/

                        string cookieStr = cookie(resGet);
                        /*string cookieStr = cookieTest(resGet, cookies);*/

                        if (content != null && cookieStr != null)
                        {
                            
                            HttpResponseMessage resPost = await postLogin(httpClientHandler, content, cookieStr, userAgent);
                            if (resPost != null)
                            {
                                HtmlDocument documentPost = await doc(resPost);
                                string status = checkLogin(documentPost, resPost);
                                exportData(status, email, password, idThread);
                                if (status == "undefined")
                                {
                                    var responseContent = await resPost.Content.ReadAsStringAsync();
                                    Console.WriteLine("undefied Check : " + responseContent);
                                }
                                Console.WriteLine(email + ":" + password + "  " + status);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("reload main: postLogin ");
                                continue;
                            }
                        }
                        else break;
                    }
                    else
                    {
                        Console.WriteLine("reload main: getLogin ");
                        continue;
                    }
                }

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Lỗi: XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" + ex.Message);
            }
            catch (Exception e) {
                Console.WriteLine("Outsite " + e.Message);
            }
            


        }
    }
}
