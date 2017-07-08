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
    public interface ISysLogBLL
    {
        List<SysLogModel> GetList(ref GridPager pager, string queryStr);
        List<SysLogModel> CreateModelList(ref GridPager pager, ref IQueryable<SysLog> list);
        SysLogModel GetById(string id);
        bool Delete(ref ValidationErrors errors,string id);
    }
}
