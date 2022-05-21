#pragma warning disable 8625

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FileStructureBuilder.Controller;
using FileStructureBuilder.Test.FileStructureBuilderTest;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace FileStructureBuilder.Test.ControllerTest;

public class StructureBuilderControllerTest
{
    private StructureBuilderController Controller { get; set; }

    public StructureBuilderControllerTest()
    {
        Controller = SetupController();
    }

    [SetUp]
    public void Setup()
    {
        Controller = SetupController();
    }

    private StructureBuilderController SetupController()
    {
        var defaultConfig = GetDefaultConfig();

        return SetupController(defaultConfig);
    }

    private StructureBuilderControllerConfig GetDefaultConfig()
    {
        var logger = new Logger<StructureBuilderController>(new LoggerFactory());
        var modelValidator = new StructureBuilderModelValidator();
        var actionSetFactory = new FileStructureBuildActionSetFactory();

        return new StructureBuilderControllerConfig(logger, modelValidator, actionSetFactory);
    }

    private StructureBuilderController SetupController(StructureBuilderControllerConfig config)
    {
        return new StructureBuilderController(config);
    }

    private void Post_GivenVariableModel_ShouldRespondWithHttpBadRequest(StructureBuilderModel model)
    {
        var response = Controller.Post(model);
        Assert.AreEqual(response.ResponseCode, HttpStatusCode.BadRequest);
    }

    [Test]
    [TestCase(StructureBuilderControllerConfigTestCases.NullConfig)]
    public void Init_GivenNullConfig_ShouldThrowArgumentNull(StructureBuilderControllerConfig nullConfig)
    {
        Assert.Throws<ArgumentNullException>(delegate
        {
            var controller = new StructureBuilderController(nullConfig);
        });
    }

    [Test]
    [TestCase(StructureBuilderModelTestCases.NullModel)]
    public void Post_GivenNullModel_ShouldRespondWithHttpBadRequest(StructureBuilderModel nullModel)
        => Post_GivenVariableModel_ShouldRespondWithHttpBadRequest(nullModel);

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

    [Test]
    public void Post_GivenNullActions_ShouldRespondWithHttpBadRequest()
    {
        var modelWithNullActions = new StructureBuilderModel(null, new List<string>());
        Post_GivenVariableModel_ShouldRespondWithHttpBadRequest(modelWithNullActions);
    }
}