using DataAccessLayer.RolesRepository;
using Model.Entity;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.RolesService
{
    public class RolesService
    {
        private readonly IRolesRepository rolesRepo;

        public RolesService()
        {
            rolesRepo = new RolesRepository();
        }

        public List<RoleInfoViewModel> GetRoles()
        {
            return rolesRepo.GetAll().Select(x => new RoleInfoViewModel
            {
                RolesId=x.RolesId,
                Name=x.Name,
                Status=x.Status,
                ShowStatus=x.Status==1?"Active":"Inactive"
            }).ToList();
        }

        public void AddRole(RoleInfoViewModel model)
        {
            RoleInfo role = new RoleInfo();
            role = rolesRepo.FindBy(o => o.Name == model.Name).FirstOrDefault();
            if (role == null)
            {
                RoleInfo newRole = new RoleInfo();
                newRole.Name = model.Name;
                newRole.Status = 1;
                newRole.CreatedDate = DateTime.Now;
                newRole.CreatedBy = 1;
                rolesRepo.Add(newRole);
                rolesRepo.Save();
            }

        }
        public RoleInfoViewModel GetRoleById(long roleId)
        {
            
            return rolesRepo.FindBy(o => o.RolesId == roleId).Select(o=>new RoleInfoViewModel { 
            RolesId=o.RolesId,
            Name=o.Name
            }).FirstOrDefault();
            

        }

        public void EditRole(RoleInfoViewModel model)
        {
            RoleInfo role = new RoleInfo();
            role = rolesRepo.FindBy(o => o.RolesId == model.RolesId).FirstOrDefault();
            if (role != null)
            {
               
                role.Name = model.Name;
                role.Status = 1;
                role.ModifiedDate = DateTime.Now;
                role.ModifiedBy = 1;
                rolesRepo.Edit(role);
                rolesRepo.Save();
            }

        }

    }
}
