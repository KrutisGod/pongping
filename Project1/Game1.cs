using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongKrutis
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Palka palka;
        private Micek micek;
        public int vyskaOkna = 800;
        public int sirkaOkna = 600;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here 
            _graphics.PreferredBackBufferWidth = vyskaOkna;
            _graphics.PreferredBackBufferHeight = sirkaOkna;
            _graphics.ApplyChanges();
                
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            palka = new Palka(100, 300, 12, 18, 125, GraphicsDevice, Keys.Up, Keys.Down, Color.Black);
            micek = new Micek(700, 300, 6, 6,GraphicsDevice, Color.Black, 15);

            // TODO: use this.Content to load your game content here 
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here 
            palka.Aktualizovat(vyskaOkna, sirkaOkna);
            micek.aktualizovat(vyskaOkna, sirkaOkna);

            Rectangle micekKolize = new Rectangle((int)micek._pozice.X, (int)micek._pozice.Y, micek._prumer, micek._prumer);
            Rectangle palkaKolize = new Rectangle((int)palka._pozice.X, (int)palka._pozice.Y, palka._velikostX, palka._velikostY);
            
            if (micekKolize.Intersects(palkaKolize))
            {
                micek._rychlost = Vector2.Reflect(micek._rychlost, new Vector2(-1, 0));
            }
            if(micek._pozice.X <= 0 + micek._textura.Width)
            {
                micek._rychlost.X ++;
                micek._rychlost.Y ++;
                micek._pozice.X = 700;
                micek._pozice.Y = 300;
                if (micek._rychlost.X == 20)
                {
                    micek._rychlost.X = 6;
                    micek._rychlost.Y = 6;
                }
                
            }

                
           
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here 
            _spriteBatch.Begin();
            palka.Vykreslit(_spriteBatch);
            micek.Vykreslit(_spriteBatch);
            _spriteBatch.End();
           

            base.Draw(gameTime);
        }
    }

}
