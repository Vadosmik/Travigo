using System;
using Newtonsoft.Json;

public class listaRezerwacji
{
    public List<string> hotel { get; set; }
    public List<string> restaurant { get; set; }
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
    public int exit = 0;
	public LoginApp()
	{
        do
        {
            //======  Login Menu  ======
            ActionSelection AccountMenu = new ActionSelection();

            AccountMenu.Action.Add("Log In");
            AccountMenu.Action.Add("rejstracja nowego użytkownik \n");
            AccountMenu.Action.Add("exit");

            int AccountAction = AccountMenu.GetActionSelection;

            if (AccountAction == 2)
            {
                exit = 5;
                break;
            }

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

            //Autoryzacja użytkownika/admina
            User authenticatedAdmin = userData.admin.Find(user => user.username == Username && user.password == password);
            User authenticatedUser = userData.users.Find(user => user.username == Username && user.password == password);


            if (AccountAction == 0)
            {

                if (authenticatedAdmin != null)
                {

                    AdminPanel admin = new AdminPanel();

                }
                else if (authenticatedUser != null)
                {
                    username = takeUsername.username;
                    break;
                }


            }
            else if (AccountAction == 1)
            {
                if (takeUsername == null) {
                    User newUser = new User
                    {
                        username = Username,
                        password = password,
                        listaRezerwacji = new listaRezerwacji
                        {
                            
                        }
                    };
                    //dodawanie nowego użytkownika do listy
                    userData.users.Add(newUser);
                    File.WriteAllText("../../../LoginAPI.json", JsonConvert.SerializeObject(userData, Formatting.Indented));

                }
                else if (takeUsername != null)
                {
                    Console.Clear();
                    Console.Write("taki użytkowniik już istnieje, prosze użyć inny username\n\n");
                    Console.Write(">return");
                    Console.ReadLine();
                }

            }
            Console.Clear();
        } while (true);
        Console.Clear();
    }
}

