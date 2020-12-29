using UnityEngine;
/// <summary>
/// 背景
/// boxの落下を表現するにbox操作に合わせて背景を上昇させる
/// あらかじめ下にもう1つ用意しておく
/// 上が特定位置まで到達した時、上にある背景を下に戻す
/// 障害物
/// ローカルポジションがある程度進むと生成
/// 移動して画面外に出た時点で削除
/// </summary>
public class Map : MonoBehaviour
{
    [SerializeField] Transform bak = null;
    [SerializeField] SpriteRenderer obsSprite = null;
    [SerializeField] Transform endObj = null;

    public static Vector3 obsGenePos { get; } = new Vector3(0, -16.0f, 0);
    public static Vector3 bakUnderPos { get; } = new Vector3(0, -30.0f, 0);
    public static Vector3 obsUpLimit { get; } = new Vector3(0, 18.0f, 0);

    // パラシュート無での落下速度
    public static float gravity { get; } = 0.6f;
    // パラシュートでの落下速度軽減率
    public static float pReduction { get; } = 0.1f;
    //終わりの距離
    public static float endDistance { get; } = 22.0f;
    //一時的に保持
    private GameObject obsTmp;
    //endObjectを生成したか
    private bool isEndObjGene = false;
    //障害物の並び
    private readonly int[] obsLine = new int[] {0,2,1,2,3,2,0,0,3,2,
                                       3,2,1,2,3,3,2,1,1,2};
    //並びのカウント
    private int lineCount = 0;

    Obstacle obs;

    private void Start()
    {
        //背景保持数
        int bakHoge = 2;
        obs = new Obstacle(obsSprite);
        new GameObject("bakHoge").transform.parent = transform;
        new GameObject("obsHoge").transform.parent = transform;

        for (int i = 0; i < bakHoge; i++)
        {
            bak.transform.position = new Vector3(0, bakUnderPos.y * i, 0);
            Instantiate(bak, transform.GetChild(0).transform);
        }
        StartObstacleSetUp();
    }

    private void Update()
    {
        GeneratePosCheck(obsTmp,-obsGenePos/2);
        DistanceCotllor();
    }

    /// <summary>
    /// 障害物の生成、引数でパターン変更
    /// </summary>
    /// <param name="pattern"></param>
    private void GenerateObstacle(int pattern)
    {
        switch (pattern)
        {
            //右寄り
            case 0:
                obsTmp = obs.pRigh();
                break;
            //左寄り
            case 1:
                obsTmp = obs.pLeft();
                break;
            //壁のみ
            case 2:
                obsTmp = obs.pWall();
                break;
            //中寄
            case 3:
                obsTmp = obs.pMiddle();
                break;
            //無し
            case 4:
                obsTmp = obs.pNull();
                break;

        }
        obsTmp.transform.position = obsGenePos;
        obsTmp.transform.parent =transform.GetChild(1);
    }

    //障害物部で何を生成するべきか判断
    private void GeneratePosCheck(GameObject target ,Vector3 checkPos)
    {
        //ゴール生成
        if (PlayerMovement.totalDistance / (-Map.obsGenePos.y / 2) > endDistance-1)
        {
            if (isEndObjGene)
            {
                return;
            }
            Instantiate(endObj);
            isEndObjGene = true;
            return;
        }

        if(target.transform.GetChild(0).localPosition.y > checkPos.y)
        {
            GenerateObstacle(obsLine[lineCount]);
            lineCount++;
        }
    }
    /// <summary>
    /// クリアポジションについたか
    /// ついた場合カウントしないようスキップ
    /// </summary>
    private void DistanceCotllor()
    {
        if (GameManager.isClearPos) { return; }
        if (PlayerMovement.totalDistance / (-Map.obsGenePos.y / 2) > endDistance)
        {
            GameManager.isClearPos = true;
        }

    }
    /// <summary>
    /// 開始時の壁作成
    /// </summary>
    private void StartObstacleSetUp()
    {
        int split = 5;
        Vector3 pos = -obsGenePos;
        //上から作っていく
        for (int i = split;i > 0; i--)
        {
            obsTmp = obs.pWall();
            obsTmp.transform.position = pos;
            //1ブロック分下げる
            pos -= -obsGenePos / 2;
        }
    }


}
