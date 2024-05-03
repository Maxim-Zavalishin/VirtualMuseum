using System.Security.Cryptography;
using System.Text;

namespace VirtualMuseum.Application.Helpers;

public static class HashPasswordHelper
{
    public static string HashPassword(string password)
    {
        var salt = "Sup-rHot";
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password + salt));
        return BitConverter.ToString(bytes).ToLower();
    }
}