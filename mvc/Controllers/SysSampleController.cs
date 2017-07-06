using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using mvc.Common;
using mvc.IBLL;
using mvc.Models.Sys;
using Microsoft.Practices.Unity;
using mvc.Core;

namespace mvc.Controllers
{
    public class SysSampleController : BaseController
    {
        ValidationErrors errors = new ValidationErrors();
        /// <summary>
        /// 业务层注入
        /// </summary>
        [Dependency]
        public ISysSampleBLL m_BLL { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetList(GridPager pager, string queryStr = null)
        {
            List<SysSampleModel> list = m_BLL.GetList(ref pager,queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysSampleModel()
                        {

                            Id = r.Id,
                            Name = r.Name,
                            Age = r.Age,
                            Bir = r.Bir,
                            Photo = r.Photo,
                            Note = r.Note,
                            CreateTime = r.CreateTime,

                        }).ToArray()

            };

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        #region 创建
        [SupportFilter]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(SysSampleModel model)
        {
            if (m_BLL.Create(ref errors, model))
            {
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name, "成功", "创建", "样例程序");
                return Json(JsonHandler.CreateMessage(1, "插入成功"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name + "," + ErrorCol, "失败", "创建", "样例程序");
                return Json(JsonHandler.CreateMessage(0, "插入失败" + ErrorCol), JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 修改

        public ActionResult Edit(string id)
        {

            SysSampleModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        public JsonResult Edit(SysSampleModel model)
        {
            if (m_BLL.Edit(ref errors, model))
            {
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name, "成功", "修改", "样例程序");
                return Json(JsonHandler.CreateMessage(1, "修改成功"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name + "," + ErrorCol, "失败", "修改", "样例程序");
                return Json(JsonHandler.CreateMessage(0, "修改失败" + ErrorCol), JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 详细
        public ActionResult Details(string id)
        {
            SysSampleModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        #endregion

        #region 删除
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                SysSampleModel model = m_BLL.GetById(id);
                if (m_BLL.Delete(ref errors,id))
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name + "," + ErrorCol, "失败", "删除", "样例程序");
                    return Json(JsonHandler.CreateMessage(1, "删除成功" + ErrorCol), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name + "," + ErrorCol, "失败", "删除", "样例程序");
                    return Json(JsonHandler.CreateMessage(0, "删除失败" + ErrorCol), JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }


        }
        #endregion

    }
}