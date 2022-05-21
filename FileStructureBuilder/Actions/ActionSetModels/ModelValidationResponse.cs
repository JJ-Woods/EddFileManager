namespace FileStructureBuilder.Actions.ActionSetModels;

public class ModelValidationResponse
{
    public bool DidSuccede { get; }

    public ModelValidationResponse(bool didSuccede)
    {
        DidSuccede = didSuccede;
    }
}