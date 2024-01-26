using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ItemInfo itemInSlot;
    public GameObject iconObject;
    public RectTransform canvasPos;
    public Transform worldPos;

    public void SetStats(Item newItem)
    {
        if (newItem == null)
        {
            itemInSlot = null;
            Destroy(iconObject);
        }
        else
        {
            itemInSlot = newItem.itemInfo;
            Vector3 pos = Camera.main.ViewportToWorldPoint(canvasPos.position);
            worldPos.position = Camera.main.WorldToViewportPoint(pos);
            iconObject = Instantiate(newItem.itemInfo.prefab, worldPos.position, worldPos.rotation, worldPos);
            iconObject.GetComponent<Icon>().itemOriginalPos = worldPos;
        }
    }
}