List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Snake Plant",
        LightNeeds = 4,
        AskingPrice = 15.99M,
        City = "Houston",
        ZIP = 2156788,
        Sold = false,
        AvailableUntil = new DateTime(2024, 12, 31)
    },
    new Plant()
    {
        Species = "Aloe",
        LightNeeds = 4,
        AskingPrice = 19.99M,
        City = "Miami",
        ZIP = 1234567,
        Sold = false,
        AvailableUntil = new DateTime(2024, 11, 15)
    },
    new Plant()
    {
        Species = "Banzai",
        LightNeeds = 2,
        AskingPrice = 29.99M,
        City = "Portland",
        ZIP = 4047899,
        Sold = true,
        AvailableUntil = new DateTime(2024, 10, 20)
    },
    new Plant()
    {
        Species = "Aspen",
        LightNeeds = 3,
        AskingPrice = 59.99M,
        City = "Grand Rapids",
        ZIP = 215678,
        Sold = false,
        AvailableUntil = new DateTime(2024, 9, 15)
    },
    new Plant()
    {
        Species = "Weeping Willow",
        LightNeeds = 2,
        AskingPrice = 99.99M,
        City = "Nashville",
        ZIP = 321716,
        Sold = false,
        AvailableUntil = new DateTime(2024, 8, 1)
    }
};

Random random = new Random();
int randomInteger = random.Next(0, plants.Count);

while (plants[randomInteger].Sold){
    randomInteger = random.Next(0, plants.Count);
}

string greeting = @"Welcome to Pete's Plants!
Where plants are our priority";

string plantOfTheDay = @$"

Our plant of the day:
Species: {plants[randomInteger].Species}
City: {plants[randomInteger].City}
Light Needs: {plants[randomInteger].LightNeeds}
Price: {plants[randomInteger].AskingPrice}
Available Until: {plants[randomInteger].AvailableUntil}

";

Console.Clear();
Console.WriteLine(greeting);
Console.WriteLine(plantOfTheDay);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. Display All Plants
                        2. Post a Plant to be Adopted
                        3. Adopt a Plant
                        4. Delist a Plant
                        5. Search by Light Need");
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
                DelistPlant();
                break;

            case "5":
                Console.Clear();
                LightNeedSearch();
                break;
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
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for ${plants[i].AskingPrice}. Available until: {plants[i].AvailableUntil}");
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
Console.WriteLine("Enter the year when the plant will be available until: ");
    int year;
    while (!int.TryParse(Console.ReadLine(), out year) || year < DateTime.Now.Year)
    {
        Console.WriteLine("Please enter a valid year.");
    }

    Console.WriteLine("Enter the month (1-12) when the plant will be available until: ");
    int month;
    while (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12)
    {
        Console.WriteLine("Please enter a valid month.");
    }

    Console.WriteLine("Enter the day (1-31) when the plant will be available until: ");
    int day;
    while (!int.TryParse(Console.ReadLine(), out day) || day < 1 || day > DateTime.DaysInMonth(year, month))
    {
        Console.WriteLine("Please enter a valid day.");
    }

    DateTime availableUntil = new DateTime(year, month, day);

    Plant newPlant = new Plant()
    {
        Species = species,
        LightNeeds = lightNeeds,
        AskingPrice = askingPrice,
        City = city,
        ZIP = zip,
        Sold = false,
        AvailableUntil = availableUntil
    };


    plants.Add(newPlant);
    Console.WriteLine($"{species} has been added to the list of plants available for adoption.");
}

void AdoptPlant()
{
    for (int i = 0; i < plants.Count; i++)
    {
        if (!plants[i].Sold && plants[i].AvailableUntil >= DateTime.Now) {
            Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for ${plants[i].AskingPrice}");
        }
    }

    Console.WriteLine("Enter your the plant you wish to adopt: ");
    int plantChoice;
    while (!int.TryParse(Console.ReadLine(), out plantChoice) || plantChoice < 1 || plantChoice > plants.Count || plants[plantChoice -1].Sold || plants[plantChoice -1].AvailableUntil <= DateTime.Now) 
    {
        Console.WriteLine("Please enter a valid number of an available plant");
    }

    plants[plantChoice - 1].Sold = true;
    Console.WriteLine($"You have adopted {plants[plantChoice - 1].Species}");
}

void DelistPlant()
{
    ListPlants();

    Console.WriteLine("Enter the plant you wish to delist");

    int delistChoice;
    while (!int.TryParse(Console.ReadLine(), out delistChoice) || delistChoice < 1 || delistChoice > plants.Count)
    {
        Console.WriteLine("Please enter a valid number of the plant you wish to delist");
    }

    plants.RemoveAt(delistChoice - 1);
    Console.WriteLine("The plant has been successfully removed");
}

void LightNeedSearch()
{
    Console.WriteLine("Enter a maximum light needs number (between 1 and 5)");

    int lightNeedChoice;
    while (!int.TryParse(Console.ReadLine(), out lightNeedChoice) || lightNeedChoice < 1 || lightNeedChoice > 5)
    {
        Console.WriteLine("Please enter a valid number between 1 and 5");
    }

    foreach (var plant in plants)
    {
        if (plant.LightNeeds <= lightNeedChoice)
        {
            Console.WriteLine($"{plant.Species} in {plant.City} {(plant.Sold ? "was sold" : "is available")} for ${plant.AskingPrice}. Light Need: {plant.LightNeeds}");
        }
    }

}