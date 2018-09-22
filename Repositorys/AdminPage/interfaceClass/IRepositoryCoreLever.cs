using System.Collections.Generic;
using Models;

namespace Repositorys
{
    public interface IRepositoryCoreLever
    {
        bool FakeDeleteAll(int id);
        bool FakeDeleteOne(int id);
        List<ModelCoreLever> FindCoreSkillLever(int id);
        ModelCoreLever FindCoreSkillLever(int coreSkillID, int CoreSkillLeverID);
        bool Insert(ModelCoreLever modelCoreLever);
        bool ReallyDeleteAll(int id);
        bool ReallyDeleteOne(int id);
        bool Update(ModelCoreLever modelCoreLever);
    }
}