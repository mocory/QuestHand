using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handshape : MonoBehaviour
{
    Handchecker handchecker;
    public int Step, Fase;
    public OVRHand HandL, HandR;
    public Text learnmessage;
    public int[] CorrecthandL,CorrecthandR;
    public bool AllowShapetrack;
    public GameObject Otehon;
    public Material RMat, LMat, OKMat;
    bool IsLcorrect, IsRcorrect;
    public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        handchecker = GetComponent<Handchecker>();
        CorrecthandR = new int[] { 0,0,0,0,0,0,0,0,0 };
        CorrecthandL = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    }

    // Update is called once per frame
    void Update()
    {
        Correctcolor();
        CorrectcolorR();
        Fingermatch();
//        colorchange();
        switch (Step)
        {
            case 0:
                Learnstart();
                break;
            case 1:
                Hello();
                break;
        }
    }
    void colorchange()
    {
        if ((int)Time.time % 2 == 1)
        {
            IsLcorrect = true;
            IsRcorrect = false;
        }
        else
        {
            IsLcorrect = false;
            IsRcorrect = true;
        }
    }
    void Correctcolor()
    {
        if (IsLcorrect)
        {
            Otehon.transform.GetChild(Fase).GetChild(0).GetChild(1).GetChild(1).GetComponent<Renderer>().material.color = new Color(0, 1, 0);
        }
        else
        {
            Otehon.transform.GetChild(Fase).GetChild(0).GetChild(1).GetChild(1).GetComponent<Renderer>().material.color = Color.blue;
        }
    }
    void CorrectcolorR()
    {
        if (IsRcorrect)
        {
            Otehon.transform.GetChild(Fase).GetChild(0).GetChild(0).GetChild(1).GetComponent<Renderer>().material.color = new Color(0, 1, 0);
        }
        else
        {
            Otehon.transform.GetChild(Fase).GetChild(0).GetChild(0).GetChild(1).GetComponent<Renderer>().material.color = Color.red;
        }
    }

    void Learnstart()
    {
        if (HandL.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            Step = 1;
        }
        /*        else if (HandL.GetFingerIsPinching(OVRHand.HandFinger.Middle))
                {
                    Step = 2;
                }
                else if (HandL.GetFingerIsPinching(OVRHand.HandFinger.Ring))
                {
                    Step = 3;
                }*/
        else
        {
            learnmessage.text = "学習モード待機中" +
                "\n\n左人差し指をピンチして下さい";
        }
    }

    void Hello()
    {
        switch (Fase)
        {
            case 0:
                Otehon.transform.GetChild(Fase).gameObject.SetActive(true);
                CorrecthandR = new int[] { 0, 1, 1, -1, -1, 1, 1, 1, 1 };
                AllowShapetrack = true;
                learnmessage.text = "お昼" +
         "\nを意味する手話";
                if (IsRcorrect)
                {
                    Fase++;
                }
                break;
            case 1:
                Otehon.transform.GetChild(Fase).gameObject.SetActive(true);
                Otehon.transform.GetChild(Fase - 1).gameObject.SetActive(false);
                CorrecthandR = new int[] { 0, 1, -1, -1, -1, 1, 1, 2, 1 };
                CorrecthandL = new int[] { 0, 1, -1, -1, -1, 1, 1, 0, 1 };
                AllowShapetrack = true;
                learnmessage.text = "あいさつ" +
            "\nを意味する手話" +
            "（１）";
                if (IsRcorrect && IsLcorrect)
                {
                    Fase++;
                }
                break;
            case 2:
                Otehon.transform.GetChild(Fase).gameObject.SetActive(true);
                Otehon.transform.GetChild(Fase - 1).gameObject.SetActive(false);
                CorrecthandR = new int[] { 0, 0, -1, -1, -1, 1, 1, 2, 1 };
                CorrecthandL = new int[] { 0, 0, -1, -1, -1, 1, 1, 0, 1 };
                AllowShapetrack = true;
                learnmessage.text = "あいさつ" +
        "\nを意味する手話" +
        "（２）";
                if (IsRcorrect && IsLcorrect)
                {
                    //                    yield return new WaitForSeconds(2);
//                    yield return null;
                    Fase++;
                }
                break;
            case 3:
                for(int i = 0; i < Otehon.transform.childCount; i++)
                {
                    Otehon.transform.GetChild(i).gameObject.SetActive(false);
                }
                learnmessage.text = "以上で\n" +
                    "「こんにちは」\n" +
                    "を意味します" +
                    "\n\n終了するには右人差し指をピンチして下さい";
//                    yield return new WaitForSeconds(1);
                if (HandR.GetFingerIsPinching(OVRHand.HandFinger.Index))
                {
                    Otehon.transform.GetChild(Fase).GetChild(0).GetChild(1).GetChild(1).GetComponent<Renderer>().material.color = Color.blue;
                    Otehon.transform.GetChild(Fase).GetChild(0).GetChild(0).GetChild(1).GetComponent<Renderer>().material.color = Color.red;
                    Fase = 0;
                    Step = 0;
                }
                break;
        }
    }
    void Fingermatch()
    {
//        if (AllowShapetrack)
        {
            for (int i = 0; i < handchecker.HandinfoL.Length; i++)
            {
                    if (handchecker.HandinfoL[i] != CorrecthandL[i]) //L側
                    {
                        IsLcorrect = false;
                        
                    }
                    else
                    {
                        IsLcorrect = true;
                    }

            }
            for(int i = 0; i < handchecker.HandinfoR.Length; i++)
            {
                if (handchecker.HandinfoR[i] != CorrecthandR[i]) //R側
                {
                    IsRcorrect = false;
                }
                else
                {
                    IsRcorrect = true;
                }
            }
            //            AllowShapetrack = false;
        }
    }
}
