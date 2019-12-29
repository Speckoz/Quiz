using Quiz.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.API.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserBaseModel> CreateTaskAync(UserBaseModel user);
        Task<UserBaseModel> FindUserTaskAsync(string login, string password);
    }
}
