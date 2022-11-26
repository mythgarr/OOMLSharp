using System.CodeDom.Compiler;
using OOMLSharp.Core;

namespace OOMLSharp.Test.Utility;

public class StubObject : IObject
{
    public string ScadText { get; set; }
    public string SyntaxTreeText { get; set; }

    public StubObject()
    {
        ScadText = String.Empty;
        SyntaxTreeText = String.Empty;
    }

    public StubObject(string text)
    {
        ScadText = text;
        SyntaxTreeText = text;
    }

    public void GenerateScad(IndentedTextWriter writer)
    {
        if (ScadText != String.Empty)
        {
            writer.WriteLine(ScadText);
        }
    }
}