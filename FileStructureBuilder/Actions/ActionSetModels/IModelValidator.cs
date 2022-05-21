namespace FileStructureBuilder.Actions.ActionSetModels;

public interface IModelValidator<T> where T : IActionSetModel
{
    ModelValidationResponse Validate(T? model);
}