using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsWalkInTheWoods.Class
{
    public class CharacterMovement
    {
        private Character hero;
        public bool InTheWood { get; private set; }

        public CharacterMovement(Character _hero, string _movement = " ")
        {
            this.hero = _hero;
            //CharacterMoving(_movement);
            InTheWood = GetTreeOrNot() || GetLimitOfMap();
        }

        public void CharacterMoving(string _movement)
        {
            char[] direction = _movement.ToCharArray();
            foreach (char c in direction)
            {
                if (c == 'N')
                {
                    hero.MoveUp();
                    if (GetTreeOrNot() || GetLimitOfMap())
                    {
                        InTheWood = true;
                        hero.MoveDown();
                        return;
                    }
                }
                if (c == 'S')
                {
                    hero.MoveDown();
                    if (GetTreeOrNot() || GetLimitOfMap())
                    {
                        InTheWood = true;
                        hero.MoveUp();
                        return;
                    }
                }
                if (c == 'O')
                {
                    hero.MoveLeft();
                    if (GetTreeOrNot() || GetLimitOfMap())
                    {
                        InTheWood = true;
                        hero.MoveRight();
                        return;
                    }
                }
                if (c == 'E')
                {
                    hero.MoveRight();
                    if (GetTreeOrNot() || GetLimitOfMap())
                    {
                        InTheWood = true;
                        hero.MoveLeft();
                        return;
                    }
                }
                if (c == ' ')
                {
                    if (InTheWood)
                    {
                        Console.WriteLine("Vous ne pouvez pas vous placer a ces coordonnées.");
                    }
                }
            }
        }

        private bool GetLimitOfMap()
        {
            if(Map.OutOfMap(hero.CharacterX, hero.CharacterY))
            {
                Console.WriteLine("Vous allez sortir de la carte !");
                return true;
            }
            return false;
        }

        private bool GetTreeOrNot()
        {
            if (Map.GetIsTree(hero.CharacterX, hero.CharacterY))
            {
                Console.WriteLine("Il y a un arbre à cet emplacement !");
                return true;
            }
            return false;
        }
    }
}