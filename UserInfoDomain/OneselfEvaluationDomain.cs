using Repositorys;
using System;

namespace Domains
{
    public class OneselfEvaluationDomain
    {
        public dynamic GetOneselfEvaluation(int userInfoID)
        {
            OneselfEvaluationRepositroy oneselfEvaluationRepositroy = new OneselfEvaluationRepositroy();
            return oneselfEvaluationRepositroy.GetOneselfEvaluation(userInfoID);
        }
    }
}