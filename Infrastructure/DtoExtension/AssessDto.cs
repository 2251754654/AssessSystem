using Repositorys.DataAccess;
using Repositorys.DataAccess.AssessModule;
using Repositorys.DataAccess.ProfessModule;
using Repositorys.DataAccess.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class AssessDto
    {
        public string Guid { get; set; }
        public string AssessGuid { get; set; }
        public string ByAssessGuid{ get; set; }
        public string AssessName { get; set; }
        public string ByAssessName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastVisitTime { get; set; }
        public string AssessDigest { get; set; }//摘要

        public virtual ICollection<AssessInfoDto> AssessInfoDtoList { get; set; }

        //数据转化
        public AssessDto ToDto(Assess assess,User assessUser,User byAssessUser)
        {
            if (assess != null && assessUser!= null && byAssessUser!=null)
            {
                Guid = assess.Guid.ToString();
                AssessName = assessUser.UserInfo.Name;
                ByAssessName = byAssessUser.UserInfo.Name;
                CreateTime = assess.CreateTime;
                LastVisitTime = assess.UpdateTime;
                AssessDigest = assess.AssessDigest;
                AssessGuid = assessUser.Guid.ToString();
                ByAssessGuid = byAssessUser.Guid.ToString();
                return this;
            }
            throw new System.Exception("<public AssessDto ToDto(Assess assess,User assessUser,User byAssessUser)> hava null ！");
        }

        public Assess ToEntity()
        {
            var assessInfoList = new List<AssessInfo>();
            foreach (var assessInfoItem in this.AssessInfoDtoList)
            {
                assessInfoList.Add( assessInfoItem.ToEntity(this));
            }

            return new Assess()
            {
                AssessUserGuid = System.Guid.Parse(this.AssessGuid),
                ByAssessUserGuid = System.Guid.Parse(this.ByAssessGuid),
                AssessDigest = this.AssessDigest,
                CreateTime = this.CreateTime,
                UpdateTime = this.LastVisitTime,
                Guid = System.Guid.NewGuid(),
                State = 0,
                VisitCount = 11,
                AssessInfos = assessInfoList,
            };

        }
    }
}
