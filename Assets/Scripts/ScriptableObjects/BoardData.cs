using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]

  public class BoardData : ScriptableObject
{    [System.Serializable]
  public class Searchingword
    {   [HideInInspector]
        public bool found = false;
        public string word;
    }
    [System.Serializable]
    public class BoardRow
    {
        public int Size;
        public string[] Row;

        public BoardRow()
        {}
        public BoardRow(int size)
        {
            CreateRow(size);
        }
        public void CreateRow(int size)
        {
            Size = size;
            Row = new string[Size];
            ClearRow();
        }
        public void  ClearRow()
        {
            for(int i = 0; i < Size; i++)
            {
                Row[i] = " ";
            }
        }
    }
    public float timeInSeconds;
    public int columns = 0;
    public int rows = 0;
    public BoardRow[] Board;
    public List<Searchingword> SearchWords = new List<Searchingword>();
    
    public void ClearData()
    {
        foreach(var word in SearchWords)
        {
            word.found = false;
        }
    }
    public void ClearWithEmptyString()
    {
        for(int i =0;i< columns; i++)
        {
            Board[i].ClearRow();
        }
    }
    public void CreateNewBoard()
    {
        Board = new BoardRow[columns];
        for (int i = 0; i < columns; i++)
        {
            Board[i] = new BoardRow(rows); 
        }
    }


    
}
