namespace OOMLSharp.Core;

public class Component : ObjectDecorator
{
    public Component(IObject decorated) : base(decorated)
    {
    }
}