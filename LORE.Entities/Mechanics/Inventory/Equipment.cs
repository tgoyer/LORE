using LORE.Entities.Characters;
using LORE.Entities.Items;

namespace LORE.Entities.Mechanics.Inventory
{
    public class Equipment
    {
        public EquipmentBase Arms { get; private set; }
        public EquipmentBase Boots { get; private set; }
        public EquipmentBase Bracelet { get; private set; }
        public EquipmentBase Cape { get; private set; }
        public EquipmentBase Chest { get; private set; }
        public EquipmentBase Finger { get; private set; }
        public EquipmentBase Gloves { get; private set; }
        public EquipmentBase Head { get; private set; }
        public EquipmentBase Legs { get; private set; }
        public EquipmentBase MainWeapon { get; private set; }
        public EquipmentBase Neck { get; private set; }
        public EquipmentBase Ranged { get; private set; }
        public EquipmentBase OffHand { get; private set; }
        public EquipmentBase Shoulders { get; private set; }

        public bool Equip(CharacterBase character, EquipmentBase item, EquipmentType location)
        {
            if (item.CanEquip(character, location))
            {
                switch (location)
                {
                    case EquipmentType.Arms:
                        if(Arms != null) character.Inventory.Add(Arms);
                        Arms = item;
                        break;
                    case EquipmentType.Boots:
                        if (Boots != null) character.Inventory.Add(Boots);
                        Boots = item;
                        break;
                    case EquipmentType.Bracelet:
                        if (Boots != null) character.Inventory.Add(Boots);
                        Boots = item;
                        break;
                    case EquipmentType.Cape:
                        if (Cape != null) character.Inventory.Add(Cape);
                        Cape = item;
                        break;
                    case EquipmentType.Chest:
                        if (Chest != null) character.Inventory.Add(Chest);
                        Chest = item;
                        break;
                    case EquipmentType.Finger:
                        if (Finger != null) character.Inventory.Add(Finger);
                        Finger = item;
                        break;
                    case EquipmentType.Gloves:
                        if (Gloves != null) character.Inventory.Add(Gloves);
                        Gloves = item;
                        break;
                    case EquipmentType.Helmet:
                        if (Head != null) character.Inventory.Add(Head);
                        Head = item;
                        break;
                    case EquipmentType.Legs:
                        if (Legs != null) character.Inventory.Add(Legs);
                        Legs = item;
                        break;
                    case EquipmentType.MainHand:
                        if (MainWeapon != null) character.Inventory.Add(MainWeapon);
                        if (OffHand != null && item.Types.Contains(EquipmentType.TwoHand)) character.Inventory.Add(OffHand);
                        MainWeapon = item;
                        break;
                    case EquipmentType.Necklace:
                        if (Neck != null) character.Inventory.Add(Neck);
                        Neck = item;
                        break;
                    case EquipmentType.Ranged:
                        if (Ranged != null) character.Inventory.Add(Ranged);
                        Ranged = item;
                        break;
                    case EquipmentType.SecondaryHand:
                        if (OffHand != null) character.Inventory.Add(OffHand);
                        if (MainWeapon.Types.Contains(EquipmentType.TwoHand)) character.Inventory.Add(MainWeapon);
                        OffHand = item;
                        break;
                    case EquipmentType.Shoulders:
                        if (Shoulders != null) character.Inventory.Add(Shoulders);
                        Shoulders = item;
                        break;
                }
            }
            return true;
        }
    }
}