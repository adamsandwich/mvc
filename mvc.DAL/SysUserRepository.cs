using System;
using System.Linq;
using mvc.Models;
using System.Data;
using System.Data.Entity;
using mvc.IDAL;

namespace mvc.DAL
{
    public partial class SysUserRepository : ISysUserRepository, IDisposable
    {

        public void Dispose()
        {

        }
        public IQueryable<P_Sys_GetRoleByUserId_Result> GetRoleByUserId(DBContainer db, string userId)
        {
            return db.P_Sys_GetRoleByUserId(userId).AsQueryable();
        }

        public void UpdateSysRoleSysUser(string userId, string[] roleIds)
        {
            using (DBContainer db = new DBContainer())
            {
                db.P_Sys_DeleteSysRoleSysUserByUserId(userId);
                foreach (string roleid in roleIds)
                {
                    if (!string.IsNullOrWhiteSpace(roleid))
                    {
                        db.P_Sys_UpdateSysRoleSysUser(roleid, userId);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
