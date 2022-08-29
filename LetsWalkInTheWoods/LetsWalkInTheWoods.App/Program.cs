﻿// See https://aka.ms/new-console-template for more information

using LetsWalkInTheWoods.Class;
using System.Text.RegularExpressions;

Map map = new Map();
Character hero = new(0,0);
CharacterMovement move;
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
                move = new CharacterMovement(hero);
                isntOk = move.InTheWood;
                if (isntOk)
                {
                    Console.WriteLine("Vous ne pouvez pas utiliser ces coordonées, ils se trouve dans la forêt.\n");
                }
            }
        }
    } while (isntOk);
    move = new CharacterMovement(hero);
    if (!move.InTheWood)
    {
        isntOk = true;
        string direction;
        do
        {
            Console.WriteLine("\nEntrez les coordonnées de destination\nN: pour nord, S: pour sud, E: pour est et O: pour ouest sans espace :");
            direction = Console.ReadLine().ToUpper();
            if (regex.IsMatch(direction))
            {
                move.CharacterMoving(direction);
                if (!move.InTheWood)
                {
                    isntOk = false;
                    Console.WriteLine($"Le personage se trouve en ({hero.CharacterX},{hero.CharacterY})");
                }
            }
            else
            {
                Console.WriteLine("Vous navez pas utilisez les point cardinaux !");
            }
        } while (isntOk);
    }
    Console.WriteLine("Voulez-vous recommencer ? O/N :");
    string response = Console.ReadLine().ToUpper();
    if(response == "N")
    {
        dontStop = false;
    }

} while (dontStop);

