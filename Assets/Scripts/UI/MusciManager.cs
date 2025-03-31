using UnityEngine;

public class MusciManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] musicObjs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
    	
    	DontDestroyOnLoad(music);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
