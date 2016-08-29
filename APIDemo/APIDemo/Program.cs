using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace APIDemo
{

    class Program
    {        
        static string _password = "mamajames1226";
        static string _token = "hCqGoQYlBorqkIyQnjpMSlqzx1Q1YEAUZaJMCrXN";
        static string _address = @"https://bibles.org/v2/eng-KJVA/passages.js?q[]=john+3%3A1-5";
        static void Main(string[] args)
        {
            Run();

            Console.ReadLine();

        }

        static async void Runapifail()
        {
            Rootobject rootobj = null;
            
            using (var client = new HttpClient())
            {
                var byteArray = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", _token, _password));
                var header = new AuthenticationHeaderValue(
                           "Basic", Convert.ToBase64String(byteArray));
                client.DefaultRequestHeaders.Authorization = header;

                var result = await client.GetAsync(_address);
                string textResult = await result.Content.ReadAsStringAsync();
                rootobj = JsonConvert.DeserializeObject<Rootobject>(textResult);

                //var test = rootobj.response.search.result.passages[0].text.ToString();

                //Console.WriteLine(test);
                foreach (var item in rootobj.response.search.result.passages)
                {
                    Console.WriteLine(item.text);
                }
            }
        }


        // This one works fine.
        static async Task Run()
        {
            Rootobject rootObj = null;

            string address = String.Format("https://bibles.org/v2/passages.xml?q[]=john+3:1-5&version=eng-KJVA");


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(address);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", _token, _password)));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                HttpResponseMessage response = await client.GetAsync(_address);
                if(response.IsSuccessStatusCode)
                {
                    Console.WriteLine();
                    var result = await response.Content.ReadAsStringAsync();
                    rootObj = JsonConvert.DeserializeObject<Rootobject>(result);
                }

                foreach (var item in rootObj.response.search.result.passages)
                {
                    Console.WriteLine(item.text);
                }
            }
        }


       
    }

}



//var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}", "jameslevj@gmail.com", "mamajames1226")));
//client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
//JObject joResponse = JObject.Parse(textResult);
//JArray array = (JArray)joResponse["verses"];