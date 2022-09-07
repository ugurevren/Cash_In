using System.Collections;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private playerStats _stats;
    private AudioHandler _audios;
    public GameObject lost;
    public GameObject won;
    
    
    public Vector3 targetPoint;

    public Joystick joystick;

    public ParticleSystem trail;
    public ParticleSystem cashFlow;

    // Start is called before the first frame update
    void Start()
    {
        _audios = GetComponent<AudioHandler>();
        cashFlow.Pause();
        _characterController = GetComponent<CharacterController>();
        _stats = GetComponent<playerStats>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        targetPoint.x = joystick.Horizontal*_stats.horizontalVelocity;
        targetPoint.z = _stats.forwardVelocity;
        if(_stats.forwardVelocity>0)
            _characterController.Move(targetPoint*Time.fixedDeltaTime*2);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            _audios.collect.Play();
           _stats.Collect(other.gameObject);
           return;
        }

        if (other.CompareTag("Door"))
        {
            other.GetComponent<doorScript>().UpdateCash(_audios);
            return;
        }

        if (other.CompareTag("Finish"))
        {
            Camera.main!.GetComponent<CameraFollow>().enabled = false;
            _stats.forwardVelocity = 0;
            _stats.horizontalVelocity = 0;
            
            Camera.main.transform.position = _stats.camNewPos.position;
            Camera.main.transform.rotation = _stats.camNewPos.rotation;

            transform.position = _stats.playerNewPos.position;
            transform.rotation = _stats.playerNewPos.rotation;
            
            trail.Stop();
            cashFlow.Play();
            _audios.cashFlow.Play();
            StartCoroutine(payDept());
        }
    }

    private IEnumerator payDept()
    {
        if (Collectibles.cash >= 0 && _stats.dept>0)
        {
            Collectibles.cash--;
            _stats.dept--;
            yield return new WaitForSeconds(0.05f);
            StartCoroutine(payDept());
        }
        else if (Collectibles.cash >= 0)
        {
            cashFlow.Stop();
            _audios.cashFlow.Stop();
            Win();
        }
        else
        {
            _audios.cashFlow.Stop();
            cashFlow.Stop();
            Lose();
        }
        
    }

    private void Win()
    {
        playerStats.chance = 0;
        _stats.dept = 0;
        _stats.horizontalVelocity = 3;
        _audios.success.Play();
        won.SetActive(true);
    }

    private void Lose()
    {
        playerStats.chance = 0;
        _stats.dept = 0;
        _stats.horizontalVelocity = 3;
        _audios.failed.Play();
        lost.SetActive(true);
    }
}
