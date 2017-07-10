using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvc.Models;

namespace mvc.BLL
{
    public class BaseBLL
    {
        protected DBContainer db = new DBContainer();
    }
}
