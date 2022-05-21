using System;

namespace FileStructureBuilder.Actions;

public interface IActionType
{
    string ActionReference { get; }

    DateTime ActionTimestamp { get; }
}