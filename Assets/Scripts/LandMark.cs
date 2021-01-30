using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandMark : MonoBehaviour
{
    GameManager gameManager;
    public GameObject grabText;
    public GameObject C, M, Y;
    public Material cyan, magenta, yellow;
    public ParticleSystem particleSystem;
    public GameObject PauseMenu;
    public GameObject Cross;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager.cyan)
            {
                grabText.GetComponent<Text>().text = "Press E to place Primary Cyan artefact";
            }
            else if (gameManager.magenta)
            {
                grabText.GetComponent<Text>().text = "Press E to place Primary Magenta artefact";
            }
            else if (gameManager.yellow)
            {
                grabText.GetComponent<Text>().text = "Press E to place Primary Yellow artefact";
            }
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager.cyan)
            {
                grabText.GetComponent<Text>().text = "Press E to place Primary Cyan artefact";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    C.SetActive(false);
                    gameManager.cyan = false;
                    grabText.GetComponent<Text>().text = "";

                    GameObject Cyan = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Cyan.GetComponent<MeshRenderer>().material = cyan;
                    Cyan.transform.position = gameObject.transform.position + new Vector3(1.5f, 1.5f, 0);

                    gameManager.RestoreColor(0);
                    //noir
                    if (particleSystem.startColor.r == 0 && particleSystem.startColor.g == 0 && particleSystem.startColor.b == 0)
                    {
                        particleSystem.startColor = new Color(0, 1, 1);
                    }
                    //jaune
                    else if (particleSystem.startColor.r == 1 && particleSystem.startColor.g == 1 && particleSystem.startColor.b == 0)
                    {
                        particleSystem.startColor = new Color(0, 1, 0);
                    }
                    //magenta
                    else if (particleSystem.startColor.r == 1 && particleSystem.startColor.g == 0 && particleSystem.startColor.b == 1)
                    {
                        particleSystem.startColor = new Color(0, 0, 1);
                    }
                    //magenta & jaune
                    else if (particleSystem.startColor.r == 1 && particleSystem.startColor.g == 0 && particleSystem.startColor.b == 0)
                    {
                        particleSystem.startColor = new Color(1, 1, 1);
                    }
                    particleSystem.gameObject.SetActive(false);
                    particleSystem.gameObject.SetActive(true);
                    gameManager.colorRestored++;
 
                }
            }
            else if (gameManager.magenta)
            {
                grabText.GetComponent<Text>().text = "Press E to place Primary Magenta artefact";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    M.SetActive(false);
                    gameManager.magenta = false;
                    grabText.GetComponent<Text>().text = "";

                    GameObject Magenta = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Magenta.GetComponent<MeshRenderer>().material = magenta;
                    Magenta.transform.position = gameObject.transform.position + new Vector3(0, 1.5f, 0);

                    gameManager.RestoreColor(1);
                    //noir
                    if (particleSystem.startColor.r == 0 && particleSystem.startColor.g == 0 && particleSystem.startColor.b == 0)
                    {
                        particleSystem.startColor = new Color(1, 0, 1);
                    }
                    //jaune
                    else if (particleSystem.startColor.r == 1 && particleSystem.startColor.g == 1 && particleSystem.startColor.b == 0)
                    {
                        particleSystem.startColor = new Color(1, 0, 0);
                    }
                    //cyan
                    else if (particleSystem.startColor.r == 0 && particleSystem.startColor.g == 1 && particleSystem.startColor.b == 1)
                    {
                        particleSystem.startColor = new Color(0, 0, 1);
                    }
                    //cyan & jaune
                    else if (particleSystem.startColor.r == 0 && particleSystem.startColor.g == 1 && particleSystem.startColor.b == 0)
                    {
                        particleSystem.startColor = new Color(1, 1, 1);
                    }
                    particleSystem.gameObject.SetActive(false);
                    particleSystem.gameObject.SetActive(true);
                    gameManager.colorRestored++;

                }
            }
            else if (gameManager.yellow)
            {
                grabText.GetComponent<Text>().text = "Press E to place Primary Yellow artefact";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Y.SetActive(false);
                    gameManager.yellow = false;
                    grabText.GetComponent<Text>().text = "";

                    GameObject Yellow = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Yellow.GetComponent<MeshRenderer>().material = yellow;
                    Yellow.transform.position = gameObject.transform.position + new Vector3(-1.5f, 1.5f, 0);

                    gameManager.RestoreColor(2);
                    //noir
                    if (particleSystem.startColor.r == 0 && particleSystem.startColor.g == 0 && particleSystem.startColor.b == 0)
                    {
                        particleSystem.startColor = new Color(1, 1, 0);
                    }
                    //magenta
                    else if (particleSystem.startColor.r == 1 && particleSystem.startColor.g == 0 && particleSystem.startColor.b == 1)
                    {
                        particleSystem.startColor = new Color(1, 0, 0);
                    }
                    //cyan
                    else if (particleSystem.startColor.r == 0 && particleSystem.startColor.g == 1 && particleSystem.startColor.b == 1)
                    {
                        particleSystem.startColor = new Color(0, 1, 0);
                    }
                    //cyan & magenta
                    else if (particleSystem.startColor.r == 0 && particleSystem.startColor.g == 0 && particleSystem.startColor.b == 1)
                    {
                        particleSystem.startColor = new Color(1, 1, 1);
                    }
                    particleSystem.gameObject.SetActive(false);
                    particleSystem.gameObject.SetActive(true);
                    gameManager.colorRestored++;

                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            grabText.GetComponent<Text>().text = "";
            if (gameManager.colorRestored == 3)
            {
                gameManager.colorRestored = 0;
                Cross.SetActive(false);
                PauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
        }
    }
}
