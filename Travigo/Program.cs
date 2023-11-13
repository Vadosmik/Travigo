int exit = 0;
do
{
    //rejstracja i logowanie do accounta
    LoginApp LoginApp = new LoginApp();
    string username = LoginApp.username;

    if (LoginApp.exit == 5)
    {
        break;
    }

    do
    {
        //======  Country  ======
        ActionSelection Country = new ActionSelection();

        Country.Action.Add("Japan");
        Country.Action.Add("Italy");
        Country.Action.Add("Poland");
        Country.Action.Add("France \n");

        Country.Action.Add("exit");

        string whichCountry = Country.Action[Country.GetActionSelection];
        Console.Clear();
        if (whichCountry != "exit")
        {
            Services Services = new Services();

            Services.Menu(whichCountry, username);

            if (Services.WhereToGo == 4 || Services.WhereToGo == 5)
            {
                exit = Services.WhereToGo;
                break;
            }
        }
        else
        {
            Console.Clear();
            break;
        }
    } while (true);
    if (exit == 5)
    {
        break;
    }
} while (true);