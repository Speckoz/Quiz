using Quiz.API.Data;
using Quiz.API.Models;
using Quiz.API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiContext _context;

        public UserRepository(ApiContext context) => _context = context;

        /// <summary>
        /// Cria um novo usuario.
        /// </summary>
        /// <param name="user">Dados do usuario</param>
        public async Task<UserModel> CreateTaskAync(UserModel user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }
    }
}
