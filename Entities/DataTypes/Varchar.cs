

using InsertGeneration.Entities.Abstract;

namespace InsertGeneration.Entities.DataTypes;

public class Varchar : AbstractAttribute
{
    public int MaxLenght { get; private set; }

    public VarcharRepresentation VarcharRepresentation { get; private set; }



    public Varchar(DataType type, string name, int maxLenght, VarcharRepresentation varcharRepresentation) : base(type, name)
    {
        MaxLenght = maxLenght;
        VarcharRepresentation = varcharRepresentation;
    }
}
