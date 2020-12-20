using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SearchableExample_0 : MonoBehaviour
{
    [Searchable]
    public List<Perk> Perks = new List<Perk>()
{
    new Perk()
    {
        Name = "Old Sage",
        Effects = new List<Effect>()
        {
            new Effect() { Skill = Skill.Wisdom, Value = 2, },
            new Effect() { Skill = Skill.Intelligence, Value = 1, },
            new Effect() { Skill = Skill.Strength, Value = -2 },
        },
    },
    new Perk()
    {
        Name = "Hardened Criminal",
        Effects = new List<Effect>()
        {
            new Effect() { Skill = Skill.Dexterity, Value = 2, },
            new Effect() { Skill = Skill.Strength, Value = 1, },
            new Effect() { Skill = Skill.Charisma, Value = -2 },
        },
    },
    new Perk()
    {
        Name = "Born Leader",
        Effects = new List<Effect>()
        {
            new Effect() { Skill = Skill.Charisma, Value = 2, },
            new Effect() { Skill = Skill.Intelligence, Value = -3 },
        },
    },
    new Perk()
    {
        Name = "Village Idiot",
        Effects = new List<Effect>()
        {
            new Effect() { Skill = Skill.Charisma, Value = 4, },
            new Effect() { Skill = Skill.Constitution, Value = 2, },
            new Effect() { Skill = Skill.Intelligence, Value = -3 },
            new Effect() { Skill = Skill.Wisdom, Value = -3 },
        },
    },
};

    [Serializable]
    public class Perk
    {
        public string Name;

        [TableList]
        public List<Effect> Effects;
    }

    [Serializable]
    public class Effect
    {
        public Skill Skill;
        public float Value;
    }

    public enum Skill
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma,
    }
}
