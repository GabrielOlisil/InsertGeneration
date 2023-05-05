

using InsertGeneration.Services;

namespace InsertGeneration.Entities;

public class Query
{
    public List<SqlAttribute> SqlAttributes { get; private set; }


    public Query(List<SqlAttribute> sqlAttributes)
    {
        SqlAttributes = sqlAttributes;
    }

    public void Build(IQueryGenerator queryGenerator, string tableName)
    {

        string query = queryGenerator.SqlBuild(SqlAttributes, tableName);



        Console.WriteLine($"{query}");

    }
}
