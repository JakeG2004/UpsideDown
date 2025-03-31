using UnityEngine;

public class MusciManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] musicObjs = GameObject.FindGameObjectsWithTag("Music");

        if (musicObjs.Length > 1)
        {
            Destroy(this.gameObject);
        }
    	
    	DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
