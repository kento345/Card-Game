using System;
using UnityEngine;
using static UnityEngine.CullingGroup;

public enum Juge
{
    none, win, lose, draw,
}

public class JugeMentManager 
{


    public Juge juge { get; private set; } = Juge.none;
    public event Action<Juge> jugeEvent;
    public Juge Juged() => juge;

    public Juge JugeMent(int player,int enemy)
    {
        var j = Juge.none;
        if(player > 21)
        {
            j = Juge.lose;
        }
        else if(player <= 21 && enemy > 0)
        {
            if(player > enemy || enemy > 21)
            {
                j = Juge.win;
            }
            else if(player < enemy)
            {
                j = Juge.lose;
            }
            else if(player == enemy) 
            {
                j = Juge.draw;
            }
        }
        jugeEvent?.Invoke(j);
        return j;
    }
}