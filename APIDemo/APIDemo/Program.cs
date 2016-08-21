using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Json;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace APIDemo
{

    class Product
    {
        public string BookName { get; set; }
        public string Chapter { get; set; }
        public string Text { get; set; }
    }

    class Program
    {
       
        static void Main(string[] args)
        {
            Run();

            Console.ReadLine();

        }

        // This one works fine.
        static async Task RunApi2()
        {
            using (var client = new HttpClient())
            {

                //string uriToken = "hCqGoQYlBorqkIyQnjpMSlqzx1Q1YEAUZaJMCrXN";
                //var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}", "jameslevj@gmail.com", "mamajames1226")));

                var uri = new Uri("https://bible-api.com/john 3:5");

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
        

                var response = await client.GetAsync(uri);
                string textResult = await response.Content.ReadAsStringAsync();

                JObject joResponse = JObject.Parse(textResult);
                JArray array = (JArray)joResponse["verses"];
                Console.WriteLine(array[0]["text"]);
                foreach (var item in array)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        static async Task RunAsync()
        {
            // string token = token - hCqGoQYlBorqkIyQnjpMSlqzx1Q1YEAUZaJMCrXN

            // Create the web request 
            StringBuilder sUrl = new StringBuilder();
            sUrl.Append("http://www.esvapi.org/v2/rest/passageQuery");
            sUrl.Append("?key=IP");
            sUrl.Append("&passage=Matthew 5");

            sUrl.Append("&include-headings=true");

            HttpWebRequest request = WebRequest.Create(sUrl.ToString()) as HttpWebRequest;

            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Console application output  
                Console.WriteLine(reader.ReadToEnd());

            }  

        }


        static string _address = "https://bibles.org/v2/passages.xml?q[]=john+3:1-5&version=eng-KJVA";
        static string _username = "jameslevj@gmail.com";
        static string _password = "mamajames1226";
        static string _token = "hCqGoQYlBorqkIyQnjpMSlqzx1Q1YEAUZaJMCrXN";
        static string _token2 = "8lriK3DFE7CEIlYuKE2K9vXGphK5hHa0GVpfPtTZ";


        static async void Run()
        {
            using (var client = new HttpClient())
            {

                string uriToken = "hCqGoQYlBorqkIyQnjpMSlqzx1Q1YEAUZaJMCrXN";
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("username:{0},password:{1}", uriToken, "mamajames1226")));
                //client.DefaultRequestHeaders.Authorization =
                //    new AuthenticationHeaderValue(
                //        "Basic",
                //        Convert.ToBase64String(
                //            System.Text.ASCIIEncoding.ASCII.GetBytes(
                //                string.Format("{0}:{1}", uriToken, "mamajames1226"))));

                var uri = new Uri(_address);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                var response = await client.GetAsync(uri);
                string textResult = await response.Content.ReadAsStringAsync();

                Console.WriteLine(textResult);

                //JObject joResponse = JObject.Parse(textResult);
                //JArray array = (JArray)joResponse["verses"];
                //Console.WriteLine(array[0]["text"]);
                //foreach (var item in array)
                //{
                //    Console.WriteLine(item.ToString());
                //}
            }
        }

       
    }

}


    
  