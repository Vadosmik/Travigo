using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
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

public class HotelData
{
    public List<Hotel> hotels { get; set; }
}


public class HotelAPP
{
    public string whichHotelM;
    public HotelAPP(string whichCountry)
	{
        // Read the JSON data from the file
        string jsonData = File.ReadAllText("../../../HotelAPI.json");
        // Deserialize the JSON data into C# objects
        HotelData hotelData = JsonConvert.DeserializeObject<HotelData>(jsonData);

        SelectionMenu WhichHotel = new SelectionMenu();

        foreach (var hotel in hotelData.hotels)
        {
            if (hotel.location.country == whichCountry) {
                WhichHotel.menuOption.Add(hotel.name + "    " + hotel.stars + "*\n  " + hotel.description + "\n  " + hotel.location.address + "\n  ");
            }
        }
        WhichHotel.menuOption.Add("return");

        int whichHotel = WhichHotel.Menu;

        if (WhichHotel.menuOption[whichHotel] != "return")
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.Write("hotel dodany do listy rezerwacji ");
            while (stopwatch.Elapsed.TotalSeconds < 2)
            {
                
                if (stopwatch.Elapsed.TotalSeconds == 0.5 || stopwatch.Elapsed.TotalSeconds == 1 || stopwatch.Elapsed.TotalSeconds == 0)
                {
                    Console.Write(".");
                }
                
            }

            stopwatch.Stop();
            Console.Clear();
        }

        whichHotelM = WhichHotel.menuOption[whichHotel];
     }
}
