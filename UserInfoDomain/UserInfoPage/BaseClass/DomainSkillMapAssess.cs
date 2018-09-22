using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domains
{
    /// <summary>
    /// 掌握的所有技能和评价信息对照
    /// </summary>
    public class DomainSkillMapAssess : IDomainSkillMapAssess
    {
        /// <summary>
        /// 所有的技能信息
        /// </summary>
        private IDomainUserCoreSkills domainUserCoreSkills;
        /// <summary>
        /// 自己的自评信息
        /// </summary>
        private IDomainOneselfAssess domainOneselfAssess;

        public DomainSkillMapAssess(IDomainUserCoreSkills _domainUserCoreSkills, IDomainOneselfAssess _domainOneselfAssess)
        {
            this.domainUserCoreSkills = _domainUserCoreSkills ?? throw new ArgumentNullException(nameof(domainUserCoreSkills));
            this.domainOneselfAssess = _domainOneselfAssess ?? throw new ArgumentNullException(nameof(domainOneselfAssess));
        }

        /// <summary>
        /// 查询出某人应该掌握的所有技能信息以后，和技能的评价信息进行连接，通过技能的等级连接，得到每种技能当前被评价的详细情况
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public Dictionary<ModelJobAndSkillAndLever, int> FindCoreSkillNowState(int roleID,int assessID)
        {
            var lever = domainUserCoreSkills.FindJobAndSkillAndLever(roleID);
            var assess = domainOneselfAssess.FindOneselfAssessToOneselfDetails(assessID);
            var array = new Dictionary<ModelJobAndSkillAndLever, int>();
            var result = from leverItem in lever
                         join assessItem in assess on leverItem.CoreLeverID equals assessItem.CoreLeverID into table
                         from item in table.DefaultIfEmpty()
                         select new { LeverInfo = leverItem, LeverNum = item == null ? 0 : item.Lever };
            var dictionary = result.ToDictionary(o=>o.LeverInfo,o=>o.LeverNum);
            return dictionary;
        }
        /// <summary>
        /// 查询出某人应该掌握的所有技能信息以后，和技能的评价信息进行连接，通过技能的等级连接，得到每种技能所有的评价信息
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public Dictionary<ModelJobAndSkillAndLever, List<int>> FindCoreSkillAllState(int userID,int roleID)
        {
            var index = 0;
            //次数
            bool tag = true;
            //存储结果
            var resultSet = new Dictionary<ModelJobAndSkillAndLever, List<int>>();
            //查询出所有等级
            var lever = domainUserCoreSkills.FindJobAndSkillAndLever(roleID);
            //查询某用户自我评价的所有信息
            var allAssess = domainOneselfAssess.FindOneselfAssessToOneself(userID);
            //遍历所有评价
            foreach (var allAssessItem in allAssess)
            {
                var assess = domainOneselfAssess.FindOneselfAssessToOneselfDetails(allAssessItem.EvaluationID);
                var result = from leverItem in lever
                             join assessItem in assess on leverItem.CoreLeverID equals assessItem.CoreLeverID into table
                             from item in table.DefaultIfEmpty()
                             select new
                             {
                                 LeverInfo = leverItem,
                                 LeverNum = item == null ? 0 : item.Lever
                             };
                if (tag == true)
                {
                    foreach (var item in result)
                    {
                        var LeverInfo = item.LeverInfo;
                        var LeverNum = item.LeverNum;
                        var list = new List<int>();
                        list.Add(LeverNum);
                        resultSet.Add(LeverInfo, list);
                    }
                    tag =false;
                }
                else
                {
                    index = 0;
                    foreach (var item in resultSet)
                    {
                        var list = item.Value;
                        list.Add(result.ToList()[index].LeverNum);
                        index++;
                    }
                }
               
            }
            return resultSet;
        }
    }
}