using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private List<KeyCode> KeyCodeList = new List<KeyCode>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddKeyCode(KeyCode keyCode)
    {
        KeyCodeList.Add(keyCode);
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameDone)
        {
            return;
        }

        foreach (KeyCode keyCode in KeyCodeList)
        {
            if (Input.GetKeyDown(keyCode) == true)
            {

                NoteManager.Instance.Onlnput(keyCode);
                break;
            }

        }
    }
}
