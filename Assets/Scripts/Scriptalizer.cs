using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scriptalizer : MonoBehaviour
{
    public Camera           RenderCamera;
    public RenderTexture    RenderTextureObject;

    private Game            _game;
    Texture2D texture;
    Rect rect;

    string[,] wholeText;


    Color backgroundColor = new Color(1, 0, 1, 0);
    // Start is called before the first frame update
    void Start()
    {
        _game = GetComponent<Game>();

        texture = new Texture2D(DATA.GRID_WIDTH, DATA.GRID_HEIGHT);
        rect = new Rect(0, 0, Screen.width, Screen.height);

        wholeText = new string[DATA.GRID_WIDTH, DATA.GRID_HEIGHT];

    }

    int counter = 0;

    // Update is called once per frame
    void Update()
    {
        //RefreshRenderTexture();

        counter++;

        if (counter >= 20)
        {
            StartCoroutine(ScriptalizeRenderTexture());
            counter = 0;
        }
    }

    private void RefreshRenderTexture()
    {
        throw new NotImplementedException();
    }

    private IEnumerator ScriptalizeRenderTexture()
    {
        RenderCamera.Render();
        RenderTexture.active = RenderTextureObject;

        //RenderTextureObject.


        int widthStep       = DATA.GRID_WIDTH / Screen.width;
        int heightStep      = DATA.GRID_HEIGHT / Screen.height;


        for (int i = 0; i < DATA.GRID_WIDTH; i++)
        {
            for (int j = 0; j < DATA.GRID_HEIGHT; j++)
            {
                texture.ReadPixels(rect, i * widthStep, j * heightStep);

                Color color = texture.GetPixel(i, j);

                float greytone = color.r + color.g + color.b;


                Debug.Log($"Color of field ({i}/{j}): {color}");

                if (color.g > 0.5f
                 && greytone < 2f)
                {
                    DATA.TextGrid[i, j].text = "+";
                }
                else
                {
                    DATA.TextGrid[i, j].text = " ";
                }


                /*
                if (color == backgroundColor)
                {
                    DATA.TextGrid[i, j].text = " ";
                }
                else if (greytone < 2f)
                {
                    DATA.TextGrid[i, j].text = "+";
                }
                else if (greytone < 2.2f)
                {
                    DATA.TextGrid[i, j].text = "*";
                }
                else if (greytone < 2.5f)
                {
                    DATA.TextGrid[i, j].text = "#";
                }
                */
                wholeText[i, j] = DATA.TextGrid[i, j].text;
            }
        }


        /*
        bool hasOnlyEqualNeighbors;

        for (int i = 1; i < DATA.GRID_WIDTH - 1; i++)
        {
            for (int j = 1; j < DATA.GRID_HEIGHT - 1; j++)
            {
                hasOnlyEqualNeighbors = true;

                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        if (!wholeText[i, j].Equals(wholeText[i + x, j + y]))
                        {
                            hasOnlyEqualNeighbors = false;
                        }
                    }
                }

                if (hasOnlyEqualNeighbors)
                {
                    DATA.TextGrid[i, j].text = " ";
                }
            }
        }
        */

        RenderTexture.active = null;

        yield return null;
    }
}
