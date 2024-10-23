﻿using System.Linq.Expressions;
using System.Text.Encodings.Web;
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

while (choice != "z")
{
    Console.WriteLine(@"
a. Display all plants
b. Post a plant to be adopted
c. Adopt a plant
d. Delist a plant
e. Plant of the day!
f. Search for plant
z. Exit");
    Console.WriteLine("Please select a lettered option");

    try
    {
        choice = Console.ReadLine().Trim().ToLower();
    }
    catch
    {
        if (choice != "a" && choice != "b" && choice != "c" && choice != "d" && choice != "e" && choice != "f") {
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
        adoptPlant();
    }
    else if (choice == "d")
    {
        delistPlant();
    }
    else if (choice == "e")
    {
        plantOfTheDay();
    }
    else if (choice == "f")
    {
        search();
    }
    else if (choice == "z")
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

    Plant userPlant = new Plant()
    {
        Species = userSpecies,
        LightNeeds = userLightNeeds,
        AskingPrice = userAskingPrice,
        City = userCity,
        ZIP = userZip,
        Sold = false
    };
    plants.Add(userPlant);

    Console.WriteLine($@"
    User entered the following information:
    {userPlant.Species}
    {userPlant.LightNeeds}
    {userPlant.AskingPrice}
    {userPlant.City}
    {userPlant.ZIP}
    ");
}

void adoptPlant()
{
    List<Plant> availablePlants = new List<Plant>();

    Console.WriteLine("Available plants to adopt:");
    for (int i = 0; i < plants.Count; i++)
    {
        if (!plants[i].Sold)
        {
            availablePlants.Add(plants[i]);
        }
    }

    for (int i = 0; i < availablePlants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {availablePlants[i].Species}");
    }
    Console.WriteLine("Choose a plant to adopt");
    int userChoice = int.Parse(Console.ReadLine());
    if (userChoice > 0 || userChoice < availablePlants.Count)
    {
        int plantIndex = userChoice - 1;
        Console.WriteLine($"You chose {availablePlants[plantIndex].Species}");
        availablePlants[plantIndex].Sold = true;
    }

}

void delistPlant()
{
    Console.WriteLine("Choose a plant to remove from the list:");
    for (int i = 0; i < plants.Count; i++) 
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
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
    Console.WriteLine($"Species: {plants[randomInteger].Species}");
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
    {
        Console.WriteLine(@"Your reponse needs to be a number between 1 and 5
        Please try again now.");
        userChoice = int.Parse(Console.ReadLine());
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
        Console.WriteLine($"{plant.Species}");
    }

}















