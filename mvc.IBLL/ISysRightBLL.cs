using mvc.Models;
using mvc.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.IBLL
{
    public partial interface ISysRightBLL
    {
        List<permModel> GetPermission(string accountid, string controllor);
        List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId,string moduleId);
        int UpdateRight(SysRightOperateModel model);
    }
}
