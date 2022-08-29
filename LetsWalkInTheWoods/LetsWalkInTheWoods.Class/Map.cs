using LetsWalkInTheWoods.Class.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsWalkInTheWoods.Class
{
    public class Map
    {
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public string GetMap { get; }

        public static int Width { get; private set; }

        public static int Heigth { get; private set; }

        public static string[] Mapping { get; private set; }

        public Map()
        {
            //GetMap = File.ReadAllText(Path.Combine(path, "carte.txt"), Encoding.UTF8);
            GetMap = Resources.carte;
            Mapping = CreateMapping();
            Width = GetWidth();
            Heigth = GetHeight();
        }

        /// <summary>
        /// Recupérer la largeur de la carte.
        /// </summary>
        /// <returns>La largeur</returns>
        private static int GetWidth()
        {
            return Mapping[0].Length;
        }

        /// <summary>
        /// Recupérer la longeur de la carte.
        /// </summary>
        /// <returns>La longeur</returns>
        private int GetHeight()
        {
            return Mapping.Length;
        }

        /// <summary>
        /// Création d'un tableaux de string pour y placer le personnage.
        /// Incluant la forêt.
        /// </summary>
        /// <returns>La carte sous la forme d'un tableaux de string</returns>
        private string[] CreateMapping()
        {
            return GetMap.Split("\r\n");
        }
        
        /// <summary>
        /// Vérifie si il y a un arbre auw coordonnées données
        /// </summary>
        /// <param name="x">Coordonnée x</param>
        /// <param name="y">Coordonnée y</param>
        /// <returns>Retourne s'il y a un arbre</returns>
        public static bool GetIsTree(int x, int y)
        {
            if (OutOfMap(x, y))
            {
                return true;
            }
            string row = Mapping[y];
            char[] col = row.ToCharArray();
            if (col[x] == '#')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Vérifie si les coordonnées sont bien sur la carte.
        /// </summary>
        /// <param name="x">Coordonnée x</param>
        /// <param name="y">Coordonnée y</param>
        /// <returns>Retourne si les coordonnées sont valides</returns>
        public static bool OutOfMap(int x, int y)
        {
            if (x < 0 || x > Width || y < 0 || y > Width)
            {
                return true;
            }
            return false;
        }
    }
}