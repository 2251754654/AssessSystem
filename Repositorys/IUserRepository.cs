using Models;

namespace Repositorys
{
    public interface IUserRepository
    {
        UserModel LoginCheck(UserModel userModel);
    }
}