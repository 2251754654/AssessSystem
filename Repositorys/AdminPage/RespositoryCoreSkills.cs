using System;
using System.Linq;
using Models;
using Repositorys.DataAccess;

namespace Repositorys
{
    public class RespositoryCoreSkills
    {
        public RespositoryCoreSkills()
        {
        }

        public dynamic GetGetCoreSkillsByUserInfoID(int userInfoID)
        {
            DBContext dbContext = new DBContext();
            var query = from userinfo in dbContext.TB_UserInfo
                        //查询谁被评价了
                        join evaluation in dbContext.TB_Evaluation on userinfo.UserInfoID equals evaluation.UserIDBy
                        //查询评价具体信息
                        join evaluationInfo in dbContext.TB_EvaluationInfo on evaluation.EvaluationID equals evaluationInfo.EvaluationID
                        //查询评价的具体技能的名字
                        join coreSkill in dbContext.TB_CoreSkills on evaluationInfo.SkillsGUID equals coreSkill.CoreSkillsGUID
                        //查询是谁评价的
                        join userinfoMain in dbContext.TB_UserInfo on evaluation.UserIDMain equals userinfoMain.UserInfoID
                        //技能对应的等级描述
                        join coreSkillsLever in dbContext.TB_CoreLever on coreSkill.CoreSkillsID equals coreSkillsLever.CoreSkillsID
                        where userinfo.UserInfoID == userInfoID && coreSkillsLever.CoreLeverNum == evaluationInfo.Lever

                        select new
                        {
                            UserInfoMain = userinfoMain.UserInfoName,
                            UserInfoBy =  userinfo.UserInfoName,
                            CoreSkillsName = coreSkill.CoreSkillsName,
                            CoreSkillsGUID = evaluationInfo.SkillsGUID,
                            CoreSkillsLever = evaluationInfo.Lever,
                            CoreLeverDetails = coreSkillsLever.CoreLeverDetails,
                        };
            return query;
        }
    }
}