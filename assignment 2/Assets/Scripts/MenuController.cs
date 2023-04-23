using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public Slider SpeedInput;
    public TextMeshProUGUI SizeDisplay;
    public TextMeshProUGUI ColorDisplay;
    public TextMeshProUGUI SpeedDisplay;
    public Dropdown Size;
    public Dropdown Color;
    public static float Speedbonus;
    public static int color;
    public static int size;

    // Update is called once per frame
    void Update()
    {
        Speedbonus = SpeedInput.value;
        SpeedDisplay.text = "Speed: " + Speedbonus.ToString("F2");
        SizeDisplay.text = "Size: " + Size.value.ToString("F2");
        ColorDisplay.text = "Color: " + Color.value.ToString("F2");
    }

    public void Play() 
    {
        Speedbonus = SpeedInput.value;
        color = Color.value;
        size = Size.value;
        SceneManager.LoadScene("minigame");
    }
}
