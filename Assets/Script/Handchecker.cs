using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handchecker : MonoBehaviour
{
    public Transform HandR, HandL,Head;
    public OVRSkeleton _skeletonR,_skeletonL; //右手、もしくは左手の Bone情報
    public Text textR,textL;
    public int HandrotateR, HandrotateL;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var isIndexStraight = IsStraight(true,0.8f, OVRSkeleton.BoneId.Hand_Index1, OVRSkeleton.BoneId.Hand_Index2, OVRSkeleton.BoneId.Hand_Index3, OVRSkeleton.BoneId.Hand_IndexTip);
        var isMiddleStraight = IsStraight(true, 0.8f, OVRSkeleton.BoneId.Hand_Middle1, OVRSkeleton.BoneId.Hand_Middle2, OVRSkeleton.BoneId.Hand_Middle3, OVRSkeleton.BoneId.Hand_MiddleTip);
        var isRingStraight = IsStraight(true, 0.8f, OVRSkeleton.BoneId.Hand_Ring1, OVRSkeleton.BoneId.Hand_Ring2, OVRSkeleton.BoneId.Hand_Ring3, OVRSkeleton.BoneId.Hand_RingTip);
        var isPinkyStraight = IsStraight(true, 0.8f, OVRSkeleton.BoneId.Hand_Pinky0, OVRSkeleton.BoneId.Hand_Pinky1, OVRSkeleton.BoneId.Hand_Pinky2, OVRSkeleton.BoneId.Hand_Pinky3, OVRSkeleton.BoneId.Hand_PinkyTip);
        var isThumbStraight = IsStraight(true, 0.8f, OVRSkeleton.BoneId.Hand_Thumb1, OVRSkeleton.BoneId.Hand_Thumb2, OVRSkeleton.BoneId.Hand_Thumb3, OVRSkeleton.BoneId.Hand_ThumbTip);

        var isIndexStraightL = IsStraight(false, 0.8f, OVRSkeleton.BoneId.Hand_Index1, OVRSkeleton.BoneId.Hand_Index2, OVRSkeleton.BoneId.Hand_Index3, OVRSkeleton.BoneId.Hand_IndexTip);
        var isMiddleStraightL = IsStraight(false, 0.8f, OVRSkeleton.BoneId.Hand_Middle1, OVRSkeleton.BoneId.Hand_Middle2, OVRSkeleton.BoneId.Hand_Middle3, OVRSkeleton.BoneId.Hand_MiddleTip);
        var isRingStraightL = IsStraight(false, 0.8f, OVRSkeleton.BoneId.Hand_Ring1, OVRSkeleton.BoneId.Hand_Ring2, OVRSkeleton.BoneId.Hand_Ring3, OVRSkeleton.BoneId.Hand_RingTip);
        var isPinkyStraightL = IsStraight(false, 0.8f, OVRSkeleton.BoneId.Hand_Pinky0, OVRSkeleton.BoneId.Hand_Pinky1, OVRSkeleton.BoneId.Hand_Pinky2, OVRSkeleton.BoneId.Hand_Pinky3, OVRSkeleton.BoneId.Hand_PinkyTip);
        var isThumbStraightL = IsStraight(false, 0.8f, OVRSkeleton.BoneId.Hand_Thumb1, OVRSkeleton.BoneId.Hand_Thumb2, OVRSkeleton.BoneId.Hand_Thumb3, OVRSkeleton.BoneId.Hand_ThumbTip);

        Debug.Log("Index is " + isIndexStraight);
        Debug.Log("Middle is " + isIndexStraight);
        Debug.Log("Ring is " + isIndexStraight);
        Debug.Log("Pinky is " + isIndexStraight);
        Debug.Log("Thumb is " + isThumbStraight);



        textR.text = "親指は" + IsFingerstraight(isThumbStraight) + "\n人差し指は" + IsFingerstraight(isIndexStraight) + "\n中指は" + IsFingerstraight(isMiddleStraight) + "\n薬指は" + IsFingerstraight(isRingStraight) + "\n小指は" + IsFingerstraight(isPinkyStraight) + "\n" + Handrot(HandR, true) + "\n" + Head2handposV(HandR) + Head2handposH(HandR);
        textL.text = "親指は" + IsFingerstraight(isThumbStraightL) + "\n人差し指は " + IsFingerstraight(isIndexStraightL) + "\n中指は" + IsFingerstraight(isMiddleStraightL) + "\n薬指は" + IsFingerstraight(isRingStraightL) + "\n小指は" + IsFingerstraight(isPinkyStraightL) + "\n" + Handrot(HandL, false) + "\n" + Head2handposV(HandL) + Head2handposH(HandL);
    }

    string IsFingerstraight(bool fingerstraight)
    {
        if (fingerstraight)
        {
            return "伸びている";
        }
        else
        {
            return "曲げている";
        }
    }

    string Handrot(Transform Hand,bool IsR)
    {
        if (IsR)
        {
            if (Hand.localEulerAngles.y <= 135 && Hand.localEulerAngles.y >= 45)
            {
                return "正面";
            }
            else if ((Hand.localEulerAngles.y < 45 && Hand.localEulerAngles.y >= 0) || (Hand.localEulerAngles.y <= 360 && Hand.localEulerAngles.y >= 315))
            {
                return "側面";
            }
            else if (Hand.localEulerAngles.y < 315 && Hand.localEulerAngles.y >= 225)
            {
                return "背面";
            }
            return "エラー";
        }
        else
        {
            if (Hand.localEulerAngles.y <= 135 && Hand.localEulerAngles.y >= 45)
            {
                return "正面";
            }
            else if (Hand.localEulerAngles.y <= 225 && Hand.localEulerAngles.y > 135)
            {
                return "側面";
            }
            else if (Hand.localEulerAngles.y <= 315 && Hand.localEulerAngles.y > 225)
            {
                return "背面";
            }
            return "エラー";
        }
    }

    string Head2handposV(Transform Hand)
    {
        if ((Hand.localPosition.y - Head.localPosition.y) <= -0.3f)
        {
            return "胸の";
        }
        else if ((Hand.localPosition.y - Head.localPosition.y) > -0.3f)
        {
            return "顔の";
        }
        return "エラー";
    }
    string Head2handposH (Transform Hand)
    {
        if ((Hand.localPosition.x - Head.localPosition.x) >= 0.15f)
        {
            return "右側";
        }
        else if ((Hand.localPosition.x - Head.localPosition.x) < 0.15f && (Hand.localPosition.x - Head.localPosition.x) > -0.15f)
        {
            return "前";
        }
        else if ((Hand.localPosition.x - Head.localPosition.x) <= -0.15f)
        {
            return "左側";
        }
        return "エラー";
    }
    private bool IsStraight(bool isR,float threshold, params OVRSkeleton.BoneId[] boneids)
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
