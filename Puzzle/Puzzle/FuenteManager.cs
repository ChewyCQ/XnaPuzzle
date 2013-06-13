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
    public class FuenteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;

        SpriteFont coordenadas;
        SpriteFont rotacion;

        String coord;
        String rot;
        String nombre;

        int minutos = 0;
        int segundos = -1;
        float milisegundos = 0f;

        int screenHeight;
        int screenWidth;

        public int modeloSeleccionado = 2;

        public Game1.estados estado;

        public List<BasicModel> modelos;

        Vector2 posicionTiempo;

        public FuenteManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            estado = Game1.estados.juego;
            posicionTiempo = new Vector2(10,10);
        }

        public FuenteManager(Game game, List<BasicModel> modelos, int screenHeight, int screenWidht)
            : base(game)
        {
            // TODO: Construct any child components here
            this.modelos = modelos;
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidht;
            estado = Game1.estados.juego;
        }
        
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            //Fuentes
            coordenadas = Game.Content.Load<SpriteFont>(@"fonts\fuente");
            rotacion = Game.Content.Load<SpriteFont>(@"fonts\fuente");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            switch (estado)
            {
                case Game1.estados.seleccion:
                    minutos = 0;
                    segundos = 0;
                    modeloSeleccionado = 2;
                    break;
                case Game1.estados.juego:
                    milisegundos += 17.85f;

                    if (milisegundos > 1000)
                    {
                        milisegundos -= 1000;
                        segundos++;
                        if (segundos > 60)
                        {
                            minutos++;
                            segundos = 0;
                        }
                    }

                    coord = modelos.ElementAt(modeloSeleccionado).posicionActual.ToString();
                    rot = "{X:" + modelos.ElementAt(modeloSeleccionado).rotacionActual.X + 
                        " Y:" +  modelos.ElementAt(modeloSeleccionado).rotacionActual.Y +
                        " Z:" + modelos.ElementAt(modeloSeleccionado).rotacionActual.Z + "}";
                    nombre = modelos.ElementAt(modeloSeleccionado).nombre;
                    break;
                case Game1.estados.fin:
                    //posicionTiempo = new Vector2(screenWidth / 2 - nombre.Length * 7, 50);
                    break;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            switch (estado)
            {
                case Game1.estados.seleccion:
                    break;
                case Game1.estados.juego:
                    spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                    //Coordenadas
                    //spriteBatch.DrawString(coordenadas, "Coordenadas: " + coord,
                    //    new Vector2(10, 10), Color.DarkBlue, 0, Vector2.Zero,
                    //    1, SpriteEffects.None, 1);

                    //Tiempo
                    spriteBatch.DrawString(coordenadas, "Tiempo: "+ minutos+ ":" + segundos,
                        new Vector2(10,10), Color.DarkBlue, 0, Vector2.Zero,
                        1, SpriteEffects.None, 1);

                    //Nombre organo
                    spriteBatch.DrawString(coordenadas, nombre,
                        new Vector2(screenWidth/2 - nombre.Length * 7, 50), Color.DarkBlue, 0, Vector2.Zero,
                        1, SpriteEffects.None, 1);

                    spriteBatch.End();
                    break;
                case Game1.estados.fin:
                    spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                    spriteBatch.DrawString(coordenadas, "Tiempo: " + minutos + ":" + segundos,
                        new Vector2(screenWidth / 2 - nombre.Length * 7, screenHeight/2), Color.DarkBlue, 0, Vector2.Zero,
                        1, SpriteEffects.None, 1);

                    spriteBatch.End();
                    break;
            }

            base.Draw(gameTime);
        }
    }
}