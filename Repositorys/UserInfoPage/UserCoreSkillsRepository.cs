using System;
using System.Collections.Generic;
using System.Linq;
using Models.ReferenceModels;
using Repositorys.DataAccess;

namespace Repositorys
{
    public class UserCoreSkillsRepository
    {
        //public List<UserCoreSkillModel> GetCoreSkillsByUserID(int userInfoID)
        //{
        //    //DBContext dbContext = new DBContext();
        //    //var query = from userInfo in dbContext.TB_UserInfo
        //    //            join role in dbContext.TB_Role on userInfo.RoleID equals role.RoleID
        //    //            join roleContent in dbContext.TB_RoleContent on role.RoleID equals roleContent.RoleID
        //    //            join professational in dbContext.TB_Professional on roleContent.ProfessionalID equals professational.ProfessionalID
        //    //            join mappingCore in dbContext.TB_MappingCore on professational.ProfessionalID equals mappingCore.ProfessionalID
        //    //            join coreSkill in dbContext.TB_CoreSkills on mappingCore.CoreSkillsID equals coreSkill.CoreSkillsID
        //    //            join coreSkillLever in dbContext.TB_CoreLever on coreSkill.CoreSkillsID equals coreSkillLever.CoreSkillsID
        //    //            where userInfoID == userInfo.UserInfoID
        //    //            select new UserCoreSkillModel() {
        //    //                Role = new Models.ModelRole()
        //    //                {
        //    //                    RoleName = role.RoleName,
        //    //                },
        //    //                Professional = new Models.TBModelMappings.ModelProfessional()
        //    //                {
        //    //                    ProfessionalName = professational.ProfessionalName,
        //    //                },
        //    //                CoreSkills = new Models.TBModelMappings.CoreSkillsModel()
        //    //                {
        //    //                    CoreSkillsName = coreSkill.CoreSkillsName,
        //    //                },
        //    //                CoreLever = new Models.TBModelMappings.ModelCoreLever()
        //    //                {
        //    //                    CoreLeverNum = coreSkillLever.CoreLeverNum,
        //    //                    CoreLeverDetails = coreSkillLever.CoreLeverDetails,
        //    //                     },      
        //    //            };

        //    return null;
        //}
    }
}