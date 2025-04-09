using UnityEngine;

public class GroundSpawner : GenericSpawner<Ground>
{
    [SerializeField] private SpawnGroundTrigger _spawnerTrigger;
    [SerializeField] private GroundDespawner _groundDespawner;
    [SerializeField] private float _yStartPosition = -5;
    [SerializeField] private float _xStartPosition = 10;

    private readonly float _ySpawnPosition = -5;
    private readonly float _xSpawnPosition = 29.6f;

    private bool _isFirstObject = true;
    private Vector2 _startPosition;
    private Vector2 _spawnPosition;

    private void OnEnable()
    {
        _groundDespawner.TriggeredToPool += Release;
        _spawnerTrigger.Triggered += GetObject;
    }

    private void OnDisable()
    {
        _groundDespawner.TriggeredToPool -= Release;
        _spawnerTrigger.Triggered -= GetObject;
    }

    private void Start()
    {
        _startPosition = new Vector2(_xStartPosition, _yStartPosition);
        _spawnPosition = new Vector2(_xSpawnPosition, _ySpawnPosition);

        GetObject();
    }

    protected override void ActionOnGet(Ground ground)
    {
        if (_isFirstObject)
        {
            ground.transform.position = _startPosition;
            _isFirstObject = false;
        }
        else
            ground.transform.position = _spawnPosition;
        
        ground.LeftFromView += Release;
    }

    protected override void Release(Ground ground)
    {
        ground.LeftFromView -= Release;

        base.Release(ground);
    }
}