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

        public enum sexo { Masculino, Femenino };
        public sexo genero;

        BasicEffect effect;

        int modeloSeleccionado = 0;

        float moveSpeed = 1;
        float rotacion = 5;
        float escala = 1.75f;
        FuenteManager fuenteManager;

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
                        Game.Content.Load<Model>(@"Masculino\Conducto_deferente_lado_derecho"),
                        new Vector3(0.326f, 0.326f, 0.326f),
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Conducto deferente lado derecho"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\Conducto_deferente_lado_Izquierdo"),
                        new Vector3(0.326f, 0.326f, 0.326f),
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Conducto deferente lado izquierdo"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\epididiimio_lado_derecho"),
                        new Vector3(1.058f, 1.058f, 1.058f),
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Epididiimio derecho"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\epididimio_lado_izquierdo"),
                        new Vector3(1.058f, 1.058f, 1.058f),
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Epididimio izquierdo"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\prostata"),
                        new Vector3(1.820f, 1.820f, 1.820f),
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Prostata"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\tejido_erectil"),
                        new Vector3(0.877f, 0.877f, 0.877f),
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Tejido erectil"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\testiculo_lado_derecho"),
                        new Vector3(1.058f, 1.058f, 1.058f),
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Testiculo derecho"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\testiculos_lado_izquierdo"),
                        new Vector3(1.058f, 1.058f, 1.058f),
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Testiculo izquierdo"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\uretra"),
                        new Vector3(0.995f, 0.995f, 0.995f),
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Uretra"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\vejiga"),
                        new Vector3(1.893f, 1.893f, 1.893f),
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Vejiga"));
                    break;

                case sexo.Femenino:
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Cuerpo"),
                        new Vector3(7.2f, 7.2f, 7.2f) * escala,
                        Vector3.Zero,
                        new Vector3(0,-13f,0),
                        "Cuerpo"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Vagina"),
                        new Vector3(2.017f, 2.017f, 1.544f) * escala,
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Vagina"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Útero"),
                        new Vector3(5.028f, 4.260f, 4.268f) * escala,
                        new Vector3(280f, 85f, 5f),
                        new Vector3(0, 0, 0),
                        "Utero"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Ovario derecho"),
                        new Vector3(2.61f, 1.92f, 1.959f) * escala,
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Ovario derecho"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Ovario izquierdo"),
                        new Vector3(2.610f, 1.920f, 1.959f) * escala,
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Ovario izquierdo"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Trompa de Falopio Derecha"),
                        new Vector3(0.731f, 0.892f, 0.963f) * escala,
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Trompa de Falopio Derecha"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Trompa de Falopio Izquierda"),
                        new Vector3(0.963f, 0.892f, 0.963f) * escala,
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Trompa de Falopio Izquierda"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Uretra"),
                        new Vector3(5.051f, 6.782f, 5.316f) * escala,
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Uretra"));
                    //models.Add(new BasicModel(
                    //    Game.Content.Load<Model>(@"Femenino\Vejiga"),
                    //    new Vector3(1.178f, 1.178f, 1.178f) * escala,
                    //    Vector3.Zero,
                    //    new Vector3(0,0,0),
                    //    "Vejiga"));
                    
                    break;

                default:
                    break;
            }

            fuenteManager = new FuenteManager(Game, models);
            Game.Components.Add(fuenteManager);

            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            //Seleccion
            manipularModelo(seleccionarModelo());

            // Loop through all models and call Update
            for (int i = 0; i < models.Count; ++i)
            {
                models[i].Update();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //Activa el buffer en distancia (Z)
            //GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            // Loop through and draw each model
            foreach (BasicModel bm in models)
            {
                bm.Draw(((Game1)Game).camera);
            }

            //Dibuja el texto sobre lo demas
            fuenteManager.Draw(gameTime);

            

            base.Draw(gameTime);
        }

        BasicModel seleccionarModelo()
        {
            try
            {
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.O))
                {
                    modeloSeleccionado++;

                    if (modeloSeleccionado >= models.Count)
                    {
                        modeloSeleccionado = 0;
                    }
                    fuenteManager.modeloSeleccionado = modeloSeleccionado;
                }
            }
            catch{}
            return models.ElementAt(modeloSeleccionado);
        }

        void manipularModelo(BasicModel modelo)
        {
            //Mover modelo
            try
            {
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.I))
                {
                    rotacion = -rotacion;
                }
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    modelo.posicionActual += new Vector3(-moveSpeed, 0, 0);
                }
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    modelo.posicionActual += new Vector3(moveSpeed, 0, 0);
                }
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    modelo.posicionActual += new Vector3(0, moveSpeed, 0);
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    modelo.posicionActual += new Vector3(0, -moveSpeed, 0);
                }
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    modelo.posicionActual += new Vector3(0, 0, moveSpeed);
                }
                if (keyboardState.IsKeyDown(Keys.S))
                {
                    modelo.posicionActual += new Vector3(0, 0, -moveSpeed);
                }
                if (keyboardState.IsKeyDown(Keys.X))
                {
                    modelo.rotacionActual += new Vector3(MathHelper.ToRadians(rotacion), 0, 0);
                    modelo.worldRotation *= Matrix.CreateRotationX(MathHelper.ToRadians(rotacion));
                }
                if (keyboardState.IsKeyDown(Keys.Y))
                {
                    modelo.rotacionActual += new Vector3(0, MathHelper.ToRadians(rotacion), 0);
                    modelo.worldRotation *= Matrix.CreateRotationY(MathHelper.ToRadians(rotacion));
                }
                if (keyboardState.IsKeyDown(Keys.Z))
                {
                    modelo.rotacionActual += new Vector3(0, 0, MathHelper.ToRadians(rotacion));
                    modelo.worldRotation *= Matrix.CreateRotationZ(MathHelper.ToRadians(rotacion));
                }
            }
            catch
            {
            }
        }
    }
}