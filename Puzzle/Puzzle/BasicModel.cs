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
        const float moveSpeed = 0.25f;
        const float rotacion = 2.5f;

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

        public BasicModel(Model m, Vector3 scale, Vector3 rot, Vector3 posicion, String nombre)
        {
            model = m;
            this.escala = scale;
            this.rotacionInicial = rot;
            this.posicionInicial = posicion;
            this.posicionActual = posicion;

            worldTranslation = Matrix.Identity;
            worldRotation = Matrix.Identity;

            rotacionActual = new Vector3(rot.X,rot.Y, rot.Z);

            worldRotation *= Matrix.CreateRotationX(MathHelper.ToRadians(rot.X));
            worldRotation *= Matrix.CreateRotationY(MathHelper.ToRadians(rot.Y));
            worldRotation *= Matrix.CreateRotationZ(MathHelper.ToRadians(rot.Z));

            this.nombre = nombre;
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
            //Escala * Rotacion * Posicion
            return Matrix.CreateScale(escala) *
                (Matrix.CreateRotationX(MathHelper.ToRadians(rotacionActual.X)) *
                Matrix.CreateRotationY(MathHelper.ToRadians(rotacionActual.Y)) *
                Matrix.CreateRotationZ(MathHelper.ToRadians(rotacionActual.Z))) *
                //worldRotation * 
                Matrix.CreateTranslation(posicionActual);
        }

        public void Move()
        {
            //Si se pasa de 360
            if (rotacionActual.X >= 360)
                rotacionActual.X -= 360;
            if (rotacionActual.Y >= 360)
                rotacionActual.Y -= 360;
            if (rotacionActual.Z >= 360)
                rotacionActual.Z -= 360;
            //Si es menor a 0
            if (rotacionActual.X < 0)
                rotacionActual.X += 360;
            if (rotacionActual.Y < 0)
                rotacionActual.Y += 360;
            if (rotacionActual.Z < 0)
                rotacionActual.Z += 360;

            try
            {
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    posicionActual += new Vector3(-moveSpeed, 0, 0);
                }
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    posicionActual += new Vector3(moveSpeed, 0, 0);
                }
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    posicionActual += new Vector3(0, moveSpeed, 0);
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    posicionActual += new Vector3(0, -moveSpeed, 0);
                }
                if (keyboardState.IsKeyDown(Keys.I))
                {
                    posicionActual += new Vector3(0, 0, moveSpeed);
                }
                if (keyboardState.IsKeyDown(Keys.K))
                {
                    posicionActual += new Vector3(0, 0, -moveSpeed);
                }
                if (keyboardState.IsKeyDown(Keys.X))
                {
                    rotacionActual.X += rotacion;
                }
                if (keyboardState.IsKeyDown(Keys.Y))
                {
                    rotacionActual.Y += rotacion;
                }
                if (keyboardState.IsKeyDown(Keys.Z))
                {
                    rotacionActual.Z += rotacion;
                }
            }
            catch { }
        }

        public void moverX(int signo)
        {
            posicionActual += new Vector3(signo * moveSpeed, 0, 0);
        }

        public void moverY(int signo)
        {
            posicionActual += new Vector3(0, signo * moveSpeed, 0);
        }

        public void moverZ(int signo)
        {
            posicionActual += new Vector3(0, 0, signo * moveSpeed);
        }

    }//Class
}//NAMESPACE