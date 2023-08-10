using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Main : MonoBehaviour
{
    public Field Field;

    private int rows = 5;
    private int columns = 5;

    private int[,] cellValues;

    private void Start()
    {
        cellValues = new int[rows, columns];
    }
    
    private void UpdateView()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Field.Rows[i].Cells[j].text = cellValues[i, j].ToString();
            }
        }
    }

    public void CreateRandomArray()
    {
        Field.CleanRows();
        Field.GetRows();
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                cellValues[i, j] = Random.Range(10, 100);
            }
        }
        
        UpdateView();
    }

    public void BubbleSortArray()
    {
        StartCoroutine(BubbleSortCoroutine());
    }
    

    public IEnumerator BubbleSortCoroutine()
    {
        bool needSwap;

        do
        {
            needSwap = false;
    
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (j < columns - 1 && cellValues[i, j] > cellValues[i, j + 1])
                    {
                        (cellValues[i, j], cellValues[i, j + 1]) = (cellValues[i, j + 1], cellValues[i, j]);
                        yield return new WaitForSeconds(0.05f);
                        UpdateView();
                        needSwap = true;
                    }
            
                    if (i < rows - 1 && cellValues[i, j] > cellValues[i + 1, j])
                    {
                        (cellValues[i, j], cellValues[i + 1, j]) = (cellValues[i + 1, j], cellValues[i, j]);
                        yield return new WaitForSeconds(0.05f);
                        UpdateView();
                        needSwap = true;
                    }
                }
            }
        } while (needSwap);
    }

}
