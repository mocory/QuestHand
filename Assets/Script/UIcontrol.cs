﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using DG.Tweening;

public class UIcontrol : MonoBehaviour
{
    public int UISelectedstep, UISelectedmode,State,Xpos,Ypos;//state　メニューの状態
    [SerializeField] ButtonController Lbutton, Rbutton, Cbutton,Backbutton;
    [SerializeField] Transform UIParent;
    [SerializeField] TextMesh numdebug;

    // Start is called before the first frame update
    void Start()
    {
        Buttoncheck();
    }

    // Update is called once per frame
    void Update()
    {
        numdebug.text = UISelectedmode.ToString();
    }

    void Buttoncheck()
    {
        Lbutton.ActionZoneEvent += args =>
        {
            if (args.InteractionT == InteractionType.Enter)
            {
                if (State == 0)
                {
                    if (UISelectedmode > 0)
                    {
                        UISelectedmode--;
                        MoveUIParent();
                    }
                }
                if (State == 1)
                {
                    if (UISelectedstep > 0)
                    {
                        UISelectedstep--;
                        MoveUIParent();
                    }
                }

            }
        };
        Rbutton.ActionZoneEvent += args =>
        {
            if (args.InteractionT == InteractionType.Enter)
            {
                if (State == 0)
                {
                    if (UISelectedmode < 1)
                    {
                        UISelectedmode++;
                        MoveUIParent();
                    }
                }
                if (State == 1)
                {
                    if (UISelectedstep < 1)
                    {
                        UISelectedstep++;
                        MoveUIParent();
                    }
                }
            }
        };
        Cbutton.ActionZoneEvent += args =>
        {
            if (args.InteractionT == InteractionType.Enter)
            {
                if (State == 0)
                {
                    if (UISelectedmode == 0)
                    {
                        State = 1;
                    }
                    else if (UISelectedmode == 1)
                    {
                        State = 2;
                    }
                    MoveUIParent();
                }
                else if (State == 1)
                {
                    State = 5;
                    MoveUIParent();
                    GetComponent<Handshape>().Step = UISelectedstep + 1;
                }
            }
        };
        Backbutton.ActionZoneEvent += args =>
        {
            if (args.InteractionT == InteractionType.Enter)
            {
                if (State == 1)//ここの値は逐次変更する
                {
                    State = 0;
                    MoveUIParent();
                }
            }
        };
    }

    void MoveUIParent()
    {
        if (State == 0)//モード選択
        {
//            UISelectedmode = Xpos;
            UIParent.transform.DOMoveX(UISelectedmode * -2.2f, 0.7f);
            UIParent.transform.DOMoveY(0 * -2.2f, 0.7f);
        }
        else if (State == 1)//学習モード
        {
 //           UISelectedstep = Xpos;
            UIParent.transform.DOMoveX(UISelectedstep * -2.2f, 0.7f);
            UIParent.transform.DOMoveY(2, 0.7f);
        }
        else if (State == 2)//テストモード
        {
            //           UISelectedstep = Xpos;
            UIParent.transform.DOMoveX(UISelectedstep * -2.2f, 0.7f);
            UIParent.transform.DOMoveY(4, 0.7f);
        }
        else if (State == 5)
        {
            UIParent.transform.DOMoveX(UISelectedstep * -2.2f, 0.7f);
            UIParent.transform.DOMoveY(10, 0.7f);
        }
    }
}
