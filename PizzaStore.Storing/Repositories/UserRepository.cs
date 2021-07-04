using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaStore.Storing.Repositories
{
    public class UserRepository
    {

        private PizzaStoreDbContext _db = new PizzaStoreDbContext();
        public void Create(PizzaStore.Domain.Models.User user)//currently already added demo users
        {

        }

        
    }
}