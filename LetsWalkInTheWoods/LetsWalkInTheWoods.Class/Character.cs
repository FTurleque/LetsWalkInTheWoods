using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsWalkInTheWoods.Class
{
    public class Character
    {
        public int CharacterX { get; set; }

        public int CharacterY { get; set; }

        public char CharacterBody { get; }

        public Character(int _X, int _Y)
        {
            this.CharacterX = _X;
            this.CharacterY = _Y;
        }

        /// <summary>
        /// Déplacement du personnage vers le sud.
        /// </summary>
        public void MoveDown()
        {
            CharacterY++;
        }

        /// <summary>
        /// Déplacement du personnage vers le nord.
        /// </summary>
        public void MoveUp()
        {
            CharacterY--;
        }

        /// <summary>
        /// Déplacement du personnage vers l'ouest.
        /// </summary>
        public void MoveLeft()
        {
            CharacterX--;
        }

        /// <summary>
        /// Déplacement du personnage vers l'est.
        /// </summary>
        public void MoveRight()
        {
            CharacterX++;
        }
    }
}