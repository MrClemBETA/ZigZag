using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float lifetime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Ball")
        {
            GetComponentInParent<Rigidbody>().useGravity = true;
            StartCoroutine(DestroyPlatform());
        }
    }

    private IEnumerator DestroyPlatform()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(transform.parent.gameObject);
    }
}
