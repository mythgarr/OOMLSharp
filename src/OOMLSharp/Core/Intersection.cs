using System.CodeDom.Compiler;

namespace OOMLSharp.Core;

/// <summary>
/// Represents the union of all added objects.
/// </summary>
public class Intersection : BaseCompositeObject
{
    internal Intersection()
    {
    }

    public static CompositeComponent Create(params IObject[] objects)
    {
        Intersection intersection = new();
        foreach (var obj in objects)
        {
            intersection.Add(obj);
        }

        return new CompositeComponent(intersection);
    }

    protected override void WriteScadPrelude(IndentedTextWriter writer)
    {
        writer.WriteLine("intersection()");
    }

    public override void Add(IObject obj)
    {
        if (obj is Intersection intersection)
        {
            Objects.AddRange(intersection.Objects);
        }
        else
        {
            Objects.Add(obj);
        }
    }

    public override bool Remove(IObject obj)
    {
        return Objects.Remove(obj);
    }
}