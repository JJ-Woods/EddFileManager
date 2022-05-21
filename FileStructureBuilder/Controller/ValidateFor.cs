namespace FileStructureBuilder.Controller;

public class ValidateForAttribute : Attribute
{
    public string FieldValidated { get; }

    public ValidateForAttribute(string fieldValidated)
    {
        FieldValidated = fieldValidated;
    }
}