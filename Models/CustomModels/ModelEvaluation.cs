using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ModelEvaluation
    {
        public int EvaluationID { get; set; }
        public string EvaluationDetails { get; set; }
        public int UserIDBy { get; set; }
        public int UserIDMain { get; set; }
        public int Delete { get; set; }//是否删除

        public virtual ModelUserInfo ModelUserInfoByItem { get; set; }
        public virtual ModelUserInfo ModelUserInfoMainItem { get; set; }
        public virtual ICollection<ModelEvaluationInfo> ModelEvaluationInfoList { get; set; }
    }
}
