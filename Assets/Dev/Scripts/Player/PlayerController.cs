using UnityEngine;

namespace Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        private static readonly int Speed = Animator.StringToHash("speed");
        
        [SerializeField] private Rigidbody rb;
        [SerializeField] private DynamicJoystick joystick;
        [SerializeField] private Animator animator;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float movementSpeed;

        private void FixedUpdate() => MoveCharacter();
        private void MoveCharacter()
        {
            var speed = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
            
            animator.SetFloat(Speed, speed.magnitude);

            rb.velocity = new Vector3(joystick.Horizontal * movementSpeed, rb.velocity.y,
                joystick.Vertical * movementSpeed);

            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                playerTransform.rotation = Quaternion.LookRotation(rb.velocity);
            }
        }
    }
}
