using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OculusSampleFramework;

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
    public bool IsLcorrect, IsRcorrect;
    [SerializeField] ButtonController _buttonController;
    UIcontrol _uIcontrol;
    public TextMesh fase;

    // Start is called before the first frame update
    void Start()
    {
        handchecker = GetComponent<Handchecker>();
        _uIcontrol = GetComponent<UIcontrol>();
        CorrecthandR = new int[] { 9, 9, 9, 9, 9, 9, 9, 9, 9 };
        CorrecthandL = new int[] { 9, 9, 9, 9, 9, 9, 9, 9, 9 };
    }

    // Update is called once per frame
    void Update()
    {
        Correctcolor();
        CorrectcolorR();
        Fingermatch();
        fase.text = Fase.ToString();
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

    public void Pressbutton()
    {
        Step = 1;
    }
    void Learnstart()
    {
        /*        if (HandL.GetFingerIsPinching(OVRHand.HandFinger.Index))
                {
                    Step = 1;
                }*/
        /*        else if (HandL.GetFingerIsPinching(OVRHand.HandFinger.Middle))
                {
                    Step = 2;
                }
                else if (HandL.GetFingerIsPinching(OVRHand.HandFinger.Ring))
                {
                    Step = 3;
                }*/
/*        _buttonController.ActionZoneEvent += args =>
        {
            if (args.InteractionT == InteractionType.Enter)
            {
                Pressbutton();
            }
        };*/

            learnmessage.text = "学習モード待機中" +
                "\n\n決定ボタンを押して下さい";
    }

    void Hello()
    {
        switch (Fase)
        {
            case 0:
                if (_uIcontrol.UISelectedmode == 0)
                {
                    Otehon.transform.GetChild(Fase).gameObject.SetActive(true);
                }
                CorrecthandR = new int[] { 0, 1, 1, -1, -1, 1, 1, 1, 1 };
                AllowShapetrack = true;
                learnmessage.text = "お昼" +
         "\nを意味する手話";
                if (IsRcorrect)
                {
                    Correctreset();
                    Fase++;
                }
                break;
            case 1:
                if (_uIcontrol.UISelectedmode == 0)
                {
                    Otehon.transform.GetChild(Fase).gameObject.SetActive(true);
                    Otehon.transform.GetChild(Fase - 1).gameObject.SetActive(false);
                }
                CorrecthandR = new int[] { 0, 1, -1, -1, -1, 1, 1, 2, 1 };
                CorrecthandL = new int[] { 0, 1, -1, -1, -1, 1, 1, 0, 1 };
                AllowShapetrack = true;
                learnmessage.text = "あいさつ" +
            "\nを意味する手話" +
            "（１）";
                if (IsRcorrect && IsLcorrect)
                {
                    Correctreset();
                    Fase++;
                }
                break;
            case 2:
                if (_uIcontrol.UISelectedmode == 0)
                {
                    Otehon.transform.GetChild(Fase).gameObject.SetActive(true);
                    Otehon.transform.GetChild(Fase - 1).gameObject.SetActive(false);
                }
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
                    Correctreset();
                    Fase++;
                }
                break;
            case 3:
                /*for(int i = 0; i < Otehon.transform.childCount; i++)
                {
                               //                       Otehon.transform.GetChild(i).gameObject.SetActive(false);
     }*/
                if (_uIcontrol.UISelectedmode == 0)
                {
                    Otehon.transform.GetChild(Fase - 1).gameObject.SetActive(false);
                    learnmessage.text = "以上で\n" +
                    "「こんにちは」\n" +
                    "を意味します" +
                    "\n\n終了するには決定ボタンを押して下さい";
                }
                if (_uIcontrol.UISelectedmode == 1)
                {
                    learnmessage.text = "正解です" +
                    "\n\n終了するには決定ボタンを押して下さい";
                }
                _uIcontrol.State = 6;
                _uIcontrol.MoveUIParent();
                //                    yield return new WaitForSeconds(1);
                /*                if (HandR.GetFingerIsPinching(OVRHand.HandFinger.Index))
                                {
                                    Otehon.transform.GetChild(Fase).GetChild(0).GetChild(1).GetChild(1).GetComponent<Renderer>().material.color = Color.blue;
                                    Otehon.transform.GetChild(Fase).GetChild(0).GetChild(0).GetChild(1).GetComponent<Renderer>().material.color = Color.red;
                                    Fase = 0;
                                    Step = 0;
                                }*/
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
                    break;
                }
                else
                {
                    IsLcorrect = true;//この辺がおかしい
                }
            }
            for (int i = 0; i < handchecker.HandinfoR.Length; i++)
            {
                if (handchecker.HandinfoR[i] != CorrecthandR[i]) //R側
                {
                    IsRcorrect = false;
                    break;
                }
                else
                {
                    IsRcorrect = true;//この辺がおかしい
                }
            }
            //            AllowShapetrack = false;
        }
    }
    public void Correctreset()
    {
        CorrecthandR = new int[] { 9,9,9,9,9,9,9,9,9 };
        CorrecthandL = new int[] { 9,9,9,9,9,9,9,9,9 };
        IsLcorrect = false;
        IsRcorrect = false;
    }
}
