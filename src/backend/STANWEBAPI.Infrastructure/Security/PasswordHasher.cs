using System.Security.Cryptography;

namespace STANWEBAPI.Infrastructure.Security
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
        public bool IsPasswordCorrect(string enteredPassword, string hashedPassword);
    }

    public class PassWordHasher : IPasswordHasher
    {
        private static readonly int SALT_SIZE_IN_BYTES = 16;
        private static readonly int HASH_SIZE_IN_BYTES = 20;
        private static readonly int HASH_ITERATION_NUMBER = 100000;
        private static readonly int HASH_AND_SALT_SIZE_IN_BYTES =
            SALT_SIZE_IN_BYTES + HASH_SIZE_IN_BYTES;


        public string HashPassword(
            string password
        )
        {
            using var rng = RandomNumberGenerator.Create();
            var salt = new byte[SALT_SIZE_IN_BYTES];
            rng.GetBytes(salt);

            var pbkf2 = new Rfc2898DeriveBytes(password, salt, HASH_ITERATION_NUMBER, HashAlgorithmName.SHA256);
            byte[] hash = pbkf2.GetBytes(HASH_SIZE_IN_BYTES);

            byte[] hashBytes = new byte[HASH_AND_SALT_SIZE_IN_BYTES];
            Array.Copy(salt, sourceIndex: 0, hashBytes, destinationIndex: 0, SALT_SIZE_IN_BYTES);
            Array.Copy(hash, sourceIndex: 0, hashBytes, destinationIndex: SALT_SIZE_IN_BYTES, HASH_SIZE_IN_BYTES);

            return Convert.ToBase64String(hashBytes);
        }

        public bool IsPasswordCorrect(string enteredPassword, string hashedPassword)
        { 
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[SALT_SIZE_IN_BYTES];
            Array.Copy(hashBytes, sourceIndex: 0, salt, destinationIndex: 0, SALT_SIZE_IN_BYTES);
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, HASH_ITERATION_NUMBER, HashAlgorithmName.SHA256);
            byte[] enteredHash = pbkdf2.GetBytes(HASH_SIZE_IN_BYTES);

            // Compare the generated hash with the stored hash (using a constant-time comparison)
            return enteredHash.SequenceEqual(hashBytes.Skip(SALT_SIZE_IN_BYTES).ToArray());
        }
    }
}