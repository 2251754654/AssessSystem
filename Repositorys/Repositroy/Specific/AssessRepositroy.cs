using Repositorys.DataAccess;
using Repositorys.DataAccess.AssessModule;
using Repositorys.DataAccess.Context;
using Repositorys.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys.Repositroy.Specific
{
    public class AssessRepositroy : GenericRepository<Assess>, IAssessRepositroy
    {
        /// <summary>
        /// 先删除子表数据在删除此数据
        /// </summary>
        /// <param name="guid"></param>
        public override void Delete(Guid assesssGuid)
            
        {
            var db = base.Context;
            var assessInfoList = db.AssessInfo.Where(o => o.AssessGuid == assesssGuid).ToList();
            if (assessInfoList != null)
            {
                db.AssessInfo.RemoveRange(assessInfoList);
            }
            var assess = db.Assess.Find(assesssGuid);
            if (assess != null)
            {
                db.Assess.Remove(assess);
            }
        }

        public void FakeDelete(Guid assessGuid)
        {
            var db = this.Context;
            var assess = db.Assess.Find(assessGuid);
            if (assess != null)
            {
                assess.State = 1;
                return;
            }
        }

        public void FakeDeleteSSSS(Guid assessGuid)
        {
            var db = this.Context;
            var assess = db.Assess.Find(assessGuid);
            if (assess != null)
            {
                assess.State = 1;
                return;
            }
        }
    }
}
