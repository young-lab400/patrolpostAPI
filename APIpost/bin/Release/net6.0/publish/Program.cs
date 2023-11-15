using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
//client.DefaultRequestHeaders.Accept.Add(
//    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
//client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    try
    {
        string webRootPath = System.Environment.CurrentDirectory;
        //string webRootPath = AppDomain.CurrentDomain.BaseDirectory;
        StreamReader reader = new StreamReader(webRootPath + "/APIpost/data.json");
        var apiData = reader.ReadToEnd();
        var fooJSON = JsonConvert.SerializeObject(apiData);
        // https://msdn.microsoft.com/zh-tw/library/system.net.http.stringcontent(v=vs.110).aspx

        using (HttpContent fooContent = new StringContent(fooJSON, Encoding.UTF8, "application/json"))
        {
            var json = await client.PostAsync("http://192.168.9.26/api/Get_patrolpoint", fooContent);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    Console.WriteLine("按任意鍵結束....");
    Console.ReadKey();  //可按任意鍵結束畫面
}