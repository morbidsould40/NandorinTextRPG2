using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemConfirmation : MonoBehaviour {

    InventoryWindow inventoryWindow;
    GameController controller;
    Inventory inventory;

    private void Start()
    {
        inventoryWindow = FindObjectOfType<InventoryWindow>();
        controller = FindObjectOfType<GameController>();
        inventory = FindObjectOfType<Inventory>();
    }

    public bool YesButtonClicked()
    {        
        gameObject.SetActive(false);
        return true;
    }

    public void NoButtonClicked()
    {
        gameObject.SetActive(false);
    }
}
