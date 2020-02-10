using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _GameManager;
    public static bool IsInputEnabled = true;
    public static bool gameEnd = false;
    public  GameObject caseModel;
   

    //public static bool isChagn;

    // Start is called before the first frame update
    void Start()
    {

        IsInputEnabled = true;
        gameEnd = false;
    }
    private void Awake()
    {
        if (_GameManager == null)
        {
            _GameManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd == true) 
        {
            //UIManager.iManager.endGameTxt.enabled = true;
            IsInputEnabled = false;
            
            //MainPlayerController.instance.anim.SetFloat("Speed", 0f);
            
        }
        else
        {
            //UIManager.iManager.endGameTxt.enabled = false;
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
