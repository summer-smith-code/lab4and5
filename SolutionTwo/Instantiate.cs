using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject characterPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Character character = new Character("Sir John", 3, 21, "Dwarf", "Paladin", true, false, true);
        character.work(character);
        // GameObject characterObject = Instantiate(characterPrefab); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
