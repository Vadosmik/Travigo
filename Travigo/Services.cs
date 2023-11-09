using System;
using System.Diagnostics;
using Newtonsoft.Json;

public class Location
{
    public string country { get; set; }
    public string city { get; set; }
    public string address { get; set; }
}


public class Hotel
{
    public string name { get; set; }
    public int stars { get; set; }
    public string description { get; set; }
    public Location location { get; set; }
}
public class Restaurant
{
    public string name { get; set; }
    public int stars { get; set; }
    public string description { get; set; }
    public string cuisine { get; set; }
    public Location location { get; set; }
}


public class HotelData
{
    public List<Hotel> hotels { get; set; }
}
public class RestaurantData
{
    public List<Restaurant> restaurant { get; set; }
}




public class Services
{
    public int WhereToGo;
    public void Menu(string whichCountry, string username)
    {
        do
        {
            //======  Services Menu  ======
            ActionSelection ServicesMenu = new ActionSelection();

            ServicesMenu.Action.Add("Hotel");
            ServicesMenu.Action.Add("Restaurant \n");
            ServicesMenu.Action.Add("lista rezerwacji");
            ServicesMenu.Action.Add("wybrać inny kraj");
            ServicesMenu.Action.Add("zmień account \n");
            ServicesMenu.Action.Add("exit");

            int ServicesAction = ServicesMenu.GetActionSelection;

            if (ServicesAction == 0)
            {
                Hotel(whichCountry, username);
            }
            else if (ServicesAction == 1)
            {
                Restaurant(whichCountry, username);
            }
            else if (ServicesAction == 2)
            {
                ReservationList(username);
            }
            else
            {
                WhereToGo = ServicesAction;
                break;
            }
        } while (true);
    }

    //==================HotelAPP==================
    public void Hotel(string whichCountry, string username)
    {
        // Read the JSON data from the file
        string userJson = File.ReadAllText("../../../LoginAPI.json");
        string hotelJson = File.ReadAllText("../../../HotelAPI.json");
        // Deserialize the JSON data into C# objects
        UserData userData = JsonConvert.DeserializeObject<UserData>(userJson);
        HotelData hotelData = JsonConvert.DeserializeObject<HotelData>(hotelJson);

        ActionSelection WhichHotel = new ActionSelection();

        //Dodajemy hoteli z jsona do listy do wyboru
        foreach (var hotel in hotelData.hotels)
        {
            if (hotel.location.country == whichCountry)
            {
                WhichHotel.Action.Add(hotel.name + "    " + hotel.stars + "*\n  " + hotel.description + "\n  " + hotel.location.address + "\n  ");
            }
        }
        WhichHotel.Action.Add("return");
        int whichHotel = WhichHotel.GetActionSelection;

        if (WhichHotel.Action[whichHotel] != "return")
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.Write("Dodajemy Hotel do listy rezerwacji ");

            int load = 0;
            while (stopwatch.Elapsed.TotalSeconds < 2)
            {
                if (stopwatch.Elapsed.TotalSeconds > 0.25 && stopwatch.Elapsed.TotalSeconds < 0.75 && load == 0)
                {
                    Console.Write(".");
                    load++;
                }
                else if (stopwatch.Elapsed.TotalSeconds > 0.75 && stopwatch.Elapsed.TotalSeconds < 1.25 && load == 1)
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

            foreach (var user in userData.users)
            {
                if (user.username == username)
                {
                    user.listaRezerwacji.hotel.Add(WhichHotel.Action[whichHotel]);
                }
            }
            File.WriteAllText("../../../LoginAPI.json", JsonConvert.SerializeObject(userData, Formatting.Indented));
        }
    }




