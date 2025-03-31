using UnityEngine;

public class MusciManager : MonoBehaviour
{
    private bool keepPlaying = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] musicObjs = GameObject.FindGameObjectsWithTag("Music");
		
//		if(this.gameObject.GetComponent<AudioSource>().clip.ToString() != musicObjs.clip.ToString())
//		{
			for(int i = 0; i < musicObjs.Length; i++)
			{
				if(musicObjs[i] != gameObject
				&& this.gameObject.GetComponent<AudioSource>().clip.ToString() != musicObjs[i].GetComponent<AudioSource>().clip.ToString())
				{
					Destroy(musicObjs[i]);
					keepPlaying = true;
				}
	//			Debug.Log(musicObjs[i].GetComponent<AudioSource>().clip.toString());
			}
//		}
//		if(this.gameObject.GetComponent<AudioSource>().clip.toString() != musicObjs
        if (musicObjs.Length > 1 && !keepPlaying)
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
