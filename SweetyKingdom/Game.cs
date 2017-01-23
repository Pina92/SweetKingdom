using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace SweetyKingdom
{

    class Game
    {

        private RenderWindow window;

        private RectangleShape background;
        private RectangleShape pointer;
        private Text button;
        private Text score;

        private Clock clock;
        private Time deltaTime;
        private Cake cake;

        //************************************************************
        public Game(RenderWindow rw)
        {

            this.window = rw;

            // Background.
            this.background = new RectangleShape(new Vector2f(Settings.WIDTH, Settings.HEIGHT));
            background.Texture = ResourceManager.GetTexture("resources/textures/tablecloth.png");
            background.Texture.Repeated = true;
            background.TextureRect = new IntRect(0, 0, (int)Settings.WIDTH, (int)Settings.HEIGHT);

            // Start button.
            this.button = new Text("Play", ResourceManager.GetFont("resources/fonts/appleberry.ttf"), 50);
            button.Position = new Vector2f(50, 50);
            button.Color = new Color(170, 90, 200);

            // Score
            this.score = new Text("0/5", ResourceManager.GetFont("resources/fonts/appleberry.ttf"), 50);
            score.Position = new Vector2f(Settings.WIDTH - 180, 50);
            score.Color = Color.White;

            // Pointer to pice of cake.
            this.pointer = new RectangleShape(new Vector2f(10, 20));
            pointer.FillColor = new Color(170, 90, 200); 
            pointer.Position = new Vector2f(Settings.WIDTH / 2 - pointer.Size.X / 2, Settings.HEIGHT / 2 + 180);

            this.clock = new Clock();
            this.deltaTime = new Time();

            this.cake = new Cake();

            RunGame();

        }
        //************************************************************
        private void RunGame()
        {
          
            bool keyPressed = true;
            bool play = false;
            bool rotating = false;
            int count = 0;

            // Start the game loop
            while (window.IsOpen)
            {

                // Handling keyboard input.
                if (Keyboard.IsKeyPressed(Keyboard.Key.Return) && !play && !keyPressed)
                {
                    play = true;
                    keyPressed = true;
                    button.Color = Color.White;
                }
                if (!Keyboard.IsKeyPressed(Keyboard.Key.Return))
                    keyPressed = false;

                // Process events.
                window.DispatchEvents();

                // Time.
                deltaTime = clock.ElapsedTime;
                if (deltaTime.AsMilliseconds() > 40)
                {

                    if(play)
                        rotating = cake.RotateCake();

                    if (!rotating && play)
                    {

                        if (cake.RemovePiece())
                        {
                            count++;
                            score.DisplayedString = count + "/5";
                        }

                        if(cake.sourOccur)
                        {
                            score.DisplayedString = "Koniec";
                        }


                        play = false;
                        button.Color = new Color(170, 90, 200);

                    }

                    RenderGame();
                    clock.Restart();

                }

            }

        }
        //************************************************************
        // Display everything on screen.
        private void RenderGame()
        {

            Color windowColor = new Color(0, 192, 255);
            // Clear screen.
            window.Clear();

            window.Draw(background);
            window.Draw(button);
            window.Draw(score);

            cake.RenderCake(window);

            window.Draw(pointer);

            // Update the window.
            window.Display();

        }
        //************************************************************
    }


}
