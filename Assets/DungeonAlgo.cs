using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonAlgo: MonoBehaviour
{


    Dictionary<String, bool> Row_One;
    Dictionary<String, bool> Row_Two;
    Dictionary<String, bool> Row_Three;
    Dictionary<String, bool> Row_Four;
    Dictionary<String, bool> Row_Boss;

    /*
     [ ] [ ] [ ] [ ]
     [ ] [ ] [ ] [ ]
     [ ] [ ] [ ] [ ]
     [ ] [ ] [ ] [ ]
     */

    private void Start()
    {
        



    }

    public void RegenerateRooms()
    {
        Debug.Log("Generating Room Connections \n");
        GenerateRooms();
    }

    public void GenerateRooms()
    {
        Row_One = new Dictionary<String, bool>()
        {
            {"(0,0)", false},
            {"(0,1)", false },
            {"(0,2)", false },
            {"(0,3)", false }
        };


        Row_Two = new Dictionary<String, bool>()
        {
            {"(1,0)", false},
            {"(1,1)", false },
            {"(1,2)", false },
            {"(1,3)", false }
        };

        Row_Three = new Dictionary<String, bool>()
        {
            {"(2,0)", false},
            {"(2,1)", false },
            {"(2,2)", false },
            {"(2,3)", false }
        };

        Row_Four = new Dictionary<String, bool>()
        {
            {"(3,0)", false},
            {"(3,1)", false },
            {"(3,2)", false },
            {"(3,3)", false }
        };

        Row_Boss = new Dictionary<String, bool>()
        {
            {"(4,0)", false},
            {"(4,1)", false },
            {"(4,2)", false },
            {"(4,3)", false }
        };



        // random index
        int firstRowRoomSelection = Random.Range(0, Row_One.Count);
        Row_One[$"(0,{firstRowRoomSelection})"] = true;


        int secondRowRoomSelection = Random.Range(0, Random.Range(0, Row_Two.Count));
        Row_Two[$"(1,{secondRowRoomSelection})"] = true;


        // firstRoom = 1 -> secondRoom = 3 // ROW TO CONNECT FROM IS LESS THAN ROW TO CONNECT TO
        if (firstRowRoomSelection < secondRowRoomSelection)
        {
            // active starting room for row one
            // then activate each room until we get to the second row index
            for (int i = firstRowRoomSelection; i <= secondRowRoomSelection; i++)
            {
                Row_One[$"(0,{i})"] = true;
            }
        }

        // firstRoom = 4 -> secondRoom = 2 // ROW TO CONNECT FROM IS GREATER THAN ROW TO CONNECT TO
        else if (firstRowRoomSelection > secondRowRoomSelection)
        {
            // active starting room for row one
            // then activate each room until we get to the second row index
            for (int i = firstRowRoomSelection; i >= secondRowRoomSelection; i--)
            {
                Row_One[$"(0,{i})"] = true;
            }
        }

        // firstRoom = 1 -> secondRoom = 1 // ROW TO CONNECT FROM IS IS THE SAME AS ROW TO CONNECT TO
        else
        {
            // Do nothing
        }


        PrintRoom();
    }

    public void PrintRoom()
    {
        

        string rowBuilderString = "\n";


        // Row One
        foreach (var room in Row_One)
        {
           
            if (room.Value)
            {
                rowBuilderString += $" [X] ";
            } else
            {
                rowBuilderString += $" [/] ";
            }
        }

        rowBuilderString += "\n";

        // Row Two
        foreach (var room in Row_Two)
        {

            if (room.Value)
            {
                rowBuilderString += $" [X] ";
            }
            else
            {
                rowBuilderString += $" [/] ";
            }
        }

        rowBuilderString += "\n";

        // Row Three
        foreach (var room in Row_Three)
        {

            if (room.Value)
            {
                rowBuilderString += $" [X] ";
            }
            else
            {
                rowBuilderString += $" [/] ";
            }
        }

        rowBuilderString += "\n";

        // Row Four
        foreach (var room in Row_Four)
        {

            if (room.Value)
            {
                rowBuilderString += $" [X] ";
            }
            else
            {
                rowBuilderString += $" [/] ";
            }
        }

        rowBuilderString += "\n";

        Debug.Log(rowBuilderString);
    }
}

