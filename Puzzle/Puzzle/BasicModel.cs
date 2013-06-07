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

        public String nombre;

        //Escala
        public Vector3 escala;

        //Rotacion
        public Vector3 rotacionCorrecta = new Vector3(0,0,0);
        public Vector3 rotacionInicial = new Vector3(0, 0, 0);
        public Vector3 rotacionActual = new Vector3(0,0,0);

        //Coordenadas
        public Vector3 posicionCorrecta;
        public Vector3 posicionInicial;
        public Vector3 posicionActual;

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

        public BasicModel(Model m, Vector3 scale, Vector3 rotacion, Vector3 posicion, String nombre)
        {
            model = m;
            this.escala = scale;
            this.rotacionInicial = rotacion;
            this.posicionInicial = posicion;
            this.posicionActual = posicion;

            rotacionActual += new Vector3(MathHelper.ToRadians(rotacion.X),
                MathHelper.ToRadians(rotacion.Y), MathHelper.ToRadians(rotacion.Z));

            worldRotation *= Matrix.CreateRotationX(MathHelper.ToRadians(rotacion.X));
            worldRotation *= Matrix.CreateRotationY(MathHelper.ToRadians(rotacion.Y));
            worldRotation *= Matrix.CreateRotationZ(MathHelper.ToRadians(rotacion.Z));

            //worldRotation *= Matrix.CreateRotationX(rotacionActual.X);
            //worldRotation *= Matrix.CreateRotationY(rotacionActual.Y);
            //worldRotation *= Matrix.CreateRotationZ(rotacionActual.Z);
            this.nombre = nombre;
        }

        public virtual void Update()
        {
            //Si se pasa de 360
            if (rotacionActual.X >= MathHelper.ToRadians(360))
                rotacionActual.X -= MathHelper.ToRadians(360);
            if (rotacionActual.Y >= MathHelper.ToRadians(360))
                rotacionActual.Y -= MathHelper.ToRadians(360);
            if (rotacionActual.Z >= MathHelper.ToRadians(360))
                rotacionActual.Z -= MathHelper.ToRadians(360);
            //Si es menor a 0
            if (rotacionActual.X < MathHelper.ToRadians(0))
                rotacionActual.X += MathHelper.ToRadians(360);
            if (rotacionActual.Y < MathHelper.ToRadians(0))
                rotacionActual.Y += MathHelper.ToRadians(360);
            if (rotacionActual.Z < MathHelper.ToRadians(0))
                rotacionActual.Z += MathHelper.ToRadians(360);
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
                worldRotation * 
                Matrix.CreateTranslation(posicionActual);
        }
    }//Class
}//NAMESPACE