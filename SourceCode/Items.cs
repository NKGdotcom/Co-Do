using System;
using UnityEngine;

[Serializable]
public class Items 
{
   //アイテムを列挙
   public enum Type
    {
        glass,
        slippers,
        toilet,
        driver,
        blanket,
        whistle,
        noodle,
        flashright,
        water,
        glove,
        battery,
        bag,
        platform,
        tonkati,
            hasami,
            amagu
    }

    public Type type;       //種類
    public Sprite sprite;   //Slotに表示する画像

    public Items(Type type, Sprite sprite)
    {
        this.type = type;
        this.sprite = sprite;
    }
}
