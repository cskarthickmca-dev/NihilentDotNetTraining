namespace CatalogRepositories;

using CatalogEntities;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class JSONCatalogManager
{
    // This class is intended to manage catalog data stored in JSON format.
    // Implementation details would include methods for reading from and writing to JSON files,
    // as well as converting between JSON data and Product objects.

    private static string GetJsonFilePath()
    {
        return Path.Combine(Directory.GetCurrentDirectory(), "Data", "products.json");
    }

    private static string GetJsonFilePathForRegister()
    {
        return Path.Combine(Directory.GetCurrentDirectory(), "Data", "customers.json");
    }

    public static IEnumerable<Product>? LoadProducts()
    {
        string filePath = @"C:\dotNet_Training\NihilentDotNetTraining\Day15\TransflowerSolution\Data\products.json";
        var json = File.ReadAllText(filePath);


        //var json = File.ReadAllText(GetJsonFilePath());
        return JsonSerializer.Deserialize<IEnumerable<Product>>(json);
    }

    public static void SaveProducts(IEnumerable<Product> products)
    {
        string filePath = @"C:\dotNet_Training\NihilentDotNetTraining\Day15\TransflowerSolution\Data\products.json";
        var json = JsonSerializer.Serialize(products);
        File.WriteAllText(filePath, json);
    }

    public static IEnumerable<Register>? LoadUsers()
    {
        string filePath = @"C:\dotNet_Training\NihilentDotNetTraining\Day15\TransflowerSolution\Data\customers.json";
        var json = File.ReadAllText(filePath);


        //var json = File.ReadAllText(GetJsonFilePath());
        return JsonSerializer.Deserialize<IEnumerable<Register>>(json);
    }

    public static void SaveRegistrationData(List<Register> register)
    {
        Console.WriteLine("update user insdie json catalog:::::"+register);
        string filePath = @"C:\dotNet_Training\NihilentDotNetTraining\Day15\TransflowerSolution\Data\customers.json";
        var json = JsonSerializer.Serialize(register);
        File.WriteAllText(filePath, json);
    }
}