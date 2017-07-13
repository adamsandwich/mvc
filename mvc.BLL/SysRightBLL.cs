using Microsoft.Practices.Unity;
using System;
using mvc.IBLL;
using mvc.IDAL;
using mvc.Models;
using mvc.Models.Sys;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace mvc.BLL
{
    public partial class SysRightBLL:ISysRightBLL
    {
        [Dependency]
        public ISysRightRepository m_Rep { get; set; }
        DBContainer db = new DBContainer();
        public List<permModel> GetPermission(string accountid, string controllor)
        {
            return m_Rep.GetPermission(accountid, controllor);
        }
        public List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId)
        {
            return m_Rep.GetRightByRoleAndModule(roleId, moduleId);
        }
        public int UpdateRight(SysRightOperateModel model)
        {
            return m_Rep.UpdateRight(model);
        }
    }
}
