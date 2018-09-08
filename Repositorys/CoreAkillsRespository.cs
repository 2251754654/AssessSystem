using System;
using System.Linq;
using Models;
using Repositorys.DataAccess;

namespace Repositorys
{
    public class CoreAkillsRespository
    {
        public CoreAkillsRespository()
        {
        }

        public dynamic GetGetCoreSkillsByUserInfoID(int userInfoID)
        {
            DB_StaffEvaluationEntities dB_StaffEvaluationEntities = new DB_StaffEvaluationEntities();
            var query = from userinfo in dB_StaffEvaluationEntities.TB_UserInfo
                        //查询谁被评价了
                        join evaluation in dB_StaffEvaluationEntities.TB_Evaluation on userinfo.UserInfoID equals evaluation.UserIDBy
                        //查询评价具体信息
                        join evaluationInfo in dB_StaffEvaluationEntities.TB_EvaluationInfo on evaluation.EvaluationID equals evaluationInfo.EvaluationID
                        //查询评价的具体技能的名字
                        join coreSkill in dB_StaffEvaluationEntities.TB_CoreSkills on evaluationInfo.SkillsGUID equals coreSkill.CoreSkillsGUID
                        //查询是谁评价的
                        join userinfoMain in dB_StaffEvaluationEntities.TB_UserInfo on evaluation.UserIDMain equals userinfoMain.UserInfoID
                        //技能对应的等级描述
                        join coreSkillsLever in dB_StaffEvaluationEntities.TB_CoreLever on coreSkill.CoreSkillsID equals coreSkillsLever.CoreSkillsID
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

        public static void Main(String [] args)
        {
            foreach (var v in new CoreAkillsRespository().GetGetCoreSkillsByUserInfoID(8))
            {
                Console.WriteLine(v+"输出");
            }
            Console.ReadKey();
        }
    }
}