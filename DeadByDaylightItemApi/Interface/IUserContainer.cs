using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface IUserContainer
    {
        public int AddNewUser(UserDTO UserDTO);
        public UserDTO FindUserByUsername(string Username);
    }
}
