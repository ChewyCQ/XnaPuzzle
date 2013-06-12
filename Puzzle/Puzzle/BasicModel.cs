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

        public String nombre;

        public Boolean acomodado = false;
        public Boolean preview = false;

        const float proximity = 2;

        //Escala
        public Vector3 escala;
        float moveSpeed = 1.0f;
        const float rotacion = 2.5f;

        //Rotacion
        public Vector3 rotacionCorrecta = new Vector3(0,0,0);
        public Vector3 rotacionInicial = new Vector3(0, 0, 0);
        public Vector3 rotacionActual = new Vector3(0,0,0);

        //Coordenadas
        public Vector3 posicionCorrecta;
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

        //Constructor q inicia acomodado
        public BasicModel(Model m, Vector3 scale, Vector3 rot, Vector3 posicion, String nombre)
        {
            model = m;
            this.escala = scale;
            this.rotacionInicial = rot;
            this.posicionCorrecta = posicion;
            this.posicionActual = posicion;
            rotacionActual = new Vector3(rot.X,rot.Y, rot.Z);
            
            this.nombre = nombre;
        }

        //Constructor que inicia desacomodado
        public BasicModel(Model m, Vector3 scale, Vector3 rot, Vector3 posicion, Vector3 inicial, String nombre)
        {
            model = m;
            this.escala = scale;
            this.rotacionInicial = rot;
            this.posicionCorrecta = posicion;
            this.posicionActual = inicial;
            
            rotacionActual = new Vector3(rot.X, rot.Y, rot.Z);
            
            this.nombre = nombre;
        }

        public virtual void Update()
        {
            proximidad();
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
            if (!preview)
                return Matrix.CreateScale(escala) *
                    (Matrix.CreateRotationX(MathHelper.ToRadians(rotacionActual.X)) *
                    Matrix.CreateRotationY(MathHelper.ToRadians(rotacionActual.Y)) *
                    Matrix.CreateRotationZ(MathHelper.ToRadians(rotacionActual.Z))) *
                    Matrix.CreateTranslation(posicionActual);
            else
                return Matrix.CreateScale(escala) *
                    (Matrix.CreateRotationX(MathHelper.ToRadians(rotacionActual.X)) *
                    Matrix.CreateRotationY(MathHelper.ToRadians(rotacionActual.Y)) *
                    Matrix.CreateRotationZ(MathHelper.ToRadians(rotacionActual.Z))) *
                    Matrix.CreateTranslation(posicionCorrecta);
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

        public void proximidad()
        {
            if (!acomodado)
            {
                if (proximidadEnX() && proximidadEnY() && proximidadEnZ())
                {
                    posicionActual = posicionCorrecta;
                    acomodado = true;
                    moveSpeed = 0;
                }
            }
        }

        Boolean proximidadEnX()
        {
            if (posicionActual.X - posicionCorrecta.X < proximity &&
                posicionCorrecta.X - posicionActual.X < proximity)
                return true;
            else
                return false;
        }

        Boolean proximidadEnY()
        {
            if (posicionActual.Y - posicionCorrecta.Y < proximity &&
                posicionCorrecta.Y - posicionActual.Y < proximity)
                return true;
            else
                return false;
        }

        Boolean proximidadEnZ()
        {
            if (posicionActual.Z - posicionCorrecta.Z < proximity &&
                posicionCorrecta.Z - posicionActual.Z < proximity)
                return true;
            else
                return false;
        }

    }//Class
}//NAMESPACE