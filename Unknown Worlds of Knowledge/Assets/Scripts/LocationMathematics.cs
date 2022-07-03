using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationMathematics : Scene
{
    public Timer timer;

    private void Start()
    {
        SetCamera();
    }

    private void Update()
    {
        ExitMenu();
        LoadScene(1);
    }

    private void ExitMenu()
    {
        if(timer.time.fillAmount == 0)
        {
            HideInterface();
        }
    }
}
