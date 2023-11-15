using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

using HttpClient client = new();
client.BaseAddress = new Uri("http://192.168.9.26/");
client.DefaultRequestHeaders.Accept.Clear();
//client.DefaultRequestHeaders.Accept.Add(
//    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));


await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    
    try
    {
        //string webRootPath = System.Environment.CurrentDirectory;
        //////string webRootPath = AppDomain.CurrentDomain.BaseDirectory;
        //StreamReader reader = new StreamReader(webRootPath + "/data.json");
        //var apiData = reader.ReadToEnd();
        //var fooJSON = JsonConvert.DeserializeObject(apiData);
        ////using (HttpContent fooContent = new StringContent(fooJSON, Encoding.UTF8, "application/json"))
        ////{
        ////    var result = await client.PostAsync("http://192.168.9.26/api/Get_patrolpoint", fooContent);
        ////    Console.WriteLine(result);
        ////}

        HttpClient httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        var content = new Dictionary<string, string>();
        content.Add("depart", "AK");
        content.Add("dt", DateTime.Now.ToString("yyyy-MM-dd"));
        content.Add("num", "3");
        content.Add("opt", "4");
        var result = httpClient.PostAsync("http://192.168.9.26/api/Get_patrolpoint", new FormUrlEncodedContent(content));
        
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    Thread.Sleep(4000);
    //Console.WriteLine("按任意鍵結束....");
    //Console.ReadKey();  //可按任意鍵結束畫面
}

