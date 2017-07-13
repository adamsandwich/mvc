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
    public partial interface ISysLogBLL
    {
        List<SysLogModel> CreateModelList(ref GridPager pager, ref IQueryable<SysLog> list);
    }
}
