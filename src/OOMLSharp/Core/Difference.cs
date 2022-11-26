using System.CodeDom.Compiler;

namespace OOMLSharp.Core;

public class Difference : BaseCompositeObject
{
    internal Difference()
    {
    }

    public static CompositeComponent Create(params IObject[] objects)
    {
        Difference difference = new();
        foreach (var obj in objects)
        {
            difference.Add(obj);
        }

        return new CompositeComponent(difference);
    }

    protected override void WriteScadPrelude(IndentedTextWriter writer)
    {
        writer.WriteLine("difference()");
    }
}