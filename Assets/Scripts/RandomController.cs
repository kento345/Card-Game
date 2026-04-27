using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class RandomController : MonoBehaviour
{
    int ran;
    bool isLoop = false;

    public void Random(int x, int y)
    {
        while (isLoop)
        {
            
        }
           //ran = Mathf.PingPong(Time.time * 2,x - y) + y;
    }
}
