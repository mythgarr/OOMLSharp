using System.CodeDom.Compiler;

namespace OOMLSharp.Core;

public abstract class ObjectDecorator : IObject
{
    private IObject _decorated;

    public IObject Decorated
    {
        get => _decorated;
        set => SetDecorated(value);
    }

    protected ObjectDecorator(IObject decorated) => _decorated = decorated;

    public virtual void GenerateScad(IndentedTextWriter writer) => _decorated.GenerateScad(writer);

    protected virtual void SetDecorated(IObject decorated) => _decorated = decorated;
}