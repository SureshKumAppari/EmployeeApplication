using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient cons = new HttpClient();
            cons.BaseAddress = new System.Uri("http://localhost:50669/api/User");
            cons.DefaultRequestHeaders.Accept.Clear();
            cons.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        static async Task GetUser(HttpClient cons)
        {
            using (cons)
            {
                HttpResponseMessage res = await cons.GetAsync("api/Users/1");
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
            }
        }
        static async Task PostUser(HttpClient cons)
        {
            using(cons)
            {
                User user = new User();
                user.Alias = "AZ";
                user.Email = "A@tectoro.com";
                user.FirstName = "A";
                user.LastName = "Z";
                HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(user));
                HttpResponseMessage res = await cons.PostAsync("api/Users", httpContent);
            }
        }
        static async Task PutUser(HttpClient cons)
        {
            using(cons)
            {
                HttpResponseMessage res = await cons.GetAsync("api/Users/1");
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    User user = (User)Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                    user.Alias = "B";
                    HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(user));
                    HttpResponseMessage resp = await cons.PutAsync("api/Users", httpContent);
                    Console.WriteLine(resp.StatusCode);
                }
            }
        }
        static async Task DeleteUser(HttpClient cons)
        {
            using (cons)
            {
                HttpResponseMessage res = await cons.GetAsync("api/Users/1");
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    HttpResponseMessage resp = await cons.DeleteAsync("api/Users/1");
                    Console.WriteLine(resp.StatusCode);
                }
            }
        }
    }
}
