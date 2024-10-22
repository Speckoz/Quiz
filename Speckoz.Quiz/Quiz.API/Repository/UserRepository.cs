﻿using Microsoft.EntityFrameworkCore;

using Quiz.API.Data;
using Quiz.API.Repository.Interfaces;
using Quiz.Dependencies.Models;

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
        /// Verifica se um email ja foi cadastrado.
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <param name="username">Username do usuario</param>
        public async Task<bool> CheckIfEmailOrUserExistsTaskAsync(string email, string username) =>
            await _context.Users.AnyAsync(u => u.Email == email || u.Username == username);

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

            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id">ID do usuario</param>
        public async Task DeleteAsync(Guid id)
        {
            UserBaseModel user = await _context.Users.SingleOrDefaultAsync(u => u.UserID == id);

            try
            {
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}