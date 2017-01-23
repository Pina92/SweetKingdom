using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SweetyKingdom
{
    class LoginWindow
    {

        RenderWindow window;
        private RectangleShape background;
        private Text login, title, loginTxt;
        private string str;
        private static String[] menuText = { "Zaloguj", "Nowy urzytkownik", "Usun zapis", "Exit" };
        private Text[] menu = new Text[menuText.Length];

        XML xml;
        
        public LoginWindow(RenderWindow rw)
        {

            this.window = rw;
            window.TextEntered += new EventHandler<TextEventArgs>(EnterLogin);

            // Load XML.
            this.xml = new XML();
            this.xml.XmlLoad();

            // Background.
            this.background = new RectangleShape(new Vector2f(Settings.WIDTH, Settings.HEIGHT));
            background.Texture = ResourceManager.GetTexture("resources/textures/background.png");
            background.Texture.Repeated = true;
            background.TextureRect = new IntRect(0, 0, (int)Settings.WIDTH, (int)Settings.HEIGHT);

            // Login.
            this.login = new Text("", ResourceManager.GetFont("resources/fonts/appleberry.ttf"), 30);
            this.login.Position = new Vector2f(Settings.WIDTH / 3, Settings.HEIGHT / 2 - 15);
            this.str = "";

            // Text "Login".
            this.loginTxt = new Text("Profil:", ResourceManager.GetFont("resources/fonts/appleberry.ttf"), 30);
            this.loginTxt.Position = new Vector2f(Settings.WIDTH / 5 + 10, Settings.HEIGHT / 2 - 15);

            // Game title.
            this.title = new Text("SweetKingdom", ResourceManager.GetFont("resources/fonts/orangejuice.ttf"), 100);
            this.title.Position = new Vector2f(Settings.WIDTH / 8, 20);

            // Creating Menu.
            for (int i = 0; i < menuText.Length; i++)
            {

                Text menuPosition = new Text(menuText[i], ResourceManager.GetFont("resources/fonts/appleberry.ttf"), 30);
                menuPosition.Position = new Vector2f(Settings.WIDTH / 3 + 20, Settings.HEIGHT / 2 + 20 + i * 30);

                menu[i] = menuPosition;

            }

            Login();

        }
        //*****************************************
        private void EnterLogin(object sender, TextEventArgs e)
        {

            string a = e.Unicode;

            // Handle ASCII characters only.
            if (a[0] <= 122 && a[0] >= 48 && str.Length <= 10)
                str += a[0];                
           
            // Handle backspace.
            if (a[0] == 8 && str.Length != 0)
               str = str.Remove(str.Length - 1, 1);

            login.DisplayedString = str;

        }
        //*****************************************
        private void Login()
        {

            int position = 0;
            bool keyPressed = false;

            while (window.IsOpen)
            {
                // Process events.
                window.DispatchEvents();

                menu[position].Color = Color.Blue;

                if (Keyboard.IsKeyPressed(Keyboard.Key.Down) && position < menu.Length - 1 && !keyPressed)
                {

                    menu[position].Color = Color.White;
                    position++;
                    keyPressed = true;

                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && position > 0 && !keyPressed)
                {

                    menu[position].Color = Color.White;
                    position--;
                    keyPressed = true;

                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Return) && !keyPressed)
                {

                    keyPressed = true;
                     
                    switch (menu[position].DisplayedString)
                    {

                        case "Zaloguj":

                            if (xml.SearchUser(str))
                            {
                                Menu mainMenu = new Menu(window);
                            }
                            else
                            {
                                str = "";
                                login.DisplayedString = str;
                            }

                            break;
                        case "Nowy urzytkownik":
                            if (str != "")
                            {
                                xml.CreateUser(str);

                                str = "";
                                login.DisplayedString = str;
                            }
                            break;
                        case "Usun zapis":
                            if (str != "")
                            {
                                xml.DeleteUser(str);

                                str = "";
                                login.DisplayedString = str;
                            }
                            break;
                        case "Exit":
                            window.Close();
                            break;

                    }

                }
                else if (!Keyboard.IsKeyPressed(Keyboard.Key.Down) && !Keyboard.IsKeyPressed(Keyboard.Key.Up) && !Keyboard.IsKeyPressed(Keyboard.Key.Return))
                {
                    keyPressed = false;
                }

                RenderMenu();
            }

        }
        //*****************************************
        private void RenderMenu()
        {

            window.Draw(background);

            for (int i = 0; i < menu.Length; i++)
                window.Draw(menu[i]);

            window.Draw(title);
            window.Draw(loginTxt);
            window.Draw(login);

            window.Display();

        }
        //*****************************************

    }
}

