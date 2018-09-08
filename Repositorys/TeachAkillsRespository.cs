using Repositorys.DataAccess;
using System;
using System.Linq;

namespace Repositorys
{
    public class TeachAkillsRespository
    {
        public TeachAkillsRespository()
        {
        }

        public dynamic GetTeachSkillsByUserInfoID(int userInfoID)
        {
            DB_StaffEvaluationEntities dB_StaffEvaluationEntities = new DB_StaffEvaluationEntities();
            var query = from userinfo in dB_StaffEvaluationEntities.TB_UserInfo
                            //查询谁被评价了
                        join evaluation in dB_StaffEvaluationEntities.TB_Evaluation on userinfo.UserInfoID equals evaluation.UserIDBy
                        //查询评价具体信息
                        join evaluationInfo in dB_StaffEvaluationEntities.TB_EvaluationInfo on evaluation.EvaluationID equals evaluationInfo.EvaluationID
                        //查询评价的具体技能的名字
                        join teachSkill in dB_StaffEvaluationEntities.TB_TechSkills on evaluationInfo.SkillsGUID equals teachSkill.TeachAkillsGUID
                        //查询是谁评价的
                        join userinfoMain in dB_StaffEvaluationEntities.TB_UserInfo on evaluation.UserIDMain equals userinfoMain.UserInfoID
                        //技能对应的等级描述
                        join terachSkillsLever in dB_StaffEvaluationEntities.TB_TeachLever on teachSkill.TeachSkillsID equals terachSkillsLever.TeachSkillsID
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