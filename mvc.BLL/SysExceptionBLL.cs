using Microsoft.Practices.Unity;
using mvc.Common;
using mvc.IBLL;
using mvc.IDAL;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.BLL
{
    public partial class SysExceptionBLL : ISysExceptionBLL
    {
        [Dependency]
        public ISysExceptionRepository exceptionRepository { get; set; }


       
    }
}
