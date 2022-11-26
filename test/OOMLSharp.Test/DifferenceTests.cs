using OOMLSharp.Core;

namespace OOMLSharp.Test;

public class DifferenceTests
{
    [Fact]
    public void Difference_WithDefaults_IsEmpty()
    {
        IndentedWriterHelper helper = new();
        Difference difference = new();

        difference.GenerateScad(helper.Writer);
        string actual = helper.Text;

        Assert.Empty(actual);
    }

    [Fact]
    public void Difference_WithTest_Succeeds()
    {
        IndentedWriterHelper helper = new();
        Difference difference = new()
        {
            new StubObject("test")
        };
        string expected = """
            difference()
            {
               test
            }
            
            """;

        difference.GenerateScad(helper.Writer);
        string actual = helper.Text;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Difference_AddUnion_MergesChildren()
    {
        IndentedWriterHelper helper = new();
        StubObject stub = new("test");
        Union union = new() { stub };
        Difference difference = new() { union };
        string expected = """
            difference()
            {
               test
            }
            
            """;

        difference.GenerateScad(helper.Writer);
        string actual = helper.Text;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Difference_AddIntersection_PreservesIntersection()
    {
        IndentedWriterHelper helper = new();
        StubObject stub = new("test");
        Intersection intersection = new() { stub };
        Difference difference = new() { intersection };
        string expected = """
            difference()
            {
               intersection()
               {
                  test
               }
            }
            
            """;

        difference.GenerateScad(helper.Writer);
        string actual = helper.Text;

        Assert.Equal(expected, actual);
    }
}