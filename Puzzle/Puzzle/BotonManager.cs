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

        int modeloSeleccionado = 2;

        int timeSinceLastClick = 0;
        const int millisecondsPerClick = 75;

        int modelosNum = 0;

        Boolean vistaX = false;

        //public enum estados{ seleccion, juego, fin};
        public Game1.estados estado;

        //Botones
        Sprite botonLeft;
        Sprite botonRight;
        Sprite botonUp;
        Sprite botonDown;
        Sprite cuerpo;
        Sprite preview;
        Sprite visionX;
        Sprite giroIzq;

        FuenteManager fuenteManager;

        public BotonManager(Game game, List<BasicModel> modelos)
            : base(game)
        {
            // TODO: Construct any child components here
            this.modelos = modelos;
            timeSinceLastClick = 0;
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

            //Tamaño pantalla
            int ScreenWidht = Game.Window.ClientBounds.Width;
            int ScreenHeight = Game.Window.ClientBounds.Height;

            float pos = 0;

            float escalaFlechas = 0.10f;

            //Texturas
            Texture2D leftTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/left");
            Texture2D rightTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/right");
            Texture2D upTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/up");
            Texture2D downTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/down");
            Texture2D cuerpoTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/silueta");
            Texture2D previewTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/eye");
            Texture2D vistaXTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/eyeX");
            Texture2D giroDerTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/giro der");
            Texture2D giroIzqTextura = Game.Content.Load<Texture2D>(@"Imagenes/Botones/giro izq");

            //Cargar Sprites
            pos += upTextura.Height * escalaFlechas / 4;
            botonUp = new Sprite(upTextura,
                new Vector2((ScreenWidht) - (upTextura.Width * escalaFlechas * 1.75f),
                    pos),
                    escalaFlechas);
            pos += botonUp.alto;
            botonLeft = new Sprite(leftTextura,
                new Vector2((ScreenWidht) - (leftTextura.Width * escalaFlechas * 2),
                    pos),
                    escalaFlechas);
            //pos += botonLeft.alto;
            botonRight = new Sprite(rightTextura,
                new Vector2((ScreenWidht) - (rightTextura.Width * escalaFlechas),
                    pos),
                    escalaFlechas);
            pos += botonRight.alto;
            botonDown = new Sprite(downTextura,
                new Vector2((ScreenWidht) - (downTextura.Width * escalaFlechas * 1.75f),
                    pos),
                    escalaFlechas);
            pos += botonDown.alto + 15;
            //Rotar izq
            giroIzq = new Sprite(giroIzqTextura,
                new Vector2((ScreenWidht) - (giroIzqTextura.Width * escalaFlechas * 1.20f),
                    pos),
                    escalaFlechas);
            pos += giroIzq.alto;
            //Mostrar/Ocultar piel
            cuerpo = new Sprite(cuerpoTextura,
                new Vector2((ScreenWidht) - (cuerpoTextura.Width * 0.5f),
                    pos),
                    0.5f);
            pos += cuerpo.alto;
            preview = new Sprite(previewTextura,
                new Vector2(0,
                    (float)(ScreenHeight - (previewTextura.Height * 0.75))),
                    0.75f);
            visionX = new Sprite(vistaXTextura,
                new Vector2(ScreenWidht - vistaXTextura.Width,
                    (float)(ScreenHeight - (vistaXTextura.Height * 0.75))),
                    0.75f);
            fuenteManager = new FuenteManager(Game, modelos, ScreenHeight, ScreenWidht);
            Game.Components.Add(fuenteManager);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            switch (estado)
            {
                case Game1.estados.seleccion:
                    break;

                case Game1.estados.juego:
                    todosAcomodados();

                    if (modelos.ElementAt(modeloSeleccionado).acomodado)
                        seleccionarModelo();

                    timeSinceLastClick += gameTime.ElapsedGameTime.Milliseconds;
                    if (timeSinceLastClick > millisecondsPerClick)
                    {
                        timeSinceLastClick -= millisecondsPerClick;
                        manipularModelo(modelos.ElementAt(modeloSeleccionado));
                        botones();
                    }
                    break;

                case Game1.estados.fin:
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
                    if (!vistaX)
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
                    preview.Draw(gameTime, spriteBatch);
                    visionX.Draw(gameTime, spriteBatch);
                    //giroDer.Draw(gameTime, spriteBatch);
                    giroIzq.Draw(gameTime, spriteBatch);
            
                    spriteBatch.End();

                    //Dibuja el texto sobre lo demas
                    fuenteManager.Draw(gameTime);
                    break;

                case Game1.estados.fin:
                    if (!vistaX)
                        GraphicsDevice.DepthStencilState = DepthStencilState.Default;

                    for (int c = modelosNum; c < modelos.Count; c++) 
                    {
                        modelos.ElementAt(c).Draw(((Game1)Game).camera);
                    }
                    fuenteManager.Draw(gameTime);
                    break;
            }

            base.Draw(gameTime);
        }

        void seleccionarModelo()
        {
            modeloSeleccionado++;

            if (modeloSeleccionado >= modelos.Count())
            {
                modeloSeleccionado = 1;
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

                //Ocultar cuerpo
                if (mouseState.X > cuerpo.GetPosition.X &&
                    mouseState.X < cuerpo.GetPosition.X + cuerpo.largo &&
                    mouseState.Y > cuerpo.GetPosition.Y &&
                    mouseState.Y < cuerpo.GetPosition.Y + cuerpo.alto)
                {
                    ocultarCuerpo();
                }

                //Botono de vista previa
                if (mouseState.X > preview.GetPosition.X &&
                    mouseState.X < preview.GetPosition.X + preview.largo &&
                    mouseState.Y > preview.GetPosition.Y &&
                    mouseState.Y < preview.GetPosition.Y + preview.alto)
                {
                    for (int c = modelosNum; c < modelos.Count; c++)
                    {
                        modelos.ElementAt(c).preview = true;
                    }
                }

                //Vision X
                if (mouseState.X > visionX.GetPosition.X &&
                    mouseState.X < visionX.GetPosition.X + visionX.largo &&
                    mouseState.Y > visionX.GetPosition.Y &&
                    mouseState.Y < visionX.GetPosition.Y + visionX.alto)
                {
                    if (!vistaX)
                        vistaX = true;
                    else
                        vistaX = false;
                }

                //Botono de giro
                if (mouseState.X > giroIzq.GetPosition.X &&
                    mouseState.X < giroIzq.GetPosition.X + giroIzq.largo &&
                    mouseState.Y > giroIzq.GetPosition.Y &&
                    mouseState.Y < giroIzq.GetPosition.Y + giroIzq.alto)
                {
                    modelos.ElementAt(modeloSeleccionado).rotar(90);
                }
            }
            else 
            {
                for (int c = modelosNum; c < modelos.Count; c++)
                {
                    modelos.ElementAt(c).preview = false;
                }
            }
            mantenerEnPantalla();
        }

        void ocultarCuerpo()
        {
            if (modelosNum == 0)
            {
                modelosNum = 1;
                if (modelos.ElementAt(1).nombre.Equals("Miembro"))
                    modelosNum = 2;
            }
            else
                modelosNum = 0;
        }

        void mantenerEnPantalla()
        {
            if (modelos.ElementAt(modeloSeleccionado).posicionActual.X < -27)
                modelos.ElementAt(modeloSeleccionado).posicionActual.X = -27;
            else
                if (modelos.ElementAt(modeloSeleccionado).posicionActual.X > 27)
                    modelos.ElementAt(modeloSeleccionado).posicionActual.X = 27;
            if (modelos.ElementAt(modeloSeleccionado).posicionActual.Y < -15)
                modelos.ElementAt(modeloSeleccionado).posicionActual.Y = -15;
            else
                if (modelos.ElementAt(modeloSeleccionado).posicionActual.Y > 15)
                    modelos.ElementAt(modeloSeleccionado).posicionActual.Y = 15;
        }

        Boolean todosAcomodados()
        {
            foreach (BasicModel model in modelos)
            {
                if (!model.acomodado)
                    return false;
            }
            estado = Game1.estados.fin;
            fuenteManager.estado = Game1.estados.fin;
            return true;
        }
    }
}