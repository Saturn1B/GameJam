using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimaryColor : MonoBehaviour
{
    public float minHigh, maxHigh;
    float floating;
    public GameObject grabText;
    public GameObject colorAff;
    GameManager gameManager;
    bool canDestroy;

    // Start is called before the first frame update
    void Awake()
    {
        floating = 0.005f;
        canDestroy = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FloatingCube();
        if(canDestroy && Input.GetKeyDown(KeyCode.E))
        {
            if (name == "Primary Cyan")
            {
                gameManager.cyan = true;
            }
            else if (name == "Primary Magenta")
            {
                gameManager.magenta = true;
            }
            else if (name == "Primary Yellow")
            {
                gameManager.yellow = true;
            }
            colorAff.SetActive(true);
            grabText.GetComponent<Text>().text = "";
            Destroy(gameObject);
        }
    }

    void FloatingCube()
    {
        transform.eulerAngles += new Vector3(0, 0.25f, 0);
        if (transform.eulerAngles.y >= 360)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        transform.position += new Vector3(0, floating, 0);
        if (transform.position.y >= maxHigh)
        {
            floating = -floating;
        }

        if (transform.position.y <= minHigh)
        {
            floating = -floating;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            grabText.GetComponent<Text>().text = "Press E to grab " + name + " artefact";
            canDestroy = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            grabText.GetComponent<Text>().text = "";
            canDestroy = false;
        }
    }
}
