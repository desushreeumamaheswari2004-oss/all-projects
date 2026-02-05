// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
namespace Demo_Encryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string message = "Hello, World!";//message to be encrypted
            //string password = "Strongpassword123!";//password to be hashed
            //byte[] passwordyte = Encoding.UTF8.GetBytes(password);
            //using SHA256 sha256 = SHA256.Create();//sha265 is a hashing algorithm which generates a fixed size hash value
            //byte[] key = sha256.ComputeHash(passwordyte);
            //string HashedPassword = Convert.ToBase64String(key);
            //Console.WriteLine("Hashed Password: " + HashedPassword);//display hashed password

            //byte[] key = RandomNumberGenerator.GetBytes(32);
            //byte[] iv = RandomNumberGenerator.GetBytes(15);
            //string secureKey = Convert.ToBase64String(key);
            //Console.WriteLine("Secure Key: " + secureKey);
            //Creating a hash value for a password using SHA256
            string password = "MySecurePassword";
            string hashedPassword;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                hashedPassword = Convert.ToBase64String(hashBytes);
            }
            Console.WriteLine("Stored Hash: " + hashedPassword);
            // Matching the password during login with the help of hash value
            string loginPassword = "MySecurePassword";
            string loginHash;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] loginBytes = Encoding.UTF8.GetBytes(loginPassword);
                byte[] loginHashBytes = sha256.ComputeHash(loginBytes);
                loginHash = Convert.ToBase64String(loginHashBytes);
            }

            bool isValid = hashedPassword == loginHash;

            Console.WriteLine("Password Match: " + isValid);

        }   
    }
}