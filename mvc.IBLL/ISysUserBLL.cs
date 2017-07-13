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
    public partial interface ISysUserBLL
    {
        List<permModel> GetPermission(string accountid, string controller);
        IQueryable<P_Sys_GetRoleByUserId_Result> GetRoleListByUser(ref GridPager pager, string userId);
        bool UpdateSysRoleSysUser(string userId, string[] roleIds);
    }
}
