using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ModelAssessDetails
    {
        public int EvaluationID { get; set; }//评价ID
        public string EvaluationDetails { get; set; }//总体评价摘要

        public string ByAssess { get; set; }//被评价人
        public string MainAssess { get; set; }//主评价人


        public int SkillsID { get; set; }//技能ID
        public int SkillsGUID { get; set; }//技能ID
        public string SkillsName { get; set; }//评价的技能名称
        public string SkillsDetails { get; set; }//技能介绍

        public string SkillLeverDetails { get; set; }//等级介绍

        public int SkillClasses { get; set; }//技能的类别
        public int Lever { get; set; }//评价的等级
    }
}
