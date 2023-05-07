global using System.Globalization;

using InsertGeneration.Entities;
using InsertGeneration.Entities.Abstract;
using InsertGeneration.Entities.DataTypes;
using InsertGeneration.Services;
bool looping = true;

List<AbstractAttribute> attributes = new List<AbstractAttribute>();


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

    DataType dt = DataType.Int;


    bool isDtValid = false;


    while (!isDtValid)
    {

        isDtValid = Enum.TryParse<DataType>(Console.ReadLine(), out dt);

        if (!isDtValid)
        {
            Console.WriteLine($"Insert an Valid Value");

        }
    }


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

    switch (dt)
    {
        case DataType.Varchar:

            Console.WriteLine($"Enter the max lenght of the value");


            bool isNumber = false;

            int maxLenght = 0;

            while (!isNumber)
            {
                isNumber = int.TryParse(Console.ReadLine(), out int maxVarcharLenght);

                if (!isNumber)
                {
                    Console.WriteLine($"Value must be a Number");
                }
                maxLenght = maxVarcharLenght;
            }


            isNumber = false;




            Console.WriteLine($"Choose a Representation for this value");
            Console.WriteLine($"Name = 1");
            Console.WriteLine($"Email = 2");
            Console.WriteLine($"CPF = 3");
            Console.WriteLine($"CNPJ = 4");
            Console.WriteLine($"Text = 5");



            VarcharRepresentation representation = VarcharRepresentation.Name;



            bool isRepresentationValid = false;

            while (!isRepresentationValid)
            {
                isRepresentationValid = Enum.TryParse<VarcharRepresentation>(Console.ReadLine(), out representation);

                if (!isRepresentationValid)
                {
                    Console.WriteLine($"Option don't match");

                }
            }



            attributes.Add(new Varchar(dt, name, maxLenght, representation));

            break;
        case DataType.Int:


            Console.WriteLine($"Enter the min value");

            int minValue = 0;

            isNumber = false;

            while (!isNumber)
            {
                isNumber = int.TryParse(Console.ReadLine(), out int minIntValue);

                if (!isNumber)
                {
                    Console.WriteLine($"Value must be a Number");
                }
                minValue = minIntValue;
            }


            Console.WriteLine($"Enter the max value");
            int maxValue = 0;

            isNumber = false;

            while (!isNumber)
            {
                isNumber = int.TryParse(Console.ReadLine(), out int maxIntValue);

                if (!isNumber)
                {
                    Console.WriteLine($"Value must be a Number");
                }
                maxValue = maxIntValue;
            }

            attributes.Add(new Int(dt, name, minValue, maxValue));

            break;

        case DataType.Double:


            Console.WriteLine($"Enter the min value");

            double minDoubleValue = 0.0;

            isNumber = false;

            while (!isNumber)
            {
                isNumber = double.TryParse(Console.ReadLine(), out minDoubleValue);

                if (!isNumber)
                {
                    Console.WriteLine($"Value must be a Number");
                }
            }


            Console.WriteLine($"Enter the max value");
            double maxDoubleValue = 0.0;

            isNumber = false;

            while (!isNumber)
            {
                isNumber = double.TryParse(Console.ReadLine(), out maxDoubleValue);

                if (!isNumber)
                {
                    Console.WriteLine($"Value must be a Number");
                }
            }

            attributes.Add(new DoubleType(dt, name, minDoubleValue, maxDoubleValue));

            break;

        case DataType.Date:

            Console.WriteLine($"Enter the min date: (yyyy/MM/dd)");

            DateTime minDateValue = DateTime.Now;

            bool isMinDateValid = false;

            while (!isMinDateValid)
            {
                isMinDateValid = DateTime.TryParse(Console.ReadLine(), out DateTime minDate);

                if (!isMinDateValid)
                {
                    Console.WriteLine($"The date wasn't in a correct format, prime again");

                }
                else
                {
                    minDateValue = minDate;
                }
            }


            DateTime maxDateValue = DateTime.Now;

            bool isMaxDateValid = false;

            while (!isMaxDateValid)
            {
                isMaxDateValid = DateTime.TryParse(Console.ReadLine(), out DateTime maxDate);

                if (!isMaxDateValid)
                {
                    Console.WriteLine($"The date wasn't in a correct format, prime again");

                }
                else
                {
                    maxDateValue = maxDate;
                }
            }



            attributes.Add(new Date(dt, name, minDateValue, maxDateValue));




            break;

    }




    Console.WriteLine($"Want to add more attributes? [S/n]");
    string? option = Console.ReadLine();

    if (option is null || option == "n")
    {
        looping = false;
    }
    Console.Clear();


}

Query query = new Query(attributes);

query.Build(new MysqlQueryGenerator(), tableName, 10);







