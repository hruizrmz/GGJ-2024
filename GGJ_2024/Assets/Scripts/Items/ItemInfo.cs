using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Create a new item")]
[System.Serializable]
public class ItemInfo : ScriptableObject
{
    public int ID;
    public string itemName;
    public GameObject prefab;
}
