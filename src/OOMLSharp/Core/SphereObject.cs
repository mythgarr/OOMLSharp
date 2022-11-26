using System.CodeDom.Compiler;
using System.Numerics;

namespace OOMLSharp.Core;

/// <summary>
/// A sphere primitive.
/// </summary>
public class SphereObject : IObject
{
    /// <summary>
    /// The radius of the sphere.
    /// </summary>
    public float Radius { get; set; }

    /// <summary>
    /// The diameter of the sphere.
    /// </summary>
    public float Diameter
    {
        get => Radius * 2;
        set => Radius = value / 2;
    }

    /// <summary>
    /// Creates a default SphereObject centered at the origin with radius of 1.
    /// </summary>
    public SphereObject()
    {
        Radius = 1;
    }

    /// <summary>
    /// Creates a default SphereObject centered at the origin with the specified radius.
    /// </summary>
    public SphereObject(float radius)
    {
        Radius = radius;
    }

    public void GenerateScad(IndentedTextWriter writer) =>
        writer.WriteLine($"sphere({Radius.ToScadString()});");
}