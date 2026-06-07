using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    List<Vector2> raindropPositions;

    // Start is called before the first frame update
    void Start()
    {
        DATA.TextGrid = new Text[DATA.GRID_WIDTH, DATA.GRID_HEIGHT];
        raindropPositions = new List<Vector2>();

        for (int i = 0; i < DATA.GRID_WIDTH; i++)
        {
            for (int j = 0; j < DATA.GRID_HEIGHT; j++)
            {
                DATA.TextGrid[i, j] = GameObject.Find($"Row ({j})").transform.Find($"Character ({i})").GetComponent<Text>();
            }
        }

        foreach (Text textItem in DATA.TextGrid)
        {
            textItem.text = ".";
        }
    }


    int counter = 0;

    int windstärke = 0;

    void Update()
    {
        counter++;




        /*

        if (counter >= 100)
        {
            windstärke++;

            Debug.Log("Erhöhe Windstärke auf " + windstärke);

            counter = 0;
        }

        CreateRaindrop();

        for (int i = 0; i < windstärke; i++)
        {
            CreateRaindrop();
        }


        /*        
                خڛؼ
               c°>°ᴐ
               /┌^┐\
                └͟ ┘
               /   \

        © ª « ¬ ­ ® ¯ ° µ ¼ ½ ¾ ¿ ǁ ȸ ȹ ˀ ˁ    ˄  
             ˽̷̸͜͡͝  א  خؼڛ ۝ ჻ ᴖ ᴗ ᴐ ⁞ ₡ ⅓ ⅔ ⅕ ⅖ ⅗ ⅘ ⅙ ← ↑ → ↓ ↔ ↕ 
        ↖ ↗ ↘ ↙ ⅟ ⌠ ⌡ ① ❶ ⴔ ﬓ ﬔ ﬕ ﬖ ﬗ אּ ﷺ ﷻ ﷼ ﻵ ﻶ ﻷ󠇒 
        
        ﴾ ﴿ Ꝇ Ꚙ ꚙ ┌ ┐ └ ┘ □ ◊ ○ ◌ ● ∆ ∂ ∏ ∞

        



        // Animiere Regen
        for (int i = 0; i < raindropPositions.Count; i++)
        {
            int x = (int)raindropPositions[i].x;
            int y = (int)raindropPositions[i].y;


            if (x > 0 && x < gridLength
             && y > 0 && y < gridHeight)
            {
                TextGrid[x, y].text = " ";
            }


            if ((int)raindropPositions[i].y != 0)
            {
                int addX = 0;


                addX -= (int)Random.Range(0, windstärke + 1);

                raindropPositions[i] = new Vector2((int)raindropPositions[i].x + addX, (int)(raindropPositions[i].y - 3));      // y-3: Regen, y-1: Schnee

                x = (int)raindropPositions[i].x;
                y = (int)raindropPositions[i].y;


                if (x > 0 && x < gridLength
                 && y > 0 && y < gridHeight)
                {
                    TextGrid[x, y].text = ".";
                }

            }
            else
            {
                raindropPositions.Remove(raindropPositions[i]);
            }

        }

        
                */
    }

    private void CreateRaindrop()
    {
        Vector2 newRainDrop = new Vector2(Random.Range(0, DATA.GRID_WIDTH * (windstärke + 1)), DATA.GRID_HEIGHT - 1);

        raindropPositions.Add(newRainDrop);


        int x = (int)newRainDrop.x;
        int y = (int)newRainDrop.y;


        if (x > 0 && x < DATA.GRID_WIDTH
         && y > 0 && y < DATA.GRID_HEIGHT)
        {
            DATA.TextGrid[x, y].text = ".";
        }
    }
}
