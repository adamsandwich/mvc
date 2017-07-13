using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.IDAL
{
    public partial interface ISysRoleRepository
    {
        IQueryable<SysUser> GetRefSysUser(DBContainer db, string id);
        IQueryable<P_Sys_GetUserByRoleId_Result> GetUserByRoleId(DBContainer db, string roleId);
        void UpdateSysRoleSysUser(string roleId, string[] userIds);
    }
}
