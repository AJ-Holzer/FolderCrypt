// ============================== //
//  Copyright (c) AJ-Holzer       //
//  SPDX-License-Identifier: MIT  //
// ============================== //


namespace FolderCrypt.fcrypt;

struct FCryptFileData(string originalFileName, string fileHash, string nonce, string tag)
{
    public readonly string OriginalFileName => originalFileName;
    public readonly string FileHash => fileHash;
    public readonly string Nonce => nonce;
    public readonly string Tag => tag;
}