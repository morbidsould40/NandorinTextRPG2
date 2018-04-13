using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour {

    public int startingPosX;
    public int startingPosY;
    public int slotCountPerPage;
    public int slotCountLength;
    public GameObject itemSlotPrefab;
    public ToggleGroup itemSlotToggleGroup;
    public int slotGap;

    private int xPos;
    private int yPos;
    private int itemSlotCount;
    private GameObject itemSlot;
    private List<GameObject> inventorySlots;
    private GameController controller;

    private void Start()
    {
        controller = FindObjectOfType<GameController>();
        CreateInventorySlotsInWindow();
        AddItemsFromInventory();
    }

    private void Update()
    {
        
    }

    private void CreateInventorySlotsInWindow()
    {
        xPos = startingPosX;
        yPos = startingPosY;
        slotGap = 5;

        for (int i = 0; i < slotCountPerPage; i++)
        {
            inventorySlots = new List<GameObject>();
            itemSlot = Instantiate(itemSlotPrefab);
            itemSlot.name = "Empty";
            itemSlot.GetComponent<Toggle>().group = itemSlotToggleGroup;
            inventorySlots.Add(itemSlot);
            itemSlot.transform.SetParent(gameObject.transform);
            itemSlot.GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos, 0);
            xPos += (int)itemSlot.GetComponent<RectTransform>().rect.width + slotGap;
            itemSlotCount++;

            if (itemSlotCount % slotCountLength == 0)
            {
                itemSlotCount = 0;
                yPos -= (int)itemSlot.GetComponent<RectTransform>().rect.width + slotGap;
                xPos = startingPosX;
            }
        }
    }

    public void AddItemsFromInventory()
    {
        var playerInventory = controller.inventory.inventory;
        for (int i = 0; i < playerInventory.Count; i++)
        {
            if (inventorySlots[i].name == "Empty")
            {
                inventorySlots[i].name = i.ToString();
                inventorySlots[i].transform.GetChild(0).gameObject.SetActive(true);
                inventorySlots[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ReturnItemIcon(playerInventory[i]);
            }
        }
    }

    private Sprite ReturnItemIcon(Items item)
    {
        Sprite icon = new Sprite();
        icon = item.itemIcon;
        return icon;
    }
}
