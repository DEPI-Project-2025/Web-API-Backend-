using BokifyGrad.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.DAL.Repositories.Interfaces
{
    internal interface IUserRepository
    {
        //Create...
        void Add(User user);
        IEnumerable<User> GetAll();
        //Read...
        User GetById(int id);
        User GetByName(string name);
        User GetByEmail(string email);
        //Update...
        void Update(User user);
        void updateEmail(int id, string newEmail);
        void updatePhone(int id, string newphone);
        void updatePassword(int id, string newpassword);
        void SetRole(int id, string role);
        //Delete...
        void Delete(int id);


    }
}
