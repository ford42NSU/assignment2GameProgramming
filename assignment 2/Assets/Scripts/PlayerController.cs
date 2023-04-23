using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using static MenuController;


public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject pauseTextObject;
    public Material red;
    public Material green;
    public GameObject player;
    public Renderer Object;

    private int count;
    private bool PauseFlag = false;
    public float sideWaysForce = 0.5f;

    void Start() 
    {
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        pauseTextObject.SetActive(false);
        
        if (color == 0)
        {
            Object.material = red;
        }
        else if (color == 1)
        {
            Object.material = green;
        }

        if (size == 1)
        {
            player.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        }

        else if (size == 2)
        {
            player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            SceneManager.LoadScene("Exit");;
        }
    }

    void Update() 
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (PauseFlag == true)
            {
                PauseFlag = false;
                Time.timeScale = 1;
                pauseTextObject.SetActive(false);
            }

            else if (PauseFlag == false)
            {
                PauseFlag = true;
                Time.timeScale = 0;
                pauseTextObject.SetActive(true);
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            rb.AddForce(sideWaysForce * Time.deltaTime * Speedbonus, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, sideWaysForce * Time.deltaTime * Speedbonus, ForceMode.VelocityChange);
        }
        
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -sideWaysForce * Time.deltaTime * Speedbonus, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideWaysForce * Time.deltaTime * Speedbonus, 0, 0, ForceMode.VelocityChange);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
}
