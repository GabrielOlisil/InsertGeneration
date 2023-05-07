using InsertGeneration.Entities;
using InsertGeneration.Entities.Abstract;

namespace InsertGeneration.Services;

public interface IQueryGenerator
{
    string SqlBuild(List<AbstractAttribute> attributes, string tableName, int quantidade);

}
