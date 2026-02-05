using System.Collections.Generic;
using UnityEngine;

public class Lab4 : MonoBehaviour
{

    public string characterName;
    public int characterLevel;
    public int conScore;
    public string characterRace;
    public bool toughFeat;
    public bool stoutFeat;
    
    // true if averaged, false if rolled
    public bool diceAveraged;
    private string rollType;
    public string characterClass;

    private int totalHP;
    private Dictionary<int, int> conScores = new Dictionary<int, int>();
    private Dictionary<string, int> characterRaces = new Dictionary<string, int>();
    private Dictionary<string, int> characterClasses = new Dictionary<string, int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setUp();
        checkValues();
        totalHP = calculateHP();
        output();
    }

    public int calculateHP()
    {
        int hitPoints;
        
        if (diceAveraged)
        {
            rollType = "averaged";
            int averagedRoll; // This is turned into an int so that it can be rounded up.
            switch (characterClasses[characterClass])
            {
                case 6:
                    averagedRoll = 4;
                    break;
                case 8:
                    averagedRoll = 5;
                    break;
                case 10:
                    averagedRoll = 6;
                    break;
                case 12:
                    averagedRoll = 7;
                    break;
                default: // This shouldn't be possible, but it has been added in for the sake of debugging.
                    averagedRoll = 0; 
                    break;
            }

            if (toughFeat && stoutFeat)
            {
                hitPoints = (characterLevel * averagedRoll) + (characterLevel * conScores[conScore]) +
                            (characterLevel * characterRaces[characterRace]) + (characterLevel * 3);
            }
            else if (toughFeat)
            {
                hitPoints = (characterLevel * averagedRoll) + (characterLevel * conScores[conScore]) + 
                            (characterLevel * characterRaces[characterRace]) + (characterLevel * 2);
            }
            else if (stoutFeat)
            {
                hitPoints = (characterLevel * averagedRoll) + (characterLevel * conScores[conScore]) + 
                            (characterLevel * characterRaces[characterRace]) + (characterLevel * 1);
            }
            else
            {
                hitPoints = (characterLevel * averagedRoll) + (characterLevel * conScores[conScore]) + 
                            (characterLevel * characterRaces[characterRace]);
            }
        }
        else
        {
            rollType = "rolled";
            int randomRoll = Random.Range(1, characterClasses[characterClass] + 1);
            hitPoints = (characterLevel * randomRoll) + (characterLevel * conScores[conScore]) + (characterLevel * characterRaces[characterRace]);
        }
        
        return hitPoints;
    }
    public void checkValues()
    {
        if (characterLevel < 1 || characterLevel > 20)
        {
            Debug.Log("Character level must be between 1 and 20.");
        }
        if (conScore < 1 || conScore > 30)
        {
            Debug.Log("Constitution score must be between 1 and 30.");
        }
        if (characterRaces.ContainsKey(characterRace) == false)
        {
            Debug.Log("The race you chose is not applicable. Setting to Human.");
            characterRace = "Human";
        }
        if (characterClasses.ContainsKey(characterClass) == false)
        {
            Debug.Log("The class you chose is not applicable. Setting to Fighter.");
            characterClass = "Fighter";
        }

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

    public void output()
    {
        if (toughFeat && stoutFeat)
        {
            Debug.LogFormat("My character " +characterName + " is a level " +characterLevel + " " +characterClass + 
                            " with a CON score of " +conScore + " and is of the " +characterRace + 
                            " race and has the Tough and Stout feats. I want the HP " + rollType + ".");
        }
        else if (toughFeat)
        {
            Debug.Log("My character " +characterName + " is a level " +characterLevel + " " +characterClass + 
                      " with a CON score of " +conScore + " and is of the " +characterRace + 
                      " race and has the Tough feat. I want the HP " + rollType + ".");
        }
        else if (stoutFeat)
        {
            Debug.Log("My character " +characterName + " is a level " +characterLevel + " " +characterClass + 
                      " with a CON score of " +conScore + " and is of the " +characterRace + 
                      " race and has the Stout feat. I want the HP " + rollType + ".");
        }
        else
        {
            Debug.Log("My character " +characterName + " is a level " +characterLevel + " " +characterClass + 
                      " with a CON score of " +conScore + " and is of the " +characterRace + 
                      " race and has no feats. I want the HP " + rollType + ".");
        }
        Debug.Log("Total HP: " + totalHP);
    }
}
