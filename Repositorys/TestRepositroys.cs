using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    class TestRepositroys
    {
        private static  IRepositoryUser repositoryUser = new RepositoryUser();
        private static  RepositroyAssess  RepositroyAssess = new RepositroyAssess();
        private static RepositoryUserInfo repositoryUserInfo = new RepositoryUserInfo();
        private static RepositoryRole repositoryRole = new RepositoryRole();
        private static RepositoryJob repositoryJob = new RepositoryJob();
        private static RepositoryCoreSkills repositoryCoreSkill = new RepositoryCoreSkills();

        public static void Main(string [] args)
        {
            //Models.ModelUser modelUser = new Models.ModelUser();

            //modelUser.UserName = "fubowenSSS";
            //modelUser.UserPassword = "123456";
            ////Console.WriteLine(repositoryUser.Login(modelUser).Login);
            ////Console.WriteLine(repositoryUser.Regist(modelUser));
            ////modelUser.UserID = 1;
            ////Console.WriteLine(repositoryUser.Update(modelUser));
            ////Console.WriteLine(repositoryUser.Delete(1));
            ////Console.WriteLine(repositoryUser.FindAllUser().Count);

            //ModelEvaluation modelEvaluation = new ModelEvaluation() {
            //      UserIDBy = 3,
            //       UserIDMain = 4,
            //        EvaluationDetails ="可以",
            //         Delete = 1,
            //          ModelEvaluationInfoList = new List<ModelEvaluationInfo>() {
            //                new ModelEvaluationInfo(){
            //                     Lever  = 1,
            //                      SkillsGUID = "11111",
            //                },
            //          }
            //};
            ////Console.WriteLine(RepositroyAssess.Insert(modelEvaluation));
            ////Console.WriteLine(RepositroyAssess.ReallyDelete(7));
            ////Console.WriteLine(RepositroyAssess.FindAllAssess().Count);
            ////Console.WriteLine(RepositroyAssess.FindAssessCoreDetails(8)[0].SkillLeverDetails);

            //var userInfo = repositoryUserInfo.FindUserInfo(2);
            ////Console.WriteLine(userInfo.UserInfoName);
            ////Console.WriteLine(repositoryUserInfo.Insert(userInfo));
            ////userInfo.UserInfoName = "付博文萨瓦达瓦达瓦";
            ////Console.WriteLine(repositoryUserInfo.Update(userInfo));
            ////Console.WriteLine(repositoryUserInfo.ReallyDelete(15));
            ////Console.WriteLine(repositoryUserInfo.FakeDelete(userInfo.UserInfoID));

            //ModelRole modelRole = new ModelRole() {
            //    RoleName = "测试",
            //    RoleDelete = 1,
            //    RoleDetails = "ddd",
            //     RoleID = 3,
            //};
            ////Console.WriteLine(repositoryRole.Insert(modelRole));
            ////Console.WriteLine(repositoryRole.Update(modelRole));
            ////Console.WriteLine(repositoryRole.FakeDelete(4));
            ////Console.WriteLine(repositoryRole.ReallyDelete(4));
            //var v= new ModelProfessional() {
            //    ProfessionalDelete = 1,
            //    ProfessionalDetails = "ee",
            //    ProfessionalName = "diqwufbwyveyfbqwf",
            //     ProfessionalID = 3,
            //};
            ////Console.WriteLine(repositoryCoreSkill.ReallyDelete(1));
            /////repositoryJob.ReallyDelete(2)
            Console.WriteLine();
        }
    }
}
