using UnityEngine;

public class BackpackToggle : MonoBehaviour
{
    public GameObject backpackCanvas;
    public KeyCode toggleKey = KeyCode.B;

    private void Start()
    {
        if (backpackCanvas != null)
        {
            backpackCanvas.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleBackpack();
        }
    }

    public void ToggleBackpack()
    {
        if (backpackCanvas != null)
        {
            bool currentState = backpackCanvas.activeSelf;
            backpackCanvas.SetActive(!currentState);
        }
    }
}