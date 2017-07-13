using Microsoft.Practices.Unity;
using mvc.BLL.Core;
using mvc.Common;
using mvc.IBLL;
using mvc.IDAL;
using mvc.Models;
using mvc.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.BLL
{
    public partial class SysRoleBLL : ISysRoleBLL
    {
        DBContainer db = new DBContainer();
        public override List<SysRoleModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<SysRole> queryData = m_Rep.GetList();
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = queryData.Where(a => a.Name.Contains(queryStr));
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            List<SysRoleModel> model = (from a in queryData
                                        select new SysRoleModel()
                                        {
                                            Id = a.Id,
                                            Name = a.Name,
                                            CreatePerson = a.CreatePerson,
                                            CreateTime = a.CreateTime,
                                            Description = a.Description,
                                            UserHolder=(from r in a.SysUser
                                                        select r.UserName).ToList()

                                        }).ToList();
            return model;
        }
        public override List<SysRoleModel> CreateModelList(ref IQueryable<SysRole> queryData)
        {
            List<SysRoleModel> modelList = new List<SysRoleModel>();
            foreach (var r in queryData)
            {
                modelList.Add(new SysRoleModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    CreateTime = r.CreateTime,
                    CreatePerson = r.CreatePerson,
                    UserHolder=(from a in r.SysUser select a.UserName).ToList()
                });
            }
            return modelList;
        }

        public override bool Create(ref ValidationErrors errors, SysRoleModel model)
        {
            try
            {
                SysRole entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new SysRole();
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.CreateTime = model.CreateTime;
                entity.CreatePerson = model.CreatePerson;
                if (m_Rep.Create(entity) == true)
                {
                    //分配给角色
                    db.P_Sys_InsertSysRight();
                    //清理无用的项
                    db.P_Sys_ClearUnusedRightOperate();
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.InsertFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public override bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }


        public override bool Edit(ref ValidationErrors errors, SysRoleModel model)
        {
            try
            {
                SysRole entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.CreateTime = model.CreateTime;
                entity.CreatePerson = model.CreatePerson;

                if (m_Rep.Edit(entity) == true)
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.EditFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public override bool IsExists(string id)
        {
            if (db.SysRole.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public override SysRoleModel GetById(string id)
        {
            if (IsExist(id))
            {
                SysRole entity = m_Rep.GetById(id);
                SysRoleModel model = new SysRoleModel();
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Description = entity.Description;
                model.CreateTime = entity.CreateTime;
                model.CreatePerson = entity.CreatePerson;
                return model;
            }
            else
            {
                return null;
            }
        }

        public bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }
        /// <summary>
        /// 获取角色对应的所有用户
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <returns></returns>
        public string GetRefSysUser(string roleId)
        {
            string UserName = "";
            var userList = m_Rep.GetRefSysUser(db, roleId);
            if (userList != null)
            {
                foreach (var user in userList)
                {
                    UserName += "[" + user.UserName + "] ";
                }
            }
            return UserName;
        }

        public IQueryable<P_Sys_GetUserByRoleId_Result> GetUserByRoleId(ref GridPager pager, string roleId)
        {
            IQueryable<P_Sys_GetUserByRoleId_Result> queryData = m_Rep.GetUserByRoleId(db, roleId);
            pager.totalRows = queryData.Count();
            queryData = m_Rep.GetUserByRoleId(db, roleId);
            return queryData.Skip((pager.page - 1) * pager.rows).Take(pager.rows);
        }
        public bool UpdateSysRoleSysUser(string roleId, string[] userIds)
        {
            try
            {
                m_Rep.UpdateSysRoleSysUser(roleId, userIds);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionHander.WriteException(ex);
                return false;
            }
        }


    }
}
