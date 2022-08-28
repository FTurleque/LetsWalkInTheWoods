using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsWalkInTheWoodsGame.Class
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
                int x = hero.X;
                int y = hero.Y;

                if (c == 'N')
                {
                    if (GetTreeOrNot(x - 1, y) && GetLimitOfMap(x - 1, y))
                    {
                        hero.MoveUp();
                    }
                }
                if (c == 'S')
                {
                    if (GetTreeOrNot(x + 1, y) && GetLimitOfMap(x + 1, y))
                    {
                        hero.MoveDown();
                    }
                }
                if (c == 'O')
                {
                    if (!GetTreeOrNot(x, y - 1) && !GetLimitOfMap(x, y - 1))
                    {
                        hero.MoveLeft();
                    }
                }
                if (c == 'E')
                {
                    if (!GetTreeOrNot(x, y + 1) && !GetLimitOfMap(x, y + 1))
                    {
                        hero.MoveRight();
                    }
                }
            }
        }

        private bool GetLimitOfMap(int x, int y)
        {
            return Map.OutOfMap(hero.X, hero.Y);
        }

        private bool GetTreeOrNot(int x, int y)
        {
            return Map.IsATree(hero.X, hero.Y);
        }
    }
}