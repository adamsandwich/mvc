using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.IDAL
{
    public partial interface ISysExceptionRepository
    {
        SysException GetById(string id);
    }
}
