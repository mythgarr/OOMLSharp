using System.CodeDom.Compiler;

namespace OOMLSharp.Core;

public abstract class BaseModule : IObject
{
    public string Name { get; set; }

    protected BaseModule(string name)
    {
        Name = name;
    }

    public abstract void GenerateScad(IndentedTextWriter writer);
}