    // =================RestaurantAPP=====================
    public void Restaurant(string whichCountry, string username)
    {
        // Read the JSON data from the file
        string userJson = File.ReadAllText("../../../LoginAPI.json");
        string restaurantJson = File.ReadAllText("../../../RestaurantAPI.json");
        // Deserialize the JSON data into C# objects
        UserData userData = JsonConvert.DeserializeObject<UserData>(userJson);
        RestaurantData restaurantData = JsonConvert.DeserializeObject<RestaurantData>(restaurantJson);

        ActionSelection WhichRestaurant = new ActionSelection();

        //Dodajemy hoteli z jsona do listy do wyboru
        foreach (var restaurant in restaurantData.restaurant)
        {
            if (restaurant.location.country == whichCountry)
            {
                WhichRestaurant.Action.Add(restaurant.name + "    " + restaurant.stars + "*\n  " + restaurant.description + "\n  " + restaurant.location.address + "\n  ");
            }
        }
        WhichRestaurant.Action.Add("return");
        int whichRestaurant = WhichRestaurant.GetActionSelection;

        if (WhichRestaurant.Action[whichRestaurant] != "return")
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.Write("Dodajemy Restauracje do listy rezerwacji ");

            int load = 0;
            while (stopwatch.Elapsed.TotalSeconds < 2)
            {
                if (stopwatch.Elapsed.TotalSeconds > 0.25 && stopwatch.Elapsed.TotalSeconds < 0.75 && load == 0)
                {
                    Console.Write(".");
                    load++;
                }
                else if (stopwatch.Elapsed.TotalSeconds > 0.75 && stopwatch.Elapsed.TotalSeconds < 1.25 && load == 1)
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

            foreach (var user in userData.users)
            {
                if (user.username == username)
                {
                    user.listaRezerwacji.restaurant.Add(WhichRestaurant.Action[whichRestaurant]);
                }
            }
            File.WriteAllText("../../../LoginAPI.json", JsonConvert.SerializeObject(userData, Formatting.Indented));
        }
    }

    public void ReservationList(string username)
    {
        string userJson = File.ReadAllText("../../../LoginAPI.json");
        UserData userData = JsonConvert.DeserializeObject<UserData>(userJson);

        ActionSelection ReservationList = new ActionSelection();

        ReservationList.Action.Add("uśunąć całe");
        ReservationList.Action.Add("uśunąć jedno");
        ReservationList.Action.Add("zobaczyć list rezerwacji");

        int ReservationAction = ReservationList.GetActionSelection;

        if (ReservationAction == 0)
        {
            foreach (var user in userData.users)
            {
                if (user.username == username)
                {
                    user.listaRezerwacji.hotel.Clear();
                    user.listaRezerwacji.restaurant.Clear();
                    break;
                }
            }
        }
        else if (ReservationAction == 1)
        {
            ActionSelection ReservationListDeleted = new ActionSelection();

            foreach (var user in userData.users)
            {
                if (user.username == username)
                {
                    for (int i = 0; i < user.listaRezerwacji.hotel.Count; i++)
                    {
                        ReservationListDeleted.Action.Add(user.listaRezerwacji.hotel[i]);
                    }
                    for (int i = 0; i < user.listaRezerwacji.restaurant.Count; i++)
                    {
                        ReservationListDeleted.Action.Add(user.listaRezerwacji.restaurant[i]);
                    }
                    ReservationListDeleted.Action.Add("return");
                    int whichPositionDeleted = ReservationListDeleted.GetActionSelection;

                    user.listaRezerwacji.restaurant.Remove(ReservationListDeleted.Action[whichPositionDeleted]);
                    user.listaRezerwacji.hotel.Remove(ReservationListDeleted.Action[whichPositionDeleted]);
                    break;
                }
            }
        }
        else if (ReservationAction == 2)
        {
            string Rezerwacja = "";
            foreach (var user in userData.users)
            {
                if (user.username == username)
                {
                    Rezerwacja += "Hoteli: \n\n";
                    for (int i = 0; i < user.listaRezerwacji.hotel.Count; i++)
                    {
                        Rezerwacja += user.listaRezerwacji.hotel[i] + "\n";
                    }
                    Rezerwacja += "Restauracji: : \n\n";
                    for (int i = 0; i < user.listaRezerwacji.restaurant.Count; i++)
                    {
                        Rezerwacja += user.listaRezerwacji.restaurant[i] + "\n";
                    }
                    //======  list rezerwacyji  ======
                    Console.Clear();
                    Console.WriteLine("===TRAVIGO===\n");

                    Console.WriteLine(Rezerwacja);

                    Console.WriteLine(">return");
                    Console.WriteLine("\n=============");
                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                    Console.Clear();
                    break;
                }
            }
        }
        File.WriteAllText("../../../LoginAPI.json", JsonConvert.SerializeObject(userData, Formatting.Indented));
    }
}


