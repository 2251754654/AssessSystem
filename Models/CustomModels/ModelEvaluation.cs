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
        public int Delete { get; set; }

        public virtual ModelUser ModelUserByItem { get; set; }
        public virtual ICollection<ModelEvaluationInfo> ModelEvaluationInfoList { get; set; }
    }
}
