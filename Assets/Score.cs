using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    int player0 = 0;
    int player1 = 0;

    // Start is called before the first frame update
    void Start()
    {

        gameObject.GetComponent<UnityEngine.UI.Text>().text = "No Score";

    }

    public void incrementPlayer(int n) {
        if (n == 0)
        {
            player0++;
        }
        else
        {
            player1++;
        }
    }

    public int winner()
    {
        return player0 > player1 ? 0 : 1;
    }

    public int max()
    {
        return player0 > player1 ? player0 : player1;
    }

    public void reset()
    {
        player0 = 0;
        player1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Player Blue: " + player0 + "\nPlayer Red: " + player1;

    }
}
