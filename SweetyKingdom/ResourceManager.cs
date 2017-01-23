using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using System.Collections;

namespace SweetyKingdom
{
    class ResourceManager
    {
        
        static Hashtable textures = new Hashtable();
        static Hashtable fonts = new Hashtable();

        //************************************************************
        static public Texture GetTexture(string texture_path)
        {

            if (textures.Contains(texture_path))
                return (Texture)textures[texture_path];
            else
            {
                Texture new_texture = new Texture(texture_path);
                textures.Add(texture_path, new_texture);

                return new_texture;
            }

        }
        //************************************************************
        static public Font GetFont(string font_path)
        {

            if (fonts.Contains(font_path))
                return (Font)fonts[font_path];
            else
            {
                Font new_font = new Font(font_path);
                fonts.Add(font_path, new_font);

                return new_font;
            }

        }
        //************************************************************

    }
}
