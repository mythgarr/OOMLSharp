using System.Numerics;
using OOMLSharp.Core;

namespace OOMLSharp;

public static class ObjectExtensions
{
    /// <summary>
    /// Translate obj by offset.
    /// </summary>
    public static IObject Translate(this IObject obj, Vector3 offset) => TranslateDecorator.Create(obj, offset);
    
    /// <summary>
    /// Performs an in-place rotation of obj by eulerAngles (specified in degrees).
    /// </summary> 
    public static IObject Rotate(this IObject obj, Vector3 eulerAngles) => RotateDecorator.Create(obj, eulerAngles);
    
    /// <summary>
    /// Rotates obj around the origin by eulerAngles (specified in degrees). 
    /// </summary>
    public static IObject RelativeRotate(this IObject obj, Vector3 eulerAngles) => RotateDecorator.Create(obj, eulerAngles);
}