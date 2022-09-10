using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager Instance {get {return instance;} }

    public string charName;
    public float strength;
    public float dexterity;
    public float constitution;
    public float intelligence;
    public float wisdom;
    public float charisma;
    public string race;
    public string playerClass;
    public string alignment;
    public int currXp;
    public int maxXp;
    public int currHp;
    public int maxHp;
    public int armorClass;
    public int walkSpeed;
    public int runSpeed;
    public int jumpHeight;
    public List<string> itemList;
    public string json;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

}
