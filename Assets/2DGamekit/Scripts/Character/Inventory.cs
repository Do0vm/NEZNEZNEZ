using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;
}

[System.Serializable]
public class ItemInstance
{
    public ItemData itemType;
    public int condition;
    public int ammo;
}
public class Inventory : MonoBehaviour
{
    public List<ItemInstance> items = new();

    public void AddItem(ItemInstance itemToAdd)
    {
        items.Add(itemToAdd);
    }

    public void RemoveItem(ItemInstance itemToRemove)
    {
        items.Remove(itemToRemove);
    }
}