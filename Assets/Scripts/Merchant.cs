using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
   // private Coroutine checkButton;
    SpriteRenderer spriteRenderer;
    private ShopController shopController;
    public List<OnSaleItem> onSaleItems;
    public int nPCid;


    private InteractionController interactionController;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shopController = GameManager.UI.GetComponent<UIScript>().shopController;
        interactionController = GameManager.player.GetComponent<InteractionController>();
        // Debug.Log(GameManager.UI.GetComponentInChildren<ShopController>());
        //shopController.gameObject.SetActive(false);

        //ѕроверка на ограничение кол-ва вещей в €чейке
        foreach (var item in onSaleItems)
        {
            if(item.item.maxItems<item.count)
            {
                item.count = item.item.maxItems;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag=="Player")
        {
            if (interactionController.AddInteraction(StartDialog, transform.position))
            {
                spriteRenderer.color = new Color(1, 0.98f, 0.32f, 1);
            }
            else
            {
                spriteRenderer.color = new Color(1, 1, 1, 1);
            }

          

           // checkButton = StartCoroutine(CheckButton());
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
            interactionController.RemoveInteraction(StartDialog);
            StopDialog();
           // StopCoroutine(checkButton);
        }
    }

    //»спользовал IEnumerator дл€ оптимизации, так как OnTriggerStay вызываетс€ от воды и стен. ¬торой способ-создать внутри торговца игровой объект
    //и к нему прикрепить компонент колайдера, дл€ объекта сделать слой, взаимодействующий только с игроком
   // IEnumerator CheckButton()
    //{
    //    while (true)
    //    {
    //        //—Ќ»«” √ќ¬Ќќ ќƒ - ќЅя«ј“≈Ћ№Ќќ ѕ≈–≈ѕ»—ј“№
    //        if (/*Input.GetButtonDown("Interaction")*/  Keyboard.current.eKey.wasPressedThisFrame && (GameManager.UI.GetComponent<UIScript>().CheckNotOpen(shopController.gameObject)))
    //        {
    //            OpenShop();
    //        }
    //        yield return null;
    //    }
    //}

    public void StartDialog()
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        while (true)
        {
            //—Ќ»«” √ќ¬Ќќ ќƒ - ќЅя«ј“≈Ћ№Ќќ ѕ≈–≈ѕ»—ј“№
            if (/*Input.GetButtonDown("Interaction")*/  Keyboard.current.eKey.wasPressedThisFrame && (GameManager.UI.GetComponent<UIScript>().CheckNotOpen(shopController.gameObject)))
            {
                OpenShop();
            }
            yield return null;
        }
=======
        interactionController.ClearInteraction();
        GameManager.player.GetComponent<NPCController>().StartDialogue(nPCid);

>>>>>>> Stashed changes
=======
        interactionController.ClearInteraction();
        GameManager.player.GetComponent<NPCController>().StartDialogue(nPCid);

>>>>>>> Stashed changes
    }

    public void StopDialog()
    {
        GameManager.player.GetComponent<NPCController>().StopDialog();
    }

    public void OpenShop()
    {
        if (GameManager.UI.GetComponent<UIScript>().CheckNotOpen(shopController.gameObject))
        {
            shopController.gameObject.SetActive(true);
            shopController.OpenShop(this);
        }

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
