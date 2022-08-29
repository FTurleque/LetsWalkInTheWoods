using System.Collections.Generic;
using System.Text;

namespace LetsWalkInTheWoodsGame.Class
{
    public class Map
    {
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public string GetMap { get; }

        public static int Width { get; private set; }

        public static int Heigth { get; private set; }

        public static string[] Mapping { get; private set; }

        private static int lastX;
        private static int lastY;

        public Map()
        {
            GetMap = File.ReadAllText(Path.Combine(path, "carte.txt"), Encoding.UTF8);
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
        /// Localisation du personnage sur la carte.
        /// </summary>
        /// <param name="_character">Personnage</param>
        public static void CharacterMapping(Character _character)
        {
            string row = Mapping[_character.Y];
            char[] col = row.ToCharArray();
            col[_character.X] = _character.CharacterBody;
            StringBuilder newRow = new StringBuilder();
            foreach (char c in col)
            {
                newRow.Append(c);
            }
            Mapping[_character.Y] = newRow.ToString();
            lastX = _character.X;
            lastY = _character.Y;
        }

        /// <summary>
        /// Vérifie si il y a un arbre auw coordonnées données
        /// </summary>
        /// <param name="x">Coordonnée x</param>
        /// <param name="y">Coordonnée y</param>
        /// <returns>Retourne s'il y a un arbre</returns>
        public static bool IsATree(int x, int y)
        {
            if (OutOfMap(x, y))
            {
                return true;
            }
            string row = Mapping[y];
            char[] col = row.ToCharArray();
            if (col[x] == '#')
            {
                Console.WriteLine("Il y a un arbre sur votre route !");
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
                Console.WriteLine("Vous sortez de la carte !");
                return true;
            }
            return false;
        }
    }
}