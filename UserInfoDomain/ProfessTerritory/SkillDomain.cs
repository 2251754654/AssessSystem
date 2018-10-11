

using Infrastructure.DtoExtension;
using Infrastructure.EntityExtension;
using Infrastructure.Exception;
using Repositorys.DataAccess.Context;
using Repositorys.DataAccess.ProfessModule;
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
    public class SkillDomain : ISkillDomain
    {
        private DBContext dbContext;
        private readonly ICoreSkillRepositroy  coreSkillRepositroy = UnityConfig.Container.Resolve(typeof(ICoreSkillRepositroy), null) as ICoreSkillRepositroy;
        private readonly ITeachSkillRepositroy  teachSkillRepositroy  = UnityConfig.Container.Resolve(typeof(ITeachSkillRepositroy), null) as ITeachSkillRepositroy;

        private readonly ICoreLeverRepositroy  coreLeverRepositroy = UnityConfig.Container.Resolve(typeof(ICoreLeverRepositroy), null) as ICoreLeverRepositroy;
        private readonly ITeachLeverRepositroy   teachLeverRepositroy = UnityConfig.Container.Resolve(typeof(ITeachLeverRepositroy), null) as ITeachLeverRepositroy;

        public void InitDbContext(DBContext dBContext)
        {
            coreSkillRepositroy.InitDbContext(dBContext);
            teachSkillRepositroy.InitDbContext(dBContext);
            coreLeverRepositroy.InitDbContext(dBContext);
            teachLeverRepositroy.InitDbContext(dBContext);
            dbContext = dBContext;
        }

        public List<CoreSkillDto> GetCore(Expression<Func<CoreSkill, bool>> filter = null, Func<IQueryable<CoreSkill>,IOrderedQueryable<CoreSkill>> orderBy = null,string includeProp=null)
        {
            var coreSkillList = coreSkillRepositroy.Get(filter,orderBy, includeProp);

            if (coreSkillList != null)
            {
                var coreSkillDtoList = new List<CoreSkillDto>();
                foreach (var item in coreSkillList)
                {
                    coreSkillDtoList.Add(item.ToDto());
                }
                return coreSkillDtoList;
            }
            return null;
        }
        public List<TeachSkillDto> GetTeach(Expression<Func<TeachSkill, bool>> filter = null, Func<IQueryable<TeachSkill>, IOrderedQueryable<TeachSkill>> orderBy = null,string includeProp=null)
        {
            var teachSkillList = teachSkillRepositroy.Get(filter, orderBy,includeProp);

            if (teachSkillList != null)
            {
                var teachSkillDtoList = new List<TeachSkillDto>();
                foreach (var item in teachSkillList)
                {
                    teachSkillDtoList.Add(item.ToDto());
                }
                return teachSkillDtoList;
            }
            return null;
        }

        public void Insert(CoreSkill coreSkill)
        {
            if (coreSkill == null)
            {
                throw new EntityIsNullException("public void Insert(CoreSkill coreSkill) have null !");
            }
            if (coreSkillRepositroy.Get(o=>o.CoreSkillName == coreSkill.CoreSkillName).FirstOrDefault() != null)
            {
                throw new EntityRepeatException("entity repeat !");
            }
            coreSkillRepositroy.Insert(coreSkill.ToInsertEntity());
        }
        public void Insert(TeachSkill teachSkill)
        {
            if (teachSkill == null)
            {
                throw new EntityIsNullException("public void Insert(TeachSkill coreSkill) have null !");
            }
            if (teachSkillRepositroy.Get(o => o.TeachSkillName == teachSkill.TeachSkillName).FirstOrDefault() != null)
            {
                throw new EntityRepeatException("entity repeat !");
            }
            teachSkillRepositroy.Insert(teachSkill.ToInsertEntity());
        }

        public void Update(CoreSkill coreSkill)
        {
            if (coreSkill == null)
            {
                throw new EntityIsNullException(" public void Update(CoreSkill coreSkill) have null !");
            }
            var core = coreSkillRepositroy.GetByID(coreSkill.Guid);
            core.ToUpdateEntity(coreSkill);
            coreSkillRepositroy.Update(core);
        }
        public void Update(TeachSkill teachSkill)
        {
            if (teachSkill == null)
            {
                throw new EntityIsNullException(" public void Update(TeachSkill coreSkill) have null !");
            }
            var teach = teachSkillRepositroy.GetByID(teachSkill.Guid);
            teach.ToUpdateEntity(teachSkill);
            teachSkillRepositroy.Update(teach);
        }

        public void FakeDeleteToCore(Guid coreSkillGuid)
        {
            if (coreSkillGuid == null)
            {
                throw new EntityIsNullException("  public void FakeDelete(Guid coreSkillGuid) have null !");
            }
            var coreSkill = coreSkillRepositroy.GetByID(coreSkillGuid);
            if (coreSkill != null)
            {
                if (coreSkill.State == 1)
                {
                    coreSkill.State = 0;
                }
                else
                {
                    coreSkill.State = 1;
                }
               
                coreSkillRepositroy.Update(coreSkill);
            } 
        }
        public void FakeDeleteToTeach(Guid teachSkillGuid)
        {
            if (teachSkillGuid == null)
            {
                throw new EntityIsNullException("  public void FakeDelete(Guid TeachSkillGuid) have null !");
            }
            var teachSkill = teachSkillRepositroy.GetByID(teachSkillGuid);
            if (teachSkill != null)
            {
                if (teachSkill.State == 1)
                {
                    teachSkill.State = 0;
                }
                else
                {
                    teachSkill.State = 1;
                }
                teachSkillRepositroy.Update(teachSkill);
            }
        }

        public void RealDeleteToCore(Guid coreSkillGuid)
        {
            if (coreSkillGuid == null)
            {
                throw new EntityIsNullException(" public void RealDelete(Guid coreSkillGuid) have null !");
            }
            var profess_CoreSkillRepositroy = UnityConfig.Container.Resolve(typeof(IProfess_CoreSkillRepositroy), null) as IProfess_CoreSkillRepositroy;
            profess_CoreSkillRepositroy.InitDbContext(dbContext);
           var profess_Core =  profess_CoreSkillRepositroy.Get(o=>o.CoreSkillGuid == coreSkillGuid).ToList();
            var coreSkill = coreSkillRepositroy.Get(o=>o.Guid == coreSkillGuid).FirstOrDefault();
            var coreLever = coreLeverRepositroy.Get(o => o.CoreSkillGuid == coreSkillGuid).ToList();
            if (coreSkill != null)
            {
                profess_CoreSkillRepositroy.Delete(profess_Core);
                coreLeverRepositroy.Delete(coreLever);
                coreSkillRepositroy.Delete(coreSkill);
            }
        }
        public void RealDeleteToTeach(Guid teachSkillGuid)
        {
            if (teachSkillGuid == null)
            {
                throw new EntityIsNullException(" public void RealDelete(Guid coreSkillGuid) have null !");
            }
            var profess_TeachSkillRepositroy = UnityConfig.Container.Resolve(typeof(IProfess_TeachSkillRepositroy), null) as IProfess_TeachSkillRepositroy;
            profess_TeachSkillRepositroy.InitDbContext(dbContext);
            var profess_Tech = profess_TeachSkillRepositroy.Get(o => o.TeachSkillGuid == teachSkillGuid).ToList();
            var teachLever = teachLeverRepositroy.Get(o => o.TeachSkillGuid == teachSkillGuid).ToList();
            var teachSkill = teachSkillRepositroy.Get(o => o.Guid == teachSkillGuid).FirstOrDefault();
            if (teachSkill != null)
            {
                profess_TeachSkillRepositroy.Delete(profess_Tech);
                teachLeverRepositroy.Delete(teachLever);
                teachSkillRepositroy.Delete(teachSkill);
            }
        }

        public List<CoreLeverDto> GetCoreLeverByCoreSkillGuid(Guid coreSkillGuid, Func<IQueryable<CoreSkill>, IOrderedQueryable<CoreSkill>> orderBy = null)
        {
            var coreLeverList = coreSkillRepositroy.Get(o=>o.Guid == coreSkillGuid,orderBy,"CoreLevers").FirstOrDefault();
            if (coreLeverList != null)
            {
                var coreLeverDto = new List<CoreLeverDto>();
                foreach (var item in coreLeverList.CoreLevers)
                {
                    coreLeverDto.Add(item.ToDto());
                }
                return coreLeverDto;
            }
            return null;
        }
        public List<TeachLeverDto> GetTeachLeverByTeachSkillGuid(Guid teachSkillGuid, Func<IQueryable<TeachLever>, IOrderedQueryable<TeachLever>> orderBy = null)
        {
            var teachLeverList = teachSkillRepositroy.Get(o => o.Guid == teachSkillGuid, null, "TeachLevers").FirstOrDefault();
            if (teachLeverList != null)
            {
                var teachLeverDtoList = new List<TeachLeverDto>();
                foreach (var item in teachLeverList.TeachLevers)
                {
                    teachLeverDtoList.Add(item.ToDto());
                }
                return teachLeverDtoList;
            }
            return null;
        }

        public void SetCoreLeverToCoreSkill(CoreLever coreLever)
        {
            var coreSkill = coreSkillRepositroy.Get(o=>o.Guid == coreLever.CoreSkillGuid,null,"CoreLevers").FirstOrDefault();
            if (coreSkill == null)
            {
                throw new EntityIsNullException("<  public void SetCoreLeverToCoreSkill(Guid coreSkillGuid, CoreLever coreLever)> coreSkill is null !");
            }
            if (coreSkill.CoreLevers.Where(o=>o.LeverNumber == coreLever.LeverNumber).FirstOrDefault() != null)
            {
                throw new EntityRepeatException("Number repeat!");
            }
            coreSkill.CoreLevers.Add(coreLever.ToInsertEntity());
            coreSkillRepositroy.Update(coreSkill);
        }
        public void SetTeachLeverToTeachSkill(TeachLever teachLever)
        {
            var teachSkill = teachSkillRepositroy.Get(o => o.Guid == teachLever.TeachSkillGuid, null, "TeachLevers").FirstOrDefault();
            if (teachSkill == null)
            {
                throw new EntityIsNullException("<  public void SetteachLeverToteachSkill(Guid coreSkillGuid, CoreLever coreLever)> coreSkill is null !");
            }
            if (teachSkill.TeachLevers.Where(o => o.LeverNumber == teachLever.LeverNumber).FirstOrDefault() != null)
            {
                throw new EntityRepeatException("Number repeat!");
            }
            teachSkill.TeachLevers.Add(teachLever.ToInsertEntity());
            teachSkillRepositroy.Update(teachSkill);
        }

        public void DeleteCoreLeverToCoreSkill( CoreLever coreLever )
        {

            if (coreLever == null)
            {
                throw new EntityIsNullException("TeachLever is null !");
            }
            coreLeverRepositroy.Delete(coreLever);
        }
        public void DeleteTeachLeverToTeachsSkill(TeachLever teachLever)
        {
            if (teachLever == null)
            {
                throw new EntityIsNullException("TeachLever is null !");
            }
            teachLeverRepositroy.Delete(teachLever);
        }

        public void Save()
        {
            coreSkillRepositroy.Save();
        }

    }
}
