using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSupplyManagementSystem.Model
{
    class User
    {
        //private fields
        private string _username;
        private string _password;

        //public properties accessing the private fields
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }

        public User()
        {
            
        }

        /// <summary>
        /// Creates a new User object
        /// </summary>
        /// <param name="username">Username used for identification of User</param>
        /// <param name="password">Password used to authenticate User upon login</param>
        public User(string username, string password)
        {
            _username = username;
            _password = password;
        }
    }
}
