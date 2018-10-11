using Infrastructure.DtoExtension;
using Infrastructure.EntityExtension;
using Infrastructure.Exception;
using Repositorys.DataAccess.Context;
using Repositorys.DataAccess.MappingModule;
using Repositorys.DataAccess.ProfessModule;
using Repositorys.DataAccess.UserModule;
using Repositorys.Repositroy.Specific;
using Repositorys.Repositroy.Specific.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UserInfoDomain.ProfessTerritory
{
    /// <summary>
    /// 此类关于职业，核心，专业技能的管理
    /// </summary>
    public class ProfessDomain : IProfessDomain
    {
        private DBContext dbContext;
        private readonly IProfessRepositroy professRepositroy = UnityConfig.Container.Resolve(typeof(IProfessRepositroy),null) as IProfessRepositroy;
        private readonly IProfess_CoreSkillRepositroy  profess_CoreSkillRepositroy = UnityConfig.Container.Resolve(typeof(IProfess_CoreSkillRepositroy), null) as IProfess_CoreSkillRepositroy;
        private readonly IProfess_TeachSkillRepositroy  profess_TeachSkillRepositroy = UnityConfig.Container.Resolve(typeof(IProfess_TeachSkillRepositroy), null) as IProfess_TeachSkillRepositroy;

        public void InitDbContext(DBContext dBContext)
        {
            professRepositroy.InitDbContext(dBContext);
            profess_CoreSkillRepositroy.InitDbContext(dBContext);
            profess_TeachSkillRepositroy.InitDbContext(dBContext);
            dbContext = dBContext;
        }
        
        public List<ProfessDto> Get(Expression<Func<Profess, bool>> filter = null, Func<IQueryable<Profess>, IOrderedQueryable<Profess>> orderBy = null)
        {
            var professList = professRepositroy.Get(filter, orderBy).ToList();
           
            if (professList != null)
            {
                var professDtoList = new List<ProfessDto>();
                foreach (var professListItem in professList)
                {
                    professDtoList.Add(professListItem.ToDto());
                }
                return professDtoList;
            }
            return null;
        }
  
        public void Insert(Profess profess)
        {
            if (profess == null)
            {
                throw new EntityIsNullException("<public void Insert(ProfessDto professDto)>  hava null !");
            }
            profess.ToInsertEntity();
            if (professRepositroy.Get(o=>o.ProfessName == profess.ProfessName).FirstOrDefault() != null)
            {
                throw new EntityRepeatException("< public void Insert(ProfessDto professDto)> professName not repeat !");
            }
            professRepositroy.Insert(profess);
            return;
        }
        
        public void Update(Profess profess)
        {
            if (profess == null)
            {
                throw new EntityIsNullException("<public void Update(ProfessDto professDto)> have null !");
            }
            var oldProfess = professRepositroy.GetByID(profess.Guid);
            if (oldProfess == null)
            {
                throw new EntityIsNullException("<public void Update(ProfessDto professDto)> have null !");
            }
            oldProfess.ToUpdateEntity(profess);
            if (professRepositroy.Get(o => o.ProfessName == profess.ProfessName) == null)
            {
                throw new EntityRepeatException("<  public void Update(ProfessDto professDto) professName not repeat !");
            }
            professRepositroy.Update(oldProfess);
            return;
        }
        
        public void FakeDelete(Guid professGuid)
        {
            if (professGuid == null)
            {
                throw new EntityIsNullException("<  public void FakeDelete(Guid professGuid)> professGuid is null !");
            }
            var profess = professRepositroy.GetByID(professGuid);
            if (profess != null)
            {
                if (profess.State == 1)
                {
                    profess.State = 0;
                }
                else
                {
                    profess.State = 1;
                }
                
                professRepositroy.Update(profess);
            }
        }

        public void RealDelete(Guid professGuid)
        {
            if (professGuid == null)
            {
                throw new EntityIsNullException("<  public void RealDelete(Guid professGuid)> professGuid is null !");
            }
            var role_Professepositroy = UnityConfig.Container.Resolve(typeof(IRole_ProfessRepositroy), null) as IRole_ProfessRepositroy;
            role_Professepositroy.InitDbContext(dbContext);
            var role_profess = role_Professepositroy.Get(o=>o.ProfessGuid == professGuid).ToList();
            var profess_Core=profess_CoreSkillRepositroy. Get(o => o.ProfessGuid == professGuid).ToList();
            var profess_Teach = profess_TeachSkillRepositroy.Get(o => o.ProfessGuid == professGuid).ToList();
            role_Professepositroy.Delete(role_profess);
            profess_CoreSkillRepositroy.Delete(profess_Core);
            profess_TeachSkillRepositroy.Delete(profess_Teach);
            professRepositroy.Delete(professGuid);
        }

       

        /// <summary>
        /// 查询已分配的核心技能
        /// </summary>
        /// <param name="professGuid"></param>
        /// <returns></returns>
        public List<CoreSkillDto> GetCoreSkillByProfessGuid(Guid professGuid)
        {
            var profess_CoreSkillList = profess_CoreSkillRepositroy.Get(o => o.ProfessGuid == professGuid, null, "CoreSkill");
            if (profess_CoreSkillList != null)
            {
                var coreSkillDtoList = new List<CoreSkillDto>();
                foreach (var item in profess_CoreSkillList)
                {
                    coreSkillDtoList.Add(item.CoreSkill.ToDto());
                }
                return coreSkillDtoList;
            }
            return null;
        }
        /// <summary>
        /// 分配核心技能，不能重复分配
        /// </summary>
        /// <param name="professGuid"></param>
        /// <param name="coreSkillGuid"></param>
        public void SetCoreSkillToProfessGuid(Guid professGuid,Guid coreSkillGuid)
        {
            if (professGuid == null || coreSkillGuid == null)
            {
                throw new EntityIsNullException("< public void SetCoreSkillToProfessGuid(Guid professGuid,Guid coreSkillGuid)> hava null !");
            }
            if (profess_CoreSkillRepositroy.Get(o=>o.ProfessGuid == professGuid && o.CoreSkillGuid == coreSkillGuid).FirstOrDefault() != null)
            {
                throw new EntityRepeatException("< public void SetCoreSkillToProfessGuid(Guid professGuid,Guid coreSkillGuid)> is repeat !");
            }
            var profess_CoreSkill = new Profess_CoreSkill();
            profess_CoreSkill.Guid = Guid.NewGuid();
            profess_CoreSkill.ProfessGuid = professGuid;
            profess_CoreSkill.CoreSkillGuid = coreSkillGuid;
            profess_CoreSkillRepositroy.Insert(profess_CoreSkill);
        }

        /// <summary>
        /// 删除职业下的某个核心技能
        /// </summary>
        /// <param name="professGuid"></param>
        /// <param name="teachSkillGuid"></param>
        public void DeleteCoreSkillToProfess(Guid professGuid, Guid coreSkillGuid)
        {
            if (professGuid == null || coreSkillGuid == null)
            {
                throw new EntityIsNullException("<  public void DeleteCoreSkillToProfess(Guid professGuid, Guid coreSkillGuid)> hava null !");
            }
            var professCcoreSkill = profess_CoreSkillRepositroy.Get(o => o.ProfessGuid == professGuid && o.CoreSkillGuid == coreSkillGuid).FirstOrDefault();
            if (professCcoreSkill != null)
            {
                profess_CoreSkillRepositroy.Delete(professCcoreSkill);
            }
        }


        /// <summary>
        /// 查询已分配的专业技能
        /// </summary>
        /// <param name="professGuid"></param>
        /// <returns></returns>
        public List<TeachSkillDto> GetTeachSkillByProfessGuid(Guid professGuid)
        {
            var profess_TeachSkillList = profess_TeachSkillRepositroy.Get(o => o.ProfessGuid == professGuid, null, "TeachSkill");
            if (profess_TeachSkillList != null)
            {
                var teachSkillDtoList = new List<TeachSkillDto>();
                foreach (var item in profess_TeachSkillList)
                {
                    teachSkillDtoList.Add(item.TeachSkill.ToDto());
                }
                return teachSkillDtoList;
            }
            return null;
        }
        /// <summary>
        /// 分配专业技能，不能重复分配
        /// </summary>
        /// <param name="professGuid"></param>
        /// <param name="teachSkillGuid"></param>
        public void SetTeachSkillToProfessGuid(Guid professGuid, Guid teachSkillGuid)
        {
            if (professGuid == null || teachSkillGuid == null)
            {
                throw new EntityIsNullException("<  public void SetTeachSkillToProfessGuid(Guid professGuid, Guid teachSkillGuid)> hava null !");
            }
            if (profess_TeachSkillRepositroy.Get(o => o.ProfessGuid == professGuid && o.TeachSkillGuid == teachSkillGuid).FirstOrDefault() != null)
            {
                throw new EntityRepeatException("< public void SetTeachSkillToProfessGuid(Guid professGuid, Guid teachSkillGuid)> is repeat !");
            }
            var profess_TeachSkill = new Profess_TeachSkill();
            profess_TeachSkill.Guid = Guid.NewGuid();
            profess_TeachSkill.ProfessGuid = professGuid;
            profess_TeachSkill.TeachSkillGuid = teachSkillGuid;
            profess_TeachSkillRepositroy.Insert(profess_TeachSkill);
        }

        /// <summary>
        /// 删除职业下的某个专业技能
        /// </summary>
        /// <param name="professGuid"></param>
        /// <param name="teachSkillGuid"></param>
        public void DeleteTeachSkillToProfess(Guid professGuid, Guid teachSkillGuid)
        {
            if (professGuid == null || teachSkillGuid == null)
            {
                throw new EntityIsNullException("<  public void DeleteTeachSkillToProfess(Guid professGuid, Guid coreSkillGuid)> hava null !");
            }
            var professTeachSkill = profess_TeachSkillRepositroy.Get(o => o.ProfessGuid == professGuid && o.TeachSkillGuid == teachSkillGuid).FirstOrDefault();
            if (professTeachSkill != null)
            {
                profess_TeachSkillRepositroy.Delete(professTeachSkill);
            }
        }

        public void Save()
        {
            professRepositroy.Save();
        }
    }
}
