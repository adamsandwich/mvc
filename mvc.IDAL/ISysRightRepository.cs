using mvc.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.IDAL
{
    public interface ISysRightRepository
    {
        List<permModel> GetPermission(string accountid, string controller);
    }
}
