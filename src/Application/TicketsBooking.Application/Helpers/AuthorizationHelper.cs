using System.Security.Cryptography;

namespace TicketsBooking.Application.Helpers;

public static class AuthorizationHelper
{
    public static string CalculatePasswordHash(string password)
    {
        using var md5 = MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
        byte[] hashBytes = md5.ComputeHash(inputBytes);
        return Convert.ToHexString(hashBytes);
    }
}