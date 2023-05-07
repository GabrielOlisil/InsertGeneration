using InsertGeneration.Entities.Abstract;

namespace InsertGeneration.Entities.DataTypes;

public class Int : AbstractAttribute
{

    public int MinValue { get; }
    public int MaxValue { get; }


    public Int(DataType type, string name, int minValue, int maxValue) : base(type, name)
    {
        MinValue = minValue;
        MaxValue = maxValue;
    }




}