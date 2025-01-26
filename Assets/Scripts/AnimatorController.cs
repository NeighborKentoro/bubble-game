using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]Animator fishAnimator;

    private int blowHash;
    private int isGroundedHash;
    private int floatDir;

    void Awake(){
        blowHash = Animator.StringToHash("blow");
        isGroundedHash = Animator.StringToHash("isGrounded");
        floatDir = Animator.StringToHash("flowDir");
    }

    public void AnimIsGrounded(bool grounded){
        fishAnimator.SetBool(isGroundedHash, grounded);
    }

    public void AnimBlow(){
        fishAnimator.SetTrigger(blowHash);
    }

    public void AnimFloatdDirection(float dir){
        fishAnimator.SetFloat(floatDir, dir);
    }


}
