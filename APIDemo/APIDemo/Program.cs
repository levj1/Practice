using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
            Runapifail();

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


        static string _address = @"https://bibles.org/v2/eng-KJVA/passages.js?q[]=john+3%3A1-5";
        static string _password = "mamajames1226";
        static string _token = "hCqGoQYlBorqkIyQnjpMSlqzx1Q1YEAUZaJMCrXN";

       
    }

}


    
  