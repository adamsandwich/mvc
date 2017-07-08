using Microsoft.Practices.Unity;
using mvc.Common;
using mvc.IBLL;
using mvc.IDAL;
using mvc.Models;
using mvc.Models.Sys;
using mvc.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.BLL
{
    public class SysLogBLL : ISysLogBLL
    {
        [Dependency]
        public ISysLogRepository logRepository { get; set; }
        DBContainer db = new DBContainer();

        public List<SysLogModel> GetList(ref GridPager pager, string queryStr)
        {
            IQueryable<SysLog> list = logRepository.GetList(db);
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                list = list.Where(a => a.Message.Contains(queryStr) || a.Module.Contains(queryStr));
                pager.totalRows = list.Count();
            }
            else
            {
                pager.totalRows = list.Count();
            }

            if (pager.order == "desc")
            {
                list = list.OrderByDescending(c => c.CreateTime);
            }
            else
            {
                list = list.OrderBy(c => c.CreateTime);
            }


            return CreateModelList(ref pager, ref list);
        }

        public List<SysLogModel> CreateModelList(ref GridPager pager, ref IQueryable<SysLog> list)
        {
            if (pager.page <= 1)
            {
                list = list.Take(pager.rows);
            }
            else
            {
                list = list.Skip((pager.page - 1) * pager.rows).Take(pager.rows);
            }
            List<SysLogModel> modelList = (from r in list
                                           select new SysLogModel
                                           {
                                               Id = r.Id,
                                               Operator = r.Operator,
                                               Message = r.Message,
                                               Result = r.Result,
                                               Type = r.Type,
                                               Module = r.Module,
                                               CreateTime = r.CreateTime

                                           }).ToList();
            return modelList;
        }

        public SysLogModel GetById(string id)
        {
            SysLog entity = logRepository.GetById(id);
            SysLogModel model = new SysLogModel();
            if (entity == null)
                return model;
            model.Id = entity.Id;
            model.Message = entity.Message;
            model.Module = entity.Module;
            model.Operator = entity.Operator;
            model.Result = entity.Result;
            model.Type = entity.Type;
            model.CreateTime = entity.CreateTime;
            return model;
        }

        public bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    if (logRepository.Delete(db, id) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        errors.Add("删除失败");
                        return false;
                    }
                }
                else
                {
                    errors.Add("主键重复");
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
    }
}
