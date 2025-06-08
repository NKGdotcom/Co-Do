using System;
using UnityEngine;

[Serializable]
public class Items 
{
   //�A�C�e�����
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

    public Type type;       //���
    public Sprite sprite;   //Slot�ɕ\������摜

    public Items(Type type, Sprite sprite)
    {
        this.type = type;
        this.sprite = sprite;
    }
}
