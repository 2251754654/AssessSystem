using Repositorys.DataAccess.ProfessModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfoDomain.ProfessTerritory;

namespace UserInfoDomain
{
    class TeastDomain
    {
        public static void Main(string [] Args)
        {
            SkillDomain skillDomain = new SkillDomain();
            skillDomain.InitDbContext(new Repositorys.DataAccess.Context.DBContext());
            //skillDomain.Insert(new CoreSkill() {
            //    Guid = Guid.NewGuid(),
            //    CoreSkillName = "开发",
            //    Specific = "开发软件",
            //    CreateTime = DateTime.Now,
            //    State = 1,
            //    UpdateTime = DateTime.Now,
            //    VisitCount = 11,
            //});
            //skillDomain.Save();

            //skillDomain.Update(new CoreSkill()
            //{
            //    Guid = Guid.Parse("FFBF0942-9614-4142-9F00-1065FEE5A430"),
            //     CoreSkillName = "fubowen1",
            //});
            //skillDomain.Save();
            //Console.WriteLine("dddd");

            skillDomain.FakeDeleteToCore(Guid.Parse("FFBF0942-9614-4142-9F00-1065FEE5A430"));
            skillDomain.Save();
            Console.WriteLine("dddd");
        }
    }
}
