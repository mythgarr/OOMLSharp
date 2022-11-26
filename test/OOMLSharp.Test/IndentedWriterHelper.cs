using System.CodeDom.Compiler;

namespace OOMLSharp.Test;

public class IndentedWriterHelper :IDisposable
{
    public const string IndentString = "   ";
    
    private readonly StringWriter _innerWriter;
    
    public string Text => _innerWriter.ToString();
    public IndentedTextWriter Writer { get; }

    public IndentedWriterHelper()
    {
        _innerWriter = new();
        Writer = new(_innerWriter, IndentString);
    }

    public void Dispose()
    {
        Writer.Dispose();
        _innerWriter.Dispose();
    }
}