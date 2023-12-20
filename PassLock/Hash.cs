using System.Security.Cryptography;
using System.Text;

namespace PassLock;

public class Hash
{
    public static byte[] GetHash(string inputString)
    { 
        HashAlgorithm algo = SHA512.Create();
        return algo.ComputeHash(Encoding.UTF8.GetBytes(inputString));
    }

    public static string GetHashedString(string inputString)
    {
        StringBuilder sb = new();
        foreach (byte b in GetHash(inputString))
            sb.Append(b.ToString("x2"));
        
        return sb.ToString();
    }
    
}