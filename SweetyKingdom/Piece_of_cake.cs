using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace SweetyKingdom
{
    class Piece_of_cake
    {

        public RectangleShape piece_of_cake;
        public bool taken;
        public bool sour;

        public Piece_of_cake()
        {

            this.piece_of_cake = new RectangleShape(new Vector2f(200, 180));
            piece_of_cake.Texture = ResourceManager.GetTexture("resources/textures/cake1.png");
            piece_of_cake.Origin = new Vector2f(piece_of_cake.Size.X / 2, piece_of_cake.Size.Y);
            piece_of_cake.Position = new Vector2f((int)Settings.WIDTH / 2, (int)Settings.HEIGHT / 2);

            this.taken = false;
            this.sour = false;

        }
        //**********************************************************************************************
        public void SetSourTrue()
        {

            this.sour = true;
            this.piece_of_cake.Texture = ResourceManager.GetTexture("resources/textures/cakeSour1.png");

        }
        //**********************************************************************************************

    }
}
