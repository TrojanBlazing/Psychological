using UnityEngine;

[CreateAssetMenu(fileName = "NewItemDetails", menuName = "Examine System/Item Details")]
public class ItemDetails : ScriptableObject
{
    public Sprite itemSprite;
    public string itemDescription;
}
