using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public static LivesManager instance;
    private int liveCounter = 5;
    private GameObject[] livesImagesUI;
    private Color livesImageUIColor;
    private GameObject panelLives;

    private void Awake()
    {
        instance = this;
        //livesImagesUI = GameObject.FindGameObjectsWithTag("LivesImageUI");
        
        livesImageUIColor = new Color(1, 1, 1, 0.3f);
    }

    private void Start()
    {
        panelLives = GameObject.Find("PanelLives");
        livesImagesUI = new GameObject[panelLives.transform.childCount];
        for (int i = 0; i < panelLives.transform.childCount; i++)
        {
            livesImagesUI[i] = GameObject.Find("Live" + (i + 1));
        }
    }

    public void RemoveLives()
    {
        if (liveCounter > 0)
        {
            liveCounter--;
            SetLiveImage();
        }
        if (liveCounter <= 0)
        {
            GameManager.instance.GameOver();
        }
    }

    private void SetLiveImage()
    {
        livesImagesUI[liveCounter].GetComponent<Image>().color = livesImageUIColor;
    }
}
