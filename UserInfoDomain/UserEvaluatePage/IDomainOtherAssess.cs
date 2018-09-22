using System.Collections.Generic;
using Models;

namespace Domains
{
    public interface IDomainOtherAssess
    {
        List<ModelAssessDetails> FindAllAssess();
        List<ModelAssessDetails> FindAllDeleteAssess();
        List<ModelAssessDetails> FindAllNotDeleteAssess();
        List<ModelAssessDetails> FindCoreSkillAssessDetails(int assessID);
        List<ModelAssessDetails> FindOtherAssessToOneself(int userID);
        List<ModelAssessDetails> FindTeachSkillAssessDetails(int assessID);
    }
}