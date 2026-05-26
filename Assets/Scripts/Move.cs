using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Move : MonoBehaviour
{
    Vector2 targetPos;
    float speed = 0.3f;
    Vector2 velocity = Vector2.zero;
    float time;


    void Start()
    {
        targetPos = new Vector2(transform.position.x ,-transform.position .y + 10 );
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref velocity, speed);
        //transform.Rotate(0,0,speed);
    }
}
