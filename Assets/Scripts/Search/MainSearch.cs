using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MainSearch : MonoBehaviour
{
    public Row Row;
    public TMP_InputField TMPInputField;
    public Button CreateButton;
    
    private int[] cellValues;
    private int searchedValue;


    private bool canAct;
    
    private void UpdateView()
    {
        for (int i = 0; i < cellValues.Length; i++)
        {
            Row.Cells[i].text = cellValues[i].ToString();
        }

    }

    public void CreateRandomArray()
    {
        if (!canAct)
        {
            return;
        }

        Row.CleanCells();
        Row.GetCells();
        
        cellValues = new int[Row.Cells.Count];

        for (int i = 0; i < cellValues.Length; i++)
        {
            cellValues[i] = Random.Range(10, 100);
        }

        var inputValue = Convert.ToInt32(TMPInputField.text);
        
        cellValues[Random.Range(0, cellValues.Length)] = inputValue;

        searchedValue = inputValue;
        
        UpdateView();
        
        TMPInputField.interactable = false;
        CreateButton.interactable = false;
    }

    public void FindValue()
    {
        if (cellValues.Length < 2)
        {
            return;
        }
        
        TMPInputField.interactable = true;
        CreateButton.interactable = true;

        BubbleSort();
        BinarySearch();
        UpdateView();
    }

    private void BinarySearch()
    {
        int guess = 0;
        int low = 0;
        int high = cellValues.Length - 1;

        int iteration = 1;
        
        while (cellValues[guess] != searchedValue)
        {
            guess = (low + high) / 2;

            if (searchedValue < cellValues[guess])
            {
                high = guess - 1;
            }
            else if (searchedValue > cellValues[guess])
            {
                low = guess + 1;
            }

            iteration++;
        }

        Row.Cells[guess].color = Color.red;
        
        Debug.Log($"Value {searchedValue} ({nameof(cellValues)}:[{guess}]) found in {iteration} attemps with help of binary search.");
    }

    private void Update()
    {
        if (TMPInputField.text.Equals(""))
        {
            canAct = false;
        }
        else
        {
            canAct = true;
        }
    }

    private void BubbleSort()
    {
        for (int i = 0; i < cellValues.Length - 1; i++)
        {
            for (int j = 0; j < cellValues.Length - i - 1; j++)
                if (cellValues[j] > cellValues[j + 1])
                {
                    (cellValues[j], cellValues[j + 1]) = (cellValues[j + 1], cellValues[j]);
                }
        }
    }
}
