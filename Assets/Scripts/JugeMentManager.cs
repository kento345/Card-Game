using UnityEngine;

public class JugeMentManager 
{
    public enum Juge
    {
        none,win,lose, draw,
    }

    public Juge JugeMent(int player,int enemy)
    {
        var j = Juge.none;
        if(player > 21)
        {
            j = Juge.lose;
        }
        else if(player< 21)
        {
            if(player > enemy)
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
        return j;
    }
}
