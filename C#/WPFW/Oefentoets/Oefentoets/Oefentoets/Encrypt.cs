// Dit programma vraagt de gebruiker om een sleutel (een integer tussen 1-9). 
// Vervolgens leest het een bestand in van c:\temp\invoer.txt en elke regel wordt opgeslagen in een object van de klasse Tekst.
// De klasse Tekst bevat een attribuut regels (een lijst van strings) en een attribuut sleutel waarin de encryptiesleutel wordt opgeslagen.
// De klasse Tekst kan de ingevoerde tekst versleutelen met behulp van de ingevoerde sleutel door de methode Crypt() aan te roepen.
// Bij de encryptie worden alle karakters, inclusief letters, leestekens en spaties, verschoven met de waarde van de sleutel.
// Dus als de key 2 is, wordt 'a' -> 'c', 'F' -> 'H', 'x' -> 'z', enz.
// De versleutelde tekst wordt teruggegeven als een list van strings en naar c:\temp\encrypted.txt geschreven.

using System;
using System.IO;
using System.Collections.Generic;

class Tekst
{
    public List<string> regels;     // Lijst van strings die de regels van het bestand opslaan
    public int sleutel;             // De encryptiesleutel
    public Tekst(List<string> regels, int sleutel)  
    {
        this.regels = regels;       // Sla de regels op
        this.sleutel = sleutel;     // Sla de sleutel op
    }
    public List<string> Crypt()  // Methode om de tekst te versleutelen
    {
        List<string> versleuteldeRegels = new List<string>();   // List voor de versleutelde regels

        // Vul hieronder het stukje programma in dat de regel versleutelt
        // loop dus door alle regels heen en doe voor iedere regel:
        // - loop door alle characters in de regel heen
        // - versleutel het karakter met de sleutel
        // - voeg het versleutelde karakter toe aan de versleutelde regel
        // - aan het eind van de regel: voeg de versleutelde regel toe aan de lijst met versleutelde regels
        // @@@@ hier onder invullen

        foreach (string regel in regels)
        {
            string newChars = "";
            foreach (char c in regel)
            {
                newChars += (char)(c + sleutel);
            }
            versleuteldeRegels.Add(newChars);
        }



        // @@@ tot hier invullen

        return versleuteldeRegels;  // Retourneer de lijst met versleutelde regels
    }
}

class Encrypt
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Voer een sleutel in (1-9): "); // Vraag de gebruiker om een sleutel
            int sleutel = int.Parse(Console.ReadLine());  // Lees en converteer de sleutel naar een integer
            
            string[] invoer = File.ReadAllLines("/Users/pep/development/hhs-projecten/C#/WPFW/Oefentoets/Oefentoets/invoer.txt"); // Lees het invoerbestand naar een string array
            List<string> regels = new List<string>(invoer);             // Zet de regels om in een list van strings
            
            Tekst tekst = new Tekst(regels, sleutel);       // Maak een Tekst object met de regels en de opgegeven sleutel
            List<string> versleuteldeTekst = tekst.Crypt(); // Versleutel de tekst door de Crypt methode aan te roepen

            File.WriteAllLines("/Users/pep/development/hhs-projecten/C#/WPFW/Oefentoets/Oefentoets/encrypted.txt", tekst.Crypt());    // Schrijf de versleutelde tekst weg
            Console.WriteLine("Tekst succesvol versleuteld en opgeslagen in /Users/pep/development/hhs-projecten/C#/WPFW/Oefentoets/Oefentoets/encrypted.txt");
        }
        catch (Exception ex)  // Foutafhandeling
        {
            Console.WriteLine("Er is een fout opgetreden: " + ex.Message);
        }
    }
}
