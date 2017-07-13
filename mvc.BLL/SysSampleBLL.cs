using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using mvc.Models;
using mvc.Common;
using mvc.Models.Sys;
using mvc.IBLL;
using mvc.IDAL;
using mvc.BLL.Core;

namespace mvc.BLL
{
    public partial class SysSampleBLL
    {
        public override bool Create(ref ValidationErrors errors, SysSampleModel model)
        {
            try
            {
                SysSample entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new SysSample();
                entity.Id = model.Id;
                entity.Name = model.Name.TrimStart();
                entity.Age = model.Age;
                entity.Bir = model.Bir;
                entity.Photo = model.Photo;
                entity.Note = model.Note;
                entity.CreateTime = model.CreateTime;
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