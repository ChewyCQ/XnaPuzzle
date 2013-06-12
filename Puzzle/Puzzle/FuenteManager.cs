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

        public int modeloSeleccionado = 2;

        public List<BasicModel> modelos;

        public FuenteManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        public FuenteManager(Game game, List<BasicModel> modelos)
            : base(game)
        {
            // TODO: Construct any child components here
            this.modelos = modelos;
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
            coord = modelos.ElementAt(modeloSeleccionado).posicionActual.ToString();
            rot = "{X:" + modelos.ElementAt(modeloSeleccionado).rotacionActual.X + 
                " Y:" +  modelos.ElementAt(modeloSeleccionado).rotacionActual.Y +
                " Z:" + modelos.ElementAt(modeloSeleccionado).rotacionActual.Z + "}";
            nombre = modelos.ElementAt(modeloSeleccionado).nombre;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            //Coordenadas
            spriteBatch.DrawString(coordenadas, "Coordenadas: " + coord,
                new Vector2(10, 10), Color.DarkBlue, 0, Vector2.Zero,
                1, SpriteEffects.None, 1);

            //Rotacion
            spriteBatch.DrawString(coordenadas, "Rotacion: " + rot,
                new Vector2(10, 25), Color.DarkBlue, 0, Vector2.Zero,
                1, SpriteEffects.None, 1);

            //Rotacion
            spriteBatch.DrawString(coordenadas, nombre,
                new Vector2(10, 40), Color.DarkBlue, 0, Vector2.Zero,
                1, SpriteEffects.None, 1);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}