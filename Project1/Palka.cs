using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;




namespace PongKrutis
{
    class Palka
    {
        public Texture2D _textura;
        public Vector2 _pozice;
        public int _rychlost;

        public int _velikostX { get; set; }
        public int _velikostY { get; set; }

        public Keys _smerNahoru { get; private set;}
        public Keys _smerDolu { get; private set; }
        public Color _barva;
        public Palka(float poziceX, float poziceY, int rychlost, int velikostX, int velikostY, GraphicsDevice zobrazovac, Keys nahoru, Keys dolu, Color barva)
        {
            _pozice.X = poziceX;
            _pozice.Y = poziceY;
            _rychlost = rychlost;
            _velikostX = velikostX;
            _velikostY = velikostY;
            _smerNahoru = nahoru;
            _smerDolu = dolu;
            _barva = barva;

            _textura = new Texture2D(zobrazovac, velikostX, velikostY);

            Color[] pixely = new Color[_velikostX * _velikostY];
            for (int i = 0; i < pixely.Length; i++)
            {
                pixely[i] = Color.White;
            }

            _textura.SetData(pixely);
        }
        public void Aktualizovat(int sirkaOkna, int vyskaOkna)
        {
            if(Keyboard.GetState().IsKeyDown(_smerNahoru))
            {
                _pozice.Y -= _rychlost;
            }
            if(Keyboard.GetState().IsKeyDown(_smerDolu))
            {
                _pozice.Y += _rychlost;
            }
            if(_pozice.Y < 0)
            {
                _pozice.Y = 0;
            }
            if (_pozice.Y >= vyskaOkna - _velikostY)
            {
                _pozice.Y = vyskaOkna - _velikostY;
            } 
        }

        public void Vykreslit(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textura, _pozice, _barva);


        }

    }
}
