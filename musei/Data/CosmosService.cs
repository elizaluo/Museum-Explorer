using System;
using System.Text.Json;

namespace musei.Data
{
    public class CosmosService
    {
        HttpClient client;
        public Dictionary<string, Event> events = new Dictionary<string, Event>();
        public Dictionary<string, Museum> museums = new Dictionary<string, Museum>();


        public CosmosService()
        {
            client = new HttpClient();
        }

        public async Task<Dictionary<string, Event>> GetEvents()
        {

            Uri uri = new Uri("https://musei-functions.azurewebsites.net/api/GetAllEvents?code=ruiMdMkpBn_iVAb7qk_uls9E3gWyPcI--GKyw5MF_xbDAzFuQpK4OA==");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    events = JsonSerializer.Deserialize<Dictionary<string, Event>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return events;
        }

        public async Task<Dictionary<string, Museum>> GetMuseums()
        {

            Uri uri = new Uri("https://musei-functions.azurewebsites.net/api/GetAllMuseums?code=b7LSMQPt4lh_vfqdo9LBNRXJnWcCEP5JR0TCzTMbhB1IAzFu9NEwwA==");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    museums = JsonSerializer.Deserialize<Dictionary<string, Museum>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return museums;
        }
    }
}
