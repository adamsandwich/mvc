using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvc.Common;
using mvc.Models.Job;
using mvc.Models;
using mvc.BLL.Core;

namespace mvc.BLL
{
    public partial class JOBTestScoreBLL
    {
        public bool creatall(ref ValidationErrors errors,JOBTestScoreModel model )
        {
            try
            {
                JOBTestScore entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new JOBTestScore();
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Score = model.Score;
                entity.StudentId = model.StudentId;
                if (m_Rep.Create(entity))
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.InsertFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }
    }
}
