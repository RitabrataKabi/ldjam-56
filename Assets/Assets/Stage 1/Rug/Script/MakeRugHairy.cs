using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRugHairy : MonoBehaviour
{

    public Vector2 Size;
    public Vector3 offset;
    public Vector2Int Grid;
    public GameObject[] hairs;

    [Range(01f, 10f)]
    public float randomOffset;

    public void AddHair()
    {
        float linearConst = Size.x/Grid.x;
        GameObject p = new GameObject("hairParent");

        for (int i = 1; i < Grid.x + 1; i++)
        {
            for (int j = 1; j < Grid.y + 1; j++)
            {
                GameObject go = selectHair();
                Vector3 position = randomPos(i, j) + transform.position + offset + new Vector3(linearConst * i, 0, linearConst * j);
                Vector3 rotation = new Vector3(-90f, Random.Range(0f, 360f) , 0f);
                Instantiate(go, position, Quaternion.Euler(rotation), p.transform);
            }
        }
    }

    int getRandom()
    {
        int i = Random.Range(0, hairs.Length);
        return i;
    }

    GameObject selectHair()
    {
        int i = getRandom();
        return hairs[i];
    }

    Vector3 randomPos(float i, float j)
    {
        float x = Mathf.Clamp01((Random.Range(0.1f, 1f) * randomOffset));
        float y = Mathf.Clamp01((Random.Range(0.1f, 1f) * randomOffset));
        Vector3 pos = new Vector3(Size.x/Grid.x  * x, 0f, Size.y/Grid.y * y);
        return pos;
    }
}
