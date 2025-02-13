using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionReferenceExample : MonoBehaviour
{
    [SerializeField] InputActionReference exampleAction;

    public GameObject otherGameObject;

    private Collider Collider;
    AudioSource hello;
    void Start()
    {

        hello = GetComponent<AudioSource>();
        Collider = GetComponent<Collider>();
        Collider.enabled = false;
    }
    void OnEnable()
    {
        exampleAction.action.performed += ExampleFunction;
        exampleAction.action.canceled += ExampleFunctionStop;
        exampleAction.action.Enable();
    }

    void OnDisable()
    {
        exampleAction.action.performed -= ExampleFunction;
        float triggerValue = exampleAction.action.ReadValue<float>();
        exampleAction.action.Disable();
    }

    void ExampleFunction(InputAction.CallbackContext obj)
    {
        otherGameObject.SetActive(true);
        PlaySound();
        Collider.enabled = true;
    }
    void ExampleFunctionStop(InputAction.CallbackContext obj)
    {

        otherGameObject.SetActive(false);
        StopSound();
        Collider.enabled = false;

    }
    public void PlaySound()
    {
        hello.Play(0);

    }
    public void StopSound()
    {
        hello.Stop();

    }

}
