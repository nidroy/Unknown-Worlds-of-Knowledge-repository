using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public int number;

    public Animator[] anim;
    public GameObject[] portal;

    private bool isPress;

    private void Start()
    {
        isPress = false;
    }

    private void Update()
    {
        if (isPress && Input.GetKeyDown(KeyCode.E))
            Press();
    }

    private void Press()
    {
        Reset(number - 1);
        if (anim[number - 1].GetBool("isOn"))
        {
            anim[number - 1].SetBool("isOn", false);
            portal[number - 1].SetActive(false);
        }
        else
        {
            anim[number - 1].SetBool("isOn", true);
            portal[number - 1].SetActive(true);
        }
    }

    private void Reset(int number)
    {
        for(int i = 0; i < 4; i++)
        {
            if (i != number)
            {
                anim[i].SetBool("isOn", false);
                portal[i].SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            isPress = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isPress = false;
    }
}
