using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Venture.DTO
{
    public class ResourceDTO
    {
        public int ResourceID { get; set; }

        public string ResourceName { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserID { get; set; }
    }
}
