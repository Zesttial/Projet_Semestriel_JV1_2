using UnityEngine;

public class EnnemySwitch : MonoBehaviour
{


    public int state = 3;
    
    void Start()
    {
        







    }

    
    void Update()
    {
        
    }


    public void ennemyState()
    {
        switch (state)
        {
            case 1:

                Debug.Log("patrol");
                break;

            case 2:
                Debug.Log("follow");
                break;

            case 3:
                Debug.Log("Attack");
                break;


            default:
                Debug.Log("i can't follow");
                break;

        }
    }
}
