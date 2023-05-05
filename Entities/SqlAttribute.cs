
namespace InsertGeneration.Entities;

public class SqlAttribute
{
    public string Name { get; set; }
    public DataType Type { get; set; }



    public SqlAttribute(string name, DataType type)
    {
        Name = name;
        Type = type;
    }
}
