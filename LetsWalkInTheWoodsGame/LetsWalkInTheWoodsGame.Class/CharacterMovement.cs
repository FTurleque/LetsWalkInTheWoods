using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsWalkInTheWoodsGame.Class
{
    public class CharacterMovement
    {
        private Character hero;

        public CharacterMovement(Character _hero)
        {
            this.hero = _hero;
            CharacterMoving();
        }

        public void CharacterMoving(char _movement = ' ')
        {
            int x = hero.X;
            int y = hero.Y;
            switch (_movement)
            {
                case 'N':
                    if (GetTreeOrNot(x, y - 1) && GetLimitOfMap(x, y - 1))
                    {
                        hero.MoveUp();
                        Map.CharacterMapping(hero);
                    }
                    break;
                case 'S':
                    if (GetTreeOrNot(x, y + 1) && GetLimitOfMap(x, y + 1))
                    {
                        hero.MoveDown();
                        Map.CharacterMapping(hero);
                    }
                    break;
                case 'O':
                    if (!GetTreeOrNot(x - 1, y) && !GetLimitOfMap(x - 1, y))
                    {
                        hero.MoveLeft();
                        Map.CharacterMapping(hero);
                    }
                    break;
                case 'E':
                    if (!GetTreeOrNot(x + 1, y) && !GetLimitOfMap(x + 1, y))
                    {
                        hero.MoveRight();
                        Map.CharacterMapping(hero);
                    }
                    break;
                default:
                    Map.CharacterMapping(hero);
                    break;
            }
            /*char[] direction = _movement.ToCharArray();
            foreach (char c in direction)
            {

                if (c == 'N')
                {
                }
                if (c == 'S')
                {
                }
                if (c == 'O')
                {
                }
                if (c == 'E')
                {
                }
            }*/
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