using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.IDAL
{
    public interface ICommonRepository<T> where T : class
    {
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="model">实体</param>
        bool Create(T model);
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="model">实体</param>
        bool Edit(T model);
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="model">主键ID</param>
        bool Delete(T model);
        /// <summary>
        /// 按主键删除
        /// </summary>
        /// <param name="keyValues">主键ID</param>
        int Delete(params object[] keyValues);
        /// <summary>
        /// 获得一个实体
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>实体</returns>
        T GetById(params object[] keyValues);
        /// <summary>
        /// 获得所有数据
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetList();
        /// <summary>
        /// 根据表达式获取数据
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetList(Func<T, bool> whereLambda);
        bool IsExist(string id);
        int SaveChanges();
    }
}
