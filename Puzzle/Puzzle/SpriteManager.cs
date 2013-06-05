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
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;

        //Seleccion
        Sprite el;
        Sprite ella;

        public SpriteManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
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

            Texture2D elTextura = Game.Content.Load<Texture2D>(@"Imagenes/Seleccion/El");
            Texture2D ellaTextura = Game.Content.Load<Texture2D>(@"Imagenes/Seleccion/Ella");

            //Cargar Sprites
            el = new Sprite(
                elTextura, //textura
                new Vector2((ScreenWidht / 4) - (elTextura.Width / 2),
                    (ScreenHeight / 2) - (elTextura.Height / 2)));  //Posicion
            ella = new Sprite(
                ellaTextura, //textura
                new Vector2((ScreenWidht * 0.75f) - (ellaTextura.Width / 2),
                    (ScreenHeight / 2) - (ellaTextura.Height / 2)));  //Posicion

            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            el.Update(gameTime, Game.Window.ClientBounds);
            ella.Update(gameTime, Game.Window.ClientBounds);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            // Draw all sprites
            el.Draw(gameTime, spriteBatch);
            ella.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void move ()
        {

        }
    }
}
