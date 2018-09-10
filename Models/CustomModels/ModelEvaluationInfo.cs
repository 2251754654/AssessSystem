namespace Models
{
    public  class ModelEvaluationInfo
    {
        public int EvaluationInfoID { get; set; }
        public string SkillsGUID { get; set; }
        public int EvaluationID { get; set; }
        public int Lever { get; set; }

        public virtual ModelEvaluation ModelEvaluationItem { get; set; }
    }
}
