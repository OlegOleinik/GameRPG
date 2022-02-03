using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropedItem : MonoBehaviour
{


    [SerializeField] protected ItemScriptableObject itemScriptableObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!itemScriptableObject)
        {
            return;
        }
        Inventory inventory = collision.GetComponent<Inventory>();

        if (inventory)
        {
            if (inventory.AddItem(itemScriptableObject))
            {
                Destroy(gameObject);
            }

        }
    }
    public void DropItem(ItemScriptableObject item, Vector2 position)
    {
        SetItem(item);
        Instantiate(gameObject, new Vector2(position.x + getChange(), position.y + getChange()), Quaternion.identity);
        
    }

    public void SetItem(ItemScriptableObject item)
    {
        itemScriptableObject = item;
        gameObject.GetComponent<SpriteRenderer>().sprite = item.itemSprite;
    }

    private float getChange()
    {
        return Random.Range(-0.3f, 0.3f);
    }
}
