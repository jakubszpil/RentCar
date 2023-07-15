using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RentCar.Services {
    internal class AuthService {
        static public async Task<User> Login(string username, string password) {
            if (username== null || username.Length == 0 || password == null || password.Length == 0) {
                throw new Exception();
            } 

            string hashedPassword = GetHashedPassword(password);
            User user = null;

            using (var context = new RentCarContext()) {
                bool exists = context.Users.Any(u => u.Username == username);
                
                if (exists) {
                    User existingUser = context.Users.Single(u => u.Username == username);

                    if (existingUser.Password == hashedPassword) {
                        user = existingUser;
                    } else {
                        throw new Exception();
                    }
                } else {
                    user = new User { Username = username, Password = hashedPassword };
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }

            return user;
        }

        static public string GetHashedPassword(string password) {
            using (SHA256 sha256 = SHA256.Create()) {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                List<byte> hashes = sha256.ComputeHash(bytes).ToList();
                StringBuilder builder = new StringBuilder();

                hashes.ForEach(hash => builder.Append(hash.ToString("x2")));

                return builder.ToString();
            }
        }
    }
}
