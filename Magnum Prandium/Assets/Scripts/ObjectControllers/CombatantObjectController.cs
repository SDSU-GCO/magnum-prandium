using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CombatantObjectController : MonoBehaviour
{
    public enum Attribute { FIRE, LAVA, ICE, AIR, WATER, VOID, DEATH, LIFE, LIGHTNING, LIGHT, DARK }
    
    public struct Modifiers
    {
        public float baseResistance;
        public Dictionary<string, float> tempModifiers;

        public Modifiers(float baseModifier, Dictionary<string, float> tempModifiers)
        {
            this.baseResistance = baseModifier;
            this.tempModifiers = tempModifiers;
        }

        public Modifiers(float baseModifier)
        {
            this.baseResistance = baseModifier;
            this.tempModifiers = new Dictionary<string, float>();
        }
    }


    [Serializable]
    public struct Stat
    {
        public float baseStat;
        public Dictionary<string, float> tempStatModifiers;

        public Stat(float baseStat, Dictionary<string, float> tempStatModifiers)
        {
            this.baseStat = baseStat;
            this.tempStatModifiers = tempStatModifiers;
        }

        public Stat(float baseStat)
        {
            this.baseStat = baseStat;
            tempStatModifiers = new Dictionary<string, float>();
        }
    }

    [Serializable]
    class Resistances
    {
        public float fire = 1;
        public float lava = 1;
        public float ice = 1;
        public float air = 1;
        public float water = 1;
        public float voidElem = 1;
        public float death = 1;
        public float life = 1;
        public float lightning = 1;
        public float light = 1;
        public float dark = 1;
    }

    [Serializable]
    public class BaseStatBlock
    {
        public float hp = 1;
        public float mp = 1;
        public float strength = 1;
        public float defense = 1;
        public float stamina = 1;
        public float dexterity = 1;
        public float intelligence = 1;
        public float critRate = 1;
        public float luck = 1;
    }

    [Serializable]
    public struct StatBlock
    {
        public Stat hp;
        public Stat mp;
        public Stat strength;
        public Stat defense;
        public Stat stamina;
        public Stat dexterity;
        public Stat intelligence;
        public Stat critRate;
        public Stat luck;
    }

    [Serializable]
    struct CombatantStats
    {
        public BaseStatBlock baseStats;
        public Resistances baseResistances;
    }
    
    [Serializable]
    public struct Stats
    {
        public StatBlock statBlock;
        public Dictionary<Attribute, Modifiers> resistances;
    }

    [SerializeField]
    CombatantStats combatantStats;

    [NonSerialized]
    public Stats stats;

    private void Awake()
    {
        CopyStatsToRuntimeStructure(combatantStats.baseStats, stats.statBlock);
        ResistancesToDictionary(ref combatantStats.baseResistances, stats.resistances);
    }

    private void CopyStatsToRuntimeStructure(BaseStatBlock stats, StatBlock statBlock)
    {
        statBlock.hp.baseStat = stats.hp;
        statBlock.mp.baseStat = stats.mp;
        statBlock.strength.baseStat = stats.strength;
        statBlock.defense.baseStat = stats.defense;
        statBlock.stamina.baseStat = stats.stamina;
        statBlock.dexterity.baseStat = stats.dexterity;
        statBlock.intelligence.baseStat = stats.intelligence;
        statBlock.critRate.baseStat = stats.critRate;
        statBlock.luck.baseStat = stats.luck;
    }

    void ResistancesToDictionary(ref Resistances resistances, Dictionary<Attribute, Modifiers> resistancesList)
    {
        resistancesList = new Dictionary<Attribute, Modifiers>();
        resistancesList.Add(Attribute.AIR, new Modifiers(resistances.air));
        resistancesList.Add(Attribute.FIRE, new Modifiers(resistances.fire));
        resistancesList.Add(Attribute.ICE, new Modifiers(resistances.ice));
        resistancesList.Add(Attribute.LAVA, new Modifiers(resistances.lava));
        resistancesList.Add(Attribute.WATER, new Modifiers(resistances.water));
        resistancesList.Add(Attribute.VOID, new Modifiers(resistances.voidElem));
        resistancesList.Add(Attribute.DEATH, new Modifiers(resistances.death));
        resistancesList.Add(Attribute.LIFE, new Modifiers(resistances.life));
        resistancesList.Add(Attribute.LIGHTNING, new Modifiers(resistances.lightning));
        resistancesList.Add(Attribute.LIGHT, new Modifiers(resistances.light));
        resistancesList.Add(Attribute.DARK, new Modifiers(resistances.dark));
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
