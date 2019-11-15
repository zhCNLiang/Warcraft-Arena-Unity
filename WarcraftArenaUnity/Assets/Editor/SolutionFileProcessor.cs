﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEditor;

public class SolutionFileProcessor : AssetPostprocessor
{
    const string ProjectTypeGuidCsharp = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}";
    const string ProjectTypeGuidConsoleApp = "{9A19103F-16F7-4668-BE54-9A1E7A4F7556}";

    private static string OnGeneratedSlnSolution(string path, string content)
    {
        // Automatically include ProjectFiles into SolutionFile

        var newContent = AddProject(
            content: content,
            ProjectTypeGuidConsoleApp,
            projectGuid: "{053476FC-B8B2-4A14-AED2-3733DFD5DFC3}",
            projectName: "ElleRealTime",
            projectPath: "..\\ElleRealTime\\ElleRealTime.csproj");

        newContent += AddProject(
            content: content,
            ProjectTypeGuidCsharp,
            projectGuid: "{340C6D91-D9E7-47C3-A3F0-F36A3A0874C9}",
            projectName: "ElleFramework.Utils",
            projectPath: "..\\ElleFramework.Utils\\ElleFramework.Utils.csproj");

        newContent += AddProject(
            content: content,
            ProjectTypeGuidCsharp,
            projectGuid: "{D8F1B2FB-A8C7-4760-BB10-31EFFC12E9C2}",
            projectName: "ElleFramework.Database",
            projectPath: "..\\ElleFramework\\ElleFramework.Database.csproj");

        newContent += AddProject(
            content: content,
            ProjectTypeGuidCsharp,
            projectGuid: "{EB5EFFC9-3B4F-415D-8DF8-43B9E4DFAA30}",
            projectName: "ElleRealTime.SqlServer",
            projectPath: "..\\ElleRealTime.SqlServer\\ElleRealTime.SqlServer.csproj");

        newContent += AddProject(
            content: content,
            ProjectTypeGuidCsharp,
            projectGuid: "{33ABC546-095E-4CF2-BF1C-AE664C1A6376}",
            projectName: "ElleRealTime.MySql",
            projectPath: "..\\ElleRealTime.MySql\\ElleRealTime.MySql.csproj");

        newContent += AddProject(
            content: content,
            ProjectTypeGuidCsharp,
            projectGuid: "{6A7422F7-F6F1-406F-8773-1498327F4F01}",
            projectName: "ElleRealTimeBaseDAO",
            projectPath: "..\\ElleRealTimeBaseDAO\\ElleRealTimeBaseDAO.csproj");

        newContent += AddProject(
            content: content,
            ProjectTypeGuidCsharp,
            projectGuid: "{5A098519-3C10-47DD-8117-50B5D9C764C2}",
            projectName: "ElleRealTime.Shared",
            projectPath: "..\\ElleRealTime.Shared\\ElleRealTime.Shared.csproj");
        
        return newContent;
    }

    private static string AddProject(string content, string projectTypeGuid, string projectGuid, string projectName, string projectPath)
    {
        var add = $"Project(\"{projectTypeGuid}\") = \"{projectName}\", \"{projectPath}\", \"{projectGuid}\"{Environment.NewLine}EndProject";

        var newContent = content.Replace($"EndProject{Environment.NewLine}Global",
            $"EndProject{Environment.NewLine}{add}{Environment.NewLine}Global");

        return newContent;
    }
}
