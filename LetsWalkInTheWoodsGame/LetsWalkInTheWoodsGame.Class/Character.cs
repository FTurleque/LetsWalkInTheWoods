using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsWalkInTheWoodsGame.Class
{
    public class Character
    {
        public int X { get; set; }

        public int Y { get; set; }

        public char CharacterBody { get; }

        public Character(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Déplacement du personnage vers le sud.
        /// </summary>
        public void MoveDown()
        {
            Y++;
        }

        /// <summary>
        /// Déplacement du personnage vers le nord.
        /// </summary>
        public void MoveUp()
        {
            Y--;
        }

        /// <summary>
        /// Déplacement du personnage vers l'ouest.
        /// </summary>
        public void MoveLeft()
        {
            X--;
        }

        /// <summary>
        /// Déplacement du personnage vers l'est.
        /// </summary>
        public void MoveRight()
        {
            X++;
        }
    }
}