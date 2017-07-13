using mvc.IDAL;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.DAL
{
    public partial class SysRoleRepository : IDisposable, ISysRoleRepository
    {

        public IQueryable<SysRole> GetList(DBContainer db)
        {
            IQueryable<SysRole> list = db.SysRole.AsQueryable();
            return list;
        }

        public int Create(SysRole entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Set<SysRole>().Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysRole entity = db.SysRole.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.Set<SysRole>().Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public int Edit(SysRole entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Set<SysRole>().Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public SysRole GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysRole.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysRole entity = GetById(id);
                if (entity != null)
                    return true;
                return false;
            }
        }

        public void Dispose()
        {

        }
        public IQueryable<SysUser> GetRefSysUser(DBContainer db, string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return from m in db.SysRole
                       from f in m.SysUser
                       where m.Id == id
                       select f;
            }
            return null;
        }

        public IQueryable<P_Sys_GetUserByRoleId_Result> GetUserByRoleId(DBContainer db, string roleId)
        {
            return db.P_Sys_GetUserByRoleId(roleId).AsQueryable();
        }

        public void UpdateSysRoleSysUser(string roleId, string[] userIds)
        {
            using (DBContainer db = new DBContainer())
            {
                db.P_Sys_DeleteSysRoleSysUserByRoleId(roleId);
                foreach (string userid in userIds)
                {
                    if (!string.IsNullOrWhiteSpace(userid))
                    {
                        db.P_Sys_UpdateSysRoleSysUser(roleId, userid);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
