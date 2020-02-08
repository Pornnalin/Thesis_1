using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text endGameTxt;
    public static UIManager iManager;
    // Start is called before the first frame update
    void Start()
    {
      
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
}
