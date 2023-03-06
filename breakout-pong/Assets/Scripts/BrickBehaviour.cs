using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Ball")
        {
            //Debug.Log();
            Destroy(gameObject);
            GameObject.Find("UICanvas").GetComponent<UIManager_PartB>().Score();
        }
    }
}
