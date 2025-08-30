using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Gameplay
{
    public class RunnerSwipeController : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float moveSpeed = 10f;
        public float maxStepPerSecond = 5f; // опционально — лимит скорости по локальной оси

        private Vector3 touchWorld;
        private bool isTouching = false;

        private MoveComponent moveComponent;
        private bool isDragging;

        private void Awake()
        {
            moveComponent = GetComponent<MoveComponent>();
        }

        private void FixedUpdate()
        {
            if (isTouching && isDragging)
            {
                // получаем локальную X точки касания (текущая локальная позиция персонажа = (0,0,0))
                Vector3 localTouch = transform.InverseTransformPoint(touchWorld);
                float deltaLocalX = localTouch.x;

                // сглаживание / ограничение шага
                float t = Mathf.Clamp01(moveSpeed * Time.fixedDeltaTime);
                float moveLocalX = Mathf.Lerp(0f, deltaLocalX, t);

                // можно дополнительно лимитировать скорость
                float maxStep = maxStepPerSecond * Time.fixedDeltaTime;
                moveLocalX = Mathf.Clamp(moveLocalX, -maxStep, maxStep);

                // переводим в мировой вектор вдоль локальной "вправо"
                Vector3 worldMove = transform.TransformDirection(new Vector3(moveLocalX, 0f, 0f));

                moveComponent.Move(worldMove);
            }
        }

        public void OnTouch(InputAction.CallbackContext context)
        {
            if (context.started || context.performed)
            {
                isTouching = true;
                Vector2 screenPos = context.ReadValue<Vector2>();

                // Проекция луча камеры на плоскость y = transform.position.y — корректно для перспективной камеры
                Ray ray = Camera.main.ScreenPointToRay(screenPos);
                Plane plane = new Plane(Vector3.up, transform.position);
                if (plane.Raycast(ray, out float enter))
                {
                    touchWorld = ray.GetPoint(enter);
                }
            }
            else if (context.canceled)
            {
                isTouching = false;
            }
        }

        public void OnMouseClick(InputAction.CallbackContext context)
        {
            if (context.started || context.performed)
                isDragging = true;
            else if (context.canceled)
                isDragging = false;
        }
    }
}
