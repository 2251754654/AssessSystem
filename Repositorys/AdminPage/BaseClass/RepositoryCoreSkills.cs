using Repositorys.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using ProjectUtils;

namespace Repositorys
{
    public class RepositoryCoreSkills : IRepositoryCoreSkills
    {
        private readonly DBContext dbContext = new DBContext();

        /// <summary>
        /// 根据技能ID查询技能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ModelCoreSkills FindCoreSkill(int id)
        {
            var coreSkill = dbContext.TB_CoreSkills.Find(id);
            var modelCoreSkill = new ModelCoreSkills();
            if (UtilClass.Convert(coreSkill, modelCoreSkill))
            {
                return modelCoreSkill;
            }
            return null;
        }
        /// <summary>
        /// 查询所有技能
        /// </summary>
        /// <returns></returns>
        public List<ModelCoreSkills> FindAllCoreSkill()
        {
            var coreSkillList = dbContext.TB_CoreSkills.ToList();
            var modelCoreSkillList= new List<ModelCoreSkills>();
            if (coreSkillList != null)
            {
                foreach (var coreSkillListItem in coreSkillList)
                {
                    var modelCoreSkillListItem = new ModelCoreSkills();
                    UtilClass.Convert(coreSkillListItem, modelCoreSkillListItem);
                    modelCoreSkillList.Add(modelCoreSkillListItem);
                }
                return modelCoreSkillList;
            }
            return null;
        }
        /// <summary>
        /// 查询所有删除的技能
        /// </summary>
        /// <returns></returns>
        public List<ModelCoreSkills> FindAllDeleteCoreSkill()
        {
            var coreSkillList = dbContext.TB_CoreSkills.Where(o=>o.CoreSkillsDelete == 0).ToList();
            var modelCoreSkillList = new List<ModelCoreSkills>();
            if (coreSkillList != null)
            {
                foreach (var coreSkillListItem in coreSkillList)
                {
                    var modelCoreSkillListItem = new ModelCoreSkills();
                    UtilClass.Convert(coreSkillListItem, modelCoreSkillListItem);
                    modelCoreSkillList.Add(modelCoreSkillListItem);
                }
                return modelCoreSkillList;
            }
            return null;
        }
        /// <summary>
        /// 查询所有未删除的技能
        /// </summary>
        /// <returns></returns>
        public List<ModelCoreSkills> FindAllNotDeleteCoreSkill()
        {
            var coreSkillList = dbContext.TB_CoreSkills.Where(o => o.CoreSkillsDelete == 1).ToList();
            var modelCoreSkillList = new List<ModelCoreSkills>();
            if (coreSkillList != null)
            {
                foreach (var coreSkillListItem in coreSkillList)
                {
                    var modelCoreSkillListItem = new ModelCoreSkills();
                    UtilClass.Convert(coreSkillListItem, modelCoreSkillListItem);
                    modelCoreSkillList.Add(modelCoreSkillListItem);
                }
                return modelCoreSkillList;
            }
            return null;
        }
        /// <summary>
        /// 插入技能
        /// </summary>
        /// <param name="modelCoreSkills"></param>
        /// <returns></returns>
        public bool Insert(ModelCoreSkills modelCoreSkills)
        {
            var coreSkills = new TB_CoreSkills();
            UtilClass.Convert(modelCoreSkills, coreSkills);
            dbContext.TB_CoreSkills.Add(coreSkills);
            if (dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 更新技能(上层必须确保字段确实更新了，没更新则为false)
        /// </summary>
        /// <param name="modelRole"></param>
        /// <returns></returns>
        public bool Update(ModelCoreSkills modelCoreSkills)
        {
            var coreSkill = dbContext.TB_CoreSkills.Find(modelCoreSkills.CoreSkillsID);
            if (coreSkill != null)
            {
                UtilClass.Convert(modelCoreSkills, coreSkill);
                if (dbContext.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        /// <summary>
        /// 物理删除技能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ReallyDelete(int id)
        {

            var result = dbContext.TB_CoreSkills.Include("TB_MappingCore").Include("TB_CoreLever").Where(o => o.CoreSkillsID == id).FirstOrDefault();
            if (result != null)
            {
                if (result.TB_MappingCore != null)
                {
                    dbContext.TB_MappingCore.RemoveRange(result.TB_MappingCore);
                }
                if (result.TB_CoreLever != null)
                {
                    dbContext.TB_CoreLever.RemoveRange(result.TB_CoreLever);
                }
                dbContext.TB_CoreSkills.Remove(result);
                if (dbContext.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
        /// <summary>
        /// 逻辑删除技能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FakeDelete(int id)
        {
            var result = dbContext.TB_CoreSkills.Find(id);
            if (result != null)
            {
                result.CoreSkillsDelete = 0;
                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                    throw e;
                }
                return true;
            }
            return true;
        }
        /// <summary>
        /// 查询职业下的核心技能
        /// </summary>
        /// <param name="professionalID"></param>
        /// <returns></returns>
        public List<ModelCoreSkills> FindCoreSkillByProfessionalID(int professionalID)
        {
            var mappingCore = dbContext.TB_MappingCore.Include("TB_CoreSkills").Where(o => o.ProfessionalID == professionalID).ToList();
            var modelCoreList = new List<ModelCoreSkills>();
            foreach (var item in mappingCore)
            {
                var modelItem = new ModelCoreSkills();
                UtilClass.Convert(item.TB_CoreSkills,modelItem);
                modelCoreList.Add(modelItem);
            }
            return modelCoreList;
        }
    }
}
