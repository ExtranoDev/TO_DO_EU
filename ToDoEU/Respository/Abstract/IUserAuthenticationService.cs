using ToDoEU.Models.DTO;

namespace ToDoEU.Respository.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAysnc(LoginModel model);
        Task<Status> RegistrationAysnc(RegistrationModel model);
        Task LogoutAsync();
    }
}
