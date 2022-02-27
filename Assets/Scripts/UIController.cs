using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject menu;
    public GameObject panel;
    public GameObject joystick;
    public GameObject joybutton;
    void Start()
    {
        Time.timeScale = 0f;
    }
    public void Menu(bool toggle)
    {
        menu.SetActive(toggle);
        panel.SetActive(toggle);

        if(toggle == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        joystick.SetActive(!toggle);
        joybutton.SetActive(!toggle);
    } 
    public void ExitButton()
    {
        Application.Quit();
    }
}
