using System.CodeDom.Compiler;
using System.Numerics;
using OOMLSharp;
using OOMLSharp.Core;

namespace Csg;

public class Csg : IObject
{
    public void GenerateScad(IndentedTextWriter writer)
    {
        var cube = new CubeObject(15);
        var sphere = new SphereObject(10);
        writer.WriteLine("// CSG.scad - Basic example of CSG usage");
        writer.WriteLine();
        Union.Create(cube, sphere)
            .Translate(new Vector3(-24, 0, 0))
            .GenerateScad(writer);
        writer.WriteLine();
        Intersection.Create(cube, sphere)
            .GenerateScad(writer);
        writer.WriteLine();
        Difference.Create(cube, sphere)
            .Translate(new Vector3(24, 0, 0))
            .GenerateScad(writer);
        writer.WriteLine();
        writer.WriteLine("echo(version=version());");
        writer.WriteLine("// Written by Marius Kintel <marius@kintel.net>");
        writer.WriteLine("//");
        writer.WriteLine("// To the extent possible under law, the author(s) have dedicated all");
        writer.WriteLine("// copyright and related and neighboring rights to this software to the");
        writer.WriteLine("// public domain worldwide. This software is distributed without any");
        writer.WriteLine("// warranty.");
        writer.WriteLine("//");
        writer.WriteLine("// You should have received a copy of the CC0 Public Domain");
        writer.WriteLine("// Dedication along with this software.");
        writer.WriteLine("// If not, see <http://creativecommons.org/publicdomain/zero/1.0/>.");
    }
}