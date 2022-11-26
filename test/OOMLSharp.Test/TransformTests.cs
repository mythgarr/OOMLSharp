using System.CodeDom.Compiler;
using System.Globalization;
using System.Numerics;
using Moq;
using NuGet.Frameworks;
using OOMLSharp.Core;

namespace OOMLSharp.Test;

public class TransformTests
{
    public const string IndentString = "   ";
    public const string TestString = "test";
    private readonly StringWriter _innerWriter;

    public string Text => _innerWriter.ToString();
    public IndentedTextWriter Writer { get; }

    public TransformTests()
    {
        _innerWriter = new();
        Writer = new(_innerWriter, IndentString);
    }

    #region Translate
    
    [Fact]
    public void Translate_WithZero_IsIgnored()
    {
        StubObject stub = new(TestString);
        var decorator = TranslateDecorator.Create(stub, Vector3.Zero);
        string expected = $"{TestString}\r\n";

        decorator.GenerateScad(Writer);
        string actual = Text;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Translate_WithNonZero_IsIndented()
    {
        StubObject stub = new(TestString);
        var decorator = TranslateDecorator.Create(stub,  new Vector3(1.5f, 1.5f, 1.5f));
        string expected = """
            translate([1.5, 1.5, 1.5])
            {
               test
            }
    
            """ ;

        decorator.GenerateScad(Writer);
        string actual = Text;

        Assert.Equal(expected, actual);
    }

    [Fact, UseCulture("en-DK")]
    public void Translate_WithOtherCulture_UsesDots()
    {
        Translate_WithNonZero_IsIndented();
    }
    
    #endregion Translate
    #region Rotate
    
    [Fact]
    public void Rotate_WithZero_IsIgnored()
    {
        StubObject stub = new(TestString);
        var decorator = RotateDecorator.Create(stub, Vector3.Zero);
        string expected = $"{TestString}\r\n";

        decorator.GenerateScad(Writer);
        string actual = Text;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Rotate_WithNonZero_IsIndented()
    {
        StubObject stub = new(TestString);
        var decorator = RotateDecorator.Create(stub,  new Vector3(1.5f, 1.5f, 1.5f));
        string expected = """
            rotate([1.5, 1.5, 1.5])
            {
               test
            }
    
            """ ;

        decorator.GenerateScad(Writer);
        string actual = Text;

        Assert.Equal(expected, actual);
    }

    [Fact, UseCulture("en-DK")]
    public void Rotate_WithOtherCulture_UsesDots()
    {
        Rotate_WithNonZero_IsIndented();
    }
    
    #endregion Rotate
    #region Scale
    
    [Fact]
    public void Scale_WithOne_IsIgnored()
    {
        StubObject stub = new(TestString);
        var decorator = ScaleDecorator.Create(stub, Vector3.One);
        string expected = $"{TestString}\r\n";

        decorator.GenerateScad(Writer);
        string actual = Text;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Scale_WithNonZero_IsIndented()
    {
        StubObject stub = new(TestString);
        var decorator = ScaleDecorator.Create(stub,  new Vector3(1.5f, 1.5f, 1.5f));
        string expected = """
            scale([1.5, 1.5, 1.5])
            {
               test
            }
    
            """ ;

        decorator.GenerateScad(Writer);
        string actual = Text;

        Assert.Equal(expected, actual);
    }

    [Fact, UseCulture("en-DK")]
    public void Scale_WithOtherCulture_UsesDots()
    {
        Scale_WithNonZero_IsIndented();
    }
    
    #endregion Scale
}