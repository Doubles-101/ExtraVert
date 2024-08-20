List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Snake Plant",
        LightNeeds = 4,
        AskingPrice = 15.99M,
        City = "Houston",
        ZIP = 2156788,
        Sold = false
    },
    new Plant()
    {
        Species = "Aloe",
        LightNeeds = 4,
        AskingPrice = 19.99M,
        City = "Miami",
        ZIP = 1234567,
        Sold = false
    },
    new Plant()
    {
        Species = "Banzai",
        LightNeeds = 2,
        AskingPrice = 29.99M,
        City = "Portland",
        ZIP = 4047899,
        Sold = true
    },
    new Plant()
    {
        Species = "Aspen",
        LightNeeds = 3,
        AskingPrice = 59.99M,
        City = "Grand Rapids",
        ZIP = 215678,
        Sold = false
    },
    new Plant()
    {
        Species = "Weeping Willow",
        LightNeeds = 2,
        AskingPrice = 99.99M,
        City = "Nashville",
        ZIP = 321716,
        Sold = false
    }
};

string greeting = @"Welcome to Pete's Plants!
Where plants are our priority";

Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. Display All Plants
                        2. Post a Plant to be Adopted
                        3. Adopt a Plant
                        4. Delist a Plant");
    choice = Console.ReadLine();

    try 
    {
        switch (choice)
        {
            case "0":
                Console.WriteLine("Goodbye");
                break;
            case "1":
                ListPlants();
                break;
            case "2":
                Console.Clear();
                throw new NotImplementedException("Post a Plant to be Adopted feature is not yet implemented.");
            
            case "3":
                Console.Clear();
                throw new NotImplementedException("Adopt a Plant feature is not yet implemented.");
            
            case "4":
                Console.Clear();
                throw new NotImplementedException("Delist a Plant feature is not yet implemented.");
        }
    }
    catch (NotImplementedException ex)
    {
        Console.Clear();
        Console.WriteLine(ex.Message);
    }
}

void ListPlants()
{
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }
}
