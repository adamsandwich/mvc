﻿using mvc.Common;
using mvc.IBLL;
using mvc.Models;
using Microsoft.Practices.Unity;
using mvc.DAL;
using mvc.Models.Sys;

namespace mvc
{
    public static class LogHandler
    {
        [Dependency]
        public static ISysLogBLL logBLL { get; set; }
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="oper">操作人</param>
        /// <param name="mes">操作信息</param>
        /// <param name="result">结果</param>
        /// <param name="type">类型</param>
        /// <param name="module">操作模块</param> 
        public static void WriteServiceLog(string oper, string mes, string result, string type, string module)
        {
            ValidationErrors errors = new ValidationErrors();
            SysLogRepository Rep = new SysLogRepository(new DBContainer());
            SysLog entity = new SysLog();
            entity.Id = ResultHelper.NewId;
            entity.Operator = oper;
            entity.Message = mes;
            entity.Result = result;
            entity.Type = type;
            entity.Module = module;
            entity.CreateTime = ResultHelper.NowTime;
            Rep.Create(entity);
        }
    }
}