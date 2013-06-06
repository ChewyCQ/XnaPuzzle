using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Puzzle
{
    public class BasicModel
    {
        public Model model { get; protected set; }
        public Matrix world = Matrix.Identity;

        public Matrix worldTranslation = Matrix.Identity;
        public Matrix worldRotation = Matrix.Identity;

        float moveSpeed = 1f;

        public String nombre;

        //Escala
        public Vector3 escala;

        //Rotacion
        public Vector3 rotacionCorrecta = new Vector3(0,0,0);
        public Vector3 rotacionInicial = new Vector3(0, 0, 0);
        public Vector3 rotacionActual = new Vector3(0,0,0);

        //Coordenadas
        public Vector3 posicionCorrecta = new Vector3(0, 0, 0);
        public Vector3 posicionInicial = new Vector3(0, 0, 0);
        public Vector3 posicionActual = new Vector3(0, 0, 0);

        public List<BasicModel> modelos;

        public BasicModel(Model m)
        {
            model = m;
        }

        public BasicModel(Model m, Vector3 escala)
        {
            model = m;
            this.escala = escala;
            rotacionActual = new Vector3(0,0,0);
        }

        public BasicModel(Model m, Vector3 scale, Vector3 rotacion, String nombre)
        {
            model = m;
            this.escala = scale;
            this.rotacionInicial = rotacion;
            this.rotacionActual = rotacion;
            worldRotation *= Matrix.CreateRotationX(rotacionActual.X);
            worldRotation *= Matrix.CreateRotationY(rotacionActual.Y);
            worldRotation *= Matrix.CreateRotationZ(rotacionActual.Z);
            this.nombre = nombre;
        }

        public virtual void Update()
        {
            if (rotacionActual.X > MathHelper.ToRadians(360))
                rotacionActual.X -= MathHelper.ToRadians(360);
            if (rotacionActual.Y > MathHelper.ToRadians(360))
                rotacionActual.Y -= MathHelper.ToRadians(360);
            if (rotacionActual.Z > MathHelper.ToRadians(360))
                rotacionActual.Z -= MathHelper.ToRadians(360);
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
            //worldRotation *= Matrix.CreateRotationX(MathHelper.ToRadians(rotacionActual.X));
            //worldRotation *= Matrix.CreateRotationY(rotacionActual.Y);
            //worldRotation *= Matrix.CreateRotationZ(rotacionActual.Z);

            //Escala * Rotacion * Posicion
            return Matrix.CreateScale(escala) * 
                worldRotation * 
                Matrix.CreateTranslation(posicionActual);
            /*
             * Matrix.CreateFromYawPitchRoll
                (MathHelper.ToRadians(rotacionActual.X), 
                MathHelper.ToRadians(rotacionActual.Y), 
                MathHelper.ToRadians(rotacionActual.Z))
             */
        }
    }//Class
}//NAMESPACE