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
                Console.Clear();
                ListPlants();
                break;
            case "2":
                Console.Clear();
                PostPlant();
                break;
            
            case "3":
                Console.Clear();
                AdoptPlant();
                break;
            
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
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for ${plants[i].AskingPrice}");
    }
}

void PostPlant()
{
    Console.WriteLine("Enter Species: ");
    string species = Console.ReadLine();

    Console.WriteLine("Enter Light Needs (1-5): ");
    int lightNeeds;
    while (!int.TryParse(Console.ReadLine(), out lightNeeds) || lightNeeds < 1 || lightNeeds > 5)
    {
        Console.WriteLine("Please enter a valid number between 1 and 5.");
    }

    Console.WriteLine("Enter an Asking Price: ");
    decimal askingPrice;
    while (!decimal.TryParse(Console.ReadLine(), out askingPrice))
    {
        Console.WriteLine("Please enter a valid price.");
    }

    Console.WriteLine("Enter City: ");
    string city = Console.ReadLine();

    Console.Write("Enter ZIP Code: ");
    int zip;
    while (!int.TryParse(Console.ReadLine(), out zip))
    {
        Console.WriteLine("Please enter a valid ZIP code.");
    }

    Plant newPlant = new Plant()
    {
        Species = species,
        LightNeeds = lightNeeds,
        AskingPrice = askingPrice,
        City = city,
        ZIP = zip,
        Sold = false
    };

    plants.Add(newPlant);
    Console.WriteLine($"{species} has been added to the list of plants available for adoption.");
}

void AdoptPlant()
{
    for (int i = 0; i < plants.Count; i++)
    {
        if (!plants[i].Sold) {
            Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for ${plants[i].AskingPrice}");
        }
    }

    Console.WriteLine("Enter your the plant you wish to adopt: ");
    int plantChoice;
    while (!int.TryParse(Console.ReadLine(), out plantChoice) || plantChoice < 1 || plantChoice > plants.Count || plants[plantChoice -1].Sold) 
    {
        Console.WriteLine("Please enter a valid number of an available plant");
    }

    plants[plantChoice - 1].Sold = true;
    Console.WriteLine($"You have adopted {plants[plantChoice - 1].Species}");
}