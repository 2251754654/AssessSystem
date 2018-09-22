using System.Collections.Generic;
using Models;

namespace Domains
{
    public interface IDomainOneselfAssess
    {
        List<ModelAssessDetails> FindOneselfAssessToOneself(int userID);
        List<ModelAssessDetails> FindOneselfAssessToOneselfDetails(int assessID);
        List<ModelAssessDetails> FindOneselfAssessToOthers(int userID);
    }
}