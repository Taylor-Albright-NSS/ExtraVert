using System.Linq.Expressions;
using System.Xml.Serialization;

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Tree",
        LightNeeds = 5,
        AskingPrice = 45.50,
        City = "Knoxville",
        ZIP = 37076,
        Sold = false,
    },
    new Plant()
    {
        Species = "Bush",
        LightNeeds = 4,
        AskingPrice = 23.50,
        City = "Nashville",
        ZIP = 22353,
        Sold = false,
    },
    new Plant()
    {
        Species = "Grass",
        LightNeeds = 3,
        AskingPrice = 10.00,
        City = "Tampa",
        ZIP = 53575,
        Sold = false,
    },
    new Plant()
    {
        Species = "Venus Fly Trap",
        LightNeeds = 2,
        AskingPrice = 35.50,
        City = "Phoenix",
        ZIP = 12575,
        Sold = true,
    },
    new Plant()
    {
        Species = "Fern",
        LightNeeds = 2,
        AskingPrice = 5.00,
        City = "Frankfurt",
        ZIP = 475773,
        Sold = false,
    },
};


string greeting = "Greetings! Welcome to the ExtraVert plant shop!";
Console.WriteLine(greeting);

string choice = null;

while (choice != "e")
{
    Console.WriteLine(@"a. Display all plants
b. Post a plant to be adopted
c. Adopt a plant
d. Delist a plant
e. Exit");
    Console.WriteLine("Please select a lettered option");

    try
    {
        choice = Console.ReadLine().Trim().ToLower();
    }
    catch
    {
        if (choice != "a" && choice != "b" && choice != "c" && choice != "d") {
            throw new ArgumentOutOfRangeException("Invalid option. Please enter a lettered option from the menu");
        }
    }

    if (choice == "a")
    {
        displayPlants();
    }
    else if (choice == "b")
    {
        postPlant();
    }
    else if (choice == "c")
    {
        throw new NotImplementedException("Adopt a plant");
    }
    else if (choice == "d")
    {
        throw new NotImplementedException("Delist a plant");
    }
    else if (choice == "e")
    {
        Console.WriteLine("Exiting the list!");
    }
    else
    {
        Console.WriteLine("Invalid Option. Please select a valid option from the list.");
    }
}

void displayPlants()
{
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice} dollars.");
    }

}

void postPlant()
{
    Console.WriteLine("To post a plant, please enter a value for each option below:");
    Console.WriteLine("Please enter your plant's species:");
    string userSpecies = Console.ReadLine();

    Console.WriteLine("Please enter your plant's light needs:");
    int userLightNeeds = int.Parse(Console.ReadLine().Trim());
        
    Console.WriteLine("Please enter your plant's asking price:");
    double userAskingPrice = double.Parse(Console.ReadLine());

    Console.WriteLine("Please enter your city:");
    string userCity = Console.ReadLine();

    Console.WriteLine("Please enter your zip:");
    int userZip = int.Parse(Console.ReadLine());
    Console.WriteLine($@"
    User entered the following information:
    {userSpecies}
    {userLightNeeds}
    {userAskingPrice}
    {userCity}
    {userZip}
    ");
}






















