// ============================== //
//  Copyright (c) AJ-Holzer       //
//  SPDX-License-Identifier: MIT  //
// ============================== //


using System.Text.Json.Nodes;

namespace FolderCrypt.fcrypt;

class FCryptFileHandler(string fcryptFilePath)
{
    private readonly string _fcryptFilePath = fcryptFilePath;
    private JsonObject _fcryptJsonData = [];

    public void AddFileData(FCryptFileData file)
    {
        _fcryptJsonData[file.FileHash] = new JsonObject()
        {
            ["original-filename"] = file.OriginalFileName,
            ["nonce"] = file.Nonce,
            ["tag"] = file.Tag
        };
    }

    public void WriteFile()
    {
        // Write file content
        File.WriteAllText(path: _fcryptFilePath, contents: _fcryptJsonData.ToString());

        // Clear fcrypt json data
        _fcryptJsonData.Clear();
    }
}
