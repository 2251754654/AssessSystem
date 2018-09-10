using System.Collections.Generic;

namespace Models
{
    public class ModelUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserLastDate { get; set; }
        public int UserLever { get; set; }
        public int UserConfirm { get; set; }
        public int Login { get; set; }
        public int UserDelete { get; set; }

        public virtual ICollection<ModelUserInfo> ModelUserInfos { get; set; }
    }
}
