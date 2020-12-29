using UnityEngine;

public class ObstacleScroll : MonoBehaviour
{

    void Update()
    {
        Scroll(Map.gravity, Map.pReduction,Map.obsUpLimit);
    }

    private void Scroll(float gravity, float pReduction,Vector3 limit)
    {
        if(!GameManager.isPlayStart) { return; }
        if (GameManager.isClearPos) { return; }
        if (GameManager.isGameOver) { return; }
        transform.Translate(0, gravity * pReduction, 0);
        if (transform.position.y > limit.y)
        {
            Destroy(transform.gameObject);
        }
    }
}
