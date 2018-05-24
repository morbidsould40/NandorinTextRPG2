using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class TextInput : MonoBehaviour
{

    public InputField inputField;

    private GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            AcceptStringInput(inputField.text);
        }

        inputField.ActivateInputField();
    }

    private void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower();
        controller.LogStringWithReturn(userInput);
        char[] delimiterCharacters = { ' ' };
        string[] seperatedInputWords = userInput.Split(delimiterCharacters);

        bool wordFound = false;
        for (int i = 0; i < controller.inputActions.Length; i++)
        {
            InputAction inputAction = controller.inputActions[i];
            if (inputAction.keyWord == seperatedInputWords[0])
            {
                inputAction.RespondToInput(controller, seperatedInputWords);
                wordFound = true;
            }           
        }

        if (!wordFound)
        {
            controller.LogStringWithReturn("You have entered an invalid command. Please type <b>commands</b> to see a list" +
                    " of all available commands.");
        }

        InputComplete();
    }

    private void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }
}
