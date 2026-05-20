using UnityEngine;

public class PlateformMove : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Platform")]
    [SerializeField] private Transform Platform;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    private float standBye;
    private float wait;

    private void Update()
    {
        if (movingLeft)
        {
            if (Platform.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();

        }
        else
        {
            if (Platform.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }

    }
    private void DirectionChange()
    {

        wait += Time.deltaTime;

        if (wait > standBye)
            movingLeft = !movingLeft;

    }




    private void MoveInDirection(int direction)
    {
        wait = 0;


        Platform.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);


        Platform.position = new Vector3(Platform.position.x + Time.deltaTime * direction * speed, Platform.position.y, Platform.position.z);
    }














}
