
using InsertGeneration.Entities.Abstract;

namespace InsertGeneration.Entities.DataTypes;

public class Date : AbstractAttribute
{

    public DateTime MinValue { get; private set; }
    public DateTime MaxValue { get; private set; }

    public DateTime? value = null;

    public Date(string name, DateTime minValue, DateTime maxValue) : base(name)
    {
        MinValue = minValue;
        MaxValue = maxValue;
    }
}
