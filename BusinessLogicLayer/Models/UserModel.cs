using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class UserModel : IModel<User>
    {
        public UserModel()
        {

        }

        public UserModel(User user) : this()
        {
            this.ID = user.ID;
            this.Login = user.Login;
            this.Password_Hash = user.Password_Hash;
            this.Name = user.Name;
        }

        public User CreateEntity()
        {
            var entity = new User();

            entity.ID = this.ID;
            entity.Login = this.Login;
            entity.Password_Hash = this.Password_Hash;
            entity.Name = this.Name;

            return entity;
        }

        public int ID { get; set; }
        public string Login { get; set; }
        public long Password_Hash { get; set; }
        public string Name { get; set; }
    }
}
