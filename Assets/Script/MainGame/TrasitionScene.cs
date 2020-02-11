using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrasitionScene : MonoBehaviour
{
    public static TrasitionScene Trasition;
    //public Text endGameTxt;
    public Image blackScreen;
    public Animator anim;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        //endGameTxt.enabled = false;
        index = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void Awake()
    {
        if (Trasition == null)
        {
            Trasition = this;
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

    public void LoadSceneCurrent()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        // load the same scene
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    
    IEnumerator WaitLoadCurrentScene()
    {
        //endGameTxt.enabled = true;
        anim.SetTrigger("End");
        LoadSceneCurrent();
        yield return new WaitForSeconds(1.5f);
        //endGameTxt.enabled = false;
    }

    public void EndGame()
    {
         StartCoroutine(WaitLoadCurrentScene()); 
    }


    //nextLevel

    public void NextLevel()
    {
        StartCoroutine(WaitLoadNextScene());
    }

    public void LoadSceneNext()
    {
        SceneManager.LoadScene(index);
    }
    IEnumerator WaitLoadNextScene()
    {
        anim.SetTrigger("End");
        LoadSceneNext();
        yield return new WaitForSeconds(1.5f);
       
    }

    

  
}
