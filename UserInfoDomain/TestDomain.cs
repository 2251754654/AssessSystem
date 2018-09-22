using Domains;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectUtils;

namespace UserInfoDomain
{
    class TestDomain
    {
        public static void Main(string[] args)
        {
           var DomainUserCoreSkills =  new DomainUserCoreSkills(
               new RepositoryRole()
            , new RepositoryJob()
            , new RepositoryCoreSkills() 
            , new RepositoryCoreLever() 
            , new RepositoryRoleContent()
            , new RepositoryMapingCore()) { };
            var domainOneselfAssess = new DomainOneselfAssess(new RepositroyAssess());

            //Console.WriteLine(ShowAllValue.ShowValue(test.FindRole(1)));
            //Console.WriteLine(ShowAllValue.ShowValue(test.FindJob(1)));
            //Console.WriteLine(ShowAllValue.ShowValue(test.FindCoreSkill(1)));

            //Console.WriteLine(ShowAllValue.ShowValue(test.FindAllLever(1)));
            //Console.WriteLine(test.FindAllLever(1).Count);
            // Console.WriteLine(ShowAllValue.ShowValue(test.FindRoleAllJob(1)));
            //Console.WriteLine(ShowAllValue.ShowValue(test.FindJobAllCoreSkill(1)));
            //Console.WriteLine(ShowAllValue.ShowValue(test.FindJobAndSkillAndLever(1)));
            //Console.WriteLine(test.FindJobAndSkillAndLever(1).Count);
            //Console.WriteLine(test.FindJobAndSkillAndLeverThreeLayers(1).Count);
            //Console.WriteLine(test.FindJobAndSkillAndLeverThreeLayersList(1).Count());
            //foreach (var job in test.FindJobAndSkillAndLeverThreeLayersList(1))
            //{
            //    foreach (var skill in job)
            //    {
            //        Console.WriteLine(ShowAllValue.ShowValue(skill.Key));

            //        foreach (var lever in skill.Value)
            //        {
            //            Console.WriteLine(ShowAllValue.ShowValue(lever.Key));
            //            Console.WriteLine(ShowAllValue.ShowValue(lever.Value));
            //        }
            //    }
            //}
            var testAssess = new DomainSkillMapAssess(DomainUserCoreSkills, domainOneselfAssess);

            foreach (var v in testAssess.FindCoreSkillNowState(1, 2))
            {
                Console.WriteLine(ShowAllValue.ShowValue(v.Key) + "value:" + v.Value);

            }

            //Console.WriteLine(ShowAllValue.ShowValue(domainOneselfAssess.FindOneselfAssessToOneself(2)));
            Console.WriteLine(ShowAllValue.ShowValue(domainOneselfAssess.FindOneselfAssessToOneselfDetails(2)));
        }
    }
}
