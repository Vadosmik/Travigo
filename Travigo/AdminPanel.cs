using System;
using Newtonsoft.Json;

public class AdminPanel
{
    public AdminPanel()
    {

        string userJson = File.ReadAllText("../../../LoginAPI.json");
        string hotelJson = File.ReadAllText("../../../HotelAPI.json");
        string restaurantJson = File.ReadAllText("../../../RestaurantAPI.json");

        // Deserialize the JSON into a UserData object
        UserData userData = JsonConvert.DeserializeObject<UserData>(userJson);
        HotelData hotelData = JsonConvert.DeserializeObject<HotelData>(hotelJson);
        RestaurantData restaurantData = JsonConvert.DeserializeObject<RestaurantData>(restaurantJson);

        do
        {
            Console.Clear();
            ActionSelection adminPanel = new ActionSelection();

            adminPanel.Action.Add("Nowy Hotel");
            adminPanel.Action.Add("Nowa Restauracja");
            adminPanel.Action.Add("Nowy Admin \n");
            adminPanel.Action.Add("zmienić account");


            int adminModification = adminPanel.GetActionSelection;
            if (adminModification == 0)
            {
                Console.Write("wpisz nazwe hotela: ");
                string HotelName = Console.ReadLine();
                Console.Write("wpisz ile ma gwiazd: ");
                int HotelStars = int.Parse(Console.ReadLine());
                Console.Write("wpisz opis: ");
                string HotelDescription = Console.ReadLine();
                Console.Write("wpisz kraj: ");
                string HotelCountry = Console.ReadLine();
                Console.Write("wpisz miasto: ");
                string HotelCity = Console.ReadLine();
                Console.Write("wpisz addres: ");
                string HotelAddres = Console.ReadLine();

                // Add a new hotel
                Hotel newHotel = new Hotel
                {
                    name = HotelName,
                    stars = HotelStars,
                    description = HotelDescription,
                    location = new Location
                    {
                        city = HotelCountry,
                        country = HotelCity,
                        address = HotelAddres
                    }
                };

                hotelData.hotels.Add(newHotel);

                // Write the updated JSON data back to the file
                File.WriteAllText("../../../HotelAPI.json", JsonConvert.SerializeObject(hotelData, Formatting.Indented));

            }
            else if (adminModification == 1)
            {

                Console.Write("wpisz nazwe restauracji: ");
                string HotelName = Console.ReadLine();
                Console.Write("wpisz ile ma gwiazd: ");
                int HotelStars = int.Parse(Console.ReadLine());
                Console.Write("wpisz opis: ");
                string HotelDescription = Console.ReadLine();
                Console.Write("wpisz opis: ");
                string HotelCouisine = Console.ReadLine();
                Console.Write("wpisz kraj: ");
                string HotelCountry = Console.ReadLine();
                Console.Write("wpisz miasto: ");
                string HotelCity = Console.ReadLine();
                Console.Write("wpisz addres: ");
                string HotelAddres = Console.ReadLine();

                // Add a new hotel
                Restaurant newRestaurant = new Restaurant
                {
                    name = HotelName,
                    stars = HotelStars,
                    description = HotelDescription,
                    cuisine = HotelCouisine,
                    location = new Location
                    {
                        city = HotelCountry,
                        country = HotelCity,
                        address = HotelAddres
                    }
                };

                restaurantData.restaurant.Add(newRestaurant);

                // Write the updated JSON data back to the file
                File.WriteAllText("../../../RestaurantAPI.json", JsonConvert.SerializeObject(restaurantData, Formatting.Indented));

            }
            else if (adminModification == 2)
            {
                Console.WriteLine("===TRAVIGO===\n");
                Console.Write("wpisz username: ");
                string usarname = Console.ReadLine();
                Console.Write("wpisz hasło: ");
                string password = Console.ReadLine();

                User newAdmin = new User
                {
                    username = usarname,
                    password = password
                };

                //dodawanie nowego użytkownika do listy
                userData.admin.Add(newAdmin);
                // Write the updated JSON data back to the file
                File.WriteAllText("../../../LoginAPI.json", JsonConvert.SerializeObject(userData, Formatting.Indented));
            }
            else
            {

                break;

            }
        } while (true);
    }
}


