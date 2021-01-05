using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Venture.Common;

namespace ABC.Venture.DTO
{
    public class MyProjectDTO
    {
        public int ProjectId { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public EnumTypes.StatusUpdateFlag StatusUpdate { get; set; }

    }
}
