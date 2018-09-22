using Models;

namespace Domains
{
    public interface IDomainLogin
    {
        ModelUser Login(ModelUser modelUser);
    }
}