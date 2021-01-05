using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Venture.DTO
{
    public class UpcomingMilestoneDTO
   {
        public string ProjectName { get; set; }
        public string Milestone  { get; set; }
        public DateTime? BaselineStart { get; set; }
        public DateTime? BaselineFinish { get; set; }
        public DateTime? ActualStart { get; set; }
        public DateTime? ActualFinish { get; set; }
        public Decimal? PercentComplete { get; set; }
    }
}
