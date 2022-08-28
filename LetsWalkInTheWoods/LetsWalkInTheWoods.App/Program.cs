// See https://aka.ms/new-console-template for more information

using LetsWalkInTheWoods.Class;
using System.Text.RegularExpressions;

Map map = new Map();
Character hero = new(0,0);
Regex regex = new Regex("^[NSEO]*$");
string[] coordonate;
bool isntOk = true;
bool dontStop = true;
do
{
    do
    {
        Console.WriteLine("Entrez les coordonnées de départ du personnage x,y (séparé par une virgule) :");
        string coordonateEntry = Console.ReadLine();
        if (coordonateEntry == null)
        {
            Console.WriteLine("Veuillez renseigner les coordonées !");
        }
        else
        {
            coordonate = coordonateEntry.Split(",");
            if (coordonate.Length > 3)
            {
                Console.WriteLine("Vous avez renseignez trop de données !");
            }
            else
            {
                hero = new Character(int.Parse(coordonate[0]), int.Parse(coordonate[1]));
                isntOk = false;
            }
        }
    } while (isntOk);
    isntOk = true;
    string direction;
    do
    {
        Console.WriteLine("Entrez les coordonnées de destination\nN: pour nord, S: pour sud, E: pour est et O: pour ouest sans espace :");
        direction = Console.ReadLine().ToUpper();
        if (regex.IsMatch(direction))
        {
            isntOk = false;
        }
        else
        {
            Console.WriteLine("Vous navez pas utilisez les point cardinaux !");
        }
    } while (isntOk);

    CharacterMovement move = new CharacterMovement(hero, direction);


    Console.WriteLine($"Le personage se trouve en ({hero.CharacterX},{hero.CharacterY})");
    Console.WriteLine("Voulez-vous continuer ? O/N :");
    string response = Console.ReadLine().ToLower();
    if(response == "n")
    {
        dontStop = false;
    }

} while (dontStop);

