using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCreater : MonoBehaviour
{
    public GameObject bomb;
    GameObject go;
    float throwTime = 2f;
    float throwBeginning = 0.5f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time>throwTime)
        {
            throwTime = Time.time + throwBeginning;
            go = Instantiate(bomb);
            go.transform.position = gameObject.transform.position;
            Destroy(go, 2f);
           
            
        }
    }

}
