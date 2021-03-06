﻿using Microsoft.Practices.Unity;
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
    public partial class SysModuleBLL :ISysModuleBLL
    {
        DBContainer db = new DBContainer();
        public List<SysModuleModel> GetList(string parentId)
        {
            IQueryable<SysModule> queryData = m_Rep.GetList();
            queryData = queryData.Where(r => r.ParentId == parentId && r.Id != "0").OrderBy(r => r.Sort);
            List<SysModuleModel> modelList = (from r in queryData
                                              select new SysModuleModel()
                                              {
                                                  Id = r.Id,
                                                  Name = r.Name,
                                                  EnglishName = r.EnglishName,
                                                  ParentId = r.ParentId,
                                                  Url = r.Url,
                                                  Iconic = r.Iconic,
                                                  Sort = r.Sort,
                                                  Remark = r.Remark,
                                                  Enable = r.Enable,
                                                  CreatePerson = r.CreatePerson,
                                                  CreateTime = r.CreateTime,
                                                  IsLast = r.IsLast

                                              }).ToList();
            return modelList;
        }
        public List<SysModule> GetModuleBySystem(string parentId)
        {

            return m_Rep.GetModuleBySystem(db, parentId).ToList();
        }

        public override bool Create(ref ValidationErrors errors, SysModuleModel model)
        {


            try
            {
                SysModule entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new SysModule();
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.EnglishName = model.EnglishName;
                entity.ParentId = model.ParentId;
                entity.Url = model.Url;
                entity.Iconic = model.Iconic;
                entity.Sort = model.Sort;
                entity.Remark = model.Remark;
                entity.Enable = model.Enable;
                entity.CreatePerson = model.CreatePerson;
                entity.CreateTime = model.CreateTime;
                entity.IsLast = model.IsLast;
                if (m_Rep.Create(entity) == true)
                {
                    //分配给角色
                    db.P_Sys_InsertSysRight();
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
                //检查是否有下级
                if (db.SysModule.AsQueryable().Where(a => a.SysModule2.Id == id).Count() > 0)
                {
                    errors.Add("有下属关联，请先删除下属！");
                    return false;
                }
                m_Rep.Delete(db, id);
                if (db.SaveChanges() > 0)
                {
                    //清理无用的项
                    db.P_Sys_ClearUnusedRightOperate();
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

        public override bool Edit(ref ValidationErrors errors, SysModuleModel model)
        {
            try
            {
                SysModule entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Name = model.Name;
                entity.EnglishName = model.EnglishName;
                entity.ParentId = model.ParentId;
                entity.Url = model.Url;
                entity.Iconic = model.Iconic;
                entity.Sort = model.Sort;
                entity.Remark = model.Remark;
                entity.Enable = model.Enable;
                entity.IsLast = model.IsLast;

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
        public bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }
    }
}
