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

        int timeSinceLastFrame = 0;
        const int millisecondsPerFrame = 50000;

        float moveSpeed = .25f;
        float rotacion = 2.5f;
        float escala = 0.875f;
        FuenteManager fuenteManager;

        public ModelManager(Game game, sexo sex)
            : base(game)
        {
            // TODO: Construct any child components here
            genero = sex;
            timeSinceLastFrame = 0;
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
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\CuerpoCompleto"),
                        new Vector3(1f, 1f, 1f),
                        Vector3.Zero,
                        new Vector3(0, 0, 0),
                        "Cuerpo"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\parte_del_pene"),
                        new Vector3(1f, 1f, 1f),
                        new Vector3(257.5f, 347.5f, 0f),
                        new Vector3(-6.5f, -28f, -17.5f),
                        "Miembro"));
                    break;

                case sexo.Femenino:
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Cuerpo"),
                        new Vector3(7.2f, 7.2f, 7.2f) * escala * 2,
                        Vector3.Zero,
                        new Vector3(0, -7.5f, .2f),
                        "Cuerpo"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Útero"),
                        new Vector3(5.028f, 4.260f, 4.268f) * escala,
                        new Vector3(247.5f, 85f, 342.5f),
                        new Vector3(0, 4.75f, 7F),
                        "Utero"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Vejiga"),
                        new Vector3(1.178f, 1.178f, 1.178f) * escala * 2,
                        new Vector3(270, 0, 0),
                        new Vector3(-1f, -1.25f, 7f),
                        "Vejiga"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Uretra2"),
                        new Vector3(5.051f, 6.782f, 5.316f) * escala,//escala
                        new Vector3(352.5f, 0f, 92.5f),//rotacion
                        new Vector3(-0.25f, -4.25f, 7f),//posicion
                        "Uretra"));
                    
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Vagina2"),
                        new Vector3(1f, 1f, 1f) * escala,//1f, 1f, 0.766f
                        new Vector3(270f, 60f, 0f),
                        new Vector3(1.25f, -1.5f, 4f),
                        "Vagina"));
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
                        new Vector3(130f, 197.5f, 232.5f),
                        new Vector3(-2.5f, 6.5f, -.5f),
                        "Trompa de Falopio Izquierda"));
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

            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                manipularModelo(seleccionarModelo());
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //Activa el buffer en distancia (Z)
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;

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
                if (keyboardState.IsKeyDown(Keys.I))
                {
                    modelo.posicionActual += new Vector3(0, 0, moveSpeed);
                }
                if (keyboardState.IsKeyDown(Keys.K))
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