using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaster : MonoBehaviour
{
    public Dictionary<int, int> conScores = new Dictionary<int, int>();
    public Dictionary<string, int> characterRaces = new Dictionary<string, int>();
    public Dictionary<string, int> characterClasses = new Dictionary<string, int>();


    // Start is called before the first frame update
    void Start()
    {
        setUp();
    }

    public void setUp()
    {
        // Set up constitution scores and modifiers
        int start = -5;
        for (int i = 1; i <= 30; i++)
        {
            if (i % 2 == 0) start++;
            conScores.Add(i, start);
        }

        // Set up races and modifiers
        characterRaces.Add("Aasmar", 0);
        characterRaces.Add("Dragonborn", 0);
        characterRaces.Add("Dwarf", 2);
        characterRaces.Add("Elf", 0);
        characterRaces.Add("Gnome", 0);
        characterRaces.Add("Goliath", 1);
        characterRaces.Add("Halfling", 0);
        characterRaces.Add("Orc", 1);
        characterRaces.Add("Human", 0);
        characterRaces.Add("Tiefling", 0);

        // set up character classes and hit die
        characterClasses.Add("Artificer", 8);
        characterClasses.Add("Barbarian", 12);
        characterClasses.Add("Bard", 8);
        characterClasses.Add("Cleric", 8);
        characterClasses.Add("Druid", 8);
        characterClasses.Add("Fighter", 10);
        characterClasses.Add("Monk", 8);
        characterClasses.Add("Ranger", 10);
        characterClasses.Add("Rogue", 8);
        characterClasses.Add("Paladin", 10);
        characterClasses.Add("Sorcerer", 6);
        characterClasses.Add("Wizard", 6);
        characterClasses.Add("Warlock", 8);
    }

    public void checkValues(int charLevel, int conScore, String charRace, String charClass)
    {

        if (charLevel < 1 || charLevel > 20)
        {
            Debug.Log("Character level must be between 1 and 20.");
        }
        if (conScore < 1 || conScore > 30)
        {
            Debug.Log("Constitution score must be between 1 and 30.");
        }
        if (characterRaces.ContainsKey(charRace) == false)
        {
            Debug.Log("The race you chose is not applicable. Setting to Human.");
            charRace = "Human";
        }
        if (characterClasses.ContainsKey(charClass) == false)
        {
            Debug.Log("The class you chose is not applicable. Setting to Fighter.");
            charClass = "Fighter";
        }

    }
}
