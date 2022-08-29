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
            InTheWood = GetTreeOrNot() || GetLimitOfMap();
        }

        /// <summary>
        /// Effectue le mouvement du personnage selon les point cardinaux
        /// </summary>
        /// <param name="_movement">Chaine de charactère comprenant tous les mouvement à éffectuer</param>
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

        /// <summary>
        /// Permet de savoir si les coordonnées du mouvement ne sont pas hors de la carte.
        /// </summary>
        /// <returns>Si les coordonnées sont sur la carte ou non</returns>
        private bool GetLimitOfMap()
        {
            if(Map.OutOfMap(hero.CharacterX, hero.CharacterY))
            {
                Console.WriteLine("Vous allez sortir de la carte !");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Permet de savoir si il y a un arbre aux coordonnées du mouvement.
        /// </summary>
        /// <returns>Si il y a un arbre ou non</returns>
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