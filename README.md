OOMLSharp
====

C# Object Oriented Mechanics Language

An adaptation of the original OOML project (https://github.com/avalero/OOML).

What's the OOML
===============

OOML stands for Object Oriented Mechanics Library. 
The OOML is a set of tools written in C++ that allow designers to create mechanical parts using the C++ language.
 * OOML applies the model of Object Oriented Programming to Mechanical Designs. 
 * Parts can be inherited from others. A part can join together other existing parts, and so forth.
 * OOML has up to now no external dependency and can be used in any computer having a standard C++ compiler.

Up to current version OOML generates OpenSCAD code. Using OpenSCAD designers may generate the STL of the parts.

 * OOML is Open Source, you can use it, modify it, share it.

What's the intention of the OOML
================================

 * Leverages the efforts of the original OOML project contributors, adopting similar syntax and class inheritance
where it makes sense to do so.
 * Adapts C# language features such as expression trees and extension methods to provide improvements where possible. 
 * OOML brings together both the design of pieces through code (as it's done with OpenSCAD) with the programming power 
of an Object Oriented Language as C#.
 * OOML provides a powerful tool for designers to boost their creativity building mechanical parts. 
 * As it uses C#, designers may use any other existing C# library to calculate, manipulate, create their parts.
 
OOMLSharp is NOT:
 * A visualizer. OpenSCAD supports hot-reload, programs can overwrite an STL file and OpenSCAD will automatically refresh the preview.
 * A boolean geometry processor. OpenSCAD has implemented a comprehensive system to handle boolean operations, there is no clear benefit
to creating our own system for this purpose.