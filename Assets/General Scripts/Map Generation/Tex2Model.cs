using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tex2Model : MonoBehaviour
{
    [SerializeField] private Texture2D mapTex;
    public GameObject dice;

	public void GenerateMap()
	{
		for (int x = 0; x < mapTex.width; x++)
		{
			for (int y = 0; y < mapTex.height; y++)
			{
				CreateMap(x, y);
                print(x + ", " + y);
			}
		}
	}

	void CreateMap(int x, int y)
	{
		Color pixelColor = mapTex.GetPixel(x, y);
        print(pixelColor);

		if(pixelColor.a == 0f)
        {
            return;
        }
        else
        {
            Vector3 position = new Vector3(dice.transform.localScale.x * x, 0f, dice.transform.localScale.z * y);  
            Instantiate(dice, position, Quaternion.Euler(0f, Random.Range(0, 4) * 90f, 0f), transform);
        }
	}

	public void Reset()
	{
		for (int i = transform.childCount - 1; i > -1; i--)
		{
			DestroyImmediate(transform.GetChild(i).gameObject);
		}
	}
}
