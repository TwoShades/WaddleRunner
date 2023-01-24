using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HatLogic : MonoBehaviour
{
    [SerializeField] private Transform hatContainer; 
    private List<GameObject> hatModels = new List<GameObject>();
    private Hat[] hats;

    private void Start()
    {
        hats = Resources.LoadAll<Hat>("Hat");
        SpawnHats();
        SelectHat(SaveManager.Instance.save.CurrentHatIndex);
    }

    private void SpawnHats()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            hatModels.Add(Instantiate(hats[i].Model, hatContainer) as GameObject);
        }

    }

    public void DisableAllHats()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            hatModels[i].SetActive(false);
        }
    }

    public void SelectHat(int index)
    {
        DisableAllHats();
        hatModels[index].SetActive(true);
    }

}
