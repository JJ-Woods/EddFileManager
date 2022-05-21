#nullable enable

using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FileStructureBuilder.Controller;

[ApiController]
[Route("")]
public class StructureBuilderController : ControllerBase
{
    private readonly StructureBuilderControllerConfig _config;

    public StructureBuilderController(StructureBuilderControllerConfig config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(StructureBuilderControllerConfig));
    }

    [HttpPost]
    public StructureBuilderResponseModel Post(StructureBuilderModel? nullableModel)
    {
        var validationResponse = _config.StructureBuilderModelValidator.Validate(nullableModel);
        if (!validationResponse.DidSuccede)
        {
            return new StructureBuilderResponseModel("Invalid model", HttpStatusCode.BadRequest);
        }
        var model = nullableModel ?? throw new ArgumentNullException(nameof(StructureBuilderControllerConfig));

        var actionSet = _config.FileStructureBuildActionSetFactory.BuildActionSet(model);
        var actionResponses = actionSet.ExecuteSet();

        return new StructureBuilderResponseModel("Success", HttpStatusCode.Accepted);
    }
}
