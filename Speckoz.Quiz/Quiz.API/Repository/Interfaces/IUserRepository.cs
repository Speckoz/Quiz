using Quiz.API.Models;
using System;
using System.Threading.Tasks;

namespace Quiz.API.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserBaseModel> CreateTaskAync(UserBaseModel user);
        Task<bool> CheckIfEmailOrUserExistsTaskAsync(string email, string username);
        Task<UserBaseModel> FindUserTaskAsync(string login, string password);
        Task DeleteAsync(Guid id);
    }
}