using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.IDAL
{
    public interface IHomeRepository
    {
        List<SysModule> GetMenuByPersonId(string personId, string moduleId);
    }
}
