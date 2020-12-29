using UnityEngine;

/// <summary>
/// アドフォースにて力を加える
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    //減衰率
    [SerializeField] float Attenuation = 0.85f;

    private Rigidbody2D rb;
    //移動方向
    public static int moveDirection { private set; get; }
    //総降下距離
    public static float totalDistance { set; get; } = 0f;

    private void Start()
    {
        totalDistance = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMoveKye();
        DirectionCounter(Map.gravity * Map.pReduction);
    }

    private void FixedUpdate()
    {
        if(moveDirection != 0)
        {
            MoveAddForce(moveDirection);
            moveDirection = 0;
            return;
        }
        if (rb.velocity.x != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x * Attenuation, 0);             
        }
    }
    /// <summary>
    /// 総距離加算
    /// </summary>
    /// <param name="speed"></param>
    private void DirectionCounter(float speed)
    {
        if (GameManager.isGameOver) { return; }
        if (!GameManager.isPlayStart) { return; }
        if (GameManager.isClearPos) { return; }
        totalDistance += speed; 
    }
    /// <summary>
    /// 入力監視
    /// </summary>
    private void PlayerMoveKye()
    {
        if (GameManager.isGameOver) { return; }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1;
        }
    }

    /// <summary>
    /// 方向に合わせて力を加える
    /// </summary>
    /// <param name="direction"></param>
    private void MoveAddForce(float direction)
    {
        float acceleration = speed * direction;
        Vector2 force = new Vector2(acceleration, 0);
        rb.AddForce(force);
    }
}
