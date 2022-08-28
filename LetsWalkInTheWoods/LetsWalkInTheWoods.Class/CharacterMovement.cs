using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsWalkInTheWoods.Class
{
    public class CharacterMovement
    {
        private Character hero;

        public CharacterMovement(Character _hero, string _movement)
        {
            this.hero = _hero;
            CharacterMoving(_movement);
        }

        private void CharacterMoving(string _movement)
        {
            char[] direction = _movement.ToCharArray();
            foreach (char c in direction)
            {
                if (c == 'N')
                {
                    hero.MoveUp();
                    if (GetTreeOrNot() || GetLimitOfMap())
                    {
                        hero.MoveDown();
                    }
                }
                if (c == 'S')
                {
                    hero.MoveDown();
                    if (GetTreeOrNot() || GetLimitOfMap())
                    {
                        hero.MoveUp();
                    }
                }
                if (c == 'O')
                {
                    hero.MoveLeft();
                    if (GetTreeOrNot() || GetLimitOfMap())
                    {
                        hero.MoveRight();
                    }
                }
                if (c == 'E')
                {
                    hero.MoveRight();
                    if (GetTreeOrNot() || GetLimitOfMap())
                    {
                        hero.MoveLeft();
                    }
                }
            }
        }

        private bool GetLimitOfMap()
        {
            return Map.OutOfMap(hero.CharacterX, hero.CharacterY);
        }

        private bool GetTreeOrNot()
        {
            return Map.GetIsTree(hero.CharacterX, hero.CharacterY);
        }
    }
}