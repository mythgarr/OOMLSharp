using System.CodeDom.Compiler;
using System.Collections;

namespace OOMLSharp.Core;

/// <summary>
/// Represents the union of all added objects.
/// </summary>
public class Union : BaseCompositeObject
{
    internal Union()
    {
    }

    public static CompositeComponent Create(params IObject[] objects)
    {
        Union union = new();
        foreach (var obj in objects)
        {
            union.Add(obj);
        }

        return new CompositeComponent(union);
    }

    protected override void WriteScadPrelude(IndentedTextWriter writer)
    {
        writer.WriteLine("union()");
    }
}