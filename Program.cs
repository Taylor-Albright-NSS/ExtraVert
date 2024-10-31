using System.Linq.Expressions;
using System.Text.Encodings.Web;
using System.Xml.Serialization;

Dictionary<string, int> inventory = new Dictionary<string, int>();

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        PlantType = "tree",
        Species = "Tree",
        LightNeeds = 5,
        AskingPrice = 45.50,
        City = "Knoxville",
        ZIP = 37076,
        Sold = false,
        AvailableUntil = new DateTime(2024, 10, 30)
    },
    new Plant()
    {
        PlantType = "herb",
        Species = "Bush",
        LightNeeds = 4,
        AskingPrice = 23.50,
        City = "Nashville",
        ZIP = 22353,
        Sold = false,
        AvailableUntil = new DateTime(2024, 10, 23)
    },
    new Plant()
    {
        PlantType = "bush",
        Species = "Grass",
        LightNeeds = 3,
        AskingPrice = 10.00,
        City = "Tampa",
        ZIP = 53575,
        Sold = false,
        AvailableUntil = new DateTime(2024, 10, 23)
    },
    new Plant()
    {
        PlantType = "flower",
        Species = "Venus Fly Trap",
        LightNeeds = 2,
        AskingPrice = 35.50,
        City = "Phoenix",
        ZIP = 12575,
        Sold = true,
        AvailableUntil = new DateTime(2024, 10, 30)
    },
    new Plant()
    {
        PlantType = "flower",
        Species = "Fern",
        LightNeeds = 2,
        AskingPrice = 5.00,
        City = "Frankfurt",
        ZIP = 475773,
        Sold = false,
        AvailableUntil = new DateTime(2024, 10, 30)
    },
};




string greeting = "Greetings! Welcome to the ExtraVert plant shop!";
Console.WriteLine(greeting);
DisplayMainOptions();

string choice = null;
while (choice != "z")
{
    choice = Console.ReadLine().Trim().ToLower();
    switch (choice)
    {
        case "a":
        displayPlants();
        break;
        case "b":
        postPlant();
        break;
        case "c":
        adoptPlant();
        break;
        case "d":
        delistPlant();
        break;
        case "e":
        plantOfTheDay();
        break;
        case "f":
        search();
        break;
        case "g":
        showStatistics();
        break;
        case "h":
        InventoryBySpecies(inventory);
        break;
        case "m":
        DisplayMainOptions();
        break;
        case "z":
        Console.WriteLine("Exiting the list!");
        break;
        default:
        Console.WriteLine("Please enter a valid option");
        break;
    }
}

void displayPlants()
{
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {PlantDetails(plants[i])} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice} dollars.");
    }

}

