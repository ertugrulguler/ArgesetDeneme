using Argeset.Entity.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Argeset.Business.Manager
{
    public class ResultManager
    {
        private RecordDto result = null;
        private readonly string apiKey = ConfigurationManager.AppSettings["ApiKey"].ToString();

        public async Task<RecordDto> GetRecord(string customObjectId, string recordId)
        {
            using (var client = new HttpClient())
            {
                var getUrl = ConfigurationManager.AppSettings["DefaultGetApiUrl"].ToString();
               
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(apiKey);
           
                var response = await client.GetStringAsync($"{getUrl}" + customObjectId + "&recordId=" + recordId);
          
                result = JsonConvert.DeserializeObject<RecordDto>(response);
            }
            return result;
        }

        public async void PostRecord(PostedObject postedObject)
        {
            using (var client = new HttpClient())
            {
                //set Accept and Authorization header 
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(apiKey);

                //make async request
                var parameters = new RecordRequestParameters
                {
                    CustomObjectId = "52275A90BDF94801B46939EE8973C06F"/*Guid.NewGuid().ToString().ToUpper().Replace("-","")*/,
                    FieldsValues = new Dictionary<string, object>
                    {
                        {"88F6EED8775845B384DAD814E6159CE7",postedObject.Name},
                        {"40A7F64FA6BE46D180BEC9C149D91C51",postedObject.Lastname},
                        {"073B95BD82774889AEEA17C2BFD8C871",postedObject.Phone},
                        {"EA1E11A3D7D441F0AFE6F763A64C5091",postedObject.Email},
                        {"ADE0E1EE23F640B18D35B45BD5D68717",postedObject.Birthday},
                        {"255EF075F4544C7E84C41F72827A616B",postedObject.Gender},
                    }
        
                };

                HttpContent content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
                var request = await client.PostAsync("http://api.setcrm.com/v1/record", content);
                //handle the result
                var result = await request.Content.ReadAsStringAsync();
            }
        }
    }
}
