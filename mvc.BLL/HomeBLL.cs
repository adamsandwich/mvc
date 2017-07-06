using Microsoft.Practices.Unity;
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
    public class HomeBLL : IHomeBLL
    {
        [Dependency]
        public IHomeRepository HomeRepository { get; set; }
        public List<SysModule> GetMenuByPersonId(string personId, string moduleId)
        {
            return HomeRepository.GetMenuByPersonId(personId, moduleId);
        }
    }
}
