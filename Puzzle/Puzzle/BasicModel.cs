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

        //Escala
        public Vector3 escala;

        //Rotacion
        public Vector3 rotacionCorrecta = new Vector3(0,0,0);
        public Vector3 rotacionInicial = new Vector3(0, 0, 0);
        public Vector3 rotacionActual = new Vector3(0,0,0);
    
        public Vector3 RotacionActual
        {
            get
            {
                return rotacionActual;
            }
            set
            {
                if (rotacionActual.X > 2 * MathHelper.Pi)
                {
                    rotacionActual.X -= 2 * MathHelper.Pi;
                }
                if (rotacionActual.Y > 360)
                {
                    rotacionActual.Y -= 360;
                }
                if (rotacionActual.Z > 360)
                {
                    rotacionActual.Z -= 360;
                } 
                rotacionActual = value;
            }
        }

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

        public BasicModel(Model m, float scale, Matrix rotation)
        {
            model = m;
            worldRotation *= rotation;
        }

        public virtual void Update()
        {
            if (rotacionActual.X > 360)
                rotacionActual.X -= 360;
            if (rotacionActual.Y > 360)
                rotacionActual.Y -= 360;
            if (rotacionActual.Z > 360)
                rotacionActual.Z -= 360;
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
            //Escala * Rotacion * Posicion
            return Matrix.CreateScale(escala) * 
                Matrix.CreateFromYawPitchRoll
                (MathHelper.ToRadians(rotacionActual.X), MathHelper.ToRadians(rotacionActual.Y), MathHelper.ToRadians(rotacionActual.Z)) * 
                Matrix.CreateTranslation(posicionActual);//worldTranslation
        }
    }//Class
}