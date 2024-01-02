using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    Texture2D texture;
    const float depth = 0.2f;
    [SerializeField] int dimension = 10;
    [SerializeField] float scale = 0.1f;
    [SerializeField]GameObject gameObject;

    GameObject[,] gameObjects;
    void Start()
    {


        texture = new Texture2D(dimension, dimension);
        gameObjects = new GameObject[dimension, dimension];
        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                float pixelX = (float)i / texture.width * scale;
                float pixelY = (float)j / texture.height * scale;

                Color color = new Color(Mathf.PerlinNoise(pixelX, pixelY), Mathf.PerlinNoise(pixelX, pixelY), Mathf.PerlinNoise(pixelX, pixelY), 1);
                texture.SetPixel(i, j, color);
                Debug.Log(color + "X: " + i + "Y: " + j);
                texture.Apply();
                gameObject.GetComponent<Renderer>().material.mainTexture = texture;
            }
        }

        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                Color color = texture.GetPixel(i, j);
                gameObjects[i,j] = Instantiate(Resources.Load<GameObject>("Cube"), new Vector3(i, (color.r + color.g + color.b) * 5, j), Quaternion.identity);
            }
        }


    }


    void Update()
    {
        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                float pixelX = (float)i / texture.width * scale;
                float pixelY = (float)j / texture.height * scale;

                Color color = new Color(Mathf.PerlinNoise(pixelX, pixelY), Mathf.PerlinNoise(pixelX, pixelY), Mathf.PerlinNoise(pixelX, pixelY), 1);
                texture.SetPixel(i, j, color);
                texture.Apply();
                gameObject.GetComponent<Renderer>().material.mainTexture = texture;
            }
        }

        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                Color color = texture.GetPixel(i, j);
                gameObjects[i,j].transform.position = new Vector3(i, (color.r + color.g + color.b) * 5, j);
            }
        }
    }
}
