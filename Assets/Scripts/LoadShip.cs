using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadShip : MonoBehaviour
{
    public GameObject[] ships;
    public int selectedShip;

    public void setActiveShip()
    {
        for (int index = 0; index < ships.Length; index++)
        {
            ships[index].SetActive(false);
        }

        ships[selectedShip].SetActive(true);
    }
    void Start()
    {
        Load();
    }

    void Load()
    {
        selectedShip = PlayerPrefs.GetInt("shipIndex");
        setActiveShip();
    }
}
