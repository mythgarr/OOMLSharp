using System.CodeDom.Compiler;

internal class Program
{
    static void Main(string[] args)
    {
        using IndentedTextWriter writer = new(Console.Out);
        new Csg.Csg().GenerateScad(writer);
    }
}