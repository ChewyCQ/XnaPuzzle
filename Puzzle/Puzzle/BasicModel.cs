using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Puzzle
{
    public class BasicModel
    {
        public Model model { get; protected set; }
        public Matrix world = Matrix.Identity;

        public Matrix worldTranslation = Matrix.Identity;
        public Matrix worldRotation = Matrix.Identity;

        public float scaleX = 1;
        public float scaleY = 1;
        public float scaleZ = 1;

        public List<BasicModel> modelos;

        public BasicModel(Model m)
        {
            model = m;
        }

        public BasicModel(Model m, float x, float y, float z)
        {
            model = m;
            this.scaleX = x;
            this.scaleY = y;
            this.scaleZ = z;
        }

        public BasicModel(Model m, float scale, Matrix rotation)
        {
            model = m;
            worldRotation *= rotation;
        }

        public virtual void Update()
        {

        }

        public void Draw(Camera camera)
        {
            Matrix[] transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect be in mesh.Effects)
                {
                    be.EnableDefaultLighting();
                    be.Projection = camera.projection;
                    be.View = camera.view;
                    be.World = GetWorld() * mesh.ParentBone.Transform;
                }
                mesh.Draw();
            }
        }

        public virtual Matrix GetWorld()
        {
            return Matrix.CreateScale(scaleX, scaleY, scaleZ) * worldRotation * worldTranslation;
        }
    }//Class
}