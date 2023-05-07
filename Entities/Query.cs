

using InsertGeneration.Entities.Abstract;
using InsertGeneration.Services;

namespace InsertGeneration.Entities;

public class Query
{
    public List<AbstractAttribute> SqlAttributes { get; private set; }


    public Query(List<AbstractAttribute> sqlAttributes)
    {
        SqlAttributes = sqlAttributes;
    }

    public void Build(IQueryGenerator queryGenerator, string tableName, int quantidade)
    {

        string query = queryGenerator.SqlBuild(SqlAttributes, tableName, quantidade);



        Console.WriteLine($"{query}");



    }
}
