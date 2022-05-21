using FileStructureBuilder.Actions;
using FileStructureBuilder.Actions.ActionSetModels;

namespace FileStructureBuilder.Controller;

public class StructureBuilderModelValidator : IModelValidator<StructureBuilderModel>
{
    public ModelValidationResponse Validate(StructureBuilderModel? nullableModel)
    {
        if (nullableModel is null)
            return new ModelValidationResponse(false);

        var model = nullableModel as StructureBuilderModel;

        if (!ValidateActions(model.Actions))
            return new ModelValidationResponse(false);

        if (!ValidateEmailAddresses(model.NotifyEmailAddresses))
            return new ModelValidationResponse(false);

        return new ModelValidationResponse(true);
    }

    [ValidateFor(nameof(StructureBuilderModel.Actions))]
    public bool ValidateActions(ActionSet actions)
    {
        return false;
    }

    [ValidateFor(nameof(StructureBuilderModel.NotifyEmailAddresses))]
    public bool ValidateEmailAddresses(IEnumerable<string> emailAddresses)
    {
        return false;
    }
}