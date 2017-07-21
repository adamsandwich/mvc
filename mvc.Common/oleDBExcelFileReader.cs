using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Data.OleDb;
using System.Data;

/// <summary>
///exportfile 的摘要说明
/// </summary>
public class oleDBExcelFileReader
{

       DataSet ReadFile_ds;
       int ReadFile_colNum;//列数
       int ReadFile_rowNum;//列数
       public oleDBExcelFileReader()
	   {
       }
       /// <summary>
       /// 设置或获得导入文件列数
       /// </summary>
       public int File_ColNum { get { return ReadFile_colNum; } set { ReadFile_colNum = value; } }
       /// <summary>
       /// 设置或获得导入文件行数
       /// </summary>
       public int File_RowNum { get { return ReadFile_rowNum; } set { ReadFile_rowNum = value; } }
       /// <summary>
       /// 设置或获得导入文件DataSet
      /// </summary>
       public DataSet File_DataSet { get { return ReadFile_ds; } set { ReadFile_ds = value; } }
       /// <summary>
       /// 读取excel文件
      /// </summary>
      /// <param name="filefullpath"></param>
       public DataSet ExcelFileRead(string filefullpath)
        {
            try
            {
                string oleDBConnString = String.Empty;
                oleDBConnString = "Provider=Microsoft.ACE.OLEDB.12.0;";
                oleDBConnString += "Data Source=";
                oleDBConnString += filefullpath;
                oleDBConnString += ";Extended Properties=Excel 12.0;";
                OleDbConnection oleDBConn = null;
                OleDbDataAdapter oleAdMaster = null;
                DataTable m_tableName = new DataTable();
                DataSet ds = new DataSet();

                oleDBConn = new OleDbConnection(oleDBConnString);
                oleDBConn.Open();
                m_tableName = oleDBConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (m_tableName != null && m_tableName.Rows.Count > 0)
                {
                    m_tableName.TableName = m_tableName.Rows[0]["TABLE_NAME"].ToString();
                }
                string sqlMaster;
                sqlMaster = " SELECT *  FROM [" + m_tableName.TableName + "]";
                oleAdMaster = new OleDbDataAdapter(sqlMaster, oleDBConn);
                oleAdMaster.Fill(ds, "m_tableName");
                oleAdMaster.Dispose();
                oleDBConn.Close();
                oleDBConn.Dispose();
                //获得列数
                File_ColNum = ds.Tables[0].Columns.Count;
                //获得行数
                File_RowNum = ds.Tables[0].Rows.Count;
                return ds;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("内部错误") || ex.Message.Contains("无法识别连接") || ex.Message.Contains("登入") || ex.Message.Contains("包写入程序失败") || ex.Message.Contains("连接失去联系") || ex.Message.Contains("因目标主机或对象不存在, 连接失败"))
                {
                    throw;
                }
                else
                {
                    throw new Exception("文件读取发生异常：" + ex.Message);
                }
            }

        }
  
   
}
