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
    // Start is called before the first frame update
    void Start()
    {
        handchecker = GetComponent<Handchecker>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (Step)
        {
            case 0:
                Learnstart();
                break;
            case 1:
                StartCoroutine(Hello());
                break;
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
            learnmessage.text = "学習モード待機中\n\n1:こんにちは";
        }
    }

    IEnumerator Hello()
    {
        switch (Fase)
        {
            case 0:
                CorrecthandR = new int[] { 0, 1, 1, 0, 0, 1, 1, 1, 1 };
                if (Fingermatch(handchecker.HandinfoR,false ))
                {
                    learnmessage.text = "お昼";
                    Fase++;
                }
                break;
            case 1:
                CorrecthandR = new int[] { 0, 1, 0, 0, 0, 1, 1, 2, 1 };
                CorrecthandL = new int[] { 0, 1, 0, 0, 0, 1, 1, 0, 1 };
                if (Fingermatch(handchecker.HandinfoR,false ) && Fingermatch(handchecker.HandinfoL,true ))
                {
                    learnmessage.text = "あいさつ（１）";
                    Fase++;
                }
                break;
            case 2:
                CorrecthandR = new int[] { 0, 0, 0, 0, 0, 1, 1, 2, 1 };
                CorrecthandL = new int[] { 0, 0, 0, 0, 0, 1, 1, 0, 1 };
                if (Fingermatch(handchecker.HandinfoR, false) && Fingermatch(handchecker.HandinfoL, true))
                {
                    learnmessage.text = "あいさつ（２）";
                    yield return new WaitForSeconds(2);
                    Fase++;
                }
                break;
            case 3:
                    learnmessage.text = "こんにちは";
                    yield return new WaitForSeconds(1);
                    Fase++;
                break;
        }
    }
    bool Fingermatch(int[] RealHand,bool IsL)
    {
        for(int i = 0; i < RealHand.Length; i++)
        {
            if (IsL)
            {
                if (RealHand[i] != CorrecthandL[i])
                {
                    //                learnmessage.text = "入力受付中 非マッチ";
                    return false;
                }
            }
            if (!IsL)
            {
                if (RealHand[i] != CorrecthandR[i])
                {
                    //                learnmessage.text = "入力受付中 非マッチ";
                    return false;
                }
            }
        }
        return true;
    }
}
