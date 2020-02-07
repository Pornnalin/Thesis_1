using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static bool IsInputEnabled = true;
    public static bool gameEnd = false;
    //public static bool isChagn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd == true) 
        {
            UIManager.iManager.endGameTxt.enabled = true;
            IsInputEnabled = false;
            //MainPlayerController.instance.anim.SetFloat("Speed", 0f);
        }
        else
        {
            UIManager.iManager.endGameTxt.enabled = false;
            IsInputEnabled = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    isChagn = true;
        //    SceneManager.LoadScene("TestCameraFollow2");
        //}
    }
}
