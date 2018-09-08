using Repositorys;
using System;

namespace Domains
{
    public class OtherEvaluationDomain
    {
        public dynamic GetOtherEvaluation(int userInfoID)
        {
            OtherEvaluationRepositroy otherEvaluationRepositroy = new OtherEvaluationRepositroy();
            return otherEvaluationRepositroy.GetOtherEvaluation(userInfoID);
        }
    }
}