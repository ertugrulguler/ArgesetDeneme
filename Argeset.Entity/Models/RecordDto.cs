using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argeset.Entity.Models
{
    public class RecordDto
    {
        public int CustomObjectId { get; set; }
        public string CustomObjectPublicId { get; set; }
        public Values[] Values { get; set; }
        public LookupTitles[] LookupTitles { get; set; }
        public LookupValues[] LookupValues { get; set; }
        public string UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public int Version { get; set; }
        public TablesValues[] TablesValues { get; set; }
        public int Id { get; set; }
        public string PublicId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int UpdatedBy { get; set; }

    }
}
