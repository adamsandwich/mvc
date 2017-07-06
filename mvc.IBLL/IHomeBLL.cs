using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.IBLL
{
    public interface IHomeBLL
    {
        List<SysModule> GetMenuByPersonId(string moduleId);
    }
}
