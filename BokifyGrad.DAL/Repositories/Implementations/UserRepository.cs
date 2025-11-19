using BokifyGrad.DAL.Models;
using BokifyGrad.DAL.Repositories.Interfaces;

namespace BokifyGrad.DAL.Repositories.Implementations
{
    internal class UserRepository : IUserRepository
    {
        private AppDBContext _context;
       public UserRepository(AppDBContext context) {
            _context = context;
        }
        public void Add(User user)
        {
            _context.users.Add(user);
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null) user.IsDeleted = true;

        }

        public IEnumerable<User> GetAll()
        {
            return _context.users.ToList();
        }

        public User GetByEmail(string email)
        {
            return _context.users.FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return _context.users.Find(id);
        }

        public User GetByName(string name)
        {
            return _context.users.FirstOrDefault(u => u.Username == name);
        }

        public void SetRole(int id, string role)
        {
            var user = GetById(id);
            if (user != null) user.Role = role;

        }

        public void Update(User user)
        {
            _context.users.Update(user);
        }

        public void updateEmail(int id, string newEmail)
        {
            var user = GetById(id);
            if (user != null) user.Email = newEmail;
            
        }

        public void updatePassword(int id, string newpassword)
        {
            var user = GetById(id);
            if (user != null) user.PasswordHash = newpassword;

        }

        public void updatePhone(int id, string newphone)
        {
            var user = GetById(id);
            if (user != null) user.PhoneNumber = newphone;

        }
    }
}
