using InsertGeneration.Entities.Abstract;

namespace InsertGeneration.Entities.DataTypes;

public class Int : AbstractAttribute
{

    public int MinValue { get; private set; }
    public int MaxValue { get; private set; }
    public Int(DataType type, string name, int minValue, int maxValue) : base(type, name)
    {
        MinValue = minValue;
        MaxValue = maxValue;
    }
}