namespace OOMLSharp.Core;

public interface ICompositeObject : IObject
{
    /// <summary>
    /// Adds obj to this composite object.
    /// </summary>
    void Add(IObject obj);

    /// <summary>
    /// Removes obj from this composite object.
    /// </summary>
    bool Remove(IObject obj);
}