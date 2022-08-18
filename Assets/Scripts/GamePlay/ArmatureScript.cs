using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmatureScript : MonoBehaviour
{
    private Animation animation;
    private bool _isArmatureAnimationAllowed = false;
    private bool _isArmatureRotationAllowed = true;
    private float _currentTime = 0;
    private float _currentRotationTime = 0;

    Quaternion leftRotation;
    Quaternion rightRotation;

    [SerializeField] private float baseQuaternionY;
    [SerializeField] private float targetQuaternionY;
    [SerializeField] private string animationName;

    void Start()
    {
        animation = GetComponent<Animation>();
        leftRotation = Quaternion.Euler(0, baseQuaternionY, 0);
        rightRotation = Quaternion.Euler(0, targetQuaternionY, 0);
    }

    void Update()
    {
        if (_isArmatureAnimationAllowed)
        {
            animation.Play(animationName);
            AnimationClip animationClip = animation.clip;

            float maxTime = animationClip.length * 2;
            _currentTime += Time.deltaTime;
            if (_currentTime >= maxTime)
            {
                animation.Stop(animationName);
                _currentTime = 0;
                _isArmatureRotationAllowed = true;
            }           
        }
        else
        {
            animation.Stop(animationName);
        }

        if (_isArmatureRotationAllowed)
        {
            _isArmatureAnimationAllowed = false;
            _currentRotationTime += Time.deltaTime;

            transform.rotation = Quaternion.Lerp(rightRotation, leftRotation, 0.5f * _currentRotationTime);

            if(_currentRotationTime >= 2.0f)
            {
                _currentRotationTime = 0;
                _isArmatureAnimationAllowed = true;
                _isArmatureRotationAllowed = false;
                
                Quaternion tmp = rightRotation;
                rightRotation = leftRotation;
                leftRotation = tmp;
            }            
        }
    }
}
