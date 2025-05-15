using System;
using System.Security.Cryptography;

namespace Utils.Censurador_De_Senha
{
    public static class Censurador_De_Senha
    {
        private const int Salt = 16;
        private const int Hash = 20;
        private const int Iteractions = 10000;

        public static string HashPassword(string senha)
        {
            byte[] salt = new byte[Salt];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, Iteractions, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(Hash);

            byte[] hashBytes = new byte[Salt + Hash];
            Array.Copy(salt, 0, hashBytes, 0, Salt);
            Array.Copy(hash, 0, hashBytes, Salt, Hash);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerificarSenha(string senha, string senhaHash)
        {
            byte[] hashBytes = Convert.FromBase64String(senhaHash);
            byte[] salt = new byte[Salt];
            Array.Copy(hashBytes, 0, salt, 0, Salt);

            var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, Iteractions, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(Hash);

            for (int i = 0; i < Hash; i++)
            {
                if (hashBytes[i + Salt] != hash[i])
                    return false;
            }
            return true;
        }
    }
}