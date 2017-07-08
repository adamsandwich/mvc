using mvc.Common;
using mvc.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.IBLL
{
    public interface ISysModuleOperateBLL
    {
        List<SysModuleOperateModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, SysModuleOperateModel model);
        bool Delete(ref ValidationErrors errors, string id);
        SysModuleOperateModel GetById(string id);
        bool IsExist(string id);
    }
}
