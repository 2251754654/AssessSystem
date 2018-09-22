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
    public class RepositoryTeachLever : IRepositoryTeachLever
    {
        private readonly DBContext dbContext = new DBContext();

        /// <summary>
        /// 查找指定ID所有技能等级
        /// </summary>
        /// <param name="id">技能ID</param>
        /// <returns></returns>
        public List<ModelTeachLever> FindTechSkillLever(int id)
        {
            var leverList = dbContext.TB_TeachLever.Where(o=>o.TeachSkillsID == id).ToList();
            var LeverModelList = new List<ModelTeachLever>();
            if (leverList != null)
            {
                foreach (var leverListItem in leverList)
                {
                    var LeverModelListItem = new ModelTeachLever();
                    UtilClass.Convert(leverListItem, LeverModelListItem);
                    LeverModelList.Add(LeverModelListItem);
                }
                return LeverModelList;
            }
            return null;
        }
        /// <summary>
        /// 查找指定技能等级ID的详细情况
        /// </summary>
        /// <param name="id">等级ID</param>
        /// <returns></returns>
        public ModelTeachLever FindTechSkillLever(int teachSkillID,int teachSkillLeverID)
        {
            return FindTechSkillLever(teachSkillID).Where(o=>o.TeachLeverID == teachSkillLeverID).FirstOrDefault();
        }
        /// <summary>
        /// 插入技能
        /// </summary>
        /// <param name="modelCoreSkills"></param>
        /// <returns></returns>
        public bool Insert(ModelTeachLever modelTeachLever)
        {
            var lever= new TB_TeachLever();
            UtilClass.Convert(modelTeachLever, lever);
            dbContext.TB_TeachLever.Add(lever);
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
        public bool Update(ModelTeachLever modelTeachLever)
        {
            var lever = new TB_TeachLever();
            UtilClass.Convert(modelTeachLever, lever);
            dbContext.TB_TeachLever.Add(lever);
            if (dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 物理删除技能，删除技能的所有等级
        /// </summary>
        /// <param name="id">技能ID</param>
        /// <returns></returns>
        public bool ReallyDeleteAll(int id)
        {

            var result = dbContext.TB_TeachLever.Where(o=>o.TeachSkillsID == id).ToList();
            if (result != null)
            {
                dbContext.TB_TeachLever.RemoveRange(result);
                if (dbContext.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
        /// <summary>
        /// 物理删除技能，删除技能的某一个等级
        /// </summary>
        /// <param name="id">技能等级ID</param>
        /// <returns></returns>
        public bool ReallyDeleteOne(int id)
        {

            var result = dbContext.TB_TeachLever.Where(o => o.TeachLeverID == id).FirstOrDefault();
            if (result != null)
            {
                dbContext.TB_TeachLever.Remove(result);
                if (dbContext.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
        /// <summary>
        /// 逻辑删除技能所有等级
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FakeDeleteAll(int id)
        {
            var result = dbContext.TB_TeachLever.Where(o=>o.TeachSkillsID == id).ToList();
            if (result != null)
            {
                foreach (var item in result)
                {
                    item.TeachLeverDelete = 0;
                }
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
        /// 逻辑删除技能某一个等级
        /// </summary>
        /// <param name="id">技能等级ID</param>
        /// <returns></returns>
        public bool FakeDeleteOne(int id)
        {
            var result = dbContext.TB_TeachLever.Find(id);
            if (result != null)
            {
                result.TeachLeverDelete = 0;
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
    }
}
