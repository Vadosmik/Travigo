using System;
using Newtonsoft.Json;

public class AdminPanel
{
    public AdminPanel()
    {

        string json = File.ReadAllText("../../../AccountAPI.json");
        string jsonData = File.ReadAllText("../../../HotelAPI.json");
        string jsonDataR = File.ReadAllText("../../../RestaurantAPI.json");

        // Deserialize the JSON into a UserData object
        UserData userData = JsonConvert.DeserializeObject<UserData>(json);
        HotelData hotelData = JsonConvert.DeserializeObject<HotelData>(jsonData);
        RestaurantData restaurantData = JsonConvert.DeserializeObject<RestaurantData>(jsonDataR);

        do
        {
            Console.Clear();
            SelectionMenu adminPanel = new SelectionMenu();

            adminPanel.menuOption.Add("Nowy Hotel");
            adminPanel.menuOption.Add("Nowa Restauracja");
            adminPanel.menuOption.Add("Nowy Admin \n");
            adminPanel.menuOption.Add("zmienić account");


            int adminModification = adminPanel.Menu;
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

                // Serialize the updated C# objects back to JSON
                string updatedJsonData = JsonConvert.SerializeObject(hotelData, Formatting.Indented);

                // Write the updated JSON data back to the file
                File.WriteAllText("../../../HotelAPI.json", updatedJsonData);

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

                // Serialize the updated C# objects back to JSON
                string updatedJsonData = JsonConvert.SerializeObject(restaurantData, Formatting.Indented);

                // Write the updated JSON data back to the file
                File.WriteAllText("../../../RestaurantAPI.json", updatedJsonData);

            }
            else if (adminModification == 2)
            {
                Console.WriteLine("===TRAVIGO===\n");
                Console.Write("wpisz username: ");
                string usarname = Console.ReadLine();
                Console.Write("wpisz hasło: ");
                string password = Console.ReadLine();

                int lastId = userData.admin.Max(user => user.id);

                User newUser = new User
                {
                    username = usarname,
                    password = password,
                    status = "admin",
                    id = lastId + 1
                };

                //dodawanie nowego użytkownika do listy
                userData.admin.Add(newUser);
                // Write the updated JSON data back to the file
                File.WriteAllText("../../../AccountAPI.json", JsonConvert.SerializeObject(userData, Formatting.Indented));
            }
            else 
            {

                break;

            }
        } while (true);
    }
}


