using System.CodeDom.Compiler;
using System.Globalization;
using System.Numerics;

namespace OOMLSharp.Core;

public class TranslateDecorator : ObjectDecorator
{
    public static IObject Create(IObject decorated, Vector3 translate)
    {
        IObject abstractObject;
        if (translate == Vector3.Zero)
        {
            abstractObject = decorated;
        }
        else if (decorated is TranslateDecorator translateDecorator)
        {
            translateDecorator._translate = translate;
            abstractObject = translateDecorator;
        }
        else
        {
            abstractObject = new TranslateDecorator(decorated, translate);
        }

        return abstractObject;
    }

    private Vector3 _translate;

    private TranslateDecorator(IObject decorated, Vector3 translate)
        : base(decorated)
    {
        _translate = translate;
    }

    public override void GenerateScad(IndentedTextWriter writer)
    {
        writer.WriteLine($"translate({_translate.ToScadString()})");
        writer.WriteLine("{");
        writer.Indent++;
        base.GenerateScad(writer);
        writer.Indent--;
        writer.WriteLine("}");
    }
}