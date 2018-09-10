using Repositorys.DataAccess;
using System;
using System.Linq;

namespace Repositorys
{
    public class TeachSkillsRespository
    {
        public TeachSkillsRespository()
        {
        }

        public dynamic GetTeachSkillsByUserInfoID(int userInfoID)
        {
            DBContext dbContext = new DBContext();
            var query = from userinfo in dbContext.TB_UserInfo
                            //查询谁被评价了
                        join evaluation in dbContext.TB_Evaluation on userinfo.UserInfoID equals evaluation.UserIDBy
                        //查询评价具体信息
                        join evaluationInfo in dbContext.TB_EvaluationInfo on evaluation.EvaluationID equals evaluationInfo.EvaluationID
                        //查询评价的具体技能的名字
                        join teachSkill in dbContext.TB_TechSkills on evaluationInfo.SkillsGUID equals teachSkill.TeachAkillsGUID
                        //查询是谁评价的
                        join userinfoMain in dbContext.TB_UserInfo on evaluation.UserIDMain equals userinfoMain.UserInfoID
                        //技能对应的等级描述
                        join terachSkillsLever in dbContext.TB_TeachLever on teachSkill.TeachSkillsID equals terachSkillsLever.TeachSkillsID
                        where userinfo.UserInfoID == userInfoID && terachSkillsLever.TeachLeverNum == evaluationInfo.Lever

                        select new
                        {
                            UserInfoMain = userinfoMain.UserInfoName,
                            UserInfoBy = userinfo.UserInfoName,
                            TeachSkillsName = teachSkill.TeachSkillsName,
                            CoreSkillsGUID = evaluationInfo.SkillsGUID,
                            CoreSkillsLever = evaluationInfo.Lever,
                            TeachLeverDetails = terachSkillsLever.TeachLeverDetails,
                        };
            return query;
        }
    }
}