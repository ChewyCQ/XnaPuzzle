using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Puzzle
{
    class Sprite
    {
        Texture2D textureImage;
        protected Point frameSize;
        Point currentFrame;
        Point sheetSize;
        protected Vector2 speed;
        protected Vector2 position = Vector2.Zero;
        public string collisionCueName { get; private set; }
        protected float scale = 1;
        protected float originalScale = 1;

        public Sprite(Texture2D textureImage, Vector2 position)
        {
            this.textureImage = textureImage;
            this.position = position;
        }

        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize,
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed,
            string collisionCueName, int scoreValue)
        {
            this.textureImage = textureImage;
            this.position = position;
            this.frameSize = frameSize;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.speed = speed;
            this.collisionCueName = collisionCueName;
        }

        //Funciones
        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
            
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Draw all sprites
            spriteBatch.Draw(textureImage, position, Color.White);
        }

        public Vector2 GetPosition
        {
            get { return position; }
        }

        public bool IsOutOfBounds(Rectangle clientRect)
        {
            if (position.X < -frameSize.X || position.X > clientRect.Width ||
            position.Y < -frameSize.Y || position.Y > clientRect.Height)
            {
                return true;
            }
            return false;
        }

        public void ModifyScale(float modifier)
        {
            scale *= modifier;
        }

        public void ResetScale()
        {
            scale = originalScale;
        }
    }//class
}//namespace
