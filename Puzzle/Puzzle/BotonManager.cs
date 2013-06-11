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

        public List<BasicModel> modelos;

        int modeloSeleccionado = 0;

        int timeSinceLastFrame = 0;
        const int millisecondsPerFrame = 50000;

        int modelosNum = 0;

        //Botones
        Sprite botonLeft;
        Sprite botonRight;
        Sprite botonUp;
        Sprite botonDown;
        Sprite cuerpo;
        Sprite select;

        FuenteManager fuenteManager;

        public BotonManager(Game game, List<BasicModel> modelos)
            : base(game)
        {
            // TODO: Construct any child components here
            this.modelos = modelos;
            timeSinceLastFrame = 0;
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

            float pos = 0;

            //Texturas
            Texture2D leftTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/left");
            Texture2D rightTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/right");
            Texture2D upTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/up");
            Texture2D downTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/down");
            Texture2D cuerpoTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/cuerpo");
            Texture2D selectTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/select");

            //Cargar Sprites
            botonLeft = new Sprite(leftTextura,
                new Vector2((ScreenWidht) - (leftTextura.Width * 0.15f),
                    pos),
                    0.15f);
            pos += botonLeft.alto;
            botonRight = new Sprite(rightTextura,
                new Vector2((ScreenWidht) - (rightTextura.Width * 0.15f),
                    pos),
                    0.15f);
            pos += botonRight.alto;
            botonUp = new Sprite(upTextura,
                new Vector2((ScreenWidht) - (upTextura.Width * 0.15f),
                    pos),
                    0.15f);
            pos += botonUp.alto;
            botonDown = new Sprite(downTextura,
                new Vector2((ScreenWidht) - (downTextura.Width * 0.15f),
                    pos),
                    0.15f);
            pos += botonDown.alto;
            cuerpo = new Sprite(cuerpoTextura,
                new Vector2((ScreenWidht) - (cuerpoTextura.Width * 0.5f),
                    pos),
                    0.5f);
            pos += cuerpo.alto;
            select = new Sprite(selectTextura,
                new Vector2((ScreenWidht) - (selectTextura.Width * 0.1f),
                    pos),
                    0.1f);

            fuenteManager = new FuenteManager(Game, modelos);
            Game.Components.Add(fuenteManager);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            

            // TODO: Add your update code here
            //Seleccion
            //manipularModelo(seleccionarModelo());

            botonLeft.Update(gameTime, Game.Window.ClientBounds);
            botonRight.Update(gameTime, Game.Window.ClientBounds);
            botonUp.Update(gameTime, Game.Window.ClientBounds);
            botonDown.Update(gameTime, Game.Window.ClientBounds);
            cuerpo.Update(gameTime, Game.Window.ClientBounds);
            select.Update(gameTime, Game.Window.ClientBounds);

            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                
            }

            manipularModelo(modelos.ElementAt(modeloSeleccionado));
            botones();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            for (int c = modelosNum; c < modelos.Count; c++) 
            {
                modelos.ElementAt(c).Draw(((Game1)Game).camera);
            }

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            botonLeft.Draw(gameTime, spriteBatch);
            botonRight.Draw(gameTime, spriteBatch);
            botonUp.Draw(gameTime, spriteBatch);
            botonDown.Draw(gameTime, spriteBatch);
            cuerpo.Draw(gameTime, spriteBatch);
            select.Draw(gameTime, spriteBatch);
            
            spriteBatch.End();

            //Dibuja el texto sobre lo demas
            fuenteManager.Draw(gameTime);

            base.Draw(gameTime);
        }

        void seleccionarModelo()
        {
            modeloSeleccionado++;

            if (modeloSeleccionado >= modelos.Count)
            {
                modeloSeleccionado = 0;
            }
            fuenteManager.modeloSeleccionado = modeloSeleccionado;
        }

        void manipularModelo(BasicModel modelo)
        {
            //Mover modelo
            modelo.Move();
        }

        void botones()
        {
            MouseState mouseState = Mouse.GetState();

            try 
            {
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.O))
                {
                    modeloSeleccionado++;

                    if (modeloSeleccionado >= modelos.Count)
                    {
                        modeloSeleccionado = 0;
                    }
                    fuenteManager.modeloSeleccionado = modeloSeleccionado;
                }
            }
            catch { }

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                //Mover izq
                if (mouseState.X > botonLeft.GetPosition.X && 
                    mouseState.X < botonLeft.GetPosition.X + botonLeft.largo &&
                    mouseState.Y > botonLeft.GetPosition.Y &&
                    mouseState.Y < botonLeft.GetPosition.Y + botonLeft.alto)
                {
                    modelos.ElementAt(modeloSeleccionado).moverX(-1);
                }

                //Mover der
                if (mouseState.X > botonRight.GetPosition.X &&
                    mouseState.X < botonRight.GetPosition.X + botonRight.largo &&
                    mouseState.Y > botonRight.GetPosition.Y &&
                    mouseState.Y < botonRight.GetPosition.Y + botonRight.alto)
                {
                    modelos.ElementAt(modeloSeleccionado).moverX(1);
                }

                //Mover arriba
                if (mouseState.X > botonUp.GetPosition.X &&
                    mouseState.X < botonUp.GetPosition.X + botonUp.largo &&
                    mouseState.Y > botonUp.GetPosition.Y &&
                    mouseState.Y < botonUp.GetPosition.Y + botonUp.alto)
                {
                    modelos.ElementAt(modeloSeleccionado).moverY(1);
                }

                //Mover abajo
                if (mouseState.X > botonDown.GetPosition.X &&
                    mouseState.X < botonDown.GetPosition.X + botonDown.largo &&
                    mouseState.Y > botonDown.GetPosition.Y &&
                    mouseState.Y < botonDown.GetPosition.Y + botonDown.alto)
                {
                    modelos.ElementAt(modeloSeleccionado).moverY(-1);
                }

                if (mouseState.X > cuerpo.GetPosition.X &&
                    mouseState.X < cuerpo.GetPosition.X + cuerpo.largo &&
                    mouseState.Y > cuerpo.GetPosition.Y &&
                    mouseState.Y < cuerpo.GetPosition.Y + cuerpo.alto)
                {
                    if (modelosNum == 0)
                        modelosNum = 1;
                    else
                        modelosNum = 0;
                    //seleccionarModelo();
                }

                if (mouseState.X > select.GetPosition.X &&
                    mouseState.X < select.GetPosition.X + select.largo &&
                    mouseState.Y > select.GetPosition.Y &&
                    mouseState.Y < select.GetPosition.Y + select.alto)
                {
                    seleccionarModelo();
                }
            }
        }
    }
}