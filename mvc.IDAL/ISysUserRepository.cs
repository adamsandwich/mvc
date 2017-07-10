using mvc.Models;
using System.Linq;
namespace mvc.IDAL
{
    public interface ISysUserRepository
    {
        IQueryable<SysUser> GetList(DBContainer db);
        int Create(SysUser entity);
        int Delete(string id);
        void Delete(DBContainer db, string[] deleteCollection);
        int Edit(SysUser entity);
        SysUser GetById(string id);
        bool IsExist(string id);
        IQueryable<P_Sys_GetRoleByUserId_Result> GetRoleByUserId(DBContainer db, string userId);
        void UpdateSysRoleSysUser(string userId, string[] roleIds);
    }
}