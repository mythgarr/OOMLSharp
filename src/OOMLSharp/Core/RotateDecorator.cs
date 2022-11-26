using System.CodeDom.Compiler;
using System.Globalization;
using System.Numerics;

namespace OOMLSharp.Core;

public class RotateDecorator : ObjectDecorator
{
    /// <summary>
    /// Create a RotateDecorator that rotates decorated by eulerAngles (specified in degrees). If relative is false
    /// an in-place rotation is performed, otherwise decorated is rotated about the origin.
    /// </summary>
    public static IObject Create(IObject decorated, Vector3 eulerAngles, bool relative = false)
    {
        IObject abstractObject;
        if (eulerAngles == Vector3.Zero)
        {
            abstractObject = decorated;
        }
        else if (!relative && decorated is TranslateDecorator translateDecorator)
        {
            translateDecorator.Decorated = Create(translateDecorator.Decorated, eulerAngles, true);
            abstractObject = translateDecorator;
        }
        else if (decorated is RotateDecorator rotateDecorator)
        {
            rotateDecorator._rotate += eulerAngles;
            abstractObject = rotateDecorator;
        }
        else
        {
            abstractObject = new RotateDecorator(decorated, eulerAngles);
        }

        return abstractObject;
    }

    private Vector3 _rotate;

    private RotateDecorator(IObject decorated, Vector3 rotate)
        : base(decorated)
    {
        _rotate = rotate;
    }

    public override void GenerateScad(IndentedTextWriter writer)
    {
        writer.WriteLine($"rotate({_rotate.ToScadString()})");
        writer.WriteLine("{");
        writer.Indent++;
        base.GenerateScad(writer);
        writer.Indent--;
        writer.WriteLine("}");
    }
}