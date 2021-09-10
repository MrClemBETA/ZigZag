using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject platform;

    private float createPlatformTime = .2f;
    private float currentPlatformTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPlatformTime += Time.deltaTime;
        if(currentPlatformTime > createPlatformTime)
        {
            createPlatform();
            currentPlatformTime = 0;
        }
    }

    private void createPlatform()
    {
        GameObject go = Instantiate(platform);
        go.transform.position = new Vector3(20, 0, 20);
    }
}
