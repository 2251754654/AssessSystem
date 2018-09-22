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
    public class RepositoryTeachSkills : IRepositoryTeachSkills
    {
        private readonly DBContext dbContext = new DBContext();

        /// <summary>
        /// 根据技能ID查询技能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ModelTechSkills FindTechSkill(int id)
        {
            var teachSkill = dbContext.TB_TechSkills.Find(id);
            var modelTeachSkill = new ModelTechSkills();
            if (UtilClass.Convert(teachSkill, modelTeachSkill))
            {
                return modelTeachSkill;
            }
            return null;
        }
        /// <summary>
        /// 查询所有技能
        /// </summary>
        /// <returns></returns>
        public List<ModelTechSkills> FindAllTechSkill()
        {
            var teachSkillList = dbContext.TB_TechSkills.ToList();
            var modelteachSkillList = new List<ModelTechSkills>();
            if (teachSkillList != null)
            {
                foreach (var teachSkillListItem in teachSkillList)
                {
                    var modelteachSkillListItem = new ModelTechSkills();
                    UtilClass.Convert(teachSkillListItem, modelteachSkillListItem);
                    modelteachSkillList.Add(modelteachSkillListItem);
                }
                return modelteachSkillList;
            }
            return null;
        }
        /// <summary>
        /// 查询所有删除的技能
        /// </summary>
        /// <returns></returns>
        public List<ModelTechSkills> FindAllDeleteTechSkill()
        {
            var teachSkillList = dbContext.TB_TechSkills.Where(o=>o.TeachSkillDelete == 0).ToList();
            var modelteachSkillList = new List<ModelTechSkills>();
            if (teachSkillList != null)
            {
                foreach (var teachSkillListItem in teachSkillList)
                {
                    var modelteachSkillListItem = new ModelTechSkills();
                    UtilClass.Convert(teachSkillListItem, modelteachSkillListItem);
                    modelteachSkillList.Add(modelteachSkillListItem);
                }
                return modelteachSkillList;
            }
            return null;
        }
        /// <summary>
        /// 查询所有未删除的技能
        /// </summary>
        /// <returns></returns>
        public List<ModelTechSkills> FindAllNotDeleteTechSkill()
        {
            var teachSkillList = dbContext.TB_TechSkills.Where(o => o.TeachSkillDelete == 1).ToList();
            var modelteachSkillList = new List<ModelTechSkills>();
            if (teachSkillList != null)
            {
                foreach (var teachSkillListItem in teachSkillList)
                {
                    var modelteachSkillListItem = new ModelTechSkills();
                    UtilClass.Convert(teachSkillListItem, modelteachSkillListItem);
                    modelteachSkillList.Add(modelteachSkillListItem);
                }
                return modelteachSkillList;
            }
            return null;
        }
        /// <summary>
        /// 插入技能
        /// </summary>
        /// <param name="modelCoreSkills"></param>
        /// <returns></returns>
        public bool Insert(ModelTechSkills modelTechSkills)
        {
            var teachSkills = new TB_TechSkills();
            UtilClass.Convert(modelTechSkills, teachSkills);
            dbContext.TB_TechSkills.Add(teachSkills);
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
        public bool Update(ModelTechSkills modelTechSkills)
        {
            var techSkills = dbContext.TB_TechSkills.Find(modelTechSkills.TeachSkillsID);
            if (techSkills != null)
            {
                UtilClass.Convert(modelTechSkills, techSkills);
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

            var result = dbContext.TB_TechSkills.Include("TB_MappingTeach").Include("TB_TeachLever").Where(o => o.TeachSkillsID == id).FirstOrDefault();
            if (result != null)
            {
                if (result.TB_MappingTeach != null)
                {
                    dbContext.TB_MappingTeach.RemoveRange(result.TB_MappingTeach);
                }
                if (result.TB_TeachLever != null)
                {
                    dbContext.TB_TeachLever.RemoveRange(result.TB_TeachLever);
                }
                dbContext.TB_TechSkills.Remove(result);
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
            var result = dbContext.TB_TechSkills.Include("TB_TeachLever").Where(o => o.TeachSkillsID == id).FirstOrDefault();
            if (result != null)
            {
                if (result.TB_TeachLever != null)
                {
                    foreach (var item in result.TB_TeachLever)
                    {
                        item.TeachLeverDelete = 0;
                    }
                }
                result.TeachSkillDelete = 0;
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
        /// 查询某个职业下的专业技能
        /// </summary>
        /// <param name="professionalID"></param>
        /// <returns></returns>
        public List<ModelTechSkills> FindTeachSkillsByProfessionalID(int professionalID)
        {
            var mappingTeach = dbContext.TB_MappingTeach.Include("TB_TechSkills").Where(o => o.ProfessionalID == professionalID).ToList();
            var modelTeachList = new List<ModelTechSkills>();
            foreach (var item in mappingTeach)
            {
                var modelTeach = new ModelTechSkills();
                UtilClass.Convert(item.TB_TechSkills,modelTeach);
                modelTeachList.Add(modelTeach);
            }
            return modelTeachList;
        }
    }
}
