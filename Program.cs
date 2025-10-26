// ============================== //
//  Copyright (c) AJ-Holzer       //
//  SPDX-License-Identifier: MIT  //
// ============================== //


namespace FolderCrypt;

using FolderCrypt.crypto;

internal class Program
{
    static void Main(string[] args)
    {
        // Check if one element is provided in args
        if (args.Length != 1)
            throw new ArgumentException("A file/folder path must be specified to encrypt!");

        // Get path
        string path = args[0];

        // TODO: Check if the path is not the directory of the current script!
    }
}
