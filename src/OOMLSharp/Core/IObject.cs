using System.CodeDom.Compiler;

namespace OOMLSharp.Core;

public interface IObject
{
    /// <summary>
    /// Generate SCAD output for this object and write to writer.
    /// </summary>
    /// <remarks>
    /// This method allows the object to write the SCAD code to the provided writer.
    /// </remarks>
    void GenerateScad(IndentedTextWriter writer);
}