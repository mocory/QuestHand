using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using DG.Tweening;

public class UIcontrol : MonoBehaviour
{
    public int UISelectedstep, UISelectedmode,State;//state　メニューの状態
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
        numdebug.text = UISelectedstep.ToString();
    }

    void Buttoncheck()
    {
        Lbutton.ActionZoneEvent += args =>
        {
            if (args.InteractionT == InteractionType.Enter)
            {
                if (UISelectedstep >= 0)
                {
                    UISelectedstep--;
                    MoveUIParent();
                }
            }
        };
        Rbutton.ActionZoneEvent += args =>
        {
            if (args.InteractionT == InteractionType.Enter)
            {
                if (UISelectedstep <= 1)
                {
                    UISelectedstep++;
                    MoveUIParent();
                }
            }
        };
        Cbutton.ActionZoneEvent += args =>
        {
            if (args.InteractionT == InteractionType.Enter)
            {
                State++;
            }
        };
    }

    void MoveUIParent()
    {
        UIParent.transform.DOMoveX(UISelectedstep * -2.2f,0.7f);
    }
}
