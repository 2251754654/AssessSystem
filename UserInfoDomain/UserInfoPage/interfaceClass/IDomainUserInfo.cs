using Models;

namespace Domains
{
    public interface IDomainUserInfo
    {
        ModelUserInfo FindUserInfo(int userID);
        bool UpdateUserInfo(ModelUserInfo modelUserInfo);
    }
}