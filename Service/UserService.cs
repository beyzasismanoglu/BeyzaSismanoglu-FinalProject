using System;
using System.Collections.Generic;
using System.Text;
using BeyzaSismanoglu_FinalProject.Data;
using System.Linq;
using System.Security.Cryptography;

namespace BeyzaSismanoglu_FinalProject.Service
{
    public class UserService
    {
        private PlastichaneDb db;

        public UserService() {
            db = new PlastichaneDb();
        }

       public User Login(string Username, string Password)
        {
            string hashedPassword = hashPassword(Password);
            var loginUser = db.Users.FirstOrDefault(u => u.Username == Username && u.Password == hashedPassword);

            return loginUser;
        }

        public string hashPassword(string plainPassword)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                var plainBytes = Encoding.UTF8.GetBytes(plainPassword);
                //ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(plainBytes);

                //Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
