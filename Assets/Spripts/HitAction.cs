using UnityEngine;

public class HitAction : MonoBehaviour
{
    [SerializeField] string wallTag = "wall";
    [SerializeField] string finishTag = "Finish";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == wallTag)
        {
            HitBreak();
            GameManager.isGameOver = true;
            GameManager.isPlayStart = false;
        }
        if(collision.collider.tag == finishTag)
        {
            GameManager.isGameClear = true;
            GameManager.isPlayStart = false;
        }
    }
    /// <summary>
    /// ゲームオーバー
    /// playerオブジェクト置き換え、アニメーションboxから4片boxへ
    /// </summary>
    private void HitBreak()
    {
        //GameOver
        //オンオフで置き換え
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);

        transform.GetChild(2).gameObject.SetActive(true);

    }
}
