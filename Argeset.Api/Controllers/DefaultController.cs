using Argeset.Business.Manager;
using Argeset.Entity.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Argeset.Api.Controllers
{
    public class DefaultController : ApiController
    {
       
        public Task<RecordDto> Get(string customObjectId, string recordId)
        {
           
            var result = new ResultManager();
            var response = result.GetRecord(customObjectId, recordId);

            return response;
        }

        
        public string Post([FromBody]PostedObject postedObject)
        {
            var result = new ResultManager();
            result.PostRecord(postedObject);

            return "Kaydınız başarıyla tamamlandı.";
        }

    }
}
