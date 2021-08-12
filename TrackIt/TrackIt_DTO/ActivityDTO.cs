using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackIt_DTO
{
    public class ActivityDTO
    {
        public string Activity_Id { get; set; }
        public string CourseBatchId { get; set; }
        public string Activity_Name { get; set; }
        public System.DateTime Activity_SDT { get; set; }
        public System.DateTime Activity_EDT { get; set; }
    }
}
