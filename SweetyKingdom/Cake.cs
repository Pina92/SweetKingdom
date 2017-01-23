using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace SweetyKingdom
{
    class Cake
    {

        private Piece_of_cake[] cake = new Piece_of_cake[6];

        private Random rnd = new Random();
        private double predkosc_krecenia;
        private double zwolnienie = 0.03;

        public bool sourOccur;

        public Cake()
        {
            
            // Creating full cake
            for (int i = 0; i < 6; i++)
            {

                Piece_of_cake piece = new Piece_of_cake();              
                piece.piece_of_cake.Rotation = i * 60;

                cake[i] = piece;

            }

            int sourPiece = rnd.Next(5);
            cake[sourPiece].SetSourTrue();
            sourOccur = false;

            this.predkosc_krecenia = rnd.Next(5, 10);

        }
        //************************************************************
        public bool RotateCake()
        {


            if (predkosc_krecenia > 0)
            {
                
                // Obracanie ciasta
                for(int i = 0; i < cake.Length; i++)
                {

                    cake[i].piece_of_cake.Rotation = (cake[i].piece_of_cake.Rotation + (float)predkosc_krecenia) % 360;

                }

                predkosc_krecenia -= zwolnienie;

                return true;

            }
            else
            {

                predkosc_krecenia = rnd.Next(5, 10);

                return false;

            }
            
        }
        //************************************************************
        public bool RemovePiece()
        {

            for (int i = 0; i < cake.Length; i++)
            {

                if (cake[i].piece_of_cake.Rotation > 150 && cake[i].piece_of_cake.Rotation < 210 && !cake[i].taken)
                {

                    cake[i].taken = true;

                    if (cake[i].sour == true)
                        sourOccur = true;

                    return true;               

                }

            }

            return false;

        }
        //************************************************************
        public void RenderCake(RenderWindow rw)
        {

            for (int i = 0; i < 6; i++)
            {

                if (!cake[i].taken)
                    rw.Draw(cake[i].piece_of_cake);

            }

        }
        //************************************************************

    }
}
