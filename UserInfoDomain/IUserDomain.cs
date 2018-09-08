using Models;

namespace Domains
{
    public interface iUserDomain
    {
        UserModel LoginCheck(UserModel userModel);
    }
}