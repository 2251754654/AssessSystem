using System.Collections.Generic;
using Models;

namespace Repositorys
{
    public interface IRepositoryTeachSkills
    {
        bool FakeDelete(int id);
        List<ModelTechSkills> FindAllDeleteTechSkill();
        List<ModelTechSkills> FindAllNotDeleteTechSkill();
        List<ModelTechSkills> FindAllTechSkill();
        ModelTechSkills FindTechSkill(int id);
        bool Insert(ModelTechSkills modelTechSkills);
        bool ReallyDelete(int id);
        bool Update(ModelTechSkills modelTechSkills);
        List<ModelTechSkills> FindTeachSkillsByProfessionalID(int professionalID);
    }
}