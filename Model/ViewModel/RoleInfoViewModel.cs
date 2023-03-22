using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class RoleInfoViewModel
    {
        public long? RolesId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string ShowStatus { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }

        public List<RoleInfoViewModel> RoleList { get; set; }
    
    }
}
