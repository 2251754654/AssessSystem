using Repositorys.DataAccess;
using Repositorys.DataAccess.AssessModule;
using Repositorys.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys.Repositroy.Specific
{
   public interface IAssessRepositroy : IGenericRepository<Assess>
    {
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="assessGuid"></param>
        void FakeDelete(Guid assessGuid);
    }
}
