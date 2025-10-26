// ============================== //
//  Copyright (c) AJ-Holzer       //
//  SPDX-License-Identifier: MIT  //
// ============================== //


using System.Security.Cryptography;
using System.Text;

static class SHA256Handler
{
    public static string HashString(string s)
    {
        // Use SHA256
        using SHA256 sha256 = SHA256.Create();

        // Convert string to bytes
        byte[] sBytes = Encoding.UTF8.GetBytes(s);

        // Compute the hash
        byte[] hashBytes = sha256.ComputeHash(sBytes);

        // Convert the byte array to hex string
        StringBuilder builder = new();
        foreach (byte b in sBytes)
        {
            builder.Append(b.ToString("x2"));
        }

        return builder.ToString();
    }
}
