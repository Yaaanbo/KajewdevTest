using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CursorStateHandler(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            CursorStateHandler(false);
        }
        else if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            CursorStateHandler(true);
        }
    }

    private void CursorStateHandler(bool _isLocking)
    {
        if (_isLocking)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
