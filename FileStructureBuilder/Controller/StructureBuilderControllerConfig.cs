using FileStructureBuilder.Actions;
using FileStructureBuilder.Actions.ActionSetModels;

namespace FileStructureBuilder.Controller;

public class StructureBuilderControllerConfig
{
    public ILogger<StructureBuilderController> Logger { get; }

    public IModelValidator<StructureBuilderModel> StructureBuilderModelValidator { get; }

    public IActionSetFactory FileStructureBuildActionSetFactory { get; }

    public StructureBuilderControllerConfig(
        ILogger<StructureBuilderController> logger
        , IModelValidator<StructureBuilderModel> structureBuilderModelValidator
        , IActionSetFactory fileStructureBuildActionSetFactory)
    {
        Logger = logger;
        StructureBuilderModelValidator = structureBuilderModelValidator;
        FileStructureBuildActionSetFactory = fileStructureBuildActionSetFactory;
    }
}