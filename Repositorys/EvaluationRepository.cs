using System;
using System.Linq;
using Repositorys.DataAccess;
using Models;
namespace Repositorys
{
    public class EvaluationRepository
    {
        public dynamic GetEvaluationByID(int evaluationID)
        {
            //查询表Evaluation
            DB_StaffEvaluationEntities dB_StaffEvaluationEntities = new DB_StaffEvaluationEntities();
            var query = from evaluation in dB_StaffEvaluationEntities.TB_Evaluation
                        join userinfoMain in dB_StaffEvaluationEntities.TB_UserInfo on evaluation.UserIDMain equals userinfoMain.UserInfoID
                        join userinfoBy   in dB_StaffEvaluationEntities.TB_UserInfo on evaluation.UserIDBy equals userinfoBy.UserInfoID
                        where evaluationID == 0 ? true : evaluationID == evaluation.EvaluationID
                        select new 
                        {
                             EvaluationID = evaluation.EvaluationID,//评论ID
                              EvaluationDetails = evaluation.EvaluationDetails,//评论摘要
                               UserIDByName = userinfoBy.UserInfoName,//被评价人
                               UserIDMainName = userinfoBy.UserInfoName//评价人
                        };
            return query;
        }
    }
}