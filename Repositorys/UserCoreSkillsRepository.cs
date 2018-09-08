using System;
using System.Collections.Generic;
using System.Linq;
using Models.ReferenceModels;
using Repositorys.DataAccess;

namespace Repositorys
{
    public class UserCoreSkillsRepository
    {
        public List<UserCoreSkillModel> GetCoreSkillsByUserID(int userInfoID)
        {
            DB_StaffEvaluationEntities dB_StaffEvaluationEntities = new DB_StaffEvaluationEntities();
            var query = from userInfo in dB_StaffEvaluationEntities.TB_UserInfo
                        join role in dB_StaffEvaluationEntities.TB_Role on userInfo.RoleID equals role.RoleID
                        join roleContent in dB_StaffEvaluationEntities.TB_RoleContent on role.RoleID equals roleContent.RoleID
                        join professational in dB_StaffEvaluationEntities.TB_Professional on roleContent.ProfessionalID equals professational.ProfessionalID
                        join mappingCore in dB_StaffEvaluationEntities.TB_MappingCore on professational.ProfessionalID equals mappingCore.ProfessionalID
                        join coreSkill in dB_StaffEvaluationEntities.TB_CoreSkills on mappingCore.CoreSkillsID equals coreSkill.CoreSkillsID
                        join coreSkillLever in dB_StaffEvaluationEntities.TB_CoreLever on coreSkill.CoreSkillsID equals coreSkillLever.CoreSkillsID
                        where userInfoID == userInfo.UserInfoID
                        select new UserCoreSkillModel() {
                            Role = new Models.RoleModel()
                            {
                                RoleName = role.RoleName,
                            },
                            Professional = new Models.TBModelMappings.ProfessionalModel()
                            {
                                ProfessionalName = professational.ProfessionalName,
                            },
                            CoreSkills = new Models.TBModelMappings.CoreSkillsModel()
                            {
                                CoreSkillsName = coreSkill.CoreSkillsName,
                            },
                            CoreLever = new Models.TBModelMappings.CoreLeverModel()
                            {
                                CoreLeverNum = coreSkillLever.CoreLeverNum,
                                CoreLeverDetails = coreSkillLever.CoreLeverDetails,
                                 },      
                        };

            return query.ToList();
        }
    }
}