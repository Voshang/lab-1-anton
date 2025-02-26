using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Cocktail
{
    public string Name { get; set; }
    public int IngredientCount { get; set; }
    public List<double> AlcoholDegrees { get; set; }
    public List<double> IngredientCosts { get; set; }
    public double TotalMass { get; set; }
    public string Color { get; set; }
    public static int CocktailCount { get; private set; } = 0;

    public Cocktail()
    {
        Name = "Unnamed";
        IngredientCount = 0;
        AlcoholDegrees = new List<double>();
        IngredientCosts = new List<double>();
        TotalMass = 0;
        Color = "Unknown";
        CocktailCount++;
    }

    public Cocktail(string name, int ingredientCount, List<double> alcoholDegrees, List<double> ingredientCosts, double totalMass, string color)
    {
        Name = name;
        IngredientCount = ingredientCount;
        AlcoholDegrees = new List<double>(alcoholDegrees);
        IngredientCosts = new List<double>(ingredientCosts);
        TotalMass = totalMass;
        Color = color;
        CocktailCount++;
    }

    public void Display()
    {
        Console.WriteLine($"Коктейль: {Name}");
        Console.WriteLine($"Число ингредиентов: {IngredientCount}");
        Console.WriteLine($"Градусы алкоголя: {string.Join(", ", AlcoholDegrees)}");
        Console.WriteLine($"Стоимость ингредиентов: {string.Join(", ", IngredientCosts)}");
        Console.WriteLine($"Общая масса: {TotalMass}");
        Console.WriteLine($"Цвет: {Color}");
    }

    public void FillFromInput()
    {
        Console.Write("Введите название коктейля: ");
        Name = Console.ReadLine();

        int temp;
        do
        {
            Console.Write("Введите количество ингредиентов: ");
        } while (!int.TryParse(Console.ReadLine(), out temp) || temp <= 0);

        IngredientCount = temp;
        AlcoholDegrees = new List<double>();
        IngredientCosts = new List<double>();
        for (int i = 0; i < IngredientCount; i++)
        {
            Console.Write($"Градус алкоголя для ингредиента {i + 1}: ");
            AlcoholDegrees.Add(double.Parse(Console.ReadLine()));
            Console.Write($"Стоимость ингредиента {i + 1}: ");
            IngredientCosts.Add(double.Parse(Console.ReadLine()));
        }
    }

    public static bool CompareByIngredients(Cocktail a, Cocktail b)
    {
        return a.IngredientCount > b.IngredientCount;
    }
}

class Program
{
    static void Main()
    {
        List<Cocktail> bar = new List<Cocktail>
        {
            new Cocktail("Mojito", 3, new List<double> { 0, 40, 10 }, new List<double> { 5, 10, 7 }, 250, "Green"),
            new Cocktail("Cosmopolitan", 4, new List<double> { 20, 40, 30, 0 }, new List<double> { 8, 12, 9, 5 }, 300, "Pink")
        };

        foreach (var cocktail in bar)
        {
            cocktail.Display();
            Console.WriteLine();
        }

        Console.WriteLine("Введите данные для последнего коктейля вручную:");
        bar[bar.Count - 1].FillFromInput();
        bar[bar.Count - 1].Display();

        Console.WriteLine("Сравнение коктейлей:");
        Console.WriteLine(Cocktail.CompareByIngredients(bar[0], bar[1]) ? "Первый сложнее" : "Второй сложнее");

        Console.WriteLine($"Число созданных коктейлей: {Cocktail.CocktailCount}");
        Console.WriteLine("УРРРРАААА ! ! ! !");
    }
}

