using Infrastructure.Dto;
using Repositorys.DataAccess.AssessModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityExtension
{
    public static class AssessInfoExtension
    {
        public static AssessInfoDto ToDto(this AssessInfo  assessInfo)
        {
            return new  AssessInfoDto()
            {

            };
        }
        public static AssessInfo ToInsertEntity(this AssessInfo  assessInfo)
        {
            return null;
        }
    }
}
