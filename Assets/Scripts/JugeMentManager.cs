using UnityEngine;

public class JugeMentManager 
{
    public enum Juge
    {
        win,lose, draw,
    }

    public Juge JugeMent(int player,int enemy)
    {
        return Juge.win;
    }
}
