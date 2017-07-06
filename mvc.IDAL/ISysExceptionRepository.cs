using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.IDAL
{
    public interface ISysExceptionRepository
    {
        int Create(SysException entity);
        IQueryable<SysException> GetList(DBContainer db);
        SysException GetById(string id);
        int Delete(string id);
    }
}
