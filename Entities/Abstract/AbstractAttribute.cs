

namespace InsertGeneration.Entities.Abstract;

public abstract class AbstractAttribute
{
    public DataType Type { get; protected set; }
    public string Name { get; set; }


    public AbstractAttribute(DataType type, string name)
    {
        Type = type;
        Name = name;
    }
}
