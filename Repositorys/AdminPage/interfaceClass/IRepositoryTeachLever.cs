using System.Collections.Generic;
using Models;

namespace Repositorys
{
    public interface IRepositoryTeachLever
    {
        bool FakeDeleteAll(int id);
        bool FakeDeleteOne(int id);
        List<ModelTeachLever> FindTechSkillLever(int id);
        ModelTeachLever FindTechSkillLever(int teachSkillID, int teachSkillLeverID);
        bool Insert(ModelTeachLever modelTeachLever);
        bool ReallyDeleteAll(int id);
        bool ReallyDeleteOne(int id);
        bool Update(ModelTeachLever modelTeachLever);
    }
}