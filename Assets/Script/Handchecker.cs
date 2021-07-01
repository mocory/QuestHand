using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handchecker : MonoBehaviour
{
    public Transform HandR, HandL,Head;
    public OVRSkeleton _skeletonR,_skeletonL; //右手、もしくは左手の Bone情報
    public Text textR,textL;
    public int isIndexStraight, isMiddleStraight, isRingStraight, isPinkyStraight, isThumbStraight, isIndexStraightL, isMiddleStraightL, isRingStraightL, isPinkyStraightL, isThumbStraightL;
    public int[] FingerR, FingerL;
    public int HandrotateR, HandrotateL, HandposVR, HandposVL, HandposHR, HandposHL;
    public int[] HandinfoL, HandinfoR;

    // Start is called before the first frame update
    void Start()
    {
//        textL.text = "textL";
//        textR.text = "textR";
    }

    // Update is called once per frame
    void Update()
    {
        isThumbStraight = IsStraight(true, 0.8f, OVRSkeleton.BoneId.Hand_Thumb1, OVRSkeleton.BoneId.Hand_Thumb2, OVRSkeleton.BoneId.Hand_Thumb3, OVRSkeleton.BoneId.Hand_ThumbTip);
        isIndexStraight = IsStraight(true,0.8f, OVRSkeleton.BoneId.Hand_Index1, OVRSkeleton.BoneId.Hand_Index2, OVRSkeleton.BoneId.Hand_Index3, OVRSkeleton.BoneId.Hand_IndexTip);
        isMiddleStraight = IsStraight(true, 0.8f, OVRSkeleton.BoneId.Hand_Middle1, OVRSkeleton.BoneId.Hand_Middle2, OVRSkeleton.BoneId.Hand_Middle3, OVRSkeleton.BoneId.Hand_MiddleTip);
        isRingStraight = IsStraight(true, 0.8f, OVRSkeleton.BoneId.Hand_Ring1, OVRSkeleton.BoneId.Hand_Ring2, OVRSkeleton.BoneId.Hand_Ring3, OVRSkeleton.BoneId.Hand_RingTip);
        isPinkyStraight = IsStraight(true, 0.8f, OVRSkeleton.BoneId.Hand_Pinky0, OVRSkeleton.BoneId.Hand_Pinky1, OVRSkeleton.BoneId.Hand_Pinky2, OVRSkeleton.BoneId.Hand_Pinky3, OVRSkeleton.BoneId.Hand_PinkyTip);
        FingerR= new int[] { isThumbStraight,isIndexStraight,isMiddleStraight,isRingStraight,isPinkyStraight };

        isThumbStraightL = IsStraight(false, 0.8f, OVRSkeleton.BoneId.Hand_Thumb1, OVRSkeleton.BoneId.Hand_Thumb2, OVRSkeleton.BoneId.Hand_Thumb3, OVRSkeleton.BoneId.Hand_ThumbTip);
        isIndexStraightL = IsStraight(false, 0.8f, OVRSkeleton.BoneId.Hand_Index1, OVRSkeleton.BoneId.Hand_Index2, OVRSkeleton.BoneId.Hand_Index3, OVRSkeleton.BoneId.Hand_IndexTip);
        isMiddleStraightL = IsStraight(false, 0.8f, OVRSkeleton.BoneId.Hand_Middle1, OVRSkeleton.BoneId.Hand_Middle2, OVRSkeleton.BoneId.Hand_Middle3, OVRSkeleton.BoneId.Hand_MiddleTip);
        isRingStraightL = IsStraight(false, 0.8f, OVRSkeleton.BoneId.Hand_Ring1, OVRSkeleton.BoneId.Hand_Ring2, OVRSkeleton.BoneId.Hand_Ring3, OVRSkeleton.BoneId.Hand_RingTip);
        isPinkyStraightL = IsStraight(false, 0.8f, OVRSkeleton.BoneId.Hand_Pinky0, OVRSkeleton.BoneId.Hand_Pinky1, OVRSkeleton.BoneId.Hand_Pinky2, OVRSkeleton.BoneId.Hand_Pinky3, OVRSkeleton.BoneId.Hand_PinkyTip);
        FingerL = new int[] { isThumbStraightL, isIndexStraightL, isMiddleStraightL, isRingStraightL, isPinkyStraightL };

        textR.text = "親指は" + IsFingerstraight(isThumbStraight) + "\n人差し指は" + IsFingerstraight(isIndexStraight) + "\n中指は" + IsFingerstraight(isMiddleStraight) + "\n薬指は" + IsFingerstraight(isRingStraight) + "\n小指は" + IsFingerstraight(isPinkyStraight) + "\n" + Handrot(HandR, true) + "\n" + Head2handposV(HandR, true) + Head2handposH(HandR, true) + "\n" + Handroll(HandR, true) + "\n" + HandinfoR[0].ToString() + HandinfoR[1].ToString() + HandinfoR[2].ToString() + HandinfoR[3].ToString() + HandinfoR[4].ToString() + HandinfoR[5].ToString() + HandinfoR[6].ToString() + HandinfoR[7].ToString() + HandinfoR[8].ToString();
        textL.text = "親指は" + IsFingerstraight(isThumbStraightL) + "\n人差し指は " + IsFingerstraight(isIndexStraightL) + "\n中指は" + IsFingerstraight(isMiddleStraightL) + "\n薬指は" + IsFingerstraight(isRingStraightL) + "\n小指は" + IsFingerstraight(isPinkyStraightL) + "\n" + Handrot(HandL, false) + "\n" + Head2handposV(HandL,false) + Head2handposH(HandL,false) + "\n" + Handroll(HandL, false) + "\n" + HandinfoL[0].ToString() + HandinfoL[1].ToString() + HandinfoL[2].ToString() + HandinfoL[3].ToString() + HandinfoL[4].ToString() + HandinfoL[5].ToString() + HandinfoL[6].ToString() + HandinfoL[7].ToString() + HandinfoL[8].ToString();

        Handstatecheker();
/*        for(int i=0;i< HandinfoR.Length; i++)
        {
 //           textR.text += "\n";
            textR.text += HandinfoR[i].ToString();
        }
        for (int i = 0; i < HandinfoL.Length; i++)
        {
 //           textL.text += "\n";
            textL.text += HandinfoL[i].ToString();
        }*/
    }

    void Handstatecheker()
    {
        Fingerchecker();
    }

    string IsFingerstraight(int fingerstraight)
    {
        if (fingerstraight==1)
        {
            return "伸びている";
        }
        else if (fingerstraight == -1)
        {
            return "折り畳んでいる";
        }
        else
        {
            return "曲げている";
        }

    }

    void Fingerchecker()
    {
        //左手
        HandinfoL[0] = isThumbStraightL;
        HandinfoL[1] = isIndexStraightL;
        HandinfoL[2] = isMiddleStraightL;
        HandinfoL[3] = isRingStraightL;
        HandinfoL[4] = isPinkyStraightL;
        //右手
        HandinfoR[0] = isThumbStraight;
        HandinfoR[1] = isIndexStraight;
        HandinfoR[2] = isMiddleStraight;
        HandinfoR[3] = isRingStraight;
        HandinfoR[4] = isPinkyStraight;
    }

    string Handrot(Transform Hand,bool IsR)
    {
        if (IsR)
        {
            if (Hand.localEulerAngles.y <= 135 && Hand.localEulerAngles.y >= 45)
            {
                HandrotateR = 0;
                HandinfoR[5] = 0;
                return "正面";
            }
            else if ((Hand.localEulerAngles.y < 45 && Hand.localEulerAngles.y >= 0) || (Hand.localEulerAngles.y <= 360 && Hand.localEulerAngles.y >= 315))
            {
                HandrotateR = 1;
                HandinfoR[5] = 1;
                return "内向き";
            }
            else if (Hand.localEulerAngles.y < 315 && Hand.localEulerAngles.y >= 225)
            {
                HandrotateR = 2;
                HandinfoR[5] = 2;
                return "背面";
            }
            else
            {
                HandrotateR = 3;
                HandinfoR[5] = 3;
                return "外向き";
            }
        }
        else
        {
            if (Hand.localEulerAngles.y <= 135 && Hand.localEulerAngles.y >= 45)
            {
                HandrotateL = 0;
                HandinfoL[5] = 0;
                return "正面";
            }
            else if (Hand.localEulerAngles.y <= 225 && Hand.localEulerAngles.y > 135)
            {
                HandrotateL = 1;
                HandinfoL[5] = 1;
                return "内向き";
            }
            else if (Hand.localEulerAngles.y <= 315 && Hand.localEulerAngles.y > 225)
            {
                HandrotateL = 2;
                HandinfoL[5] = 2;
                return "背面";
            }
            else
            {
                HandrotateL = 3;
                HandinfoL[5] = 3;
                return "外向き";
            }
        }
    }

    string Handroll(Transform Hand, bool IsR)
    {
        if (IsR)//右手
        {
            if (Hand.localEulerAngles.x <= 135 && Hand.localEulerAngles.x >= 30)//左傾斜
            {
                HandinfoR[8] = 2;
                return "右傾斜";
            }
            else if (Hand.localEulerAngles.x <= 225&&Hand.localEulerAngles.x >= 135)//中央
            {
                HandinfoR[8] = 3;
                return "エラー";
            }
            else if(Hand.localEulerAngles.x <= 330 && Hand.localEulerAngles.x >= 225)//右傾斜
            {
                HandinfoR[8] = 0;
                return "左傾斜";
            }
            else
            {
                HandinfoR[8] = 1;
                return "傾斜なし";
            }
        }
        else//左手
        {
            if (Hand.localEulerAngles.x <= 135 && Hand.localEulerAngles.x >= 30)//左傾斜
            {
                HandinfoL[8] = 2;
                return "右傾斜";
            }
            else if (Hand.localEulerAngles.x <= 225 && Hand.localEulerAngles.x >= 135)//中央
            {
                HandinfoL[8] = 3;
                return "エラー";
            }
            else if (Hand.localEulerAngles.x <= 330 && Hand.localEulerAngles.x >= 225)//右傾斜
            {
                HandinfoL[8] = 0;
                return "左傾斜";
            }
            else
            {
                HandinfoL[8] = 1;
                return "傾斜なし";
            }
        }
    }

    string Head2handposV(Transform Hand,bool IsR)
    {
        if (IsR)
        {
            if ((Hand.localPosition.y - Head.localPosition.y) <= -0.3f)
            {
                HandposVR = 0;
                HandinfoR[6] = 0;
                return "胸の";
            }
            else if ((Hand.localPosition.y - Head.localPosition.y) > -0.3f)
            {
                HandposVR = 1;
                HandinfoR[6] = 1;
                return "顔の";
            }
            else
            {
                HandinfoR[6] = 2;
                return "エラー";
            }
        }
        else
        {
            if ((Hand.localPosition.y - Head.localPosition.y) <= -0.3f)
            {
                HandposVL = 0;
                HandinfoL[6] = 0;
                return "胸の";
            }
            else if ((Hand.localPosition.y - Head.localPosition.y) > -0.3f)
            {
                HandposVL = 1;
                HandinfoL[6] = 1;
                return "顔の";
            }
            else
            {
                HandinfoL[6] = 2;
                return "エラー";
            }
        }

    }
    string Head2handposH (Transform Hand, bool IsR)
    {
        if (IsR)
        {
            if ((Hand.localPosition.x - Head.localPosition.x) >= 0.15f)
            {
                HandposHR = 2;
                HandinfoR[7] = 2;
                return "右側";
            }
            else if ((Hand.localPosition.x - Head.localPosition.x) < 0.15f && (Hand.localPosition.x - Head.localPosition.x) > -0.15f)
            {
                HandposHR = 1;
                HandinfoR[7] = 1;
                return "前";
            }
            else if ((Hand.localPosition.x - Head.localPosition.x) <= -0.15f)
            {
                HandposHR = 0;
                HandinfoR[7] = 0;
                return "左側";
            }
            else
            {
                HandinfoR[7] = 3;
                return "エラー";
            }
        }
        else
        {
            if ((Hand.localPosition.x - Head.localPosition.x) >= 0.15f)
            {
                HandposHL = 2;
                HandinfoL[7] = 2;
                return "右側";
            }
            else if ((Hand.localPosition.x - Head.localPosition.x) < 0.15f && (Hand.localPosition.x - Head.localPosition.x) > -0.15f)
            {
                HandposHL = 1;
                HandinfoL[7] = 1;
                return "前";
            }
            else if ((Hand.localPosition.x - Head.localPosition.x) <= -0.15f)
            {
                HandposHL = 0;
                HandinfoL[7] = 0;
                return "左側";
            }
            else
            {
                HandinfoL[7] = 3;
                return "エラー";
            }
        }
    }
    private int IsStraight(bool isR, float threshold, params OVRSkeleton.BoneId[] boneids)
    {
        if (isR)
        {
//            if (boneids.Length < 3) return 1;   //調べようがない
            var dot = 1.0f;
                var v1 = (_skeletonR.Bones[(int)boneids[1]].Transform.position - _skeletonR.Bones[(int)boneids[0]].Transform.position).normalized;
                var v2 = (_skeletonR.Bones[(int)boneids[3]].Transform.position - _skeletonR.Bones[(int)boneids[2]].Transform.position).normalized;

                dot = Vector3.Dot(v2, v1); //内積の値
            if (dot > 0.4f)
            {
                return 1;
            }
            else if (dot <= 0.4f && dot >= -0.4f)
            {
                return 0;
            }
            else
            {
                return -1;
            }
//            return dot >= threshold; //指定したBoneIDの内積の総乗が閾値を超えていたら直線とみなす
        }
        else
        {
//            if (boneids.Length < 3) return 1;   //調べようがない
            var dot = 1.0f;
                var v1 = (_skeletonL.Bones[(int)boneids[1]].Transform.position - _skeletonL.Bones[(int)boneids[0]].Transform.position).normalized;
                var v2 = (_skeletonL.Bones[(int)boneids[3]].Transform.position - _skeletonL.Bones[(int)boneids[2]].Transform.position).normalized;
          
            dot = Vector3.Dot(v2, v1); //内積の値
            if (dot > 0.4f)
            {
                return 1;
            }
            else if (dot <= 0.4f && dot >= -0.4f)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }

    private bool IsStraightold(bool isR,float threshold, params OVRSkeleton.BoneId[] boneids)
    {
        if (isR)
        {
            if (boneids.Length < 3) return false;   //調べようがない
            Vector3? oldVec = null;
            var dot = 1.0f;
            for (var index = 0; index < boneids.Length - 1; index++)
            {
                var v = (_skeletonR.Bones[(int)boneids[index + 1]].Transform.position - _skeletonR.Bones[(int)boneids[index]].Transform.position).normalized;
                if (oldVec.HasValue)
                {
                    dot *= Vector3.Dot(v, oldVec.Value); //内積の値を総乗していく
                }
                oldVec = v;//ひとつ前の指ベクトル
            }
            return dot >= threshold; //指定したBoneIDの内積の総乗が閾値を超えていたら直線とみなす
        }
        else
        {
            if (boneids.Length < 3) return false;   //調べようがない
            Vector3? oldVec = null;
            var dot = 1.0f;
            for (var index = 0; index < boneids.Length - 1; index++)
            {
                var v = (_skeletonL.Bones[(int)boneids[index + 1]].Transform.position - _skeletonL.Bones[(int)boneids[index]].Transform.position).normalized;
                if (oldVec.HasValue)
                {
                    dot *= Vector3.Dot(v, oldVec.Value); //内積の値を総乗していく
                }
                oldVec = v;//ひとつ前の指ベクトル
            }
            return dot >= threshold; //指定したBoneIDの内積の総乗が閾値を超えていたら直線とみなす
        }
    }
}
