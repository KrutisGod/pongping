using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;


namespace PongKrutis
{
    class Micek
    {
        public Texture2D _textura;
        public Vector2 _pozice;
        

        public int _prumer { get; private set; }

        public Vector2 _rychlost;
       
        

        

        public Color _barva;

        public Micek(float poziceX, float poziceY, float rychlostX, float rychlostY, GraphicsDevice zobrazovac, Color barva, int prumer)
        {
            _pozice.X = poziceX;
            _pozice.Y = poziceY;
            _rychlost.X = rychlostX;
            _rychlost.Y = rychlostY;
            
            _prumer = prumer;
            _barva = barva;

            int polomer = prumer / 2;
            Color[] pixely = new Color[prumer * prumer];
            for (int i = 0; i < _prumer; i++)
            {
                for (int j = 0; j < _prumer; j++)
                {
                    if (Math.Sqrt(Math.Pow(j - polomer, 2)+ Math.Pow(i-polomer,2)) < polomer)
                    {
                        pixely[_prumer * i + j] = Color.Black;
                    } else
                    {
                        pixely[_prumer * i + j] = Color.Transparent;
                    }
                }
            }
            _textura = new Texture2D(zobrazovac, _prumer, _prumer);
            _textura.SetData(pixely);

        }

        public void aktualizovat (int sirkaOkna, int vyskaOkna)
        {
            
            
            _pozice.X += _rychlost.X;
            _pozice.Y += _rychlost.Y;
            

            if(_pozice.Y >= vyskaOkna - _prumer || _pozice.Y <= 0 + _prumer)
            {
                _rychlost.Y *= -1;
                
            
            }
            if(_pozice.X >= sirkaOkna - _prumer || _pozice.X <= 0 + _prumer)
            {
                _rychlost.X *= -1;
            }
        }

        public void Vykreslit(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textura, _pozice, _barva);


        }
    }
}
