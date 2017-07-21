using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace mvc.Controllers
{
    public class UploadTestController : Controller
    {
        // GET: UploadTest
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Fileupload()
        {
            //HttpPostedFileBase file =Request.Files["file"];
            //Stream s = System.Web.HttpContext.Current.Request.InputStream;
            

            NameValueCollection nvc = System.Web.HttpContext.Current.Request.Form;

            HttpFileCollection uploadFiles = System.Web.HttpContext.Current.Request.Files;
            string file = Request.Form["file"];
            string filepath = "d://";
            Stream s = new FileStream(filepath, FileMode.Create);
            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);

            string fileName = uploadFiles[0].FileName;//完整的路径
            fileName = System.IO.Path.GetFileName(uploadFiles[0].FileName); //获取到名称

            if (uploadFiles.Count > 0)
                uploadFiles[0].SaveAs("e://");

            //var b = System.Web.HttpContext.Current.Request.ContentLength;
            return Json(new { status = 0, length = b, JsonRequestBehavior.AllowGet });
        }
        private static IDictionary<Guid, int> tasks = new Dictionary<Guid, int>();

        public ActionResult Start()
        {
            var taskId = Guid.NewGuid();
            tasks.Add(taskId, 0);

            Task.Factory.StartNew(() =>
            {
                for (var i = 0; i <= 100; i++)
                {
                    tasks[taskId] = i; // update task progress
                    Thread.Sleep(50); // simulate long running operation
                }
                tasks.Remove(taskId);
            });

            return Json(taskId);
        }

        public ActionResult Progress(Guid id)
        {
            return Json(tasks.Keys.Contains(id) ? tasks[id] : 100);
        }
    }
}