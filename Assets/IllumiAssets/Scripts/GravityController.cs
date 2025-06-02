using UnityEngine;

public class GravityController : MonoBehaviour
{
    //�d�͉����x
    private const float Gravity = 9.8f;

    //�d�͂̓K�p�
    [SerializeField] private float _gravityScale = 1.0f;

    private InputSystem_Actions _inputActions;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        var direction = _inputActions.Player.Move.ReadValue<Vector2>();
        var vector = new Vector3(direction.x, 0, direction.y);
        if (_inputActions.Player.Jump.IsPressed())
            vector.y = 1.0f;
        else
            vector.y = -1.0f;
        Physics.gravity = Gravity * vector.normalized * _gravityScale;


    }
}
