using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombController : MonoBehaviour
{
    Rigidbody2D physics;
    float speed = 10;
    
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        physics.velocity = new Vector3(0, 1, 0) * speed;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        TagManager tagManager = col.gameObject.GetComponent<TagManager>();
        if (tagManager == null)
            return;
        Tag tag = tagManager.myTag;
        if (tag.Equals(Tag.ball))
        {
            Destroy(gameObject);
        }
    }
}
