using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ObjectClicker : MonoBehaviour
{
    public Text turnText;

    public float waitTime = 1f;

    private float timer;
    private bool gameOver = false;

    private int playerTurn = 1;
    private int indArray1 = 0;
    private int indArray2 = 0;

    readonly private string[] playerOnePieces = new string[5];
    readonly private string[] playerTwoPieces = new string[4];

    readonly private string[] winCondition1 = new string[] { "Cube_1", "Cube_2", "Cube_3" }; //vertical
    readonly private string[] winCondition2 = new string[] { "Cube_4", "Cube_5", "Cube_6" }; //vertical
    readonly private string[] winCondition3 = new string[] { "Cube_7", "Cube_8", "Cube_9" }; //vertical
    readonly private string[] winCondition4 = new string[] { "Cube_1", "Cube_5", "Cube_9" }; //diagonal
    readonly private string[] winCondition8 = new string[] { "Cube_7", "Cube_5", "Cube_3" }; //diagonal
    readonly private string[] winCondition5 = new string[] { "Cube_1", "Cube_4", "Cube_7" }; //horizontal
    readonly private string[] winCondition6 = new string[] { "Cube_2", "Cube_5", "Cube_8" }; //horizontal
    readonly private string[] winCondition7 = new string[] { "Cube_3", "Cube_6", "Cube_9" }; //horizontal

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            return;
        }

        timer += Time.deltaTime;
        //print(timer);

        bool isPlayerOneTurn = (playerTurn % 2) != 0;

        if ((playerTurn <= 9))
        {
            string[] currentPlayerPieces = isPlayerOneTurn ? playerOnePieces : playerTwoPieces;

            if (isPlayerOneTurn)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    print("Player1 pressed mouse");

                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit, 100.0f))
                    {
                        if (hit.transform != null)
                        {
                            Rigidbody clickedSquare;
                            if (clickedSquare = hit.transform.GetComponent<Rigidbody>())
                            {
                                print("Hit - this.name: " + this.name);
                                print("hit.transform.gameObject: " + hit.transform.gameObject);
                                if (playerTurn <= 9)
                                {
                                    // bool isPlayerOneTurn = (playerTurn % 2) != 0;
                                   // string[] currentPlayerPieces = isPlayerOneTurn ? playerOnePieces : playerTwoPieces;
                                    print("playerTurn: " + playerTurn);
                                    clickedSquare.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
                                    clickedSquare.tag = "SquareSelected";
                                    hit.transform.gameObject.layer = 2;

                                    currentPlayerPieces[indArray1] = hit.transform.gameObject.name;
                                    Debug.Log("playerOnePieces[indArray1]: " + " indArray1:  " + indArray1 + currentPlayerPieces[indArray1].ToString());
                                    indArray1++;

                                }
                            }
                        }
                    }
                    playerTurn++;
                    timer = 0f;
                }
            }
            else
            {
                if (timer > waitTime)
                {
                    print("Player2 turn");
                    if (playerTurn <= 9)
                    {
                       // string[] currentPlayerPieces = isPlayerOneTurn ? playerOnePieces : playerTwoPieces;
                        print("playerTurn: " + playerTurn);

                        var playableSquare = GameObject.FindGameObjectWithTag("SquareUnselected");
                        playableSquare.GetComponent<Renderer>().material.color = new Color(0, 0, 10);
                        playableSquare.tag = "SquareSelected";
                        print("tag: " + playableSquare.tag);
                    }
                    playerTurn++;
                }
            }

            if (playerTurn >= 5)
            {
                if (IsWinningPlay(currentPlayerPieces, winCondition1)
                 || IsWinningPlay(currentPlayerPieces, winCondition2)
                 || IsWinningPlay(currentPlayerPieces, winCondition3)
                 || IsWinningPlay(currentPlayerPieces, winCondition4)
                 || IsWinningPlay(currentPlayerPieces, winCondition5)
                 || IsWinningPlay(currentPlayerPieces, winCondition6)
                 || IsWinningPlay(currentPlayerPieces, winCondition7))
                {
                    print("YOU WON!!!!");
                    gameOver = true;
                }
                
            }
        }
    }

    static bool IsWinningPlay(string[] currentPlayerPieces, string[] winCondition)
    {
        var missingPieces = winCondition.Except(currentPlayerPieces);
        bool hasMissingPieces = missingPieces.Any();
        bool isWinningPlay = !hasMissingPieces;
        return isWinningPlay;
    }
}


//if (Input.GetMouseButtonDown(0)) //player 1 uses mouse input
//{
//    RaycastHit hit;
//    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//    if (Physics.Raycast(ray, out hit, 100.0f))
//    {
//        if (hit.transform != null)
//        {
//            Rigidbody clickedSquare;
//            if (clickedSquare = hit.transform.GetComponent<Rigidbody>())
//            {
//                //print("Hit - this.name: " + this.name);
//                //print("hit.transform.gameObject: " + hit.transform.gameObject);

//                if (playerTurn <= 9)
//                {
//                    //bool isPlayerOneTurn = (playerTurn % 2) != 0;

//                    string[] currentPlayerPieces = isPlayerOneTurn ? playerOnePieces : playerTwoPieces;

//                    print("playerTurn: " + playerTurn);

//                    //clickedSquare.GetComponent<Renderer>().material.color = isPlayerOneTurn ? new Color(255, 255, 0) : new Color(0, 0, 0);
//                    //hit.transform.gameObject.layer = 2;

//                    if (isPlayerOneTurn)
//                    {
//                        clickedSquare.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
//                        hit.transform.gameObject.layer = 2;

//                        currentPlayerPieces[indArray1] = hit.transform.gameObject.name;
//                        Debug.Log("playerOnePieces[indArray1]: " + " indArray1:  " + indArray1 + currentPlayerPieces[indArray1].ToString());
//                        indArray1++;
//                    }
//                    //else
//                    //{
//                    //    currentPlayerPieces[indArray2] = hit.transform.gameObject.name;
//                    //    Debug.Log("playerTwoPieces[indArray2]: " + " indArray2:  " + indArray2 + currentPlayerPieces[indArray2].ToString());
//                    //    indArray2++;
//                    //}

//                    if (playerTurn >= 5)
//                    {
//                        if (IsWinningPlay(currentPlayerPieces, winCondition1)
//                         || IsWinningPlay(currentPlayerPieces, winCondition2)
//                         || IsWinningPlay(currentPlayerPieces, winCondition3)
//                         || IsWinningPlay(currentPlayerPieces, winCondition4)
//                         || IsWinningPlay(currentPlayerPieces, winCondition5)
//                         || IsWinningPlay(currentPlayerPieces, winCondition6)
//                         || IsWinningPlay(currentPlayerPieces, winCondition7))
//                        {
//                            print("YOU WON!!!!");
//                        }
//                        else
//                        {
//                            print("winCondition[] is not a subset of currentPlayerPieces[]");
//                        }
//                    }

//                    playerTurn++;
//                }
//            }
//        }
//    }
//}
//if (!isPlayerOneTurn) // player 2
//{
//    if (playerTurn <= 9)
//    {
//        string[] currentPlayerPieces = isPlayerOneTurn ? playerOnePieces : playerTwoPieces;
//        print("playerTurn: " + playerTurn);

//        var playableSquare = GameObject.FindGameObjectWithTag("SquareUnselected");
//        playableSquare.GetComponent<Renderer>().material.color = new Color(100, 100, 100);
//        playableSquare.tag = "SquareSelected";
//        print("tag: "+ playableSquare.tag);
//    }

//}