

using InsertGeneration.Entities.Abstract;
using InsertGeneration.Entities.DataTypes;
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

        foreach (AbstractAttribute attr in SqlAttributes)
        {
            switch (attr)
            {
                case Varchar var:

                    switch (var.VarcharRepresentation)
                    {
                        case VarcharRepresentation.Name:
                            attr.Value = "Gabriel de Oliveira Silva";
                            break;
                        case VarcharRepresentation.Email:
                            attr.Value = "gabriel@gmail.com";

                            break;
                        case VarcharRepresentation.CPF:
                            attr.Value = "091.012.123-12";
                            break;
                        case VarcharRepresentation.CNPJ:
                            attr.Value = "091.012.123-12";
                            break;
                        case VarcharRepresentation.Text:
                            attr.Value = "Qualquer coisa";
                            break;
                    }
                    break;

                case Bool:
                    attr.Value = "false";
                    break;

                case Date:
                    attr.Value = "2020-10-02";
                    break;

                case DoubleType:
                    attr.Value = "202.00";
                    break;

                case Int:
                    attr.Value = "202";
                    break;
            }
        }

        string query = queryGenerator.SqlBuild(SqlAttributes, tableName, quantidade);

        var path = $"{Path.GetTempFileName()}.sql";
        var fs = new FileInfo(path);
        using (var sw = fs.CreateText())
        {
            sw.Write(query);
        }

        Console.WriteLine($"O arquvo foi gerado em {path}");
        Console.ReadKey();





    }
}
