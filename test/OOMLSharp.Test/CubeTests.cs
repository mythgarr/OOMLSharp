using System.Numerics;
using OOMLSharp.Core;

namespace OOMLSharp.Test;

public class CubeTests
{
    [Fact]
    public void Cube_WithDefaults_Succeeds()
    {
        using IndentedWriterHelper helper = new();
        CubeObject cube = new();
        string expected = """
            cube([1, 1, 1], center = true);
            
            """;

        cube.GenerateScad(helper.Writer);
        string actual = helper.Text;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Cube_WithCenterFalse_Succeeds()
    {
        using IndentedWriterHelper helper = new();
        CubeObject cube = new() { Size = Vector3.One * 1.5f, Center = false };
        string expected = """
            cube([1.5, 1.5, 1.5]);
            
            """;

        cube.GenerateScad(helper.Writer);
        string actual = helper.Text;

        Assert.Equal(expected, actual);
    }
}