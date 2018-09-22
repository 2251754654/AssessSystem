using System.Collections.Generic;
using Models;

namespace Repositorys
{
    public interface IRepositroyAssess
    {
        bool FakeDelete(int id);
        List<ModelAssessDetails> FindAllAssess();
        List<ModelAssessDetails> FindAllDeleteAssess();
        List<ModelAssessDetails> FindAllNotDeleteAssess();
        List<ModelAssessDetails> FindAssessCoreDetails(int id);
        List<ModelAssessDetails> FindAssessTeachDetails(int id);
        List<ModelAssessDetails> FindByAssess(int id);
        List<ModelAssessDetails> FindMainAssess(int id);
        bool Insert(ModelEvaluation assess);
        bool ReallyDelete(int id);
        bool Update(ModelEvaluation assess);
        List<ModelAssessDetails> FindMainAssessToOneself(int userID);
    }
}