using System.Numerics;

namespace OOMLSharp.Core;

/// <summary>
/// Represents a rectangle in the first quadrant or centered around the origin.
/// </summary>
public class RectangleObject
{
    /// <summary>
    /// X and Y dimensions of the rectangle.
    /// </summary>
    public Vector2 Size { get; set; }

    /// <summary>
    /// If false the rectangle will be located in the first quadrant with one corner at the origin.
    /// </summary>
    public bool Center { get; set; } = true;
}