using OOMLSharp.Core;

namespace OOMLSharp.Test;

public class IntersectionTests
{
    [Fact]
    public void Intersection_WithDefaults_IsEmpty()
    {
        IndentedWriterHelper helper = new();
        Intersection intersection = new();

        intersection.GenerateScad(helper.Writer);
        string actual = helper.Text;

        Assert.Empty(actual);
    }

    [Fact]
    public void Intersection_WithTest_Succeeds()
    {
        IndentedWriterHelper helper = new();
        Intersection intersection = new()
        {
            new StubObject("test")
        };
        string expected = """
            intersection()
            {
               test
            }
            
            """;

        intersection.GenerateScad(helper.Writer);
        string actual = helper.Text;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Intersection_AddUnion_PreservesUnion()
    {
        IndentedWriterHelper helper = new();
        StubObject stub = new("test");
        Union union = new() { stub };
        Intersection intersection = new() { union };
        string expected = """
            intersection()
            {
               union()
               {
                  test
               }
            }
            
            """;

        intersection.GenerateScad(helper.Writer);
        string actual = helper.Text;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Intersection_AddIntersection_MergesChildren()
    {
        IndentedWriterHelper helper = new();
        StubObject stub = new("test");
        Intersection intersection = new() { stub };
        Intersection intersection2 = new() { intersection };
        string expected = """
            intersection()
            {
               test
            }
            
            """;

        intersection2.GenerateScad(helper.Writer);
        string actual = helper.Text;

        Assert.Equal(expected, actual);
    }
}