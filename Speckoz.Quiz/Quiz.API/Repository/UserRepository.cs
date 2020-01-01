using Microsoft.EntityFrameworkCore;

using Quiz.API.Data;
using Quiz.API.Models;
using Quiz.API.Repository.Interfaces;

using System;
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
        public async Task<UserBaseModel> CreateTaskAync(UserBaseModel user)
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

        /// <summary>
        /// Procura um usuario pelo user e senha
        /// </summary>
        /// <param name="login">Login do usuario</param>
        /// <param name="password">Senha do usuario</param>
        public async Task<UserBaseModel> FindUserTaskAsync(string login, string password)
        {
            IQueryable<UserBaseModel> query = _context.Users
                .Where(u => (u.Username == login || u.Email == login) && u.Password == password);

            var user = await query.FirstOrDefaultAsync();
            return user;
        }
    }
}