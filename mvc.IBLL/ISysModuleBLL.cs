using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvc.Common;
using mvc.Models.Sys;
using mvc.Models;

namespace mvc.IBLL
{
    public partial interface ISysModuleBLL
    {
        List<SysModule> GetModuleBySystem(string parentId);
    }
}
