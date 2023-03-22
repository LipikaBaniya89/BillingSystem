using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class UserViewModel
    {
        public long? UserId { get; set; }
        public string Full_name {get; set;}
        public long ContactNo { get; set; }
        public string Email { get; set; }
        public List<UserViewModel> UserList { get; set; }
    }
}
