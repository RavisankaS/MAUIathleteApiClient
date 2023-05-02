using System;
using RSIRIWARDENAGE1_Test3.Models;
using RSIRIWARDENAGE1_Test3.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RSIRIWARDENAGE1_Test3.Data
{
    public class AthleteRepository : IAthleteRepository
    {
        readonly HttpClient client = new HttpClient();

        public AthleteRepository()
        {
            client.BaseAddress = Jeeves.DBUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Athlete>> GetAthletes()
        {
            HttpResponseMessage response = await client.GetAsync("api/Athletes");
            if (response.IsSuccessStatusCode)
            {
                List<Athlete> athletes = await response.Content.ReadAsAsync<List<Athlete>>();
                return athletes;
            }
            else
            {
                var ex = Jeeves.CreateApiException(response);
                throw ex;
            }
        }

        public async Task<List<Athlete>> GetAthletesBySport(int SportID)
        {
            var response = await client.GetAsync($"api/Athletes/bySport{SportID}");
            if (response.IsSuccessStatusCode)
            {
                List<Athlete> athletes = await response.Content.ReadAsAsync<List<Athlete>>();
                return athletes;
            }
            else
            {
                var ex = Jeeves.CreateApiException(response);
                throw ex;
            }
        }

        public async Task<Athlete> GetAthlete(int ID)
        {
            var response = await client.GetAsync($"api/Athletes/{ID}");
            if (response.IsSuccessStatusCode)
            {
                Athlete Athlete = await response.Content.ReadAsAsync<Athlete>();
                return Athlete;
            }
            else
            {
                var ex = Jeeves.CreateApiException(response);
                throw ex;
            }
        }

    }
}
