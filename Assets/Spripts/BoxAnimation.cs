
using System.Collections;
using UnityEngine;


public class BoxAnimation : MonoBehaviour
{
    [SerializeField]public Sprite[] gazou = new Sprite[4];

    bool isLoopEnd = false;
    private float wait = 0.75f;

    SpriteRenderer boxSprite;

    private void Awake()
    {
        boxSprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine("BoxRotationAnimeC");
    }

    private void OnDisable()
    {
        isLoopEnd = true;
        StopCoroutine("BoxRotationAnimeC");
    }
    
    private IEnumerator BoxRotationAnimeC()
    {
        int n = 0;
        while (!isLoopEnd)
        {
            yield return new WaitForSeconds(wait);
            n++;
            n %= 4;
            boxSprite.sprite = gazou[n];
        }
    }
}
