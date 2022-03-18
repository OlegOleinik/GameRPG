using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class OnSaleItem
{
    public OnSaleItem(ItemScriptableObject item)
    {
        this.item = item;
        count = 1;
    }
    public ItemScriptableObject item;
    public int count;
}

public class Merchant : ANPC
{
    private Coroutine checkButton;
    SpriteRenderer spriteRenderer;
    private ShopController shopController;
    public List<OnSaleItem> onSaleItems;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shopController = GameManager.UI.GetComponent<UIScript>().shopController;
        // Debug.Log(GameManager.UI.GetComponentInChildren<ShopController>());
        //shopController.gameObject.SetActive(false);

        //Проверка на ограничение кол-ва вещей в ячейке
        foreach (var item in onSaleItems)
        {
            if(item.item.maxItems<item.count)
            {
                item.count = item.item.maxItems;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            spriteRenderer.color = new Color(1, 0.98f, 0.32f, 1);
            checkButton = StartCoroutine(CheckButton());
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
            StopCoroutine(checkButton);
        }
    }

    //Использовал IEnumerator для оптимизации, так как OnTriggerStay вызывается от воды и стен. Второй способ-создать внутри торговца игровой объект
    //и к нему прикрепить компонент колайдера, для объекта сделать слой, взаимодействующий только с игроком
    IEnumerator CheckButton()
    {
        while(true)
        {
            if (Input.GetButtonDown("Interaction") && (GameManager.UI.GetComponent<UIScript>().CheckNotOpen(shopController.gameObject)))
            {
                OpenShop();
            }
            yield return null;
        }
    }

    private void OpenShop()
    {
        shopController.gameObject.SetActive(true);
        shopController.OpenShop(this);
    }

    public void AddItem(ItemScriptableObject addItem)
    {
        foreach (OnSaleItem slot in onSaleItems)
        {
            if (slot.item == addItem && slot.count < addItem.maxItems)
            {
                slot.count++;
                return;
            }
        }
        if (onSaleItems.Count >= 23)
        {
            return;
        }
        onSaleItems.Add(new OnSaleItem(addItem));
    }

    public bool RemoveItem(int id)
    {
        if(--onSaleItems[id].count<=0)
        {
            onSaleItems.RemoveAt(id);
            return true;
        }
        return false;
    }
}