void postPlant()
{
    string[] plantTypes =
    {  
        "tree",
        "bush",
        "flower",
        "herb"
    };

    Console.WriteLine("To post a plant, please enter a value for each option below:");

    Console.WriteLine("Please enter a plant type for your plant:");

    int listCount = 1;
    foreach (string type in plantTypes)
    {
        Console.WriteLine($"{listCount}. {type}");
        listCount++;
    }
    int userChoice;
    string userPlantType = null;
    while (userPlantType == null)
    {
    try 
    {
        userChoice = int.Parse(Console.ReadLine());
        if (userChoice <= 0 || userChoice >= 5)
        {
            throw new ArgumentOutOfRangeException();
        } 
        else 
        {
            userPlantType = plantTypes[userChoice];
        }
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"PLEASE SELECT A VALUE WITHIN THE GIVEN RANGE");
    }
    catch (FormatException)
    {
        Console.WriteLine($"PLEASE ONLY USE INTEGERS");
    }
    }




    Console.WriteLine("Please enter your plant's species:");
    string userSpecies = null;
    while(userSpecies == null)
    {
        try
        {
            userSpecies = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userSpecies))
            {
                Console.WriteLine("PLEASE ENTER A VALUE");
                throw new FormatException();
            }
            else if (int.TryParse(userSpecies, out _))
            {
                Console.WriteLine("You entered a number. Please enter a string name for your species, and do it right!");
                throw new FormatException();
            }
        }
        catch (FormatException)
        {
            userSpecies = null;
        }
    }

    Console.WriteLine("Please enter your plant's light needs on a scale from 1 - 5:");
    int userLightNeeds = 0;
    while (userLightNeeds < 1 || userLightNeeds > 5) 
    {
        try 
        {
            userLightNeeds = int.Parse(Console.ReadLine().Trim());
            if (userLightNeeds < 1 || userLightNeeds > 5)
            {
                throw new FormatException();
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter your plant's light needs on a scale from 1 - 5 correctly this time.");
        }
    }
       
    Console.WriteLine("Please enter your plant's asking price:");
    double userAskingPrice = 0;
    string input;
    while (userAskingPrice <= 0)
    {
        try 
        {
            input = Console.ReadLine();
            if (double.TryParse(input, out userAskingPrice))
            {
                if (userAskingPrice <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
                else
                {
                    throw new FormatException();
                }
        }
        catch(FormatException)
        {
            Console.WriteLine("Please enter a number value for the price! NO LETTERS");
        }
        catch(ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please enter a number value greater than 0!");
        }

    }

    Console.WriteLine("Please enter your city:");
    string userCity = Console.ReadLine();

    Console.WriteLine("Please enter your zip:");
    int userZip = int.Parse(Console.ReadLine());

    Console.WriteLine("Please enter the expiration year of your post (example: 2024):");
    int availableUntilYear = 0;
    while (availableUntilYear < 2024) 
    {
        try 
        {
            availableUntilYear = int.Parse(Console.ReadLine().Trim());
            
            if (availableUntilYear < 2024)
            {
                Console.WriteLine("Year must be 2024 or later. Please try again.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter a valid year.");
        }
    }

    Console.WriteLine("Please enter the expiration month of your post (example: 12):");
    int availableUntilMonth = 0;
    while (availableUntilMonth < 1 || availableUntilMonth > 12)
    {
        try 
        {
            availableUntilMonth = int.Parse(Console.ReadLine());
            if (availableUntilMonth < 1 || availableUntilMonth > 12)
                {
                    Console.WriteLine("Month must be a number between 1 and 12");
                }
        }
        catch (Exception ex)
        {
            Console.Write($"{ex.Message}");
        }
    }

    Console.WriteLine("Please enter the expiration day of your post (example: 31):");
    int availableUntilDay = 0;
    while (availableUntilDay < 1 || availableUntilDay > 30)
    {
        try 
        {
            availableUntilDay = int.Parse(Console.ReadLine());
            if (availableUntilDay < 1 || availableUntilDay > 30)
                {
                    Console.WriteLine("Month must be a number between 1 and 31");  
                }
        }
        catch (Exception ex)
        {
            Console.Write($"{ex.Message}");
        }
    }


    Plant userPlant = new Plant()
    {
        PlantType = userPlantType,
        Species = userSpecies,
        LightNeeds = userLightNeeds,
        AskingPrice = userAskingPrice,
        City = userCity,
        ZIP = userZip,
        AvailableUntil = new DateTime(availableUntilYear, availableUntilMonth, availableUntilDay),
        Sold = false
    };
    plants.Add(userPlant);

    Console.WriteLine($@"
    User entered the following information:
    {PlantDetails(userPlant)}
    {userPlant.PlantType}
    {userPlant.Species}
    {userPlant.LightNeeds}
    {userPlant.AskingPrice}
    {userPlant.City}
    {userPlant.ZIP}
    {userPlant.AvailableUntil}
    ");
}

void adoptPlant()
{
    List<Plant> availablePlants = new List<Plant>();

    DateTime now = DateTime.Now;

    Console.WriteLine("Available plants to adopt:");
    for (int i = 0; i < plants.Count; i++)
    {
        TimeSpan availability = plants[i].AvailableUntil - now;
        if (!plants[i].Sold && availability.Days > 0)
        {
            availablePlants.Add(plants[i]);
        }
    }

    for (int i = 0; i < availablePlants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {PlantDetails(availablePlants[i])}");
    }
    Console.WriteLine("Choose a plant to adopt");
    int userChoice = int.Parse(Console.ReadLine());
    if (userChoice > 0 || userChoice < availablePlants.Count)
    {
        int plantIndex = userChoice - 1;
        Console.WriteLine($"You chose {PlantDetails(availablePlants[plantIndex])}");
        availablePlants[plantIndex].Sold = true;
    }

}

void delistPlant()
{
    Console.WriteLine("Choose a plant to remove from the list:");
    for (int i = 0; i < plants.Count; i++) 
    {
        Console.WriteLine($"{i + 1}. {PlantDetails(plants[i])}");
    }
    int userChoice = int.Parse(Console.ReadLine());
    if (userChoice > 0 || userChoice < plants.Count)
    {
        plants.RemoveAt(userChoice - 1);
    }
}

void plantOfTheDay()
{
    Random random = new Random();
    int randomInteger = random.Next(0, plants.Count);
    while (plants[randomInteger].Sold == true)
    {
        randomInteger = random.Next(0, plants.Count);
    }
    Console.WriteLine("Plant of the day!");
    Console.WriteLine($"Species: {PlantDetails(plants[randomInteger])}");
    Console.WriteLine($"City: {plants[randomInteger].City}");
    Console.WriteLine($"Light needs: {plants[randomInteger].LightNeeds}");
    Console.WriteLine($"Asking price: {plants[randomInteger].AskingPrice} dollars");
}


void search()
{
    List<Plant> lightPlants = new List<Plant>();
    List<Plant> lightPlants2 = new List<Plant>();

    Console.WriteLine("Please enter a light needs value between 1 and 5");
    int userChoice = int.Parse(Console.ReadLine());
    while (userChoice < 1 || userChoice > 5) 

    try {
        Console.WriteLine(@"Your reponse needs to be a number between 1 and 5
Please try again now.");
        userChoice = int.Parse(Console.ReadLine());
    }
    catch (Exception ex) {
        Console.WriteLine($"This is your exception: {ex.Message}");
    }
    //for loop
    for (int i = 0; i < plants.Count; i++)
    {
        if (plants[i].LightNeeds <= userChoice)
        {
            lightPlants.Add(plants[i]);
        }
    }
    //foreach 
    foreach (Plant plant in plants)
    {
        if (plant.LightNeeds <= userChoice)
        {
            lightPlants2.Add(plant);
        }
    }
    //displays plants that fit the search criteria
    foreach (Plant plant in lightPlants)
    {
        Console.WriteLine($"{PlantDetails(plant)}");
    }

}

void showStatistics()
{
    DateTime now = DateTime.Now;
    Plant cheapestPlant = plants[0];
    Plant neediestPlant = plants[0];
    int availablePlants = 0;
    int totalLightNeeds = 0;
    int numberOfAdoptedPlants = 0;

    Console.WriteLine("Plant stats");
    foreach (Plant plant in plants)
    {
        if (plant.AskingPrice < cheapestPlant.AskingPrice ) {
            cheapestPlant = plant;
        }
    }
    Console.WriteLine($"Cheapest plant: {PlantDetails(cheapestPlant)}");


    foreach (Plant plant in plants)
    {
        TimeSpan availability = plant.AvailableUntil - now;
        if (availability.Days > 0 && !plant.Sold)
        {
           availablePlants++;
        }
    }
    Console.WriteLine($"Number of plants available: {availablePlants}");


    foreach (Plant plant in plants)
    {
        if (plant.LightNeeds > neediestPlant.LightNeeds)
        {
            neediestPlant = plant;
        }
    }
    Console.WriteLine($"Plant with most light needs: {PlantDetails(neediestPlant)}");


    foreach (Plant plant in plants)
    {
        totalLightNeeds += plant.LightNeeds;
    }
    double totalLightNeedsDouble = (double)totalLightNeeds;
    double averageLightNeeds = totalLightNeedsDouble / plants.Count;
    Console.WriteLine($"Average light needs: {averageLightNeeds}");

    foreach (Plant plant in plants)
    {
        if (plant.Sold)
        {
            numberOfAdoptedPlants++;
        }
    }
    double adoptedPlantsDouble = (double)numberOfAdoptedPlants;
    double percentageOfAdoptedPlants = (adoptedPlantsDouble / plants.Count) * 100;
    Console.WriteLine($"Percentage of plants that have been adopted: {percentageOfAdoptedPlants}%");
}

string PlantDetails(Plant plant)
{
    string plantString = plant.Species;

    return plantString;
}



void InventoryBySpecies(Dictionary<string, int> inv)
{
    foreach (Plant plant in plants)
    {
        if (inv.TryGetValue(plant.Species, out int count))
        {
            inv[plant.Species] = count + 1;
        }
        else
        {
            inv[plant.Species] = 1;
        }
    }
    Console.WriteLine($"");
    Console.WriteLine($"Inventory Report");
    foreach (KeyValuePair<string, int> item in inventory)
    {
        Console.WriteLine($"{item.Key}: {item.Value}");
    }
}

string[] saladToppings = new string[4];
saladToppings[0] = "First";
saladToppings[1] = "Second";
saladToppings[2] = "Third";

foreach (string topping in saladToppings)
{
    Console.WriteLine($"{topping}");
}

void DisplayMainOptions()
{
     Console.WriteLine(@"
a. Display all plants
b. Post a plant to be adopted
c. Adopt a plant
d. Delist a plant
e. Plant of the day!
f. Search for plant
g. View statistics
h. Get inventory by species
z. Exit");
}

public partial class Program { }