﻿using Microsoft.Practices.Unity;
using mvc.BLL.Core;
using mvc.Common;
using mvc.IBLL;
using mvc.IDAL;
using mvc.Models;
using mvc.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.BLL
{
    public partial class SysUserBLL :  ISysUserBLL
    {
        DBContainer db = new DBContainer();
        [Dependency]
        public ISysRightRepository sysRightRepository { get; set; }
        public List<permModel> GetPermission(string accountid, string controller)
        {
            return sysRightRepository.GetPermission(accountid, controller);
        }
        
        public override List<SysUserModel> CreateModelList(ref IQueryable<SysUser> queryData)
        {

            List<SysUserModel> modelList = (from r in queryData
                                            select new SysUserModel
                                            {
                                                Address = r.Address,
                                                Attach = r.Attach,
                                                Birthday = (DateTime)r.Birthday,
                                                Card = r.Card,
                                                City = r.City,
                                                CreatePerson = r.CreatePerson,
                                                CreateTime = (DateTime)r.CreateTime,
                                                Degree = r.Degree,
                                                DepId = r.DepId,
                                                EmailAddress = r.EmailAddress,
                                                Expertise = r.Expertise,
                                                Id = r.Id,
                                                JobState = r.JobState,
                                                JoinDate = (DateTime)r.JoinDate,
                                                Marital = r.Marital,
                                                MobileNumber = r.MobileNumber,
                                                Nationality = r.Nationality,
                                                Native = r.Native,
                                                OtherContact = r.OtherContact,
                                                Password = r.Password,
                                                PhoneNumber = r.PhoneNumber,
                                                Photo = r.Photo,
                                                Political = r.Political,
                                                PosId = r.PosId,
                                                Professional = r.Professional,
                                                Province = r.Province,
                                                QQ = r.QQ,
                                                School = r.School,
                                                Sex = r.Sex,
                                                State = (bool)r.State,
                                                TrueName = r.TrueName,
                                                UserName = r.UserName,
                                                Village = r.Village,
                                                RoleHolder = (from a in r.SysRole select a.Name).ToList()
                                            }).ToList();
            return modelList;
        }

        public override bool Create(ref ValidationErrors errors, SysUserModel model)
        {
            try
            {
                SysUser entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new SysUser();
                entity.Address = model.Address;
                entity.Attach = model.Attach;
                entity.Birthday = model.Birthday;
                entity.Card = model.Card;
                entity.City = model.City;
                entity.CreatePerson = model.CreatePerson;
                entity.CreateTime = model.CreateTime;
                entity.Degree = model.Degree;
                entity.DepId = model.DepId;
                entity.EmailAddress = model.EmailAddress;
                entity.Expertise = model.Expertise;
                entity.Id = model.Id;
                entity.JobState = model.JobState;
                entity.JoinDate = model.JoinDate;
                entity.Marital = model.Marital;
                entity.MobileNumber = model.MobileNumber;
                entity.Nationality = model.Nationality;
                entity.Native = model.Native;
                entity.OtherContact = model.OtherContact;
                entity.Password = model.Password;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Photo = model.Photo;
                entity.Political = model.Political;
                entity.PosId = model.PosId;
                entity.Professional = model.Professional;
                entity.Province = model.Province;
                entity.QQ = model.QQ;
                entity.School = model.School;
                entity.Sex = model.Sex;
                entity.State = model.State;
                entity.TrueName = model.TrueName;
                entity.UserName = model.UserName;
                entity.Village = model.Village;
                if (m_Rep.Create(entity) == true)
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

        public override bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
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
        /*
        public bool Delete(ref ValidationErrors errors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        m_Rep.Delete(db, deleteCollection);
                        if (db.SaveChanges() == deleteCollection.Length)
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            Transaction.Current.Rollback();
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }
        */
        public override bool Edit(ref ValidationErrors errors, SysUserModel model)
        {
            try
            {
                SysUser entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Address = model.Address;
                entity.Attach = model.Attach;
                entity.Birthday = model.Birthday;
                entity.Card = model.Card;
                entity.City = model.City;
                entity.CreatePerson = model.CreatePerson;
                entity.CreateTime = model.CreateTime;
                entity.Degree = model.Degree;
                entity.DepId = model.DepId;
                entity.EmailAddress = model.EmailAddress;
                entity.Expertise = model.Expertise;
                entity.Id = model.Id;
                entity.JobState = model.JobState;
                entity.JoinDate = model.JoinDate;
                entity.Marital = model.Marital;
                entity.MobileNumber = model.MobileNumber;
                entity.Nationality = model.Nationality;
                entity.Native = model.Native;
                entity.OtherContact = model.OtherContact;
                entity.Password = model.Password;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Photo = model.Photo;
                entity.Political = model.Political;
                entity.PosId = model.PosId;
                entity.Professional = model.Professional;
                entity.Province = model.Province;
                entity.QQ = model.QQ;
                entity.School = model.School;
                entity.Sex = model.Sex;
                entity.State = model.State;
                entity.TrueName = model.TrueName;
                entity.UserName = model.UserName;
                entity.Village = model.Village;

                if (m_Rep.Edit(entity) == true)
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.EditFail);
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

        public override bool IsExists(string id)
        {
            if (db.SysUser.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public override SysUserModel GetById(string id)
        {
            if (IsExist(id))
            {
                SysUser entity = m_Rep.GetById(id);
                SysUserModel model = new SysUserModel();
                model.Address = entity.Address;
                model.Attach = entity.Attach;
                model.Birthday = (DateTime)entity.Birthday;
                model.Card = entity.Card;
                model.City = entity.City;
                model.CreatePerson = entity.CreatePerson;
                model.CreateTime = (DateTime)entity.CreateTime;
                model.Degree = entity.Degree;
                model.DepId = entity.DepId;
                model.EmailAddress = entity.EmailAddress;
                model.Expertise = entity.Expertise;
                model.Id = entity.Id;
                model.JobState = entity.JobState;
                model.JoinDate = (DateTime)entity.JoinDate;
                model.Marital = entity.Marital;
                model.MobileNumber = entity.MobileNumber;
                model.Nationality = entity.Nationality;
                model.Native = entity.Native;
                model.OtherContact = entity.OtherContact;
                model.Password = entity.Password;
                model.PhoneNumber = entity.PhoneNumber;
                model.Photo = entity.Photo;
                model.Political = entity.Political;
                model.PosId = entity.PosId;
                model.Professional = entity.Professional;
                model.Province = entity.Province;
                model.QQ = entity.QQ;
                model.School = entity.School;
                model.Sex = entity.Sex;
                model.State = (bool)entity.State;
                model.TrueName = entity.TrueName;
                model.UserName = entity.UserName;
                model.Village = entity.Village;
                return model;
            }
            else
            {
                return null;
            }
        }

        public bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }
        public IQueryable<P_Sys_GetRoleByUserId_Result> GetRoleListByUser(ref GridPager pager, string userId)
        {
            IQueryable<P_Sys_GetRoleByUserId_Result> queryData = m_Rep.GetRoleByUserId(db, userId);
            pager.totalRows = queryData.Count();
            queryData = m_Rep.GetRoleByUserId(db, userId);
            return queryData.Skip((pager.page - 1) * pager.rows).Take(pager.rows);
        }
        public bool UpdateSysRoleSysUser(string userId, string[] roleIds)
        {
            try
            {
                m_Rep.UpdateSysRoleSysUser(userId, roleIds);
                return true;

            }
            catch (Exception ex)
            {
                ExceptionHander.WriteException(ex);
                return false;
            }

        }
    }

}