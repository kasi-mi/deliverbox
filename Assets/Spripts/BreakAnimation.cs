using System.Collections.Generic;
using UnityEngine;

public class BreakAnimation : MonoBehaviour
{
    List<GameObject> boxChild = new List<GameObject>();


    private void OnEnable()
    {
        foreach (Transform child in transform)
        {
            boxChild.Add(child.gameObject);
        }
        Explode(boxChild);
    }

    private void Explode(List<GameObject> parts)
    {
        foreach(GameObject obj in parts)
        {
            float x = Random.Range(-10, 10);
            float y = Random.Range(-10, 10);
            Vector2 forcePower = new Vector2(x, y);

            float torque = Random.Range(-10, 10);

            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.AddForce(forcePower, ForceMode2D.Impulse);
            rb.AddTorque(torque, ForceMode2D.Impulse);
        }
    }

}
