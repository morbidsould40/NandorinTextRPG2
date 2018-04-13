using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SelectedItem : MonoBehaviour {

    private Text selectedItemText;
    private GameController controller;

    
    // Use this for initialization
	void Start () {

        selectedItemText = GameObject.Find("SelectedItemText").GetComponent<Text>();
        controller = FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowSelectedItemText()
    {
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            if (gameObject.name == "Empty")
            {
                selectedItemText.text = "This slot is empty.";
            }
            else
            {
                selectedItemText.text = controller.inventory.inventory[System.Int32.Parse(gameObject.name)].itemName + "\n" +
                    controller.inventory.inventory[System.Int32.Parse(gameObject.name)].itemDesc;
            }

        }
        else
        {
            selectedItemText.text = "";
        }
    }
}
