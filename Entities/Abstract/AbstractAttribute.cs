

namespace InsertGeneration.Entities.Abstract;

public abstract class AbstractAttribute
{
    public string Name { get; set; }
    public string Value { get; set; } = string.Empty;

    public AbstractAttribute(string name)
    {
        Name = name;
    }
}
