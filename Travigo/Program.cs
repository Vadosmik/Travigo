do
{
    //rejstracja i logowanie do accounta
    LoginApp LoginApp = new LoginApp();

    do
    {
        if (LoginApp.username == "admin")
        {
            Console.WriteLine("admin");
            Console.ReadLine();
            Console.Clear();
            break;
        }

        //======  Country  ======
        ActionSelection Country = new ActionSelection();

        Country.Action.Add("Japan");
        Country.Action.Add("Italy");
        Country.Action.Add("Poland");
        Country.Action.Add("France \n");

        Country.Action.Add("exit");

        string where = Country.Action[Country.GetActionSelection];
        Console.Clear();
        if (where != "exit")
        {
            Console.WriteLine(where);
            Console.ReadLine();
            Console.Clear();
            break;
        }
        else
        {
            Console.Clear();
            break;
        }
    } while (true);
} while (true);