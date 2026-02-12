using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : DungeonMaster
{
    public bool diceAveraged;
    public string characterName;
    public int characterLevel;
    public int conScore;
    public string characterRace;
    public string characterClass;
    public bool toughFeat;
    public bool stoutFeat;

    private string rollType;
    private int totalHP;
    private int rollHP;

    public Character(string name, int level, int con, string race, string cclass, bool tfeat, bool sfeat, bool dice)
    {
        this.characterName = name;
        this.characterLevel = level;
        this.characterClass = cclass;
        this.conScore = con;
        this.characterRace = race;
        this.toughFeat = tfeat;
        this.stoutFeat = sfeat;
        this.diceAveraged = dice;
    }

    // Start is called before the first frame update
    void Start()
    {
        Character character = new Character("Test Character", 1, 10, "Dwarf", "Fighter", true, true, true);
        Instantiate(character);
        character.setUp();
        character.checkValues(characterLevel, conScore, characterRace, characterClass);
        character.totalHP = calculateHP();
        output(character);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int diceRoll()
    {
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
            return averagedRoll*characterLevel;
        } else
        {
            rollType = "rolled";
            int randomRoll = 0;
            for (int i = 0; i < characterLevel - 1; i++)
            {
                randomRoll += Random.Range(1, characterClasses[characterClass] + 1);
            }
            return randomRoll;
        }

    }
    public int calculateHP()
    {
        int hitPoints;

        rollHP = diceRoll();
            if (toughFeat && stoutFeat)
            {
                hitPoints = (rollHP) + (characterLevel * conScores[conScore]) +
                            (characterLevel * characterRaces[characterRace]) + (characterLevel * 3);
            }
            else if (toughFeat)
            {
                hitPoints = (rollHP) + (characterLevel * conScores[conScore]) +
                            (characterLevel * characterRaces[characterRace]) + (characterLevel * 2);
            }
            else if (stoutFeat)
            {
                hitPoints = (rollHP) + (characterLevel * conScores[conScore]) +
                            (characterLevel * characterRaces[characterRace]) + (characterLevel * 1);
            }
            else
            {
                hitPoints = (rollHP) + (characterLevel * conScores[conScore]) +
                            (characterLevel * characterRaces[characterRace]);
            }
        return hitPoints;
    }

    public void output(Character character)
    {
        if (toughFeat && stoutFeat)
        {
            Debug.LogFormat("My character " + characterName + " is a level " + characterLevel + " " + characterClass +
                            " with a CON score of " + conScore + " and is of the " + characterRace +
                            " race and has the Tough and Stout feats. I want the HP " + rollType + ".");
        }
        else if (toughFeat)
        {
            Debug.Log("My character " + characterName + " is a level " + characterLevel + " " + characterClass +
                      " with a CON score of " + conScore + " and is of the " + characterRace +
                      " race and has the Tough feat. I want the HP " + rollType + ".");
        }
        else if (stoutFeat)
        {
            Debug.Log("My character " + characterName + " is a level " + characterLevel + " " + characterClass +
                      " with a CON score of " + conScore + " and is of the " + characterRace +
                      " race and has the Stout feat. I want the HP " + rollType + ".");
        }
        else
        {
            Debug.Log("My character " + characterName + " is a level " + characterLevel + " " + characterClass +
                      " with a CON score of " + conScore + " and is of the " + characterRace +
                      " race and has no feats. I want the HP " + rollType + ".");
        }
        Debug.Log("Total HP: " + totalHP);
    }
}
