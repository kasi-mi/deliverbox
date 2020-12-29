using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 障害物関係
/// 5パータンの障害物
/// 縦5
/// </summary>
public class Obstacle
{
    [SerializeField] Vector3 wallPos =new Vector3( 23.5f,0,0);
    [SerializeField] Vector3 edgeScale = new Vector3(1.5f, 1f, 1f);
    [SerializeField] Vector3 edgePos = new Vector3(10.0f, 0, 0);
    SpriteRenderer obs;

    public Obstacle(SpriteRenderer obs)
    {
        this.obs = obs;
    }

    /// <summary>
    /// 左出っ張り、右壁のみ
    /// </summary>
    /// <returns></returns>
    public GameObject pRigh()
    {
        GameObject parent = new GameObject("pRigh");
        //反対側
        obs.transform.localScale = edgeScale;
        GameObject.Instantiate(obs,-edgePos,Quaternion.identity , parent.transform);
        obs.transform.localScale = Vector3.one;
        GameObject.Instantiate(obs, wallPos, Quaternion.identity, parent.transform);
        return parent;
    }
   /// <summary>
   /// 右出っ張り、左壁のみ
   /// </summary>
   /// <returns></returns>
    public GameObject pLeft()
    {
        GameObject parent = new GameObject("pLeft");
        //反対側
        obs.transform.localScale = edgeScale;
        GameObject.Instantiate(obs, edgePos, Quaternion.identity, parent.transform);
        obs.transform.localScale = Vector3.one;
        GameObject.Instantiate(obs, -wallPos, Quaternion.identity, parent.transform);
        return parent;
    }
    /// <summary>
    /// 壁のみ
    /// </summary>
    /// <returns></returns>
    public GameObject pWall()
    {
        GameObject parent = new GameObject("wall");
        GameObject.Instantiate(obs, wallPos, Quaternion.identity, parent.transform);
        GameObject.Instantiate(obs, -wallPos, Quaternion.identity, parent.transform);
        return parent;
    }
    /// <summary>
    /// 何も無し
    /// </summary>
    /// <returns></returns>
    public GameObject pNull()
    {
        return new GameObject("null");       
    }
    /// <summary>
    /// 両端壁、真ん中障害物設置
    /// </summary>
    /// <returns></returns>
    public GameObject pMiddle()
    {
        GameObject parent = new GameObject("middle");
        //真ん中
        GameObject.Instantiate(obs, Vector3.zero, Quaternion.identity, parent.transform);

        GameObject.Instantiate(obs, wallPos, Quaternion.identity, parent.transform);
        GameObject.Instantiate(obs, -wallPos, Quaternion.identity, parent.transform);
        return parent;
    }
}
