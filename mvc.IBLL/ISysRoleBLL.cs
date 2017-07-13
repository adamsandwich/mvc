using mvc.Common;
using mvc.Models;
using mvc.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.IBLL
{
    public partial interface ISysRoleBLL
    {
        IQueryable<P_Sys_GetUserByRoleId_Result> GetUserByRoleId(ref GridPager pager, string roleId);
        bool UpdateSysRoleSysUser(string roleId, string[] userIds);
    }
}
