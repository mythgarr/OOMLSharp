using System.CodeDom.Compiler;
using System.Collections;

namespace OOMLSharp.Core;

/// <summary>
/// Base implementation of ICompositeObject.
/// </summary>
public abstract class BaseCompositeObject : ICompositeObject, IList<IObject>
{
    protected List<IObject> Objects { get; }
    public int Count => Objects.Count;
    public bool IsReadOnly => false;

    public IObject this[int index]
    {
        get => Objects[index];
        set => Objects[index] = value;
    }

    protected BaseCompositeObject()
    {
        Objects = new List<IObject>();
    }

    /// <summary>
    /// Generate SCAD output for this composite operation and write to writer.
    /// Default implementation will skip outputting if no objects have been added and will call
    /// WriteScadPrelude followed by all contained objects. 
    /// </summary>
    public virtual void GenerateScad(IndentedTextWriter writer)
    {
        if (!Objects.Any())
        {
            return;
        }

        WriteScadPrelude(writer);
        writer.WriteLine("{");
        writer.Indent++;
        foreach (var obj in Objects)
        {
            obj.GenerateScad(writer);
        }

        writer.Indent--;
        writer.WriteLine("}");
    }

    /// <summary>
    /// Write SCAD instructions to writer for the composite operation.
    /// </summary>
    protected abstract void WriteScadPrelude(IndentedTextWriter writer);

    public virtual void Add(IObject obj)
    {
        if (obj is Union union)
        {
            Objects.AddRange(union.Objects);
        }
        else
        {
            Objects.Add(obj);
        }
    }

    public virtual bool Remove(IObject obj)
    {
        bool wasRemoved = Objects.Remove(obj);
        // Removing a union can succeed if all objects within the union can be removed.
        if (!wasRemoved
            && obj is Union union
            && union.Objects.TrueForAll(Objects.Contains))
        {
            foreach (var o in union.Objects)
            {
                Objects.Remove(o);
            }

            wasRemoved = true;
        }

        return wasRemoved;
    }

    public virtual void Clear() => Objects.Clear();

    public virtual void Insert(int index, IObject item) => Objects.Insert(index, item);

    public bool Contains(IObject item) => Objects.Contains(item);

    public void CopyTo(IObject[] array, int arrayIndex) => Objects.CopyTo(array, arrayIndex);

    public IEnumerator<IObject> GetEnumerator() => Objects.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public int IndexOf(IObject item) => Objects.IndexOf(item);

    public void RemoveAt(int index) => Objects.RemoveAt(index);
}