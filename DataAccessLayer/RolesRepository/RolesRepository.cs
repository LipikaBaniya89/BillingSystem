using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RolesRepository
{
    public class RolesRepository:GenericRepository<BillingSystemEntities,RoleInfo>,IRolesRepository
    {
    }
}
