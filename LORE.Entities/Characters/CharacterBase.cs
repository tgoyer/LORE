﻿using System.Collections.Generic;
using LORE.Entities.Items;
using LORE.Entities.Mechanics.Rules;
using LORE.Entities.Misc;

namespace LORE.Entities.Characters
{
    public abstract class CharacterBase
    {
        public CharacterBase() {
            Skills = new List<Skill>();
            Abilities = new List<Ability>();
            Money = new Money();
            Inventory = new List<ItemBase>();
        }

        public CharacterBase(string name) : this() {
            Name = name;
        }

        public List<Ability> Abilities { get; private set; }
        public List<Skill> Skills { get; private set; }
        public string Name { get; set; }
        public int CurrentHealth { get; set; }
        public int MaximumHealth { get; set; }
        public int Level { get; set; }
        public RaceType Race { get; set; }
        public List<ItemBase> Inventory { get; set; }
        public Money Money { get; set; }
    }
}