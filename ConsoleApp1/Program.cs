// See https://aka.ms/new-console-template for more information

public class Program
{
    public string Name { get; set; } = "";
    public bool IsNameShrirang => Name == "Shrirangubale";
    public static void Main()
    {
        Program program = new Program { Name = "Shriranga" };
        Console.WriteLine($"Enter First Name {program.Name} and {program.IsNameShrirang} ");

        Console.WriteLine("Welcome!");


    }

}