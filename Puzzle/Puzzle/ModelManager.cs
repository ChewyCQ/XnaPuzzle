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

        const float escala = 0.875f;

        int screenHeight;
        int screenWidth;

        public ModelManager(Game game, sexo sex)
            : base(game)
        {
            // TODO: Construct any child components here
            
            genero = sex;
        }

        public ModelManager(Game game, sexo sex, int screenHeight, int screenWidth)
            : base(game)
        {
            // TODO: Construct any child components here
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;
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
                        Game.Content.Load<Model>(@"Masculino\CuerpoCompleto"),
                        new Vector3(7.2f, 7.2f, 7.2f) * escala * 2,
                        Vector3.Zero,
                        new Vector3(0.25f, 38.75f, 7.2f),//38.75
                        "Cuerpo Masculino"));
                    models.Last().acomodado = true;
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\parte_del_pene2"),
                        new Vector3(0.203f * 7.6f, 0.203f * 7.6f, 0.203f * 7.6f) * escala * 2,
                        new Vector3(270.5f, 0f, 0f),
                        new Vector3(-0.25f, -7.25f, 8.5f),
                        "Miembro"));
                    models.Last().acomodado = true;
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\conducto deferente der1"),
                        new Vector3(0.03619f * 7.2f, 0.03619f * 7.2f, 0.03619f * 7.2f) * 2f,
                        new Vector3(3.97f, 176.6f, 88.669f),//8.97f, 171.6f, 91.169f
                        new Vector3(3.5f, -2.7f, 5.8f),//3.5f, -2.45f, 6.3f
                        new Vector3(-25f, 10, 7.2f),
                        "Conducto deferente derecho"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\conducto deferente izq"),
                        new Vector3(0.07898f * 7.2f, 0.07898f * 7.2f, 0.07898f * 7.2f) * 2f,
                        new Vector3(282.5f, 0f, 85f),
                        new Vector3(-2.5f, -2, 5),
                        new Vector3(-25f, 5, 5f),
                        "Conducto deferente izquierdo"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\testiculo derecho"),
                        new Vector3(0.118f * 7.2f, 0.118f * 7.2f, 0.172f * 7.2f) * 2f,
                        new Vector3(90f,0f,0f),
                        new Vector3(2.2f, -7.4f, 8.5f),
                        new Vector3(-25f, -5, 8.5f),
                        "Testiculo derecho"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\testiculo derecho"),
                        new Vector3(0.118f * 7.2f, 0.118f * 7.2f, 0.172f * 7.2f) * 2f,
                        new Vector3(90f, 0f, 0f),
                        new Vector3(-2.55f, -7.4f, 8.5f),
                        new Vector3(-26f, -10, 8.5f),
                        "Testiculo izquierdo"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\prostata"),
                        new Vector3(0.202f * 7.2f, 0.202f * 7.2f, 0.202f * 7.2f) * 2f,
                        new Vector3(90f,90f,0f),
                        new Vector3(0, 3.25f, 3.75f),
                        new Vector3(-23f, -10, 3.75f),
                        "Prostata"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\uretra"),
                        new Vector3(0.108f * 7.2f, 0.108f * 7.2f, 0.108f * 7.2f) * 2f,
                        new Vector3(270f, 0f, 0f),
                        new Vector3(-0.04f, -4.05f, 10.1f),
                        new Vector3(23f, 10, 10.1f),
                        "Uretra"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\tejido erectil"),
                        new Vector3(0.0974f * 7.2f, 0.0974f * 7.2f, 0.0974f * 7.2f) * 2f,
                        new Vector3(265f, 0f, 0f),
                        new Vector3(0f, -2.65f, 9.55f),
                        new Vector3(23f, 0, 9.55f),
                        "Tejido erectil"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Masculino\vejiga"),
                        new Vector3(0.210f * 7.2f, 0.210f * 7.2f, 0.210f * 7.2f) * 2f,
                        new Vector3(270f, 272.5f, 0f),
                        new Vector3(-0.4f, 11.2f, 4.25f),
                        new Vector3(25f, -11, 4.25f),
                        "Vejiga"));
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
                        new Vector3(-23, -7.75f, 7F),
                        "Utero"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Vejiga"),
                        new Vector3(1.178f, 1.178f, 1.178f) * escala * 2,
                        new Vector3(270, 0, 0),
                        new Vector3(-1f, -1.25f, 7f),
                        new Vector3(21f, 5.25f, 7f),
                        "Vejiga"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Uretra2"),
                        new Vector3(5.051f, 6.782f, 5.316f) * escala,//escala
                        new Vector3(352.5f, 0f, 92.5f),//rotacion
                        new Vector3(0f, -4.25f, 7f),//posicion
                        new Vector3(-29f, 10.25f, 7f),//posicion inicial
                        "Uretra"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Vagina2"),
                        new Vector3(1f, 1f, 1f) * escala,//1f, 1f, 0.766f
                        new Vector3(270f, 60f, 0f),
                        new Vector3(1.25f, -1.5f, 4f),
                        new Vector3(23.25f, 15f, 4f),
                        "Vagina"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Ovario derecho"),
                        new Vector3(2.61f, 1.92f, 1.959f) * escala,
                        new Vector3(0f, 90f, 0f),
                        new Vector3(6.75f, 7.75f, 5.25f),
                        new Vector3(-28f, -14.5f, 4f),
                        "Ovario derecho"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Ovario izquierdo"),
                        new Vector3(2.610f, 1.920f, 1.959f) * escala,
                        new Vector3(0f, 90f, 0f),
                        new Vector3(-6f, 8f, 5f),
                        new Vector3(-25f, 0f, 5f),
                        "Ovario izquierdo"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Trompa de Falopio Derecha2"),
                        new Vector3(0.691f, 0.640f, 0.691f) * escala,
                        new Vector3(310f, 10f, 0f),
                        new Vector3(4.75f, 6.75f, 8.5f),
                        new Vector3(23.75f, -5.75f, 8.5f),
                        "Trompa de Falopio Derecha"));
                    models.Add(new BasicModel(
                        Game.Content.Load<Model>(@"Femenino\Trompa de Falopio Izquierda2"),
                        new Vector3(0.691f, 0.640f, 0.691f) * escala,
                        new Vector3(200f, 247.5f, 65f),
                        new Vector3(-4.5f, 7.25f, 8.5f),
                        new Vector3(23.75f, -10.25f, 8.5f),
                        "Trompa de Falopio Izquierda"));
                    break;

                default:
                    break;
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
            

            base.Draw(gameTime);
        }
    }
}