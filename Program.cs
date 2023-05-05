global using System.Globalization;

using InsertGeneration.Entities;
using InsertGeneration.Services;
bool looping = true;

List<SqlAttribute> attributes = new List<SqlAttribute>();


Console.WriteLine($"MySql Insert generator");


Console.WriteLine($"Enter the name of the table: ");
string? tableName = null;



while (tableName is null)
{
    tableName = Console.ReadLine();

    if (String.IsNullOrWhiteSpace(tableName))
    {
        Console.WriteLine($"Table must be a word");
    }
}

while (looping)
{
    Console.WriteLine($"Select typeof the attribute");
    Console.WriteLine($"Varchar = 1");
    Console.WriteLine($"Integer = 2");
    Console.WriteLine($"Float = 3");
    Console.WriteLine($"Bool = 4");
    Console.WriteLine($"Date = 5");

    Console.WriteLine($"Specific Data types");

    Console.WriteLine($"Name = 6");
    Console.WriteLine($"Email = 7");

    DataType dt = Enum.Parse<DataType>(Console.ReadLine());


    Console.WriteLine($"Enter the name of the attribute");
    string? name = null;

    while (name is null)
    {
        name = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine($"Attribute must be a word");
        }
    }



    attributes.Add(new SqlAttribute(name, dt));


    Console.WriteLine($"Want to add more attributes? [S/n]");
    string? option = Console.ReadLine();

    if (option is null || option == "n")
    {
        looping = false;
    }

}

Query query = new Query(attributes);

query.Build(new MysqlQueryGenerator(), tableName);







