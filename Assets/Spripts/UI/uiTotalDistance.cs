using UnityEngine;
using UnityEngine.UI;

public class uiTotalDistance : MonoBehaviour
{
    Text totalDistanceText;
    private void Start()
    {
        totalDistanceText = GetComponent<Text>();
    }
    void Update()
    {
        DistanceTextDisplay(PlayerMovement.totalDistance);
    }
    private void DistanceTextDisplay(float distance)
    {
        //総距離をブロック長さで割り、表示距離を計算
        int intDistance =(int)(distance / (-Map.obsGenePos.y / 2));

        totalDistanceText.text = intDistance.ToString();
    }
}
