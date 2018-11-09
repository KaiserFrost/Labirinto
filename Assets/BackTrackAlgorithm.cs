using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTrackAlgorithm : MazeAlgorithm
{


    int currentRow = 0;
    int currentColumn = 0;
    bool completed = true;
    Stack<Vector2> cellvisited;

    public BackTrackAlgorithm(MazeCell[,] mazeCells) : base(mazeCells)
    {
        cellvisited = new Stack<Vector2>();
    }

    public override void CreateMaze()
    {
        Recurse();
    }


    public void Recurse()
    {

        mazeCells[currentRow, currentColumn].visited = true;
        cellvisited.Push(new Vector2(currentRow,currentColumn));
       

        while (cellvisited.Count > 0)
        {
            stuff();
            Backtrack();
        }
    }
    public void Backtrack()
    {

       cellvisited.Pop();
        Vector2 current = cellvisited.Peek();
        currentRow = (int)current.x;
        currentColumn = (int)current.y;
        Debug.Log("row: " + currentRow + "column :" + currentColumn);
        Debug.Log("stack: " + cellvisited.Count);


    }

    public void stuff()
    {
       

        while (AvailableAdjacentCell(currentRow, currentColumn))
        {
            int direction = Random.Range(1, 5);
            //norte
            if (direction == 1 && CellAvailable(currentRow - 1, currentColumn))
            {
                KickWallDown(mazeCells[currentRow, currentColumn].northWall);
                KickWallDown(mazeCells[currentRow - 1, currentColumn].southWall);

               cellvisited.Push(new Vector2(currentRow, currentColumn));
                currentRow--;
            }
            // sul
            else if (direction == 2 && CellAvailable(currentRow + 1, currentColumn))
            {

                KickWallDown(mazeCells[currentRow, currentColumn].southWall);
                KickWallDown(mazeCells[currentRow + 1, currentColumn].northWall);

                cellvisited.Push(new Vector2(currentRow, currentColumn));
                currentRow++;
            }
            // este
            else if (direction == 3 && CellAvailable(currentRow, currentColumn + 1))
            {

                KickWallDown(mazeCells[currentRow, currentColumn].eastWall);
                KickWallDown(mazeCells[currentRow, currentColumn + 1].westWall);

                cellvisited.Push(new Vector2(currentRow, currentColumn));
                currentColumn++;
            }
            // oeste
            else if (direction == 4 && CellAvailable(currentRow, currentColumn - 1))
            {

                KickWallDown(mazeCells[currentRow, currentColumn].westWall);
                KickWallDown(mazeCells[currentRow, currentColumn - 1].eastWall);

                cellvisited.Push(new Vector2(currentRow, currentColumn));
                currentColumn--;
            }

            //cellvisited.Push(mazeCells[currentRow, currentColumn]);
            mazeCells[currentRow, currentColumn].visited = true;
        }

    }

    

    public void KickWallDown(GameObject wall)
    {
        if (wall != null)
        {
            Object.Destroy(wall);
        }
    }

    private bool CellAvailable(int row, int column)
    {
        if (row >= 0 && row < mazeRows && column >= 0 && column < mazeColumns && !mazeCells[row, column].visited)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool AvailableAdjacentCell(int row, int column)
    {
        int unvisited = 0;

        if ((row > 0 && !mazeCells[row - 1, column].visited) || 
            (row < mazeRows - 1 && !mazeCells[row + 1, column].visited) ||
            (column > 0 && !mazeCells[row, column - 1].visited)||
            (column < mazeColumns - 1 && !mazeCells[row, column + 1].visited))

                {
                        unvisited++;
                }

                return unvisited > 0;
    }

}
