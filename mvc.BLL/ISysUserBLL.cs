using mvc.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.BLL
{
    public interface ISysUserBLL
    {
        List<permModel> GetPermission(string accountid, string controller);
    }
}
