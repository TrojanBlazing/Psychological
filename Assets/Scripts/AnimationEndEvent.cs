
using UnityEngine;

public class AnimationEndEvent : MonoBehaviour 
{
    [SerializeField] WakingUpScript wakingUp;
    public void DestroyAnimator()
    {
        Animator animator = GetComponent<Animator>();
        
        Destroy(animator);
        wakingUp.PerformAfterWakingAction();
    }
}
