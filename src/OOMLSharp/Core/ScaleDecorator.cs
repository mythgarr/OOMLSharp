using System.CodeDom.Compiler;
using System.Numerics;

namespace OOMLSharp.Core;

public class ScaleDecorator : ObjectDecorator
{
    public static IObject Create(IObject decorated, Vector3 scale)
    {
        IObject abstractObject;
        if (scale == Vector3.One)
        {
            abstractObject = decorated;
        }
        else if (decorated is ScaleDecorator scaleDecorator)
        {
            scaleDecorator._scale = scale;
            abstractObject = scaleDecorator;
        }
        else
        {
            abstractObject = new ScaleDecorator(decorated, scale);
        }

        return abstractObject;
    }

    private Vector3 _scale;

    private ScaleDecorator(IObject decorated, Vector3 scale)
        : base(decorated)
    {
        _scale = scale;
    }

    public override void GenerateScad(IndentedTextWriter writer)
    {
        writer.WriteLine($"scale({_scale.ToScadString()})");
        writer.WriteLine("{");
        writer.Indent++;
        base.GenerateScad(writer);
        writer.Indent--;
        writer.WriteLine("}");
    }
}