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
    public class ModelManager : DrawableGameComponent
    {
        public List<BasicModel> models = new List<BasicModel>();
        byte modeloSeleccionado = 0;

        public enum sexo { Masculino, Femenino };
        public sexo genero;

        BasicEffect effect;

        public ModelManager(Game game, sexo sex)
            : base(game)
        {
            // TODO: Construct any child components here
            genero = sex;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            switch (genero)
            {
                case sexo.Masculino:
                    
                    break;

                case sexo.Femenino:
                    
                    break;

                default:
                    break;
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Initialize the BasicEffect
            effect = new BasicEffect(GraphicsDevice);

            switch (genero)
            {
                case sexo.Masculino:
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\Conducto_deferente_lado_derecho"), 0.326f, 0.326f, 0.326f));//spaceship
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\Conducto_deferente_lado_Izquierdo"), 0.326f, 0.326f, 0.326f));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\epididiimio_lado_derecho"), 1.058f, 1.058f, 1.058f));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\epididimio_lado_izquierdo"), 1.058f, 1.058f, 1.058f));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\prostata"), 1.820f, 1.820f, 1.820f));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\tejido_erectil"), 0.877f, 0.877f, 0.877f));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\testiculo_lado_derecho"), 1.058f, 1.058f, 1.058f));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\testiculos_lado_izquierdo"), 1.058f, 1.058f, 1.058f));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\uretra"), 0.995f, 0.995f, 0.995f));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\vejiga"), 1.893f, 1.893f, 1.893f));
                    break;

                case sexo.Femenino:
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Cuerpo"), 7.2f, 7.2f, 7.2f));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Ovario derecho"), 2.61f, 1.92f, 1.959f));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Ovario izquierdo"), 2.610f, 1.920f, 1.959f));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Trompa de Falopio Derecha"), 0.731f, 0.892f, 0.963f));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Trompa de Falopio Izquierda"), 0.963f, 0.892f, 0.963f));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Uretra"), 5.051f, 6.782f, 5.316f));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Útero"), 5.028f, 4.260f, 4.268f));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Vagina"), 2.017f, 2.017f, 2.017f));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Vejiga"), 1.178f, 1.178f, 1.178f));
                    break;

                default:
                    break;
            }

            foreach (BasicModel bm in models)
            {
                bm.worldTranslation = Matrix.Identity;
            }

            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            //Move(models[0]);

            // Loop through all models and call Update
            for (int i = 0; i < models.Count; ++i)
            {
                models[i].Update();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            // Loop through and draw each model
            foreach (BasicModel bm in models)
            {
                bm.Draw(((Game1)Game).camera);
            }

            base.Draw(gameTime);
        }

        private void Move(BasicModel modelo)
        {
            Matrix worldTranslation = Matrix.Identity;

            try
            {
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.Left))
                    worldTranslation *= Matrix.CreateTranslation(-.01f, 0, 0);
                if (keyboardState.IsKeyDown(Keys.Right))
                    worldTranslation *= Matrix.CreateTranslation(.01f, 0, 0);
                if (keyboardState.IsKeyDown(Keys.Up))
                    worldTranslation *= Matrix.CreateTranslation(0, .01f, 0);
                if (keyboardState.IsKeyDown(Keys.Down))
                    worldTranslation *= Matrix.CreateTranslation(0, -.01f, 0);
                if (keyboardState.IsKeyDown(Keys.W))
                    worldTranslation *= Matrix.CreateTranslation(0, 0, 1f);
                if (keyboardState.IsKeyDown(Keys.S))
                    worldTranslation *= Matrix.CreateTranslation(0, 0, -1f);

            }
            catch
            {
            }

            effect.World = worldTranslation;
        }
    }
}