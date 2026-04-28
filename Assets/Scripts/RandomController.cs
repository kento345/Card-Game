using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class RandomController : MonoBehaviour
{
    int ran;
    bool isLoop = false;

    private void Update()
    {
        
    }

    public void Random(int x, int y)
    {
        isLoop = true;

        while (isLoop)
        {
            Mathf.PingPong(x, y);
        }
           //ran = Mathf.PingPong(Time.time * 2,x - y) + y;
    }
}
