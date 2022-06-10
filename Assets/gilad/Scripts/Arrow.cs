using UnityEngine;

namespace gilad.Scripts
{
    public class Arrow : MonoBehaviour
    {
        // [SerializeField] private int timeOfDemo = 7;

        private bool enableInput = true;

        private static Arrow _instance;

        [SerializeField] private Transform forward;
    
        [SerializeField] private Transform backward;

        [SerializeField] private Animator explosionAnimator;
        
        [SerializeField] private Animator explosionAnimator2;

        private Animator _animator;

        private float _dir = 0f;
    
        [SerializeField] private float _turnSpeed = 50f;

        [SerializeField] private BallEitan ball;

        private static bool isActive = true;

        public static bool IsActive
        {
            get => isActive;
            set => isActive = value;
        }

        private void Awake()
        {
        
        }

        private void Start()
        {
            RotateItems.Cur = transform;
            RotateItems.Default = gameObject.transform;
            _animator = GetComponent<Animator>();
            _instance = this;
        }

        public static Vector3 GetDirection()
        {
            //Deactivate();
            return _instance.forward.position - _instance.backward.position;
        }

        private void HitAfterTime()
        {
            Time.timeScale = 2;
            Hit();
        }

        private void Update()
        {
            if (GameManager.Level == 12 && enableInput)
            {
                Invoke("HitAfterTime", 0.5f);
                enableInput = false;
            }

            if (! enableInput)
            {
                return;
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                if (!ball.moving)
                {
                    Time.timeScale = 2;
                    Hit();
                }
                else
                {
                    var find = GameObject.Find("ball");
                    if (!find) return;
                    var ballScript = find.gameObject.GetComponent<BallEitan>();
                    ballScript.ResetPlayer();
                }
            }
        
        }
        
        public static void Activate()
        {
            _instance.gameObject.SetActive(true);
        }

        private static void Deactivate()
        {
            _instance._dir = 0f;
            _instance.gameObject.SetActive(false);
        }
    
        public void Hit()
        {
            if(isActive)
            {
                GetComponent<Orah>().TurnOf();
                transform.Find("Lazer").gameObject.SetActive(false);
                ball.transform.SetParent(null);
                ball.GetComponent<CircleCollider2D>().isTrigger = false;
                if(_animator != null)_animator.SetTrigger("Lanch");
                if(explosionAnimator != null)explosionAnimator.SetTrigger("Smoke");
                Shake.ShakeMe();
                // if(explosionAnimator2 != null)explosionAnimator2.SetTrigger("Smoke");
                ball.Hit();
            }
        }
    }
}
