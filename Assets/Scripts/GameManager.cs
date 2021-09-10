using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject platform;

    private float createPlatformTime = .2f;
    private float currentPlatformTime = 0f;

    private float xPos;
    private float zPos;
    private float scale;

    public bool GameOver { get; private set; }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        GameOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        xPos = transform.position.x;
        zPos = transform.position.z;
        scale = platform.transform.localScale.x;
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
        go.transform.position = new Vector3(xPos, transform.position.y, zPos);
        int direction = Random.Range(0, 2);
        if(direction == 0)
        {
            xPos += scale;
        } else
        {
            zPos += scale;
        }
    }

    public void SetGameOver(bool value)
    {
        GameOver = value;
    }
}
