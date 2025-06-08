using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoves : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] Items.Type itemSlipper,itemBattery,itemPlatform,itemGlove,itemFlashRight,itemWhistle,itemBlanket,itemBag,itemToilet,itemNoodle,itemWater,itemDriver,itemTonkati;
    Items item;
    [SerializeField]Slot slot;
    bool getSlipper,getBattery, getPlatform,getGlove, getFlashRight,getWhistle,getBlanket,getBag,getToilet,getCupNoodle,getWater,getDriver,getTonkati;
    public float speed;
    public Sprite normal,laugh,move,bother;
    public SpriteRenderer spriteRenderer; // SpriteRenderer�̐錾

    public int itemNumber=0;

    void Start()
    {
        getSlipper = true;
        getBattery = true;
        getPlatform = true;
        getGlove = true;
        getFlashRight = true;
        getWhistle = true;
        getBlanket = true;
        getBag = true;
        getToilet = true;
        getCupNoodle = true;
        getWater = true;
        getDriver = true;
        getTonkati = true;
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer�̎擾
    }

    void Update()
    {
        Debug.Log(itemNumber);
        
        GetKeyItem();
        float input = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            input = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            input = 1;
        }

        rb2d.velocity = new Vector2(input * speed, rb2d.velocity.y);

        //�i�s�����֌�����ς���
        if (input < 0)
        {
            spriteRenderer.sprite = move; 
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (input > 0)
        {
            spriteRenderer.sprite = move;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(input == 0)
        {
            spriteRenderer.sprite = normal;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (itemNumber <= 4)
        {
            if (collision.CompareTag("Item"))
            {
                itemNumber++;
            }
        }
    }
    public void GetKeyItem()
    {
       

        if (itemNumber <=4)
        {
             if (Input.GetKeyDown(KeyCode.Alpha1) && getSlipper)//�X���b�p
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemSlipper);
                ItemBox.instance.SetKeyItem(item);
                getSlipper = false;

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && getBattery)//�d�r
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemBattery);
                ItemBox.instance.SetKeyItem(item);
                getBattery = false;

            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && getPlatform)//���グ��
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemPlatform);
                ItemBox.instance.SetKeyItem(item);
                getPlatform = false;

            }
            else if (Input.GetKeyDown(KeyCode.Q) && getGlove)//�R��
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemGlove);
                ItemBox.instance.SetKeyItem(item);
                getGlove = false;

            }
            //�L�[����������A�C�e�����o��
            else if (Input.GetKeyDown(KeyCode.W) && getFlashRight)//�����d��
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemFlashRight);
                ItemBox.instance.SetKeyItem(item);
                getFlashRight = false;
                
            }
            else if (Input.GetKeyDown(KeyCode.E) && getWhistle)//�z�C�b�X��
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemWhistle);
                ItemBox.instance.SetKeyItem(item);
                getWhistle = false;

            }
            else if (Input.GetKeyDown(KeyCode.A) && getBlanket)//�u�����P�b�g
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemBlanket);
                ItemBox.instance.SetKeyItem(item);
                getBlanket = false;

            }
            else if (Input.GetKeyDown(KeyCode.S) && getBag)//�r�j�[����
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemBag);
                ItemBox.instance.SetKeyItem(item);
                getBag = false;

            }
            else if (Input.GetKeyDown(KeyCode.D) && getToilet)//�g�C��
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemToilet);
                ItemBox.instance.SetKeyItem(item);
                getToilet = false;

            }
            else if (Input.GetKeyDown(KeyCode.Z) && getCupNoodle)//�J�b�v��
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemNoodle);
                ItemBox.instance.SetKeyItem(item);
                getCupNoodle = false;
            }
            else if (Input.GetKeyDown(KeyCode.X) && getWater)//��
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemWater);
                ItemBox.instance.SetKeyItem(item);
                getWater = false;

            }
            else if (Input.GetKeyDown(KeyCode.C) && getDriver)//�h���C�o�[
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemDriver);
                ItemBox.instance.SetKeyItem(item);
                getDriver = false;

            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && getTonkati)//�g���J�`
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemTonkati);
                ItemBox.instance.SetKeyItem(item);
                getTonkati = false;

            }
            else if (Input.GetKeyDown(KeyCode.Delete))
             {
                itemNumber--;
            }
        }

    }
}