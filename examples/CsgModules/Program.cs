using System.CodeDom.Compiler;

internal class Program
{
    static void Main(string[] args)
    {
        using IndentedTextWriter writer = new(Console.Out);
        /* Target syntax for creating modules:
         ```
         Module.Create("body", (writer) =>
            SphereObject.Create(10).GenerateScad(writer);
         );
         
         var module = Module.Create<float>("body2", (foo) => 
         {          
            SphereObject.Create(foo);
        });
        module.Invoke(12.0f);
        module.Invoke(param);
        ```
        
        Generates
        ```
        body2(12);
        body2(param);
        
        module body2(foo)
        {
            sphere(foo);        
        }
        ```
         */
        // new Csg.Csg().GenerateScad(writer);
    }
}