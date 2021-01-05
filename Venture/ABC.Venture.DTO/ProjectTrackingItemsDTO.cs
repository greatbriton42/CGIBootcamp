using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Venture.DTO
{
    public class ProjectTrackingItemsDTO
    {
        public int IssueId { get; set; }
        public string ProjectName { get; set; }
        public int? ProjectID { get; set; }
        public string IssueType { get; set; }
        public string Issue { get; set; }

        public string AssignedTo { get; set; }

        public string NextAction { get; set; }
        public DateTime? TargetDate { get; set; }

        public string Status { get; set; }
    }
}
