﻿using System;
using System.Drawing;

namespace EnVoiture
{
    /// <summary>
    /// Classe représentant un élément mobile de l'application, comme une voiture ou un piéton, par exemple.
    /// </summary>
    public abstract class Usager
    {
        private RectangleF bornes;
        private float dblVitesse;
        private float dblVitesseMax;
        private const float ACCELERATION = 0.10F;
        private const float DECCELERATION = 0.02F;
        private const float FREINAGE = 0.15F;

        /// <summary>
        /// propriété règlant la vitesse
        /// </summary>
        public float Vitesse
        {
            get
            {
                return dblVitesse;
            }
            set
            {
                if (value <= dblVitesseMax)
                {
                    dblVitesse = value;
                }
                else
                {
                    dblVitesse = dblVitesseMax;
                }
            }
        }

        /// <summary>
        /// propriété règéant la vitesse maximum 
        /// </summary>
        public float VitesseMax
        {
            get
            {
                return dblVitesseMax;
            }
            set
            {
                dblVitesseMax = value;
            }
        }

        public RectangleF Bornes
        {
            get
            {
                return bornes;
            }
            set
            {
                bornes = value;
            }
        }

        /// <summary>
        /// Emplacement de l'usager
        /// </summary>
        public PointF Position
        {
            get
            {
                return bornes.Location;
            }
            set
            {
                bornes.Location = value;
            }
        }
        /// <summary>
        /// propriétét automatique défini la taille en float
        /// </summary>
        public SizeF Size
        {
            get
            {
                return bornes.Size;
            }
            set
            {
                bornes.Size = value;
            }
        }

        /// <summary>
        /// Largeur de l'usager
        /// </summary>
        public float Largeur
        {
            get
            {
                return bornes.Width;
            }
            set
            {
                bornes.Width = value;
            }
        }

        /// <summary>
        /// Hauteur de l'usager
        /// </summary>
        public float Hauteur
        {
            get
            {
                return bornes.Height;
            }
            set
            {
                bornes.Height = value;
            }
        }

        /// <summary>
        /// Position x de la gauche de l'usager
        /// </summary>
        public float Gauche
        {
            get
            {
                return bornes.Left;
            }
        }

        /// <summary>
        /// Position x de la droite de l'usager
        /// </summary>
        public float Droite
        {
            get
            {
                return bornes.Right;
            }
        }

        /// <summary>
        /// Position y du haut de l'usager
        /// </summary>
        public float Haut
        {
            get
            {
                return bornes.Top;
            }
        }

        /// <summary>
        /// Position y du bas de l'usager
        /// </summary>
        public float Bas
        {
            get
            {
                return bornes.Bottom;
            }
        }

        /// <summary>
        /// Angle de rotation de l'usager.
        /// </summary>
        public float Angle { get; set; }

        /// <summary>
        /// Constructeur permettant de définir la position et la taille d'un usager d'après un rectangle.
        /// </summary>
        /// <param name="bounds">Rectangle sur lequel baser la géométrie de l'usager</param>
        public Usager(RectangleF bounds, float v, float vMax)
        {
            this.bornes = bounds;
            VitesseMax = vMax;
            Vitesse = v;
        }

        /// <summary>
        /// Constructeur permettant de définir la position et la taille d'un usager en donnant directement les valeurs.
        /// </summary>
        /// <param name="x">Position x du côté gauche</param>
        /// <param name="y">Position y du haut</param>
        /// <param name="width">Largeur</param>
        /// <param name="height">Hauteur</param>
        /// <param name="v"> vitesse de base </param>
        /// <param name="vMax">vitesse Max</param>
        public Usager(float x, float y, float width, float height, float v, float vMax)
            : this(new RectangleF(x, y, width, height), v, vMax)
        {

        }

        /// <summary>
        /// Vérifie si cet usager et un second sont en contact.
        /// </summary>
        /// <param name="other">L'autre usager</param>
        /// <returns>Si cet usager et l'autre se touchent</returns>
        public bool Heurte(Usager autre)
        {
            return bornes.IntersectsWith(autre.bornes);
        }
        /// <summary>
        /// Vérifie si le clique de souris est en contact avec un usager.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Si le clique de souris à la même position que l'usager</returns>
        public bool estClique(PointF cursorPosition)
        {
            return bornes.IntersectsWith(new RectangleF(cursorPosition, new SizeF(1, 1)));
        }

        /// <summary>
        /// modifie la location en créant un nouveau point et nous permet d'avancer
        /// </summary>
        public void Avancer()
        {
            Position = new PointF((float)(Position.X + dblVitesse * Math.Sin(Angle)), (float)(Position.Y - dblVitesse * Math.Cos(Angle)));
        }
        public void TournerGauche()
        {
            Angle -= Vitesse / 100.0F;
        }
        public void TournerDroite()
        {//ACCELERATION = 10F;DECCELERATION = 2F;FREINAGE = 15F;
            Angle += Vitesse / 100.0F;
        }
        /// <summary>
        /// décrémente la vitesse 
        /// </summary>
        public void Reculer()
        {
            dblVitesse -= ACCELERATION;
            Position = new PointF((float)(Position.X + dblVitesse * Math.Sin(Angle)), (float)(Position.Y - dblVitesse * Math.Cos(Angle)));
        }
        /// <summary>
        /// si on ne presse plus rien et que la voiture avance, on ralenti 
        /// </summary>
        public void Ralentir()
        {
            if (Vitesse > 0)
            {
                dblVitesse -= DECCELERATION;
            }
            else if (Vitesse < 0)
            {
                dblVitesse += DECCELERATION;
            }
        }

        /// <summary>
        /// incrémente la vitesse 
        /// </summary>
        public void Accelerer()
        {
            dblVitesse += ACCELERATION;
            Avancer();
        }
        /// <summary>
        /// décrémente la vitesse 
        /// </summary>

        public void Freiner()
        {
            Position = new PointF(Position.X, Position.Y);
            dblVitesse -= FREINAGE;
        }
        /// <summary>
        /// pas encore implémenter, décrémentera la vitessse en fonction du freinage d'urgence (gros freinage)
        /// </summary>
        public void FreinageUrgence()
        {
        }
    }
}
