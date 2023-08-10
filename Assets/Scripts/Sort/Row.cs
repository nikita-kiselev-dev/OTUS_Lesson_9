using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Row : MonoBehaviour
{
    public List<TextMeshProUGUI> Cells;

    public void GetCells()
    {
        foreach (Transform child in gameObject.transform)
        {
            var cell = child.GetComponent<Cell>();
            
            Cells.Add(cell.Text);
        }
    }

    public void CleanCells()
    {
        foreach (var text in Cells)
        {
            text.color = Color.white;
        }
        
        Cells.Clear();
    }
}
