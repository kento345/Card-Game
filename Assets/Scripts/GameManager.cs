using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private CharacterBase player_;

    [SerializeField] private Image coin;
    [SerializeField] private List<Sprite> coins_ = new();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bet(int num)
    {
        var obj = Instantiate(coin,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
        

        player_.CoinBet(num);
    }
}
