using UnityEngine;

public class uEndUi : MonoBehaviour
{
    private void Update()
    {
        GameOverDisplay();
        ClearDisplay();
    }

    private void GameOverDisplay()
    {
        if (GameManager.isGameOver)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void ClearDisplay()
    {
        if (GameManager.isGameClear)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
