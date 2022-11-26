namespace OOMLSharp.Core;

public sealed class CompositeComponent : Component, ICompositeObject
{
    private ICompositeObject? DecoratedComposite
    {
        get => Decorated as ICompositeObject;
        set => SetDecorated(value);
    }

    public CompositeComponent(ICompositeObject decorated) : base(decorated)
    {
    }

    public void Add(IObject obj)
    {
        DecoratedComposite?.Add(obj);
    }

    public bool Remove(IObject obj)
    {
        return DecoratedComposite?.Remove(obj) == true;
    }

    protected override void SetDecorated(IObject? decorated)
    {
        if (decorated is not ICompositeObject)
        {
            throw new InvalidCastException("CompositeComponent can only decorate ICompositeObjects");
        }

        base.SetDecorated(decorated);
    }
}