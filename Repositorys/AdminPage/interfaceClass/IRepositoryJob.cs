using System.Collections.Generic;
using Models;

namespace Repositorys
{
    public interface IRepositoryJob
    {
        bool FakeDelete(int id);
        List<ModelProfessional> FindAllDeleteJob();
        List<ModelProfessional> FindAllJob();
        List<ModelProfessional> FindAllNotDeleteJob();
        ModelProfessional FindJob(int id);
        bool Insert(ModelProfessional modelProfessional);
        bool ReallyDelete(int id);
        bool Update(ModelProfessional modelProfessional);
        List<ModelProfessional> AllotedProfessional(int roleID);
    }
}