using UnityEngine;

public class WoodcutterScript : MonoBehaviour
{
    [SerializeField]
    private LayerMask treeLayerNumber;
    [SerializeField]
    private float timeBeforeDestroy;
    [SerializeField]
    private ToolSystem ToolSystem;

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip[] _chopTreeSounds;

    private bool isCuttingTree = false;
    private TreeHealth _treeHealth;
    private AudioSource _audioSource;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 1.3f);
        if (ToolSystem.IsAxeUse())
        {
            CheckIsTreeHere();
        }
        else
        {
            isCuttingTree = false;
        }
    }

    public void HitTheTree()
    {
        _treeHealth.TakeDamage(Random.Range(5, 10));
        _audioSource.PlayOneShot(_chopTreeSounds[Random.Range(0,_chopTreeSounds.Length)]);
    }

    public bool IsCuttingTree()
    {
        return isCuttingTree;
    }

    private void CheckIsTreeHere()
    {
        TreeHealth treeHealth;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.3f, treeLayerNumber))
        {
            if (hit.transform.TryGetComponent(out treeHealth))
            {
                _treeHealth = treeHealth;
                isCuttingTree = true;
            }
            else
            {
                _treeHealth = null;
                isCuttingTree = false;
            }
        }
        else
        {
            _treeHealth = null;
            isCuttingTree = false;
        }
    }
}

