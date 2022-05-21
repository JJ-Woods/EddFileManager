using FileStructureBuilder.Actions.ActionSetModels;

namespace FileStructureBuilder.Actions;

public interface IActionSetFactory
{
    ActionSet BuildActionSet(IActionSetModel actionSetModel);
}