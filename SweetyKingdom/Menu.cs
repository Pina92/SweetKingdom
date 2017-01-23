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
    class Menu
    {

        private RenderWindow window;
        private RectangleShape background;
        private static String[] menuText = { "Ruletka", "Sweet Progress", "Options", "Exit"};
        private Text[] menu = new Text[menuText.Length];
        private Text title;

        public Menu(RenderWindow rw)
        {

            this.window = rw;

            // Background.
            this.background = new RectangleShape(new Vector2f(Settings.WIDTH, Settings.HEIGHT));
            background.Texture = ResourceManager.GetTexture("resources/textures/background.png");
            background.Texture.Repeated = true;
            background.TextureRect = new IntRect(0, 0, (int)Settings.WIDTH, (int)Settings.HEIGHT);

            // Game title.
            this.title = new Text("SweetKingdom", ResourceManager.GetFont("resources/fonts/orangejuice.ttf"), 100);
            this.title.Position = new Vector2f(Settings.WIDTH / 8, 20);

            // Creating Menu.
            for (int i = 0; i < menuText.Length; i++)
            {

                Text menuPosition = new Text(menuText[i], ResourceManager.GetFont("resources/fonts/appleberry.ttf"), 50);
                menuPosition.Position = new Vector2f(60, Settings.HEIGHT/4 + i * 60);

                menu[i] = menuPosition;

            }

            // Run menu.
            RunMenu();

        }
        //*****************************************
        private void RunMenu()
        {
            int position = 0;
            bool keyPressed = true;

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

                        case "Ruletka":
                            Game ruletka = new Game(window);
                            break;
                        case "Sweet Progress":
                            break;
                        case "Options":
                            break;
                        case "Exit":
                            window.Close();
                            break;

                    }

                }
                else if(!Keyboard.IsKeyPressed(Keyboard.Key.Down) && !Keyboard.IsKeyPressed(Keyboard.Key.Up) && !Keyboard.IsKeyPressed(Keyboard.Key.Return))
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
            window.Draw(title);

            for(int i = 0; i < menu.Length; i++)
                window.Draw(menu[i]);
           

            window.Display();

        }
        //*****************************************
    }


}
