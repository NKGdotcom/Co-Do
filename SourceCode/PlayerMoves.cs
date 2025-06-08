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
    public SpriteRenderer spriteRenderer; // SpriteRendererの宣言

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
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRendererの取得
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

        //進行方向へ向きを変える
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
             if (Input.GetKeyDown(KeyCode.Alpha1) && getSlipper)//スリッパ
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemSlipper);
                ItemBox.instance.SetKeyItem(item);
                getSlipper = false;

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && getBattery)//電池
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemBattery);
                ItemBox.instance.SetKeyItem(item);
                getBattery = false;

            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && getPlatform)//乗り上げ台
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemPlatform);
                ItemBox.instance.SetKeyItem(item);
                getPlatform = false;

            }
            else if (Input.GetKeyDown(KeyCode.Q) && getGlove)//軍手
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemGlove);
                ItemBox.instance.SetKeyItem(item);
                getGlove = false;

            }
            //キーを押したらアイテムが出現
            else if (Input.GetKeyDown(KeyCode.W) && getFlashRight)//懐中電灯
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemFlashRight);
                ItemBox.instance.SetKeyItem(item);
                getFlashRight = false;
                
            }
            else if (Input.GetKeyDown(KeyCode.E) && getWhistle)//ホイッスル
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemWhistle);
                ItemBox.instance.SetKeyItem(item);
                getWhistle = false;

            }
            else if (Input.GetKeyDown(KeyCode.A) && getBlanket)//ブランケット
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemBlanket);
                ItemBox.instance.SetKeyItem(item);
                getBlanket = false;

            }
            else if (Input.GetKeyDown(KeyCode.S) && getBag)//ビニール袋
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemBag);
                ItemBox.instance.SetKeyItem(item);
                getBag = false;

            }
            else if (Input.GetKeyDown(KeyCode.D) && getToilet)//トイレ
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemToilet);
                ItemBox.instance.SetKeyItem(item);
                getToilet = false;

            }
            else if (Input.GetKeyDown(KeyCode.Z) && getCupNoodle)//カップ麺
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemNoodle);
                ItemBox.instance.SetKeyItem(item);
                getCupNoodle = false;
            }
            else if (Input.GetKeyDown(KeyCode.X) && getWater)//水
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemWater);
                ItemBox.instance.SetKeyItem(item);
                getWater = false;

            }
            else if (Input.GetKeyDown(KeyCode.C) && getDriver)//ドライバー
            {
                itemNumber++;
                item = ItemGenerater.instance.Spawn(itemDriver);
                ItemBox.instance.SetKeyItem(item);
                getDriver = false;

            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && getTonkati)//トンカチ
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