using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    None,       // 初期状態
    Bet,        // ベット待ち
    Dealing,    // 最初のカードを配る
    PlayerTurn, // プレイヤーの行動中
    DealerTurn, // ディーラーの行動中
    Result      // 勝敗判定・結果表示
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private JugeMentManager jugeManager;                   //JugeMentManager

    [SerializeField] private CharacterBase player_;　　　　//playerScript
    [SerializeField] private CharacterBase enemy_;         //enemyScript
    [SerializeField] private Canvas canv_;                 //CanvasObj
    [SerializeField] private Image coin;                   //コインPrefab
    [SerializeField] private List<Sprite> coins_ = new();　//コインSprite
    [SerializeField] private Text coinText_;               //コインText
    [SerializeField] private Text haveCoinText_;           //所有コインText
    List<Image> beforeObj = new();                         //前回生成したコイン

    protected GameState state { get; private set; } = GameState.None;

    //イベント
    public event Action<GameState> stateChanged;
    public GameState Stated() => state;


    void Awake()
    {
        //シングルトン
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject );
            return;
        }
        Instance = this;
        //------Script取得-------
        jugeManager = new JugeMentManager();
        //-----------------------
        StateUpdate(GameState.Bet);
        //Time.timeScale = 0f;
        haveCoinText_.text = "所有数: "+ player_.Coin().ToString();
    }


    /// <summary>
    /// ベット数,コイン生成,
    /// </summary>
    /// <param name="num"></param>
    public void Bet(int num)
    {
        if(player_.CoinNum() + num <= 300)
        {
            //コインSpriteのdataIndex
            int coinIndex = num switch
            {
                10 => 0,
                50 => 1,
                100 => 2,
                _ => 0
            };
            //text,sprite変更,生成,移動
            var obj = Instantiate(coin, new Vector3(1000, 700, transform.position.z), Quaternion.identity);
            var text = obj.GetComponentInChildren<Text>();
            text.text = num.ToString();
            obj.sprite = coins_[coinIndex];
            obj.transform.SetParent(canv_.transform);
            for (int i = 0; i < beforeObj.Count; i++)
            {
                if (beforeObj[i] != null)
                {
                    beforeObj[i].transform.position += new Vector3(-50f, 0f, 0f);
                }
            }
            beforeObj.Add(obj);

            player_.CoinBet(num);
            coinText_.text = "Bet数: " + player_.CoinNum().ToString();
        }
    }
    
    /// <summary>
    /// 決定Button用
    /// </summary>
    public void Entry()
    {
        if(player_.CoinNum() > 0)
        {
            canv_.enabled = false;
            StateUpdate(GameState.Dealing);
        }
    }

    /// <summary>
    /// ResetButton用
    /// </summary>
    public void Reset()
    {
        if(Stated() == GameState.Bet)
        {
            player_.ResetCoinBet();
            foreach(var coin in beforeObj)
            {
                Destroy(coin.gameObject);
            }
            beforeObj.Clear();
            coinText_.text = "Bet数: " + player_.CoinNum().ToString();
        }
    }

    public void StateUpdate(GameState s)
    {
        if (state == s) return;
        state = s;
        stateChanged?.Invoke(s);
    }

    public GameObject obj()
    {
        return gameObject;
    }
}
