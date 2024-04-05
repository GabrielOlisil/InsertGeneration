

using InsertGeneration.Entities.Abstract;

namespace InsertGeneration.Entities.DataTypes;

public class Varchar : AbstractAttribute
{
    public int MaxLenght { get; private set; }

    public VarcharRepresentation VarcharRepresentation { get; private set; }



    public Varchar(string name, int maxLenght, VarcharRepresentation varcharRepresentation) : base(name)
    {
        MaxLenght = maxLenght;
        VarcharRepresentation = varcharRepresentation;
    }
}
