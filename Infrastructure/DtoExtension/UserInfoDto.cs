using Repositorys.DataAccess.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoExtension
{
    public class UserInfoDto
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public int Sex { get; set; }

        public string Address { get; set; }

        public string CurrentAddress { get; set; }

        public DateTime Birthday { get; set; }

        public string Phone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string QQ { get; set; }

        public string PersonalProfile { get; set; }//个人简介

        public Guid UserGuid { get; set; }

        public int VisitCount { get; set; }//访问次数

        public virtual User User { get; set; }
    }
}
