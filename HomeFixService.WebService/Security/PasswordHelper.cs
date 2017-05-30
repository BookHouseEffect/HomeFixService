using System;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;

namespace HomeFixService.WebService.Security
{
    public static class PasswordHelper
    {
        public static HashedAndSaltedPassword CryptPassword(string password, String defaultSalt = null)
        {
            var data = Encoding.UTF8.GetBytes(password);
            byte[] salt = null;
            if (defaultSalt == null)
                salt = GenerateSalt();
            else
            {
                SoapHexBinary hexBinary = SoapHexBinary.Parse(defaultSalt);
                salt = hexBinary.Value;
            }
            var saltedpass = Combine(data, salt);
            HashedAndSaltedPassword hashedAndSaltedPassword = new HashedAndSaltedPassword();
            using (SHA512 shaM = new SHA512Managed())
            {
                var hash = shaM.ComputeHash(saltedpass);
                SoapHexBinary crypted = new SoapHexBinary(hash);
                SoapHexBinary salted = new SoapHexBinary(salt);
                hashedAndSaltedPassword.PasswordHash = crypted.ToString();
                hashedAndSaltedPassword.PasswordSalt = salted.ToString();
            }
            return hashedAndSaltedPassword;
        }

        public static bool PasswordCompare(HashedAndSaltedPassword encryptedPassword, string plainPassword)
        {
            HashedAndSaltedPassword plainEncrypted = CryptPassword(plainPassword, encryptedPassword.PasswordSalt);
            SoapHexBinary left = SoapHexBinary.Parse(encryptedPassword.PasswordHash);
            SoapHexBinary right = SoapHexBinary.Parse(plainEncrypted.PasswordHash);
            return SlowEquals(left.Value, right.Value);
        }

        private static byte[] GenerateSalt(int arrayLength = 64)
        {
            byte[] salt = new byte[arrayLength];
            using (var myRNGCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                myRNGCryptoServiceProvider.GetNonZeroBytes(salt);
            }
            return salt;
        }

        private static byte[] Combine(params byte[][] arrays)
        {
            byte[] rv = new byte[arrays.Sum(a => a.Length)];
            int offset = 0;
            foreach (byte[] array in arrays)
            {
                Buffer.BlockCopy(array, 0, rv, offset, array.Length);
                offset += array.Length;
            }
            return rv;
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            int diff = a.Length ^ b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= a[i] ^ b[i];
            return diff == 0;
        }
    }
}