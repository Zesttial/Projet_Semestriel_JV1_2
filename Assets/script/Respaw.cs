using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform myTransform;

    void Start()
    {

    }


    void Update()               
    {
        if (myTransform.position.y < -10)            
        {
            myTransform.position = new Vector2(-10, 0);   
        }
    }
}