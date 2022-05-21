using System.Net;

namespace FileStructureBuilder.Controller;

public class StructureBuilderResponseModel
{
    public HttpStatusCode ResponseCode { get; }

    public string ResponseBody { get; }

    public StructureBuilderResponseModel(string responseBody, HttpStatusCode responseCode)
    {
        ResponseBody = responseBody;
        ResponseCode = responseCode;
    }
}