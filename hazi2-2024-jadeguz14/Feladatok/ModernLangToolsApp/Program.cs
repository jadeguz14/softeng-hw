using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace ModernLangToolsApp;

public class Program
{   
    private static void MessageReceived(string message)
    {
        Console.WriteLine(message);
    }

    [Description("Feladat2")]
    public static void test2(Jedi jedi)
    {
        var serializer = new XmlSerializer(typeof(Jedi));
        var outStream = new FileStream("jedi.txt", FileMode.Create);
        serializer.Serialize(outStream, jedi);
        outStream.Close();
        var deSerializer = new XmlSerializer(typeof(Jedi));
        var inStream = new FileStream("jedi.txt", FileMode.Open);
        var clone = (Jedi)serializer.Deserialize(inStream);
        inStream.Close();
    }

    [Description("Feladat3")]
    public static void test3()
    {
        var council = new JediCouncil();
        council.JediCouncilChangedMember += MessageReceived;

        for (int i = 1; i <= 2; i++)
            council.Add(new Jedi { Name = $"Jedi #{i}" });

        council.Remove();
        council.Remove();
    }

    [Description("Feladat4")]
    public static void test4()
    {
        var council = InitializeCouncil();
        var res = council.Search_Delegate();
        
        foreach (Jedi jedi in res)
        {
            Console.WriteLine(jedi.Name);
        }
    }

    [Description("Feladat5")]
    public static void test5()
    {
        var council = InitializeCouncil();
        var res = council.Search_Lambda();

        foreach (Jedi jedi in res)
        {
            Console.WriteLine(jedi.Name);
        }
    }
    static JediCouncil InitializeCouncil()
    {
        JediCouncil council = new JediCouncil();
        council.Add(new Jedi { Name = "Obi-Wan Kenobi", MidiChlorianCount = 600 });
        council.Add(new Jedi { Name = "Anakin Skywalker", MidiChlorianCount = 1200 });
        council.Add(new Jedi { Name = "Yoda", MidiChlorianCount = 1100 });
        council.Add(new Jedi { Name = "Luke Skywalker", MidiChlorianCount = 400 });
        council.Add(new Jedi { Name = "Mace Windu", MidiChlorianCount = 500 });
        return council;
    }

    [Description("Feladat6")]
    static void test6()
    {
        var employees = new Person[] { new Person("Joe", 20), new Person("Jill", 30) };

        ReportPrinter reportPrinter = new(
            employees,
            () => Console.WriteLine("Employees"),
            () => Console.WriteLine($"Number of Employees: {employees.Length}"),
            (person) => Console.WriteLine($"Name: {person.Name} (Age: {person.Age})")
        );

        reportPrinter.PrintReport();
    }
    public static void Main(string[] args)
    {
        Jedi jedi1 = new Jedi();
        jedi1.Name = "Anakin Skywalker";
        jedi1.MidiChlorianCount = 20000;

        Console.WriteLine($"Jedi name: {jedi1.Name}, Midi chlorian count: {jedi1.MidiChlorianCount}");

        Jedi jedi2 = new Jedi();
        jedi2.Name = "Obi-Wan Kenobi";
        jedi2.MidiChlorianCount = 15000;

        test2(jedi1);
        test3();
        test4();
        test5();
        test6();
    }
}
