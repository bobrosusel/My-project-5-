using UnityEngine;

public class PlayerAnimator
{
    private Animator _animator;
    public PlayerAnimator(Animator animator)
    {
        _animator = animator;
    }

    public void SetMovement(bool isWalk)
    {
        _animator.SetBool("Walk", isWalk);
    }

    public void SetShot()
    {
        _animator.SetTrigger("IsShooting");
    }

    public void SetDeath()
    {
        _animator.SetTrigger("Death");
    }
}
