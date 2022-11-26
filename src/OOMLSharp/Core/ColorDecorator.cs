using System.CodeDom.Compiler;
using System.Numerics;

namespace OOMLSharp.Core;

public class ColorDecorator : ObjectDecorator
{
    public string? ColorString { get; set; }
    public Vector4 Components { get; set; }

    public static IObject Create(IObject decorated, string color)
    {
        IObject abstractObject;
        if (decorated is ColorDecorator colorDecorator)
        {
            colorDecorator.ColorString = color;
            abstractObject = colorDecorator;
        }
        else
        {
            abstractObject = new ColorDecorator(decorated, color);
        }

        return abstractObject;
    }

    /// <summary>
    /// Creates a ColorDecorator with the specified RGBA components, specified in the range [0,1].
    /// </summary>
    public static IObject Create(IObject decorated, Vector4 components)
    {
        IObject abstractObject;
        if (decorated is ColorDecorator colorDecorator)
        {
            colorDecorator.ColorString = null;
            colorDecorator.Components = components;
            abstractObject = colorDecorator;
        }
        else
        {
            abstractObject = new ColorDecorator(decorated, components);
        }

        return abstractObject;
    }

    private ColorDecorator(IObject decorated, string color)
        : base(decorated)
    {
        ColorString = color;
    }

    private ColorDecorator(IObject decorated, Vector4 components)
        : base(decorated)
    {
        Components = components;
    }

    public override void GenerateScad(IndentedTextWriter writer)
    {
        writer.WriteLine(String.IsNullOrEmpty(ColorString)
            ? $"color({Components.ToScadString()})"
            : $"color(\"{ColorString}\")");
        writer.WriteLine("{");
        writer.Indent++;
        base.GenerateScad(writer);
        writer.Indent--;
        writer.WriteLine("}");
    }
}