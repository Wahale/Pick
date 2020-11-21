using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Equals : MonoBehaviour
{
    public bool isLose;
    public GameObject buttonGo,buttonRestart,buttonNext;
    private GameObject[] leftSlots;
    private GameObject[] rightSlots;
    private GameObject[] leftMiddleSlots;
    private GameObject[] rightMiddleSlots;
    private GameObject[] items;
    private GameObject[] players;
    private int all;
    private int countArr;
    public bool returnToSpawnPoint = true;

    private void Start()
    {
        all = GameObject.FindGameObjectWithTag("Container").transform.childCount;
        leftSlots = GameObject.FindGameObjectsWithTag("LeftSlots");
        rightSlots = GameObject.FindGameObjectsWithTag("RightSlots");
        leftMiddleSlots = GameObject.FindGameObjectsWithTag("LeftMiddleSlots");
        rightMiddleSlots = GameObject.FindGameObjectsWithTag("RightMiddleSlots");
        items = GameObject.FindGameObjectsWithTag("Item");
        players = GameObject.FindGameObjectsWithTag("Player");
        CountAllObjects();
        NewColorForItems();
    }
    private void Update()
    {
        ActiveButton();
    }

    public void EqualsItems()
    {
        isLose = true;
        returnToSpawnPoint = false;
        EqulsPositionItemAndSlots(items);
        EqulsPositionItemAndSlots(players);
        Invoke("LoseOrWin",0.1f);
        SetActiveFalse(leftSlots);
        SetActiveFalse(leftMiddleSlots);
    }

    private void EqulsPositionItemAndSlots(GameObject[] gm)
    {
        for (int i = 0; i < gm.Length; i++)
        {
            for (int j = 0; j < leftSlots.Length; j++)
                if (gm[i].transform.position == leftSlots[j].transform.position)
                {
                    gm[i].transform.position = new Vector3( rightSlots[j].transform.position.x, gm[i].transform.position.y, gm[i].transform.position.z);
                }

            for (int j = 0; j < leftMiddleSlots.Length; j++)
                if (gm[i].transform.position == leftMiddleSlots[j].transform.position)
                {
                    gm[i].transform.position = new Vector3(rightMiddleSlots[j].transform.position.x, gm[i].transform.position.y, gm[i].transform.position.z);
                }
        }
    }

    private void SetActiveFalse(GameObject[] gm)
    {
        for (int i = 0; i < gm.Length; i++)
            gm[i].SetActive(false);
    }

    private void ActiveButton()
    {
        all = GameObject.FindGameObjectWithTag("Container").transform.childCount;;
        if (countArr == all)
        {
            buttonGo.SetActive(true);
        }
    }

    private void CountAllObjects()
    {
        countArr = all + players.Length;
    }

    private void LoseOrWin()
    {
        if (!buttonRestart.activeSelf)
        {
            buttonNext.SetActive(true);
        }   
    }

    public void YouWin()
    {
        Bridge.money += Bridge.income;
        SceneManager.LoadScene(0);
    }

    public void YouLose()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    private void NewColorForItems()
    {
        for(int  i = 0 ; i < items.Length; i++)
        {
            items[i].GetComponent<Image>().color = Bridge.color;
        }
    }
}
