using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackIt_DTO
{
    public class ActivityTrackerDTO
    {
        public int Tracker_Id { get; set; }
        public string Activity_Id { get; set; }
        public int P_PSNo { get; set; }
        public string Activity_Status { get; set; }
        public string GitUrl { get; set; }

    }
}
