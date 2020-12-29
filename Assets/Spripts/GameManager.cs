using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform playerBox = null;
    [SerializeField] Vector2 boxStartMoveSpeed = new Vector2(0f, 0.2f);

    public static bool isGameOver { set; get; } = false;
    public static bool isGameClear { set; get; } = false;
    public static bool isPlayStart { set; get; } = false;
    public static bool isClearPos { set; get; } = false;

    Rigidbody2D playerRb;

    private void Start()
    {
        isGameClear = false;
        isGameOver = false;
        isPlayStart = false;
        isClearPos = false;
        playerRb = playerBox.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlayerStartMove();
        PlayerBoxEndMove();
    }
    /// <summary>
    /// クリアポジ位置時の最終降下
    /// </summary>
    private void PlayerBoxEndMove()
    {
        if (!isClearPos) { return; }
        if (isGameClear) { return; }
        Vector2 pos = playerBox.transform.position;
        playerRb.MovePosition(pos - boxStartMoveSpeed);

    }

    //boxを所定位置へ徐々に移動、位置につき次第スキップ
    private void PlayerStartMove()
    {
        if (isPlayStart) { return; }
        Vector2 pos = playerBox.transform.position;
        if (pos.y > Vector2.zero.y)
        {
            playerRb.MovePosition(pos- boxStartMoveSpeed);
            return;
        }
        isPlayStart = true;
    }
    
}
