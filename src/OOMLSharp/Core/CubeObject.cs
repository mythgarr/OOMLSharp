using System.CodeDom.Compiler;
using System.Numerics;

namespace OOMLSharp.Core;

/// <summary>
/// A cube primitive.
/// </summary>
public class CubeObject : IObject
{
    /// <summary>
    /// The size of the cube.
    /// </summary>
    public Vector3 Size { get; set; }

    /// <summary>
    /// If false the cube will be positioned in the 1st octant with one corner at the origin.
    /// </summary>
    public bool Center { get; set; } = true;

    /// <summary>
    /// Creates a default CubeObject centered at the origin with all sides equal to 1.
    /// </summary>
    public CubeObject()
    {
        Size = Vector3.One;
    }

    /// <summary>
    /// Creates a new CubeObject centered at the origin with all sides equal to side.
    /// </summary>
    public CubeObject(float side)
    {
        Size = Vector3.One * side;
    }

    public void GenerateScad(IndentedTextWriter writer) =>
        writer.WriteLine(Center
            ? $"cube({Size.ToScadString()}, center = true);"
            : $"cube({Size.ToScadString()});"
        );
}