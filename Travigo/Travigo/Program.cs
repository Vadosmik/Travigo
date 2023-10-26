using Newtonsoft.Json;
using Travigo;

internal class Program
{
    private static void Main(string[] args)
    {
        int what;

        

        // odczytywanie plika JSON i zapisanie go do zmianej json
        string json = File.ReadAllText("../../../AccountAPI.json");
        // Deserialize the JSON into a UserData object
        UserData userData = JsonConvert.DeserializeObject<UserData>(json);


        do
        {
            //======  Login APP  ======
            LogInApp LogInApp = new LogInApp();

            int id = LogInApp.id;
            if (LogInApp.exit == 1)
            {
                break;
            }

            do
            {
                //======  Country  ======
                SelectionMenu Country = new SelectionMenu();

                Country.menuOption.Add("Japan");
                Country.menuOption.Add("Italy");
                Country.menuOption.Add("Poland");
                Country.menuOption.Add("France");

                string where = Country.menuOption[Country.Menu];
                Console.Clear();
                do
                {
                    do
                    {
                        //======  Servicec  ======
                        SelectionMenu Servicec = new SelectionMenu();

                        Servicec.menuOption.Add("Hotel");
                        Servicec.menuOption.Add("Restaurants \n ================");
                        Servicec.menuOption.Add("list rezerwacyj");
                        Servicec.menuOption.Add("wybrać iny kraj");
                        Servicec.menuOption.Add("zmień acccount \n");
                        Servicec.menuOption.Add("exit");

                        what = Servicec.Menu;

                        if (what == 0)
                        {
                            HotelAPP hotelAPP = new HotelAPP(where);
                            if (hotelAPP.whichHotelM != "return")
                            {
                                foreach (var user in userData.users)
                                {
                                    if (user.id == id)
                                    {
                                        user.listRezerwacji.Add(hotelAPP.whichHotelM);
                                    }
                                }
                            }
                        }
                        else if (what == 1)
                        {
                            RestaurantAPP restaurantAPP = new RestaurantAPP(where);
                            if (restaurantAPP.whichRestaurantM != "return")
                            {
                                foreach (var user in userData.users)
                                {
                                    if (user.id == id)
                                    {
                                        user.listRezerwacji.Add(restaurantAPP.whichRestaurantM);
                                    }
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    } while (true);
                    File.WriteAllText("../../../AccountAPI.json", JsonConvert.SerializeObject(userData, Formatting.Indented));

                    if (what == 3 || what == 4 || what == 5 )
                    {
                        break;
                    }

                    string Rezerwacja = "";
                    do
                    {
                        SelectionMenu ListRezerwacji = new SelectionMenu();

                        ListRezerwacji.menuOption.Add("uśunąć całe");
                        ListRezerwacji.menuOption.Add("uśunąć jedno");
                        ListRezerwacji.menuOption.Add("zobaczyć list rezerwacji");

                        int whatDo = ListRezerwacji.Menu;

                        if (whatDo == 0)
                        {
                            foreach (var user in userData.users)
                            {
                                if (user.id == id)
                                {
                                    user.listRezerwacji.Clear();
                                    break;
                                }
                            }
                        }
                        else if (whatDo == 1)
                        {
                            foreach (var user in userData.users)
                            {
                                if (user.id == id)
                                {
                                    SelectionMenu SelectedDeletedRezervation = new SelectionMenu();
                                    for (int i = 0; i < user.listRezerwacji.Count; i++)
                                    {
                                        SelectedDeletedRezervation.menuOption.Add(user.listRezerwacji[i]);
                                    }
                                    int whatSelected = SelectedDeletedRezervation.Menu;
                                    user.listRezerwacji.Remove(SelectedDeletedRezervation.menuOption[whatSelected]);
                                    break;
                                }
                            }

                        }
                        else if (whatDo == 2)
                        {
                            foreach (var user in userData.users)
                            {
                                if (user.id == id)
                                {
                                    for (int i=0; i<user.listRezerwacji.Count; i++)
                                    {
                                        Rezerwacja += user.listRezerwacji[i] + "\n";
                                    }
                                    //======  list rezerwacyji  ======
                                    Console.Clear();
                                    Console.WriteLine("===TRAVIGO===\n");

                                    Console.WriteLine(id);
                                    Console.WriteLine(Rezerwacja);
                                    Console.WriteLine(where);


                                    Console.WriteLine("\n=============");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                }
                            }
                        }

                        File.WriteAllText("../../../AccountAPI.json", JsonConvert.SerializeObject(userData, Formatting.Indented));
                        break;
                    }while (true);
                } while (true);
                if (what == 4 || what == 5)
                {
                    break;
                }
            } while (true);
            if (what == 5)
            {
                break;
            }
        } while (true);
    }
}