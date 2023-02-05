using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongKrutis
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Palka palka1;
        private Palka palka2;
        private Micek micek1;
        private Micek micek2;
        public int sirkaOkna = 1000;
        public int vyskaOkna= 600;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here 
            _graphics.PreferredBackBufferWidth = sirkaOkna;
            _graphics.PreferredBackBufferHeight = vyskaOkna;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            palka1 = new Palka(100, 300, 12, 18, 125, GraphicsDevice, Keys.Up, Keys.Down, Color.Black);
            palka2 = new Palka(sirkaOkna-120, 300, 12, 18, 125, GraphicsDevice, Keys.W, Keys.S, Color.Black);
            micek1 = new Micek(sirkaOkna/2, 300, 6, 6, GraphicsDevice, Color.White, 15);
            micek2 = new Micek(sirkaOkna/2, 300, -6, -6, GraphicsDevice, Color.Black, 15);
            // TODO: use this.Content to load your game content here 
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here 
            palka1.Aktualizovat(sirkaOkna, vyskaOkna);
            palka2.Aktualizovat(sirkaOkna, vyskaOkna);
            micek1.aktualizovat(sirkaOkna, vyskaOkna);
            micek2.aktualizovat(sirkaOkna, vyskaOkna);

            Rectangle micekKolize1 = new Rectangle((int)micek1._pozice.X, (int)micek1._pozice.Y, micek1._prumer, micek1._prumer);
            Rectangle micekKolize2 = new Rectangle((int)micek2._pozice.X, (int)micek2._pozice.Y, micek2._prumer, micek2._prumer);
            Rectangle palkaKolize1 = new Rectangle((int)palka1._pozice.X, (int)palka1._pozice.Y, palka1._velikostX, palka1._velikostY);
            Rectangle palkaKolize2 = new Rectangle((int)palka2._pozice.X, (int)palka2._pozice.Y, palka2._velikostX, palka2._velikostY);

            if (micekKolize1.Intersects(palkaKolize1) || micekKolize1.Intersects(palkaKolize2))
            {
                micek1._rychlost = Vector2.Reflect(micek1._rychlost, new Vector2(-1, 0));
            }
            if (micek1._pozice.X <= 0 + micek1._textura.Width || micek1._pozice.X >= sirkaOkna)
            {
                micek1._rychlost.X++;
                micek1._rychlost.Y++;
                micek1._pozice.X = sirkaOkna / 2;
                micek1._pozice.Y = 300;
                if (micek1._rychlost.X == 15)
                {
                    micek1._rychlost.X = 6;
                    micek1._rychlost.Y = 6;
                }
    
            }
            if (micekKolize2.Intersects(palkaKolize1) || micekKolize2.Intersects(palkaKolize2))
            {
                micek2._rychlost = Vector2.Reflect(micek2._rychlost, new Vector2(-1, 0));
            }
            if (micek2._pozice.X <= 0 + micek2._textura.Width || micek2._pozice.X >= sirkaOkna)
            {
                micek2._rychlost.X++;
                micek2._rychlost.Y++;
                micek2._pozice.X = sirkaOkna / 2;
                micek2._pozice.Y = 300;
                if (micek2._rychlost.X == 15)
                {
                    micek2._rychlost.X = 6;
                    micek2._rychlost.Y = 6;
                }

            }

            


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here 
            _spriteBatch.Begin();
            palka1.Vykreslit(_spriteBatch);
            palka2.Vykreslit(_spriteBatch);
            micek1.Vykreslit(_spriteBatch);
            micek2.Vykreslit(_spriteBatch);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
