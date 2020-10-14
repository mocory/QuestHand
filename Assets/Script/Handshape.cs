using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handshape : MonoBehaviour
{
    Handchecker handchecker;
    public int Step, Fase;
    public OVRHand HandL, HandR;
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
                Hello();
                break;
        }
    }

    void Learnstart()
    {
        if (HandR.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            Step = 1;
        }
        else if (HandR.GetFingerIsPinching(OVRHand.HandFinger.Middle))
        {
            Step = 2;
        }
        else if (HandR.GetFingerIsPinching(OVRHand.HandFinger.Ring))
        {
            Step = 3;
        }
    }

    void Hello()
    {
        switch (Fase)
        {
            case 0:
                if (Fingermatch(handchecker.HandinfoR,new int[] { 0, 1, 1, 0, 0 }))
                {
                    Fase++;
                }
                break;
            case 1:

                break;
        }
    }
    bool Fingermatch(int[] RealHand,int[] CorrectHand)
    {
        for(int i = 0; i < RealHand.Length; i++)
        {
            if (RealHand[i] != CorrectHand[i])
            {
                return false;
            }
        }
        return true;
    }
}
