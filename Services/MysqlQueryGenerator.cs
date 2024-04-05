using System.Text;
using InsertGeneration.Entities;
using InsertGeneration.Entities.Abstract;
using InsertGeneration.Entities.DataTypes;

namespace InsertGeneration.Services;

public class MysqlQueryGenerator : IQueryGenerator
{
    public string SqlBuild(List<AbstractAttribute> attributes, string tableName, int quantidade)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("INSERT INTO ");
        sb.Append(tableName);
        sb.Append(" (");

        foreach (AbstractAttribute attr in attributes)
        {
            sb.Append(attr.Name);
            if (attr != attributes.Last())
            {
                sb.Append(",");
            }
            else
            {
                sb.AppendLine(")");
            }
        }

        for (int i = 0; i < quantidade; i++)
        {

            sb.Append("VALUES (");

            foreach (AbstractAttribute attr in attributes)
            {

                if (attr is Varchar || attr is Date)
                {

                    sb.Append($"'{attr.Value}'");
                }
                else
                {
                    sb.Append(attr.Value);
                }


                if (attr != attributes.Last())
                {
                    sb.Append(",");
                }
                else
                {
                    if (i == quantidade - 1)
                    {
                        sb.AppendLine(");");
                    }
                    else
                    {
                        sb.AppendLine("),");

                    }
                }

            }
        }

        return sb.ToString();
    }
}
