using Models;
using ProjectUtilsns;
using Repositorys.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys.HomePage
{
    public class RepositoryJob
    {
        private readonly DBContext dbContext = new DBContext();

        /// <summary>
        /// 根据职业ID查询职业
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ModelProfessional FindJoib(int id)
        {
            var job = dbContext.TB_Professional.Find(id);
            var modelJoib = new ModelProfessional();
            if (UtilClass.Convert(job, modelJoib))
            {
                return modelJoib;
            }
            return null;
        }
        /// <summary>
        /// 查询所有职业
        /// </summary>
        /// <returns></returns>
        public List<ModelProfessional> FindAllJob()
        {
            var jobList = dbContext.TB_Professional.ToList();
            var modelJoibList = new List<ModelProfessional>();
            if (jobList != null)
            {
                foreach (var jobListItem in jobList)
                {
                    var modelJoibListItem = new ModelProfessional();
                    UtilClass.Convert(jobListItem, modelJoibListItem);
                    modelJoibList.Add(modelJoibListItem);
                }
                return modelJoibList;
            }
            return null;
        }
        /// <summary>
        /// 查询所有删除的用户
        /// </summary>
        /// <param name="evaluationID"></param>
        /// <returns></returns>
        public List<ModelProfessional> FindAllDeleteJoib()
        {
            var jobList = dbContext.TB_Professional.Where(o => o.ProfessionalDelete == 0).ToList();
            var modelJoibList = new List<ModelProfessional>();
            if (jobList != null)
            {
                foreach (var jobListItem in jobList)
                {
                    var modelJoibListItem = new ModelProfessional();
                    UtilClass.Convert(jobListItem, modelJoibListItem);
                    modelJoibList.Add(modelJoibListItem);
                }
                return modelJoibList;
            }
            return null;
        }
        /// <summary>
        /// 查询所有未删除的用户
        /// </summary>
        /// <param name="evaluationID"></param>
        /// <returns></returns>
        public List<ModelProfessional> FindAllNotDeleteJoib()
        {
            var jobList = dbContext.TB_Professional.Where(o => o.ProfessionalDelete == 1).ToList();
            var modelJoibList = new List<ModelProfessional>();
            if (jobList != null)
            {
                foreach (var jobListItem in jobList)
                {
                    var modelJoibListItem = new ModelProfessional();
                    UtilClass.Convert(jobListItem, modelJoibListItem);
                    modelJoibList.Add(modelJoibListItem);
                }
                return modelJoibList;
            }
            return null;
        }
        /// <summary>
        /// 插入职业
        /// </summary>
        /// <param name="modelRole"></param>
        /// <returns></returns>
        public bool Insert(ModelProfessional  modelProfessional)
        {
            var job = new TB_Professional();
            UtilClass.Convert(modelProfessional, job);
            dbContext.TB_Professional.Add(job);
            if (dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 更新职业(上层必须确保字段确实更新了，没更新则为false)
        /// </summary>
        /// <param name="modelRole"></param>
        /// <returns></returns>
        public bool Update(ModelProfessional  modelProfessional)
        {
            var job = dbContext.TB_Professional.Find(modelProfessional.ProfessionalID);
            if (job != null)
            {
                UtilClass.Convert(modelProfessional, job);
                if (dbContext.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        /// <summary>
        /// 物理删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ReallyDelete(int id)
        {

            var result = dbContext.TB_Professional.Include("TB_RoleContent").Where(o => o.ProfessionalID == id).FirstOrDefault();
            if (result != null)
            {
                dbContext.TB_Professional.Remove(result);
                if (dbContext.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
        /// <summary>
        /// 逻辑删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FakeDelete(int id)
        {
            var result = dbContext.TB_Professional.Find(id);
            if (result != null)
            {
                result.ProfessionalDelete = 0;
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
