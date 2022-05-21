namespace FileStructureBuilder.Actions;

public class AssertFileExists : IActionType
{
    //File path
    public string ActionReference { get; }

    public DateTime ActionTimestamp { get; }

    public FileInfo File { get; }

    public AssertFileExists(string actionReference, DateTime actionTimestamp, FileInfo file)
    {
        ActionReference = actionReference;
        ActionTimestamp = actionTimestamp;
        File = file;
    }
}