using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipSelection : MonoBehaviour
{
    public GameObject[] ships;
    public int selectedShip=0;

    public void setActiveShip ()
    {
        for (int index = 0; index < ships.Length; index++)
        {
            ships[index].SetActive(false);
        }

        ships[selectedShip].SetActive(true);
    }

    void Start()
    {
        setActiveShip();    
    }

    public void Next()
    {
        selectedShip++;
        if(selectedShip >= ships.Length)
        {
            selectedShip = 0;
        }

        setActiveShip();
    }

    public void Prev()
    {
        selectedShip--;
        if (selectedShip < 0)
        {
            selectedShip = ships.Length - 1;
        }

        setActiveShip();
    }

    public void Play()
    {
        SceneManager.LoadScene("level1");
        PlayerPrefs.SetInt("shipIndex", selectedShip);
    }
    void Update()
    {
        
    }
}
