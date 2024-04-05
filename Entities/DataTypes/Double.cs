
using InsertGeneration.Entities.Abstract;

namespace InsertGeneration.Entities.DataTypes;

public class DoubleType : AbstractAttribute
{

    public double MinValue { get; }
    public double MaxValue { get; }


    public DoubleType(string name, double minValue, double maxValue) : base(name)
    {
        MinValue = minValue;
        MaxValue = maxValue;
    }
}
