using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointControl : MonoBehaviour
{
    public static CheckPointControl checkPointControl;
    public Vector3 lastCheckPos;

    // Start is called before the first frame update
    void Start()
    {
        if (checkPointControl == null)
        {
            checkPointControl = this;
            DontDestroyOnLoad(checkPointControl);
        }
        else
        {
            Destroy(gameObject);
        }

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
