using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ObjectClicker : MonoBehaviour
{
    public GameObject[] cubes;
    public Text turnText;

    List<string> pieces;

    public float waitTime = 1f;

    private float timer;
    private bool gameOver = false;

    private bool isPlayerOneTurn;

    private int playerTurn = 1;
    private int indArray1 = 0;
    private int indArray2 = 0;

    readonly private string[] playerOnePieces = new string[5];
    readonly private string[] playerTwoPieces = new string[4];

    readonly private static string[] winCondition1 = new [] { "Cube_1", "Cube_2", "Cube_3" }; //vertical
    readonly private static string[] winCondition2 = new [] { "Cube_4", "Cube_5", "Cube_6" }; //vertical
    readonly private static string[] winCondition3 = new [] { "Cube_7", "Cube_8", "Cube_9" }; //vertical
    readonly private static string[] winCondition4 = new [] { "Cube_1", "Cube_5", "Cube_9" }; //diagonal
    readonly private static string[] winCondition5 = new [] { "Cube_1", "Cube_4", "Cube_7" }; //horizontal
    readonly private static string[] winCondition6 = new [] { "Cube_2", "Cube_5", "Cube_8" }; //horizontal
    readonly private static string[] winCondition7 = new [] { "Cube_3", "Cube_6", "Cube_9" }; //horizontal
    readonly private static string[] winCondition8 = new [] { "Cube_7", "Cube_5", "Cube_3" }; //diagonal

    private string[][] winConditions = new[] { winCondition1, winCondition2, winCondition3, winCondition4, winCondition5, winCondition6, winCondition7, winCondition8 };

    // Update is called once per frame
    

    void Update()
    {
        if (gameOver)
        {
            return;
        }

        timer += Time.deltaTime;
        //print(timer);

        isPlayerOneTurn = (playerTurn % 2) != 0;

        if ((playerTurn <= 9))
        {
            string[] currentPlayerPieces = isPlayerOneTurn ? playerOnePieces : playerTwoPieces;

            if (isPlayerOneTurn)
            {
                turnText.text = "Player 1";
                if (Input.GetMouseButtonDown(0))
                {
                    print("Player1 pressed mouse");

                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit, 100.0f))
                    {
                        if (hit.transform != null)
                        {
                            PlacePiece(hit.transform.gameObject);
                        }
                    }
                    turnText.text = "Player 2";
                    timer = 0f;
                }
            }
            else
            {
                if (timer > waitTime)
                {
                    GameObject piece = GetAiWinningPiece();
                    if (piece == null)
                    {
                        piece = GetAiLosingPiece();
                    }
                    if (piece == null)
                    {
                        piece = GameObject.FindGameObjectWithTag("SquareUnselected");
                    }
                    PlacePiece(piece);
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
                 || IsWinningPlay(currentPlayerPieces, winCondition7)
                 || IsWinningPlay(currentPlayerPieces, winCondition8))
                {
                    print("YOU WON!!!!");
                    turnText.text = "YOU WON!!!!";
                    gameOver = true;
                }

            }
        }
    }

    private GameObject GetAiLosingPiece()
    {
        return GetWinningPiece(playerOnePieces);
    }

    private GameObject GetAiWinningPiece()
    {
        return GetWinningPiece(playerTwoPieces);
    }

    private GameObject GetWinningPiece(string[] playerPieces)
    {
        foreach (var winCondition in winConditions)
        {
            var missingPieces = winCondition.Except(playerPieces);
            if (missingPieces.Count() == 1)
            {
                string missingPieceName = missingPieces.First();
                GameObject missingPiece = GameObject.Find(missingPieceName);
                if (missingPiece.CompareTag("SquareUnselected"))
                {
                    return missingPiece;
                }
            }
        }

        return null;
    }

    private void PlacePiece(int cubeNumber)
    {
        PlacePiece(cubes[cubeNumber - 1]);
    }

    private void PlacePiece(GameObject cube)
    {
        cube.tag = "SquareSelected";
        cube.layer = 2;

        if (isPlayerOneTurn)
        {
            cube.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            playerOnePieces[indArray1] = cube.name;
            indArray1++;
        }
        else
        {
            cube.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
            playerTwoPieces[indArray2] = cube.name;
            indArray2++;
        }
        playerTurn++;
    }

    static bool IsWinningPlay(string[] currentPlayerPieces, string[] winCondition)
    {
        var missingPieces = winCondition.Except(currentPlayerPieces);
        bool hasMissingPieces = missingPieces.Any();
        bool isWinningPlay = !hasMissingPieces;
        return isWinningPlay;
    }
}