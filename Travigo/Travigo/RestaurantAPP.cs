using System;
using System.Diagnostics;
using Newtonsoft.Json;

public class Restaurant
{
    public string name { get; set; }
    public int stars { get; set; }
    public string description { get; set; }
    public string cuisine { get; set; }
    public Location location { get; set; }
}

public class RestaurantData
{
    public List<Restaurant> restaurant { get; set; }
}

namespace Travigo
{
    public class RestaurantAPP
    {
        public string whichRestaurantM;
        public RestaurantAPP(string whichCountry)
        {


            // Read the JSON data from the file
            string jsonDataR = File.ReadAllText("../../../RestaurantAPI.json");
            // Deserialize the JSON data into C# objects
            RestaurantData restaurantData = JsonConvert.DeserializeObject<RestaurantData>(jsonDataR);


            SelectionMenu WhichRestaurant = new SelectionMenu();
            {

                foreach (var restaurant in restaurantData.restaurant)
                {
                    if (restaurant.location.country == whichCountry)
                    {
                        WhichRestaurant.menuOption.Add(restaurant.name + "    " + restaurant.stars + "*\n  " + restaurant.cuisine + "*\n  " + restaurant.description + "\n  " + restaurant.location.address + "\n  ");

                    }
                }
                WhichRestaurant.menuOption.Add("return");
                int whichRestaurant = WhichRestaurant.Menu;

                if (WhichRestaurant.menuOption[whichRestaurant] != "return")
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    Console.Write("restauracja dodany do listy rezerwacji");
                    int load = 0;
            while (stopwatch.Elapsed.TotalSeconds < 2)
            {
                if (stopwatch.Elapsed.TotalSeconds > 0.25 && stopwatch.Elapsed.TotalSeconds < 0.75 && load == 0)
                {
                    Console.Write(".");
                    load++;
                }else if (stopwatch.Elapsed.TotalSeconds > 0.75 && stopwatch.Elapsed.TotalSeconds < 1.25 && load == 1)
                {
                    Console.Write(".");
                    load++;
                }
                else if (stopwatch.Elapsed.TotalSeconds > 1.25 && stopwatch.Elapsed.TotalSeconds < 1.50 && load == 2)
                {
                    Console.Write(".");
                    load++;
                }
            }

                    stopwatch.Stop();
                    Console.Clear();
                }
                

                whichRestaurantM = WhichRestaurant.menuOption[whichRestaurant];

            }
        }
    }
}

