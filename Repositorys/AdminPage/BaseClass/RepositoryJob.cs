using Models;
using ProjectUtils;
using Repositorys.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class RepositoryJob : IRepositoryJob
    {
        private readonly DBContext dbContext = new DBContext();

        /// <summary>
        /// 根据职业ID查询职业
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ModelProfessional FindJob(int id)
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
        public List<ModelProfessional> FindAllDeleteJob()
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
        public List<ModelProfessional> FindAllNotDeleteJob()
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

            var result = dbContext.TB_Professional.Include("TB_RoleContent").Include("TB_MappingCore").Include("TB_MappingTeach").Where(o => o.ProfessionalID == id).FirstOrDefault();
            if (result != null)
            {
                if (result.TB_RoleContent != null)
                {
                    dbContext.TB_RoleContent.RemoveRange(result.TB_RoleContent);
                    dbContext.TB_MappingCore.RemoveRange(result.TB_MappingCore);
                    dbContext.TB_MappingTeach.RemoveRange(result.TB_MappingTeach);
                }
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
        /// <summary>
        /// 查看角色对应的职业
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public List<ModelProfessional> AllotedProfessional(int roleID)
        {
            var professList = dbContext.TB_RoleContent.Include("TB_Professional").Where(o => o.RoleID == roleID).ToList();
            var professModelList = new List<ModelProfessional>();
            foreach (var item in professList)
            {
                var modelItem = new ModelProfessional();
                UtilClass.Convert(item.TB_Professional, modelItem);
                professModelList.Add(modelItem);
            }
            return professModelList;
           
        }
    }
}
