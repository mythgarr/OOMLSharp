using OOMLSharp.Core;

namespace OOMLSharp.Test;

public class UnionTests
{
    [Fact]
    public void Union_WithDefaults_IsEmpty()
    {
        IndentedWriterHelper helper = new();
        Union union = new();

        union.GenerateScad(helper.Writer);
        string actual = helper.Text;

        Assert.Empty(actual);
    }

    [Fact]
    public void Union_WithTest_Succeeds()
    {
        IndentedWriterHelper helper = new();
        Union union = new()
        {
            new StubObject("test")
        };
        string expected = """
            union()
            {
               test
            }
            
            """;

        union.GenerateScad(helper.Writer);
        string actual = helper.Text;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Union_AddUnion_MergesChildren()
    {
        IndentedWriterHelper helper = new();
        StubObject stub = new("test");
        Union union = new() { stub };
        Union union2 = new() { union };
        string expected = """
            union()
            {
               test
            }
            
            """;

        union2.GenerateScad(helper.Writer);
        string actual = helper.Text;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Union_AddIntersection_PreservesIntersection()
    {
        IndentedWriterHelper helper = new();
        StubObject stub = new("test");
        Intersection intersection = new() { stub };
        Union union = new() { intersection };
        string expected = """
            union()
            {
               intersection()
               {
                  test
               }
            }
            
            """;

        union.GenerateScad(helper.Writer);
        string actual = helper.Text;

        Assert.Equal(expected, actual);
    }
}