using InsertGeneration.Entities;

namespace InsertGeneration.Services;

public interface IQueryGenerator
{
    string SqlBuild(List<SqlAttribute> attributes, string tableName);

}
