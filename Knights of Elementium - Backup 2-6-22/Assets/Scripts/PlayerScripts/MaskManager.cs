using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskManager : MonoBehaviour
{
    public GameObject Mask;
    public GameObject Player;
    public Image PreviousMaskState;
    public Sprite Shatter1;
    public Sprite Shatter2;
    public Sprite Shatter3;
    public Sprite Shatter4;
    public Sprite Shatter5;
    public Sprite Shatter6;
    public Sprite Shatter7;


    public void MaskShatter1()
    {
        PreviousMaskState.sprite = Shatter1;
    }
    public void MaskShatter2()
    {
        PreviousMaskState.sprite = Shatter2;
    }
    public void MaskShatter3()
    {
        PreviousMaskState.sprite = Shatter3;
    }
    public void MaskShatter4()
    {
        PreviousMaskState.sprite = Shatter4;
    }
    public void MaskShatter5()
    {
        PreviousMaskState.sprite = Shatter5;
    }
    public void MaskShatter6()
    {
        PreviousMaskState.sprite = Shatter6;
    }
    public void MaskShatter7()
    {
        PreviousMaskState.sprite = Shatter7;
    }
}
