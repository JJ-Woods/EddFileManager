#pragma warning disable 8625, 8619

using System.Collections.Generic;
using FileStructureBuilder.Controller;
using NUnit.Framework;

namespace FileStructureBuilder.Test.FileStructureBuilderTest;

public class StructureBuilderModelTestCases
{
    public const StructureBuilderModel NullModel = null;

    public static IEnumerable<TestCaseData> ModelWithNullActions
    {
        get
        {
            yield return new TestCaseData(new StructureBuilderModel(null, new List<string>()));
        }
    }
}