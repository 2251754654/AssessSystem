using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EvaluationModel
    {
        public int EvaluationID { get; set; }
        public string EvaluationDetails { get; set; }
        public int UserIDBy { get; set; }
        public int UserIDMain { get; set; }
    }
}
