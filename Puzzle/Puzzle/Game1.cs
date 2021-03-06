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
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Screen sizes
        public int screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public int screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        public enum estados{ seleccion, juego, fin};
        public estados estado = estados.seleccion;

        //Componentes
        SpriteManager spriteManager;
        ModelManager modelManager;
        BotonManager botonManager;

        int tiempoEspera = 100;
        int tiempoPasado = 0;

        public Camera camera { get; protected set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = screenHeight;//768
            graphics.PreferredBackBufferWidth = screenWidth;//1366

            //Antialiasing
            graphics.PreferMultiSampling = true;
            graphics.ApplyChanges();

            // Pantalla completa
            if (!graphics.IsFullScreen)
                graphics.ToggleFullScreen();

            //Velocidad del juego, 50 = 20FPS
            //16.6666667 milliseconds = 60FPS
            //TargetElapsedTime = new TimeSpan(0, 0, 0, 0, 60);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Sprites de Seleccion
            spriteManager = new SpriteManager(this);
            Components.Add(spriteManager);

            //Mouse/cursor visible
            this.IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //Camera
            camera = new Camera(this, new Vector3(0, 0, 50),
                Vector3.Zero, Vector3.Up);
            Components.Add(camera);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            try
            {
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.Escape))
                    this.Exit();
            }
            catch
            {
            }

            switch (estado)
            {
                case estados.seleccion:
                    tiempoPasado++;
                    if (tiempoPasado > tiempoEspera) 
                    {
                        
                        if (mouseState.LeftButton == ButtonState.Pressed)
                        {
                            tiempoPasado = 0;
                            tiempoEspera = 100;
                            modelManager = null;
                            botonManager = null;
                            if (mouseState.X > (screenWidth / 2))
                            {
                                femeninooSeleccionado();
                            }
                            else
                            {
                                masculinoSeleccionado();
                            }
                        }
                    }
                    
                    break;
                case estados.juego:
                    if (botonManager.estado == estados.fin)
                        estado = estados.fin;
                    break;
                case estados.fin:
                    tiempoPasado++;
                    if (tiempoPasado > tiempoEspera*2)
                        if (mouseState.LeftButton == ButtonState.Pressed)
                        {
                            estado = estados.seleccion;
                            botonManager.estado = estados.seleccion;
                            modelManager.estado = estados.seleccion;
                            spriteManager.Enabled = true;
                            spriteManager.Visible = true;
                            tiempoPasado = 0;
                            tiempoEspera = 10;
                        }
                    break;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        void masculinoSeleccionado() 
        {
            modelManager = new ModelManager(this, ModelManager.sexo.Masculino, screenHeight, screenWidth);
            Components.Add(modelManager);
            spriteManager.Enabled = false;
            spriteManager.Visible = false;
            botonManager = new BotonManager(this, modelManager.models, screenHeight, screenWidth);
            Components.Add(botonManager);
            estado = estados.juego;
        }

        void femeninooSeleccionado() 
        {
            modelManager = new ModelManager(this, ModelManager.sexo.Femenino, screenHeight, screenWidth);
            Components.Add(modelManager);
            spriteManager.Enabled = false;
            spriteManager.Visible = false;
            botonManager = new BotonManager(this, modelManager.models, screenHeight, screenWidth);
            Components.Add(botonManager);
            estado = estados.juego;
        }
    }
}
