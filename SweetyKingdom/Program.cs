using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace SweetyKingdom
{
    class Program
    {

        //**************************************************************
        static void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }
        //**************************************************************
        static void Main(string[] args)
        {

            // Create the main window
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Sweet Kingdom");
            window.Closed += new EventHandler(OnClose);


            LoginWindow login = new LoginWindow(window);
            //Menu menu = new Menu(window); 

        }
        //**************************************************************
    }
}
