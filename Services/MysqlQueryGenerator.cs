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
        }
        sb.AppendLine(") ");

        for (int i = 0; i < quantidade; i++)
        {

            sb.Append("VALUES");

            sb.Append(" (");
            foreach (AbstractAttribute attr in attributes)
            {
                switch (attr.Type)
                {
                    case DataType.Varchar:

                        Varchar? castedAttribute = attr as Varchar;


                        switch (castedAttribute?.VarcharRepresentation)
                        {
                            case VarcharRepresentation.Name:
                                sb.Append("'Gabriel'");
                                break;
                            case VarcharRepresentation.Email:
                                sb.Append("'Gabriel@gmail.com'");
                                break;
                            case VarcharRepresentation.CPF:
                                sb.Append("'123.123.132-12'");
                                break;
                            case VarcharRepresentation.CNPJ:
                                sb.Append("'123123.1312-3131/21'");
                                break;
                            case VarcharRepresentation.Text:
                                sb.Append("'TextoTextoTexto'");
                                break;
                        }


                        break;
                    case DataType.Bool:
                        sb.Append("true");
                        break;
                    case DataType.Date:
                        sb.Append("2020-10-02");
                        break;
                    case DataType.Double:
                        sb.Append("123.12");
                        break;
                    case DataType.Int:
                        sb.Append("12");
                        break;

                }
                if (attr != attributes.Last())
                {
                    sb.Append(",");
                }
            }
            sb.Append(")");

            if (i != quantidade - 1)
            {
                sb.AppendLine(",");
            }
            else
            {

                sb.Append(";");
            }
        }

        return sb.ToString();
    }
}
