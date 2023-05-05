using System.Text;
using InsertGeneration.Entities;

namespace InsertGeneration.Services;

public class MysqlQueryGenerator : IQueryGenerator
{
    public string SqlBuild(List<SqlAttribute> attributes, string tableName)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("INSERT INTO ");
        sb.Append(tableName);
        sb.Append(" (");

        foreach (SqlAttribute attr in attributes)
        {
            sb.Append(attr.Name);
            if (attr != attributes.Last())
            {
                sb.Append(",");
            }
        }
        sb.Append(") ");
        sb.Append("VALUES");

        sb.Append(" (");
        foreach (SqlAttribute attr in attributes)
        {
            switch (attr.Type)
            {
                case DataType.Varchar:
                    sb.Append("'Gabriel'");
                    break;
                case DataType.Bool:
                    sb.Append("true");
                    break;
                case DataType.Date:
                    sb.Append("2020-10-02");
                    break;
                case DataType.Email:
                    sb.Append("Gabriel@gmail.com");
                    break;
                case DataType.Float:
                    sb.Append("123.12");
                    break;
                case DataType.Int:
                    sb.Append("12");
                    break;
                case DataType.Name:
                    sb.Append("Gabriel");
                    break;

            }
            if (attr != attributes.Last())
            {
                sb.Append(",");
            }
        }
        sb.Append(");");

        return sb.ToString();
    }
}
