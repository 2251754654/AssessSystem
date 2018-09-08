using Repositorys;
using System;

namespace Domains
{
    public class EvaluationDomain
    {
        public dynamic GetAllEvaluation()
        {
            EvaluationRepository evaluationRepository = new EvaluationRepository();
            return evaluationRepository.GetEvaluationByID(0);
        }
        public dynamic GetEvaluationByID(int evaluationID)
        {
            EvaluationRepository evaluationRepository = new EvaluationRepository();
            return evaluationRepository.GetEvaluationByID(evaluationID);
        }
    }
}