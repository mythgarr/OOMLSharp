using System.CodeDom.Compiler;
using System.Numerics;

namespace OOMLSharp.Core;

public sealed class TransformDecorator : ObjectDecorator
{
    /// <summary>
    /// Create a new TransformDecorator decorating the specified decorated object, representing a transformation of matrix.
    /// </summary>
    public static IObject Create(IObject decorated, Matrix4x4 matrix)
    {
        IObject abstractObject;
        if (matrix.IsIdentity)
        {
            abstractObject = decorated;
        }
        else if (decorated is TransformDecorator transformDecorator)
        {
            transformDecorator._matrix = matrix;
            abstractObject = transformDecorator;
        }
        else
        {
            abstractObject = new TransformDecorator(decorated, matrix);
        }

        return abstractObject;
    }

    private Matrix4x4 _matrix;

    private TransformDecorator(IObject decorated, Matrix4x4 matrix) : base(decorated)
    {
        _matrix = matrix;
    }

    public override void GenerateScad(IndentedTextWriter writer)
    {
        writer.WriteLine($"mulmatrix(m = [ [{_matrix.M11}, {_matrix.M12}, {_matrix.M13}, {_matrix.M14} ],");
        writer.WriteLine($"                [{_matrix.M21}, {_matrix.M22}, {_matrix.M23}, {_matrix.M24} ],");
        writer.WriteLine($"                [{_matrix.M31}, {_matrix.M32}, {_matrix.M33}, {_matrix.M34} ],");
        writer.WriteLine($"                [{_matrix.M41}, {_matrix.M42}, {_matrix.M43}, {_matrix.M44} ] ])");
        writer.WriteLine("{");
        writer.Indent++;
        base.GenerateScad(writer);
        writer.Indent--;
        writer.WriteLine("}");
    }
}