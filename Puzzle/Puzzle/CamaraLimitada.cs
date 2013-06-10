using System;
using Microsoft.Xna.Framework;

namespace Puzzle
{
    class CamaraLimitada : Microsoft.Xna.Framework.GameComponent
    {
        //Camera matrices
        public Matrix view { get; protected set; }
        public Matrix projection { get; protected set; }

        public CamaraLimitada(Game game, Vector3 pos, Vector3 target, Vector3 up)
            : base(game)
        {
            float width = (float)Game.Window.ClientBounds.Width;
            float height = (float)Game.Window.ClientBounds.Height;

            view = Matrix.CreateLookAt(pos, target, up);
            projection = Matrix.CreatePerspectiveFieldOfView(
            MathHelper.PiOver4,
            width / height,
            1, 3000);
        }
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            base.Update(gameTime);
        }
    }
}
