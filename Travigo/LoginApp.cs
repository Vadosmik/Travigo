using System;
using Newtonsoft.Json;

public class listaRezerwacji
{
    public string hotel { get; set; }
    public string restaurant { get; set; }
}

public class User
{
    public string username { get; set; }
    public string password { get; set; }
    public listaRezerwacji listaRezerwacji { get; set; }
}

public class UserData
{
    public List<User> users { get; set; }
    public List<User> admin { get; set; }
}

public class LoginApp
{
    public string username = "";
	public LoginApp()
	{
        do
        {
            //======  Login Menu  ======
            ActionSelection AccountMenu = new ActionSelection();

            AccountMenu.Action.Add("Log In");
            AccountMenu.Action.Add("rejstracja nowego użytkownik");

            int AccountAction = AccountMenu.GetActionSelection;

            // odczytywanie plika JSON
            string user = File.ReadAllText("../../../LoginAPI.json");
            UserData userData = JsonConvert.DeserializeObject<UserData>(user);


            Console.WriteLine("===TRAVIGO===\n");

            Console.Write("wpisz username: ");
            string Username = Console.ReadLine();
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
            } while (keyInfo.Key != ConsoleKey.Enter);

            User takeUsername = userData.users.Find(user => user.username == Username);

            if (AccountAction == 0)
            {
                //Autoryzacja użytkownika/admina
                User authenticatedAdmin = userData.admin.Find(user => user.username == Username && user.password == password);
                User authenticatedUser = userData.users.Find(user => user.username == Username && user.password == password);

                if (authenticatedAdmin != null)
                {

                    //AdminPanel admin = new AdminPanel();
                    username = "admin";
                    break;

                }
                else if (authenticatedUser != null)
                {
                    username = takeUsername.username;
                    break;
                }


            }
            else if (AccountAction == 1 && takeUsername.username == null)
            {
                User newUser = new User
                {
                    username = Username,
                    password = password,
                    listaRezerwacji = new listaRezerwacji
                    {
                        hotel = "",
                        restaurant = ""
                    }
                };

                //dodawanie nowego użytkownika do listy
                userData.users.Add(newUser);
                File.WriteAllText("../../../LoginAPI.json", JsonConvert.SerializeObject(userData, Formatting.Indented));
            }
            Console.Clear();
        } while (true);
        Console.Clear();
    }
}

