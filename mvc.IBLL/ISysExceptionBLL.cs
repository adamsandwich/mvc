using mvc.Common;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.IBLL
{
    public interface ISysExceptionBLL
    {
        List<SysException> GetList(ref GridPager pager, string queryStr);
        SysException GetById(string id);
        bool Delete(string id);
    }
}
