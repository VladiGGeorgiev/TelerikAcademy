using System;
using System.Collections.Generic;
using System.Threading;

class Cooking
{
    static List<string> RecipeProducts = new List<string>();
    static List<string> RecipeUnits = new List<string>();
    static List<decimal> RecipeAmounts = new List<decimal>();
    static List<string> originalUnits = new List<string>();
    static void Main()
    {
        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        int recipeLines = int.Parse(Console.ReadLine());

        for (int i = 0; i < recipeLines; i++)
        {
            string recipeLine = Console.ReadLine();
            string[] tokens = recipeLine.Split(':');
            var amount = decimal.Parse(tokens[0]);
            string unit = tokens[1];
            string product = tokens[2];

            AddProduct(product, amount, unit);
        }

        int addProductsLines = int.Parse(Console.ReadLine());
        for (int i = 0; i < addProductsLines; i++)
        {
            string addLine = Console.ReadLine();
            string[] tokens = addLine.Split(':');
            var amount = decimal.Parse(tokens[0]);
            string unit = tokens[1];
            string product = tokens[2];

            UpdateProduct(product, amount, unit);
        }

        for (int i = 0; i < RecipeProducts.Count; i++)
        {
            if (RecipeAmounts[i] > 0)
            {
                Console.WriteLine("{0:f2}:{1}:{2}",
                    ConvertToOriginal(RecipeUnits[i], RecipeAmounts[i]),
                    RecipeUnits[i],
                    RecipeProducts[i]
                );
            }
        }
    }

    private static void UpdateProduct(string product, decimal amount, string unit)
    {
        decimal millilitersAmount = ConvertToMls(unit, amount);
        for (int i = 0; i < RecipeProducts.Count; i++)
        {
            if (string.Compare(RecipeProducts[i], product, true) == 0)
            {
                RecipeAmounts[i] -= millilitersAmount;
                return;
            }
        }
    }

    private static void AddProduct(string product, decimal amount, string unit)
    {
        decimal millilitersAmount = ConvertToMls(unit, amount);
        for (int i = 0; i < RecipeProducts.Count; i++)
        {
            if (string.Compare(RecipeProducts[i], product, true) == 0)
            {
                RecipeAmounts[i] += millilitersAmount;
                return;
            }
        }

        RecipeProducts.Add(product);
        RecipeAmounts.Add(millilitersAmount);
        RecipeUnits.Add(unit);
    }
    public static decimal ConvertToMls(string unit, decimal amount)
    {
        switch (unit)
        {
            case "mls":
            case "milliliters":
                return amount;
            case "tbsps":
            case "tablespoons":
                return amount * 15;
            case "ls":
            case "liters":
                return amount * 1000;
            case "fl ozs":
            case "fluid ounces":
                return amount * 30;
            case "tsps":
            case "teaspoons":
                return amount * 5;
            case "gals":
            case "gallons":
                return amount * 3840;
            case "pts":
            case "pints":
                return amount * 480;
            case "qts":
            case "quarts":
                return amount * 960;
            case "cups":
                return amount * 240;
            default: throw new ArgumentException("Wrong unit!");
        }
    }

    public static decimal ConvertToOriginal(string unit, decimal amount)
    {
        switch (unit)
        {
            case "mls":
            case "milliliters":
                return amount;
            case "tbsps":
            case "tablespoons":
                return amount / 15;
            case "ls":
            case "liters":
                return amount / 1000;
            case "fl ozs":
            case "fluid ounces":
                return amount / 30;
            case "tsps":
            case "teaspoons":
                return amount / 5;
            case "gals":
            case "gallons":
                return amount / 3840;
            case "pts":
            case "pints":
                return amount / 480;
            case "qts":
            case "quarts":
                return amount / 960;
            case "cups":
                return amount / 240;
            default: throw new ArgumentException("Wrong unit!");
        }
    }
}