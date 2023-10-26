using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

public class User
{
    public string username { get; set; }
    public string password { get; set; }
    public string status { get; set; }
    public int id { get; set; }
    public List<string> listRezerwacji { get; set; }
}

public class UserData
{
    public List<User> users { get; set; }
    public List<User> admin { get; set; }
}

public class LogInApp
	{
    public int id = 0;
    public int exit = 0;
    public LogInApp()
		{
        do
        {
            //======  Login Menu  ======
            SelectionMenu AccountMenu = new SelectionMenu();

            AccountMenu.menuOption.Add("Log in");
            AccountMenu.menuOption.Add("registered \n");
            AccountMenu.menuOption.Add("exit");
            int accountActions = AccountMenu.Menu;


            // odczytywanie plika JSON i zapisanie go do zmianej json
            string json = File.ReadAllText("../../../AccountAPI.json");

            // Deserialize the JSON into a UserData object
            UserData userData = JsonConvert.DeserializeObject<UserData>(json);


            //logowanie do konta
            if (accountActions == 0)
            {
                Console.WriteLine("===TRAVIGO===\n");
                Console.Write("wpisz username: ");
                string username = Console.ReadLine();
                Console.Write("wpisz hasło: ");

                //ukrywanie hasła
                string password = "";
                ConsoleKeyInfo keyInfo;
                do
                {
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                    {
                        password += keyInfo.KeyChar;
                        Console.Write("*");//zamiana znaka na symbol gwiazdy
                    }
                    else if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b"); //przesuwanie kursora do tyłu i kasowanie znaka
                    }
                }
                while (keyInfo.Key != ConsoleKey.Enter);

                //Autoryzacja użytkownika/admina
                User authenticatedAdmin = userData.admin.Find(user => user.username == username && user.password == password && user.status == "admin");
                User authenticatedUser = userData.users.Find(user => user.username == username && user.password == password && user.status == "user");

                User takeId = userData.users.Find(user => user.username == username);

                if (authenticatedAdmin != null)
                {

                    AdminPanel admin = new AdminPanel();

                }
                else if (authenticatedUser != null)
                {
                    if (takeId != null)
                    {
                        id = takeId.id;
                        break;
                    }

                }


            }
            // rejstracja nowego użytkownika
            else if (accountActions == 1)
            {
                Console.Write("wpisz username: ");
                string usarname = Console.ReadLine();
                Console.Write("wpisz hasło: ");
                string password = Console.ReadLine();

                int lastId = userData.users.Max(user => user.id);

                User newUser = new User
                {
                    username = usarname,
                    password = password,
                    status = "user",
                    id = lastId + 1
                };

                //dodawanie nowego użytkownika do listy
                userData.users.Add(newUser);
                // Write the updated JSON data back to the file
                File.WriteAllText("../../../AccountAPI.json", JsonConvert.SerializeObject(userData, Formatting.Indented));
            }
            else
            {
                exit = 1;
                break;
            }
            Console.Clear();
        } while (true);
        Console.Clear();
    }
	}


