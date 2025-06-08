using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemListEntity : ScriptableObject
{
   public List<Items> itemList = new List<Items>(); 
}
