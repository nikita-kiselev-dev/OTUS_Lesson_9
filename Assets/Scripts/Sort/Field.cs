using System;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public List<Row> Rows;

    public void GetRows()
    {
        foreach (Transform child in gameObject.transform)
        {
            var row = child.GetComponent<Row>();
            Rows.Add(row);
            
            row.GetCells();
        }
    }

    public void CleanRows()
    {
        foreach (Transform child in gameObject.transform)
        {
            var row = child.GetComponent<Row>();
            row.CleanCells();
        }
        
        Rows.Clear();
    }
}
