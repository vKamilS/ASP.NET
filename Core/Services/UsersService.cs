using Core.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class UserService
    {
        public IDataDbContext DbContext { get; set; }
        public UserService(IDataDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<UserModel[]> GetAllUsers()
        {
            return await DbContext.Users.Select(x => new UserModel()
            {
                UserId = x.UserId,
                Name = x.Name,
                Email = x.Email,
                CakeDay = x.CakeDay.Value.Date,

            }).ToArrayAsync();
        }
    }
}
