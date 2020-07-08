using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argeset.Entity.Models
{
    public class RecordRequestParameters
    {
        public string CustomObjectId { get; set; }
        public Dictionary<string,object> FieldsValues { get; set; }
    }
}
