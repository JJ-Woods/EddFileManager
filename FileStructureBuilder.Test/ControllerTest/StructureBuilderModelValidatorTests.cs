using System.Linq;
using FileStructureBuilder.Controller;
using NUnit.Framework;

namespace FileStructureBuilder.Test.ControllerTest;

public class StructureBuilderModelValidatorTests
{
    [Test]
    public void Meta_Validation_ShouldHaveValidatorForEveryModelProperty()
    {
        var allModelPropertyNames =
            typeof(StructureBuilderModel)
            .GetProperties()
            .Select(prop => prop.Name);

        var validatedProperties =
            typeof(StructureBuilderModelValidator)
            .GetMethods()
            .SelectMany(meth => meth.GetCustomAttributes(typeof(ValidateForAttribute), false))
            .Select(valProp => ((ValidateForAttribute)valProp).FieldValidated);

        var propertiesWithNoValidator =
            allModelPropertyNames.Where(prop => !validatedProperties.Any(valProp => valProp == prop));

        if (propertiesWithNoValidator.Any())
            Assert.Fail();
    }
}