using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    // Start is called before the first frame update
    public string leveltoload;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Change Scene
            SceneManager.LoadScene(leveltoload);
        }
    }

    // Update is called once per frame
    void Start()
    {
        
    }
}
