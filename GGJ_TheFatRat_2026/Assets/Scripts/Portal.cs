using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] int next_level;
    public bool character_has_enter = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "character")
        {
            character_has_enter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "character")
        {
            character_has_enter = false;
        }
    }
}
