using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: create|read|update|delete [args]");
            return;
        }

        var connectionString = Environment.GetEnvironmentVariable("SQL_CONN_STR")
            ?? "Server=localhost;Database=DemoDb;Trusted_Connection=True;";

        var crud = new CrudOperations(connectionString);

        switch (args[0].ToLowerInvariant())
        {
            case "create":
                if (args.Length < 3)
                {
                    Console.WriteLine("Usage: create <first> <last>");
                    return;
                }
                crud.CreatePerson(args[1], args[2]);
                Console.WriteLine("Person created.");
                break;
            case "read":
                foreach (var p in crud.ReadPeople())
                {
                    Console.WriteLine($"{p.Id}: {p.FirstName} {p.LastName}");
                }
                break;
            case "update":
                if (args.Length < 4)
                {
                    Console.WriteLine("Usage: update <id> <first> <last>");
                    return;
                }
                crud.UpdatePerson(int.Parse(args[1]), args[2], args[3]);
                Console.WriteLine("Person updated.");
                break;
            case "delete":
                if (args.Length < 2)
                {
                    Console.WriteLine("Usage: delete <id>");
                    return;
                }
                crud.DeletePerson(int.Parse(args[1]));
                Console.WriteLine("Person deleted.");
                break;
            default:
                Console.WriteLine("Unknown command");
                break;
        }
    }
}
