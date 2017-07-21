using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvc.Common;
using System.Data;
using System.Web.Mvc;
using System.IO;
using mvc.Models;
using Microsoft.Practices.Unity;
using mvc.IBLL;
using mvc.Models.Sys;

namespace mvc.Controllers
{
    public class DataUploadController : Controller
    {
        [Dependency]
        public IJOBTestScoreBLL itestbll { get; set; }
        public ValidationErrors errors;
        // GET: DataUpload
        public ActionResult Index()
        {
            return View();
        }
        public void upload()
        {
            Stream uploadStream = null;
            FileStream fs = null;
            try
            {
                //文件上传，一次上传1M的数据，防止出现大文件无法上传  
                //file为input中name的值
                HttpPostedFileBase postFileBase = Request.Files["file"];
                uploadStream = postFileBase.InputStream;
                int bufferLen = 1024;
                byte[] buffer = new byte[bufferLen];
                int contentLen = 0;

                string fileName = Path.GetFileName(postFileBase.FileName);
                //string baseUrl = Server.MapPath("/");
                string uploadPath = "E:\\test\\";
                string time = DateTime.Now.ToString("yyyyMMdd_hhmm_ssffff");
                fs = new FileStream(uploadPath + time + fileName, FileMode.Create, FileAccess.ReadWrite);

                while ((contentLen = uploadStream.Read(buffer, 0, bufferLen)) != 0)
                {
                    fs.Write(buffer, 0, bufferLen);
                    fs.Flush();
                }
                if (null != fs)
                {
                    fs.Close();
                }
                if (null != uploadStream)
                {
                    uploadStream.Close();
                }

                //ole读取excel
                oleDBExcelFileReader ole = new oleDBExcelFileReader();
                DataSet ds = ole.ExcelFileRead(uploadPath + time + fileName);
                //DataSet ds = ole.ExcelFileRead("E:\\score.xlsx");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    JOBTestScoreModel temp = new JOBTestScoreModel();
                    temp.Name = dr[0].ToString();
                    temp.StudentId = dr[1].ToString();
                    temp.Score = dr[2].GetInt();
                    itestbll.Create(ref errors, temp);
                }
                
            }
            catch (Exception ex)
            {

            }
        }
    }
}