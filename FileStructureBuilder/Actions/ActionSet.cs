namespace FileStructureBuilder.Actions;

public class ActionSet
{
    public IEnumerable<IActionType> Actions { get; }

    public ActionSet(IEnumerable<IActionType> actions)
    {
        Actions = actions;
    }

    public IEnumerable<ActionResponse> ExecuteSet()
    {
        return new List<ActionResponse>();
    }
}