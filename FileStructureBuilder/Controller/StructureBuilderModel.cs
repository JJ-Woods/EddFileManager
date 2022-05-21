using FileStructureBuilder.Actions;
using FileStructureBuilder.Actions.ActionSetModels;

namespace FileStructureBuilder.Controller;

public class StructureBuilderModel : IActionSetModel
{
    public ActionSet Actions { get; set; }

    public IEnumerable<string> NotifyEmailAddresses { get; set; }

    public StructureBuilderModel(ActionSet actions, IEnumerable<string> notifyEmailAddresses)
    {
        Actions = actions;
        NotifyEmailAddresses = notifyEmailAddresses;
    }
}