using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover), typeof(BirdCollisionHandler), typeof(ScoreCounter))]
public class Bird : MonoBehaviour, IDestroyable
{
    private BirdMover _birdMover;
    private ScoreCounter _scoreCounter;
    private BirdCollisionHandler _birdCollisionHandler;

    public event Action GameOver;

    private void Awake()
    {
        _birdMover = GetComponent<BirdMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _birdCollisionHandler = GetComponent<BirdCollisionHandler>();
    }

    private void OnEnable()
    {
        _birdCollisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _birdCollisionHandler.CollisionDetected -= ProcessCollision;
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _birdMover.Reset();
    }

    public void Destroy()
    {
        GameOver?.Invoke();
    }

    private void ProcessCollision(IInteracteble interacteble)
    {
        if (interacteble is Enemy || interacteble is Earth)
        {
            GameOver?.Invoke();
        }
    }
}