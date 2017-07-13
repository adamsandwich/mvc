using mvc.Models;
using System.Linq;
namespace mvc.IDAL
{
    public partial interface ISysUserRepository
    {
        IQueryable<P_Sys_GetRoleByUserId_Result> GetRoleByUserId(DBContainer db, string userId);
        void UpdateSysRoleSysUser(string userId, string[] roleIds);
    }
}