// ============================== //
//  Copyright (c) AJ-Holzer       //
//  SPDX-License-Identifier: MIT  //
// ============================== //


using FolderCrypt.crypto;
using FolderCrypt.fcrypt;

namespace FolderCrypt.encryption;

class EncryptFile(byte[] key, FCryptFileHandler fcryptFileHandler)
{
    private readonly byte[] _key = key;

    private readonly FCryptFileHandler _fcryptFileHandler = fcryptFileHandler;

    public void Encrypt(string filePath)
    {
        // Create .tmp file path
        string tmpFilePath = $"{filePath}.tmp";

        // Get file name
        string fileName = Path.GetFileName(path: filePath);

        // Get file content
        byte[] fileContent = File.ReadAllBytes(path: filePath);

        // Encrypt file content
        byte[] encryptedFileContent = EncryptionHandler.Encrypt(
            plaintextBytes: fileContent,
            key: _key,
            nonce: out byte[] nonce,
            tag: out byte[] tag
        );

        // Get base64 of nonce and tag
        string b64Nonce = Convert.ToBase64String(nonce);
        string b64Tag = Convert.ToBase64String(tag);

        // Write encrypted file content to .tmp file
        File.WriteAllBytes(path: tmpFilePath, bytes: encryptedFileContent);

        // Replace file
        File.Replace(sourceFileName: tmpFilePath, destinationFileName: filePath, destinationBackupFileName: null);

        // Add file to .fcrypt content
        _fcryptFileHandler.AddFileData(
            file: new FCryptFileData(
                originalFileName: filePath,
                fileHash: SHA256Handler.HashString(fileName),
                nonce: b64Nonce,
                tag: b64Tag
            )
        );
    }
}
