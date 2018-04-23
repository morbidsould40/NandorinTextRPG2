using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemConfirmation : MonoBehaviour {

    private void Start()
    {
        
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
