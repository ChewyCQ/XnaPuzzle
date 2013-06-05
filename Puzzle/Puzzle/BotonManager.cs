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
    public class BotonManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;

        public List<BasicModel> modelos;

        float moveSpeed = 0.3f;

        //Botones
        Sprite botonRotar;

        public BotonManager(Game game, List<BasicModel> modelos)
            : base(game)
        {
            // TODO: Construct any child components here
            this.modelos = modelos;
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

            //Texturas
            Texture2D rotarTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/redo");

            //Cargar Sprites
            botonRotar = new Sprite (rotarTextura,
                new Vector2((ScreenWidht) - (rotarTextura.Width),
                    (ScreenHeight) - (rotarTextura.Height)));  //Posicion

            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            // TODO: Add your update code here
            botonRotar.Update(gameTime, Game.Window.ClientBounds);

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (mouseState.X > botonRotar.GetPosition.X)
                {
                    foreach (BasicModel bm in modelos)
                    {
                        bm.worldTranslation *= Matrix.CreateTranslation(0, 0, -1f); ;// CreateTranslation(0, 0, -1f);
                    }
                }
            }

            //Mover con teclas
            Matrix worldTranslation = Matrix.Identity;
            try
            {
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.Left))
                    foreach (BasicModel bm in modelos)
                    {
                        bm.worldTranslation *= Matrix.CreateTranslation(-moveSpeed, 0, 0);
                    }
                if (keyboardState.IsKeyDown(Keys.Right))
                    foreach (BasicModel bm in modelos)
                    {
                        bm.worldTranslation *= Matrix.CreateTranslation(moveSpeed, 0, 0);
                    }
                if (keyboardState.IsKeyDown(Keys.Up))
                    foreach (BasicModel bm in modelos)
                    {
                        bm.worldTranslation *= Matrix.CreateTranslation(0, moveSpeed, 0);
                    }
                if (keyboardState.IsKeyDown(Keys.Down))
                    foreach (BasicModel bm in modelos)
                    {
                        bm.worldTranslation *= Matrix.CreateTranslation(0, -moveSpeed, 0);
                    }
                if (keyboardState.IsKeyDown(Keys.W))
                    foreach (BasicModel bm in modelos)
                    {
                        bm.worldRotation *= Matrix.CreateRotationX(MathHelper.PiOver4 / 60);
                    }
                if (keyboardState.IsKeyDown(Keys.S))
                    foreach (BasicModel bm in modelos)
                    {
                        bm.worldRotation *= Matrix.CreateRotationX(-MathHelper.PiOver4);
                    }
                if (keyboardState.IsKeyDown(Keys.X))
                    foreach (BasicModel bm in modelos)
                    {
                        bm.worldRotation *= Matrix.CreateRotationX(MathHelper.ToRadians(45f));
                        //bm.worldRotation *= Matrix.CreateFromYawPitchRoll(.1f, 0f, 0f);
                    }
                if (keyboardState.IsKeyDown(Keys.Y))
                    foreach (BasicModel bm in modelos)
                    {
                        bm.worldRotation *= Matrix.CreateRotationY(MathHelper.ToRadians(45f));
                        //bm.worldRotation *= Matrix.CreateRotationY(MathHelper.PiOver4 / 30);
                    }
                if (keyboardState.IsKeyDown(Keys.Z))
                    foreach (BasicModel bm in modelos)
                    {
                        bm.worldRotation *= Matrix.CreateRotationZ(MathHelper.ToRadians(45f));
                        //bm.worldRotation *= Matrix.CreateRotationZ(MathHelper.PiOver4 / 30);
                    }

            }
            catch
            {
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