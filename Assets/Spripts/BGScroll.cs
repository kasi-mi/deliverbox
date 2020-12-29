using UnityEngine;

public class BGScroll : MonoBehaviour
{
    private void Update()
    {
        Scroll(Map.gravity, Map.pReduction,Map.bakUnderPos);
    }

    private void Scroll(float gravity,float pReduction,Vector3 limitPos)
    {
        if(!GameManager.isPlayStart) { return; }
        if (GameManager.isGameOver) { return; }
        if (GameManager.isClearPos) { return; }
        transform.Translate(0, gravity * pReduction, 0);

        if(transform.position.y > -limitPos.y)
        {
            transform.position = limitPos;
        }
    }

}
