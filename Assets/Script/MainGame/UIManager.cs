using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager iManager;
    public Text endGameTxt;
    public Image blackScreen;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        endGameTxt.enabled = false;
    }
    public void Awake()
    {
        if (iManager == null)
        {
            iManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        // load the same scene
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
     IEnumerator WaitLoadScene()
    {
        endGameTxt.enabled = true;
        anim.SetTrigger("End");
        LoadScene();
        yield return new WaitForSeconds(1.5f);
        endGameTxt.enabled = false;
    }

    public void EndGame()
    {
         StartCoroutine(WaitLoadScene()); 
    }
}
