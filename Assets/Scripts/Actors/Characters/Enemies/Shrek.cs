
using UnityEngine;
using UnityEngine.AI;

using UnityEngine.UI;
public class Shrek : Actor
{
    private NavMeshAgent _shrek;
    public Transform Target;
    private MovementController _movementController;
    [SerializeField] private Image _screamerImage;
    private bool doorDestroyed = false;
    private Animator _animator;
    private bool collided = false;
    private IDamageable _damageable = null;
    private void Start()
    {
        _screamerImage.enabled = false;
        _screamerImage.GetComponent<AudioSource>().enabled = false;
        _shrek = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        EventManager.instance.OnChase += OnChase;
        EventManager.instance.ActionDonkeyKilled += OnDonkeyKilled;
    }

    void Update()
    {
        if (Target != null && doorDestroyed)
        {
            _shrek.SetDestination(Target.position);
            _animator.SetBool("isMoving", _shrek.velocity.magnitude > 0.1f);
        }
    }
    void OnDonkeyKilled(int currentKills)
    {
        _shrek.speed += 0.6f;
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        //if collided with character give character damage
        if (collision.gameObject.layer == 6 && !collided)
        {
            collided = true;
            _screamerImage.enabled = true;
            _screamerImage.GetComponent<AudioSource>().enabled = true;
            _screamerImage.GetComponent<AudioSource>().Play();
            var damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                _damageable = damageable;
                Invoke("ApplyDamage", 1f);
            }
            
        }
    }

    private void ApplyDamage()
    {
        EventQueueManager.instance.AddEvent(new CmdApplyDamage(_damageable, 10000));
    }
    
    private void OnChase(bool isBroken)
    {
        doorDestroyed = isBroken;
        _animator.SetTrigger("release");
        _animator.SetBool("isMoving", true);
    }
}
