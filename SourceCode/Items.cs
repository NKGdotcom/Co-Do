using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsList", menuName = "ScriptableObjects/ItemsList")]
public class Items : ScriptableObject
{
    [System.Serializable]
    public class ItemType
    {
        /// <summary>
        /// �l���ł���A�C�e���̎��
        /// </summary>
        public enum ItemTypes
        {
            Slippers,Toilet,Driver,Blanket,Whistle,FlashLight,Water,Glove,Battery,Noodle,
            PlasticBag,SteppingStone,Hammer,Scissors,RainCoat,PieceOfGlass
        }
        [Header("�A�C�e���̎��")]
        public ItemTypes itemTypes;
        [Header("�A�C�e���̃C���[�W�摜")]
        public Sprite itemImage;

        public ItemType(ItemTypes itemTypes, Sprite itemImage)
        {
            this.itemTypes = itemTypes;
            this.itemImage = itemImage;
        }
    }
    public List<ItemType> itemsList = new List<ItemType>();

    public ItemType GetItem(ItemType.ItemTypes itemTypes)
    {
        foreach (ItemType items in itemsList)
        {
            if (items.itemTypes == itemTypes)
            {
                return new ItemType(items.itemTypes, items.itemImage);
            }
        }
        return null;
    }
}
