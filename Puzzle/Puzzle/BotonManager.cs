using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Puzzle
{
    public class BotonManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;

        //public List<BasicModel> modelos;

        float moveSpeed = .1f;

        //Botones
        Sprite botonRotar;

        public BotonManager(Game game, List<BasicModel> modelos)
            : base(game)
        {
            // TODO: Construct any child components here
            //this.modelos = modelos;
        }

        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            //Tamaño pantalla
            int ScreenWidht = Game.Window.ClientBounds.Width;
            int ScreenHeight = Game.Window.ClientBounds.Height;

            //Texturas
            Texture2D rotarTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/redo");

            //Cargar Sprites
            botonRotar = new Sprite (rotarTextura,
                new Vector2((ScreenWidht) - (rotarTextura.Width),
                    (ScreenHeight) - (rotarTextura.Height)));  //Posicion

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            // TODO: Add your update code here
            botonRotar.Update(gameTime, Game.Window.ClientBounds);

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (mouseState.X > botonRotar.GetPosition.X)
                {
                    //foreach (BasicModel bm in modelos)
                    //{
                        
                    //}
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            botonRotar.Draw(gameTime, spriteBatch);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}