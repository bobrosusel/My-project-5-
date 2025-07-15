using UnityEngine;

public class PlayerAnimator
{
    private Animator _animator;
    public PlayerAnimator(Animator animator)
    {
        _animator = animator;
    }

    public void SetMovement(Vector2 move)
    {
        if (move == Vector2.zero)
            _animator.SetBool("Walk", false);
        else
            _animator.SetBool("Walk", true);
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
