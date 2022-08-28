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

        public void MoveDown()
        {
            CharacterY++;
        }

        public void MoveUp()
        {
            CharacterY--;
        }

        public void MoveLeft()
        {
            CharacterX--;
        }

        public void MoveRight()
        {
            CharacterX++;
        }
    }
}