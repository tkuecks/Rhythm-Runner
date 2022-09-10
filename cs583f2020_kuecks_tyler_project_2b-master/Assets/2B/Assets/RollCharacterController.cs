using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollCharacterController : MonoBehaviour
{
    public Dropdown classDD;
    public Dropdown raceDD;
    public InputField nameIF;
    public InputField strengthIF;
    public InputField dexterityIF;
    public InputField constitutionIF;
    public InputField intelligenceIF;
    public InputField wisdomIF;
    public InputField charismaIF;
    public InputField alignmentIF;
    public InputField currHPIF;
    public InputField maxHPIF;
    public InputField armorIF;
    public InputField wSpeedIF;
    public InputField rSpeedIF;
    public InputField jumpHeightIF;
    public InputField currXPIF;
    public InputField maxXPIF;
    private List<string> raceList = new List<string>() {"Dragonborn", "Dwarf", "Elf", "Gnome", "Half-Elf", "Half-Orc", "Halfling", "Human", "Tiefling"};
    private List<string> classList = new List<string>() {"Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard"};
    // Start is called before the first frame update
    void Start()
    {
        classDD.AddOptions(classList);
        raceDD.AddOptions(raceList);
    }
    public int RollDice()
    {
        int max1 = Random.Range(1,7);
        int max2 = Random.Range(1,7);
        if(max2>max1)
        {
            int temp = max1;
            max1 = max2;
            max2 = temp;
        }

        int currRand1 = Random.Range(1,7);
        if(currRand1 >= max1)
        {
            max2 = max1;
            max1 = currRand1;
        }
        else if(currRand1 > max2)
            max2 = currRand1;

        int sumd6 = max1 + max2;

        int max3 = Random.Range(1,5);
        int max4 = Random.Range(1,5);
        if(max3>max4)
        {
            int temp = max3;
            max3 = max4;
            max4 = temp;
        }
        int currRand2 = Random.Range(1,5);
        if(currRand2 >= max3)
        {
                max4 = max3;
                max3 = currRand2;
        }
        else if(currRand2 > max4)
            max4 = currRand2;
        
        int sumd4 = max3 + max4;
        return sumd6 + sumd4 + 2;
    }
    public void rollStrength()
    {
        float myStrength = RollDice();
        PlayerManager.Instance.strength = myStrength;
        strengthIF.text = myStrength.ToString();
    }
    public void rollDexterity()
    {
        float myDexterity = RollDice();
        PlayerManager.Instance.dexterity = myDexterity;
        dexterityIF.text = myDexterity.ToString();
    }
    public void rollConstitution()
    {
        float myConst = RollDice();
        PlayerManager.Instance.constitution = myConst;
        constitutionIF.text = myConst.ToString();
    }
    public void rollIntelligence()
    {
        float myI = RollDice();
        PlayerManager.Instance.intelligence = myI;
        intelligenceIF.text = myI.ToString();
    }
    public void rollWisdom()
    {
        float myW = RollDice();
        PlayerManager.Instance.wisdom = myW;
        wisdomIF.text = myW.ToString();
    }
    public void rollCharisma()
    {
        float myC = RollDice();
        PlayerManager.Instance.charisma = myC;
        charismaIF.text = myC.ToString();
    }
    public void ClassChanged(int index)
    {
        PlayerManager.Instance.playerClass = classList[index];
    }
    public void RaceChanged(int index)
    {
        PlayerManager.Instance.race = raceList[index];
    }
    public void StrengthChanged(string newStrength){
        PlayerManager.Instance.strength = float.Parse(newStrength + ",");
    }
    public void DexterityChanged(string newDexterity){
        PlayerManager.Instance.dexterity = float.Parse(newDexterity + ",");
    }
    public void ConstitutionChanged(string newConst){
        PlayerManager.Instance.constitution = float.Parse(newConst + ",");
    }
    public void IntelligenceChanged(string newI){
        PlayerManager.Instance.intelligence = float.Parse(newI + ",");
    }
    public void WisdomChanged(string newW){
        PlayerManager.Instance.wisdom = float.Parse(newW + ",");
    }
    public void CharismaChanged(string newC){
        PlayerManager.Instance.charisma = float.Parse(newC + ",");
    }
    public void NameChanged(string newText){
        PlayerManager.Instance.charName = newText;
    }
    public void AlignmentChanged(string newAl){
        PlayerManager.Instance.alignment = newAl;
    }
    public void CurrHPChanged(string newcHP){
        int myCHP = int.Parse(newcHP);
        PlayerManager.Instance.currHp = myCHP;
    }
    public void MaxHPChanged(string newmHP){
        int myMHP = int.Parse(newmHP);
        PlayerManager.Instance.maxHp = myMHP;
    }
    public void ArmorClassChanged(string newAr){
        int myAr = int.Parse(newAr);
        PlayerManager.Instance.armorClass = myAr;
    }
    public void WalkSpeedChanged(string newWS){
        int myWS = int.Parse(newWS);
        PlayerManager.Instance.walkSpeed = myWS;
    }
    public void RunSpeedChanged(string newRS){
        int myRS = int.Parse(newRS);
        PlayerManager.Instance.runSpeed = myRS;
    }
    public void JumpHeightChanged(string newJH){
        int myJH = int.Parse(newJH);
        PlayerManager.Instance.jumpHeight = myJH;
    }
    public void CurrXPChanged(string newcXP){
        int myCXP = int.Parse(newcXP);
        PlayerManager.Instance.currXp = myCXP;
    }
    public void MaxXPChanged(string newmXP){
        int myMXP = int.Parse(newmXP);
        PlayerManager.Instance.maxXp = myMXP;
    }
    public void ToJson(){
        PlayerManager.Instance.json = JsonUtility.ToJson(PlayerManager.Instance);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
