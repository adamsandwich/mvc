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
    public partial class SysLogBLL : ISysLogBLL
    {
        [Dependency]
        public ISysLogRepository logRepository { get; set; }
        DBContainer db = new DBContainer();

       

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

    }
}
