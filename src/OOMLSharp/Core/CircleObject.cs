using System.CodeDom.Compiler;

namespace OOMLSharp.Core;

/// <summary>
/// Represents a circle, centered at the origin.
/// </summary>
public class CircleObject : IObject
{
    /// <summary>
    /// The radius of the circle.
    /// </summary>
    public float Radius { get; set; }
    
    /// <summary>
    /// The diameter of the circle.
    /// </summary>
    public float Diameter
    {
        get => Radius * 2;
        set => Radius = value / 2;
    }

    public void GenerateScad(IndentedTextWriter writer)
    {
        writer.WriteLine($"circle(r = {Radius.ToScadString()});");
    }
}