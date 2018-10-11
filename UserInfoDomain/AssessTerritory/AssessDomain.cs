using Infrastructure.Dto;
using Infrastructure.DtoExtension;
using Infrastructure.EntityExtension;
using Infrastructure.Exception;
using Repositorys.DataAccess;
using Repositorys.DataAccess.AssessModule;
using Repositorys.DataAccess.Context;
using Repositorys.Repositroy.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserInfoDomain;

namespace Domains.AssessTerritory
{
    //实现评论
    public class AssessDomain : IAssessDomain
    {
        private readonly IAssessRepositroy assessRepositroy = UnityConfig.Container.Resolve(typeof(IAssessRepositroy), null) as IAssessRepositroy;
        private readonly IUserRepositroy   userRepositroy = UnityConfig.Container.Resolve(typeof(IUserRepositroy), null) as IUserRepositroy;
        private readonly IAssessInfoRepositroy  assessInfoRepositroy = UnityConfig.Container.Resolve(typeof(IAssessInfoRepositroy), null) as IAssessInfoRepositroy;

        void IAssessDomain.InitDbContext(DBContext dBContext)
        {
            assessRepositroy.InitDbContext(dBContext);
            userRepositroy.InitDbContext(dBContext);
            assessInfoRepositroy.InitDbContext(dBContext);
        }

        public void Delete(Guid assessGuid,int deleteTag = 0)
        {
            if (assessGuid != null)
            {
                if (deleteTag == 0)
                {
                    assessRepositroy.FakeDelete(assessGuid);
                }
                if (deleteTag == 1)
                {
                    assessRepositroy.Delete(assessGuid);
                }
                throw new Exception("<public void Delete(Guid assessGuid)> hava tag error !");
            }
            throw new Exception("<public void Delete(Guid assessGuid)> hava null !");
        }
        //返回查询的评论
        public IEnumerable<AssessDto> Get(Expression<Func<Assess, bool>> filter = null, Func<IQueryable<Assess>, IOrderedQueryable<Assess>> orderBy = null)
        {
            //查出所有评论
            var assessList = assessRepositroy.Get(filter, orderBy,null);
            var assessDtoList = new List<AssessDto>();
            if (assessList != null)
            {
                foreach (var assessItem in assessList)
                {
                    //查出评论人
                    var assessUser = userRepositroy.Get(o => o.Guid == assessItem.AssessUserGuid, null, "UserInfo").FirstOrDefault(); ;
                    //查出被评论人
                    var byAssessUser = userRepositroy.Get(o => o.Guid == assessItem.ByAssessUserGuid, null, "UserInfo").FirstOrDefault();

                    assessDtoList.Add(new AssessDto().ToDto(assessItem, assessUser, byAssessUser));
                }
                return assessDtoList.AsEnumerable();
            }
            return null;
        }
        //返回某一条的评论
        public IEnumerable<AssessInfoDto> GetByID(Guid assessGuid, Expression<Func<AssessInfo, bool>> filter = null)
        {
            //查出评论项目列表
            var assessInfoList = assessInfoRepositroy.Get(o => o.AssessGuid == assessGuid);
          
            if (filter != null)
            {
                assessInfoList = assessInfoList.AsQueryable().Where(filter);
            }
            var assessInfoDtoList = new List<AssessInfoDto>();
            foreach (var item in assessInfoList)
            {
                assessInfoDtoList.Add(item.ToDto());
            }
            return assessInfoDtoList;
        }

        public void Insert(Assess assess)
        {
            if (assess == null || assess.AssessInfos == null)
            {
                throw new EntityIsNullException("assess is null");
            }
            assessRepositroy.Insert(assess.ToInsertEntity());
        }
        public void Save()
        {
            assessRepositroy.Save();
        }
    }
}
