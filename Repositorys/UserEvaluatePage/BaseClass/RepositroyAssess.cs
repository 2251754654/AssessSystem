using System;
using System.Linq;
using System.Text;
using Repositorys.DataAccess;
using Models;
using System.Collections.Generic;
using ProjectUtils;

namespace Repositorys
{
    public class RepositroyAssess : IRepositroyAssess
    {
        private readonly DBContext dbContext = new DBContext();

        /// <summary>
        /// 查询所有的评价信息
        /// </summary>
        /// <returns></returns>
        public List<ModelAssessDetails> FindAllAssess()
        {
            var assessList = from assess in dbContext.TB_Evaluation
                             //join userby in dbContext.TB_User on assess.UserIDBy equals userby.UserID
                             //join usermain in dbContext.TB_User on assess.UserIDMain equals usermain.UserID
                             join userbyinfo in dbContext.TB_UserInfo on assess.UserIDBy equals userbyinfo.UserID
                             join usermaininfo in dbContext.TB_UserInfo on assess.UserIDMain equals usermaininfo.UserID
                             select new ModelAssessDetails()
                             {
                                 EvaluationID = assess.EvaluationID,
                                 ByAssess = userbyinfo.UserInfoName,
                                 MainAssess = usermaininfo.UserInfoName,
                                 EvaluationDetails = assess.EvaluationDetails,
                                 Delete = assess.Delete,
                                 UserIDBy = userbyinfo.UserID,
                                 UserIDMain = usermaininfo.UserID,
                             };
            return assessList.ToList();
        }
        /// <summary>
        /// 查询所有未删除的评价信息 1未删除
        /// </summary>
        /// <returns></returns>
        public List<ModelAssessDetails> FindAllNotDeleteAssess()
        {
            var notDelete = FindAllAssess().Where(o => o.Delete == 1);
            return notDelete.ToList();
        }
        /// <summary>
        /// 查询所有删除的评价信息 1未删除
        /// </summary>
        /// <returns></returns>
        public List<ModelAssessDetails> FindAllDeleteAssess()
        {
            var notDelete = FindAllAssess().Where(o => o.Delete == 0);
            return notDelete.ToList();
        }
        /// <summary>
        /// 当前用户作为被评估对象
        /// </summary>
        /// <param name="id">被评估人ID</param>
        /// <returns></returns>
        public List<ModelAssessDetails> FindByAssess(int id)
        {
            var assessList =  FindAllAssess().Where(o=>o.UserIDBy == id);
            return assessList.ToList();
        }
        /// <summary>
        /// 当前对象为他人评估
        /// </summary>
        /// <param name="id">评估人ID</param>
        /// <returns></returns>
        public List<ModelAssessDetails> FindMainAssess(int id)
        {
            
            var assessList = FindAllAssess().Where(o => o.UserIDMain == id);
            return assessList.ToList();
        }
        /// <summary>
        /// 当前对象为本身评估
        /// </summary>
        /// <param name="id">评估人ID</param>
        /// <returns></returns>
        public List<ModelAssessDetails> FindMainAssessToOneself(int id)
        {
            //筛选出自己对自己的评论ID
            var assessList = FindAllAssess().Where(o => o.UserIDMain == id && o.UserIDBy == id);
            return assessList.ToList();
        }
        /// <summary>
        /// 评估核心技能详细情况查询
        /// </summary>
        /// <param name="id">评论摘要ID</param>
        /// <returns></returns>
        public List<ModelAssessDetails> FindAssessCoreDetails(int id)
        {
            var assessList = from assess in dbContext.TB_EvaluationInfo
                             join coreSkill in dbContext.TB_CoreSkills on assess.SkillsGUID equals coreSkill.CoreSkillsGUID
                             join coreSkillLever in dbContext.TB_CoreLever on coreSkill.CoreSkillsID equals coreSkillLever.CoreSkillsID
                             where assess.EvaluationID == id && coreSkillLever.CoreLeverID == assess.Lever
                             select new ModelAssessDetails()
                             {
                                 EvaluationID = assess.EvaluationID,
                                 SkillsName = coreSkill.CoreSkillsName,
                                 SkillsDetails = coreSkill.CoreSkillsDetails,
                                 Lever = coreSkillLever.CoreLeverNum,
                                 SkillClasses = 0,
                                 CoreLeverID  = coreSkillLever.CoreLeverID,
                                 SkillLeverDetails = coreSkillLever.CoreLeverDetails
                             };
            return assessList.ToList();
        }
        /// <summary>
        /// 评估专业技能详细情况查询
        /// </summary>
        /// <param name="id">评论摘要ID</param>
        /// <returns></returns>
        public List<ModelAssessDetails> FindAssessTeachDetails(int id)
        {
            var assessList = from assess in dbContext.TB_EvaluationInfo
                             join teachSkill in dbContext.TB_TechSkills on assess.SkillsGUID equals teachSkill.TeachSkillsGUID
                             join teachSkillLever in dbContext.TB_TeachLever on teachSkill.TeachSkillsID equals teachSkillLever.TeachSkillsID
                             where assess.EvaluationID == id && teachSkillLever.TeachLeverID == assess.Lever
                             select new ModelAssessDetails()
                             {
                                 EvaluationID = assess.EvaluationID,
                                 SkillsName = teachSkill.TeachSkillsName,
                                 SkillsDetails = teachSkill.TeachSkillsDetails,
                                 Lever = teachSkillLever.TeachLeverNum,
                                 SkillClasses = 1,
                                 SkillLeverDetails = teachSkillLever.TeachLeverDetails,
                                 
                             };
            return assessList.ToList();
        }
        /// <summary>
        /// 插入一条评论
        /// </summary>
        /// <param name="assess"></param>
        /// <returns></returns>
        public bool Insert(ModelEvaluation assess)
        {
            var assessModel = new TB_Evaluation();
            var assessInfoList = new List<TB_EvaluationInfo>();
 
            foreach (var assessInfoItem in assess.ModelEvaluationInfoList)
            {
                var Item = new TB_EvaluationInfo();
                UtilClass.Convert(assessInfoItem, Item);
                assessInfoList.Add(Item);
            }
            UtilClass.Convert(assess, assessModel);
            assessModel.TB_EvaluationInfoList = assessInfoList;
            dbContext.TB_Evaluation.Add(assessModel);
            if (dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FakeDelete(int id)
        {
            var assess = dbContext.TB_Evaluation.Find(id);
            assess.Delete = 0;
            if (dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ReallyDelete(int id)
        {
            var assess = dbContext.TB_Evaluation.Include("TB_EvaluationInfoList").Where(o=>o.EvaluationID == id).FirstOrDefault();
            if (assess != null)
            {
                dbContext.TB_Evaluation.Remove(assess);
                if (dbContext.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
        /// <summary>
        ///更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Update(ModelEvaluation assess)
        {
            return false;
        }
    }
}