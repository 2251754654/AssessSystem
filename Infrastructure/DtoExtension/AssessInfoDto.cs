using Repositorys.DataAccess.AssessModule;
using Repositorys.DataAccess.ProfessModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class AssessInfoDto
    {
        public string AssessGuid { get; set; }
        public string AssessInfoGuid { get; set; }
        public string SkillGuid { get; set; }
        public string LeverGuid { get; set; }
        public String SkillName { get; set; }//评价内容子项
        public int LeverNumber { get; set; }//等级编号
        public string LeaveMessage { get; set; }//留言

        public AssessInfoDto ToDto(AssessInfo assessInfo,CoreSkill coreSkill,CoreLever coreLever)
        {
            if (assessInfo != null && coreSkill != null && coreLever != null)
            {
                AssessInfoGuid = assessInfo.Guid.ToString();
                SkillGuid = coreSkill.Guid.ToString();
                LeverGuid = coreLever.Guid.ToString();
                SkillName = coreSkill.CoreSkillName;
                LeverNumber = coreLever.LeverNumber;
                LeaveMessage = assessInfo.Message;
                AssessGuid = assessInfo.AssessGuid.ToString();
                return this;
            }
            throw new System. Exception("< public AssessInfoDto ToDto(AssessInfo assessInfo,CoreSkill coreSkill)> hava null !");
        }

        public AssessInfoDto ToDto(AssessInfo assessInfo, TeachSkill  teachSkill,TeachLever teachLever)
        {
            if (assessInfo != null && teachSkill != null && teachLever != null)
            {
                AssessInfoGuid = assessInfo.Guid.ToString();
                SkillGuid = teachSkill.Guid.ToString();
                LeverGuid = teachLever.Guid.ToString();
                SkillName = teachSkill.TeachSkillName;
                LeverNumber = teachLever.LeverNumber;
                LeaveMessage = assessInfo.Message;
                AssessGuid = assessInfo.AssessGuid.ToString();
                return this;
            }
            throw new System.Exception("< public AssessInfoDto ToDto(AssessInfo assessInfo, TeachSkill  teachSkill)> hava null !");
        }

        public AssessInfo ToEntity(AssessDto assessDto)
        {
            return new AssessInfo()
            {
                AssessGuid = System.Guid.Parse(this.AssessGuid),
                AssessItemGuid = System.Guid.Parse(this.SkillGuid),
                LeverGuid = System.Guid.Parse(this.LeverGuid),
                Message = this.LeaveMessage,
                VisitCount = 10,
                Guid = Guid.NewGuid(),
            };
        }
    }
}
