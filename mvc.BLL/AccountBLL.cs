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
    public class AccountBLL : IAccountBLL
    {
        [Dependency]
        public IAccountRepository accountRepository { get; set; }
        public SysUser Login(string username, string pwd)
        {
            return accountRepository.Login(username, pwd);

        }
    }
}
