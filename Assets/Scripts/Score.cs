using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int points = 0;
    public static int points2 = 0;
    public TMP_Text pointsText;
    public TMP_Text pointsText2;
    public GameObject striker;
    public GameObject board;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (board.GetComponent<gameManager>().count % 2 == 0)
        {
            if (collision.gameObject.tag == "puck")
            {
                Destroy(collision.gameObject);
                points += 1;

            }
            if (collision.gameObject.tag == "queen")
            {
                Destroy(collision.gameObject);
                points += 2;

            }
            if (board.GetComponent<gameManager>().count % 2 == 0)
            {
                pointsText.text = "Score: " + points.ToString();
            }
        }
        if (board.GetComponent<gameManager>().count % 2 != 0)
        {
            if (collision.gameObject.tag == "puck")
            {
                Destroy(collision.gameObject);
                points2 += 1;

            }
            if (collision.gameObject.tag == "queen")
            {
                Destroy(collision.gameObject);
                points2 += 2;

            }
            if (board.GetComponent<gameManager>().count % 2 != 0)
            {
                pointsText2.text = "Score: " + points2.ToString();
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
