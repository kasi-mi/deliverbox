using UnityEngine;
using UnityEngine.SceneManagement;

public class uReStart : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
