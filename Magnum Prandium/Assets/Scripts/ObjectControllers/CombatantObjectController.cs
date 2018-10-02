using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CombatantObjectController : MonoBehaviour
{
    public enum Attribute { FIRE, LAVA, ICE, AIR, WATER, VOID, DEATH, LIFE, LIGHTNING }
    
    [Serializable]
    public struct AttributeValue
    {
        public Attribute attribute;
        public float multiplier;
        public AttributeValue(Attribute _attribute, float _multiplier)
        {
            attribute = _attribute;
            multiplier = _multiplier;
        }
    }

    
    [Serializable]
    public class Stats
    {
        public float hp;
        public float mp;
        public List<AttributeValue> resistances = new List<AttributeValue>()
        {
            {new AttributeValue( Attribute.FIRE, 1.0f ) },
            {new AttributeValue( Attribute.LAVA, 1.0f ) },
            {new AttributeValue( Attribute.ICE, 1.0f ) },
            {new AttributeValue( Attribute.WATER, 1.0f ) },
            {new AttributeValue( Attribute.VOID, 1.0f ) },
            {new AttributeValue( Attribute.DEATH, 1.0f ) },
            {new AttributeValue( Attribute.LIFE, 1.0f ) },
            {new AttributeValue( Attribute.LIGHTNING, 1.0f ) },
            {new AttributeValue( Attribute.AIR, 1.0f ) },
        };

    }
    
    public Stats stats;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
