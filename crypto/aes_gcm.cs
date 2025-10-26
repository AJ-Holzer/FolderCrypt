// ============================== //
//  Copyright (c) AJ-Holzer       //
//  SPDX-License-Identifier: MIT  //
// ============================== //


using System.Security.Cryptography;
using System.Text;

namespace FolderCrypt.crypto;

static class EncryptionHandler
{
    public static byte[] Encrypt(byte[] plaintextBytes, byte[] key, out byte[] nonce, out byte[] tag)
    {
        nonce = RandomNumberGenerator.GetBytes(count: 12);  // 96-bit nonce (standard)
        byte[] ciphertext = new byte[plaintextBytes.Length];
        tag = new byte[16];  // 128 bit tag

        using AesGcm aes = new(key, tag.Length);
        aes.Encrypt(nonce: nonce, plaintext: plaintextBytes, ciphertext: ciphertext, tag: tag);

        return ciphertext;
    }

    public static byte[] Decrypt(byte[] ciphertext, byte[] key, byte[] nonce, byte[] tag)
    {
        byte[] plaintextBytes = new byte[ciphertext.Length];

        using AesGcm aes = new(key, tag.Length);
        aes.Decrypt(nonce: nonce, ciphertext: ciphertext, tag: tag, plaintext: plaintextBytes);

        return plaintextBytes;
    }
}
