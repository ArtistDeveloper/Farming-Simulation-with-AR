using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlacementGuide : MonoBehaviour
{
    [HideInInspector] public Vector3 SmoothedPosition;
    [HideInInspector] public Vector3 SmoothedNormal;
    [HideInInspector] public Vector3 TargetPosition;
    [HideInInspector] public Vector3 TargetNormal;


    [Tooltip("Displacement in local coordinates from placed position. Can be useful for placing the UI slightly above or below some objects.")]
    public Vector3 Displacement = Vector3.zero;

    [Tooltip("Size of placement UI image. If viewed in AR space, this is equal to the diameter in meters.")]
    public float Scale = 0.3f; //0.3
    
    [Tooltip("(Approximate) Duration of the placement UI image turning a full 360 degrees. Unit in seconds. If set to zero, the UI will not rotate.")]
    public float RotationDuration = 6f;

    [Tooltip("The amount of damping to apply to previous position and normal vector. Value close to zero will make the UI quick but jumpy; close to one it will be slower but stable")]
    [Range(0f, 1f)]
    public float DampingFactor = 0.85f; // damp previous smooths by this value
       
    [Tooltip("Color and Opacity of placement UI Image")]
    public Color ColorAndOpacity = new Color(1f, 1f, 1f, .2f);

    [Flags]
    public enum Appearance
    {
        None = 0,
        FadeIn = 1,
        SizeUp = 4,
    };
    [Flags]
    public enum Disappearance
    {
        None = 0,
        FadeOut = 2,
        SizeDown = 8
    };

    /// <summary>
    /// If None is selected in Unity Editor, AppearanceAnimation == AppearanceAnimationType.None
    /// If Everything is selected in Unity Editor, AppearanceAnimation == -1
    /// If One option is selected in Unity Editor, AppearanceAnimation == AppearanceAnimationType.FadeIn
    /// </summary>
    public Appearance AppearanceAnimation;
    public Disappearance DisappearanceAnimation;
    [Tooltip("Duration (in seconds) of appearance animation")]
    [Range(0f, 5f)]
    public float AppearanceDuration = .8f;

    [Tooltip("Duration (in seconds) of disappearance animation")]
    [Range(0f, 5f)]
    public float DisappearanceDuration = .2f;


    private new Renderer renderer;
    [HideInInspector] public bool IsActive;



    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
        {
            // update Smooths
            SmoothedNormal = (SmoothedNormal * DampingFactor) + (TargetNormal * (1 - DampingFactor));
            SmoothedPosition = (SmoothedPosition * DampingFactor) + (TargetPosition * (1 - DampingFactor));


            transform.position = SmoothedPosition + Displacement;
            transform.up = SmoothedNormal;
            if (RotationDuration > 0)
            {
                transform.Rotate(new Vector3(0, Time.frameCount * 6f / RotationDuration, 0));
            }
        }
    }

    private void OnValidate()
    {
        var mat = GetComponent<Renderer>().sharedMaterial;
        mat.SetColor("_Color", ColorAndOpacity);
        SetScale(Scale);
    }

    /// <summary>
    /// Places a guide UI object. This method can be called however frequently one wishes. 
    /// </summary>
    /// <param name="position">Position where the UI will be placed</param>
    /// <param name="normal">Normal vector or the up direction of the UI</param>
    public void ActivateAt(Vector3 position, Vector3 normal)
    {
        if (!IsActive)
        {
            renderer.enabled = true;
            IsActive = true;

            // don't smooth the first input
            SmoothedPosition = position;
            SmoothedNormal = normal;

            StopAllCoroutines();

            if (AppearanceAnimation.HasFlag(Appearance.FadeIn))
            {
                StartCoroutine(FadeInOut(true, AppearanceDuration));
            }
            else
            {
                SetAlpha(ColorAndOpacity.a); // default fallback if no animation for opacity
            }
            if (AppearanceAnimation.HasFlag(Appearance.SizeUp))
            {
                StartCoroutine(SizeUpDown(true, AppearanceDuration));
            }
            else
            {
                SetScale(Scale);
            }
        }
        TargetPosition = position;
        TargetNormal = normal;

    }

    /// <summary>
    /// Deactivates the guide UI until ActivateAt() is called again
    /// </summary>
    public void Deactivate()
    {
        if (IsActive)
        {
            // reset smooths
            IsActive = false;
            StopAllCoroutines();
            if (DisappearanceAnimation.Equals(Disappearance.None))
            {
                StartCoroutine(DisableRenderer(renderer, 0));
            }
            else
            {
                StartCoroutine(DisableRenderer(renderer, DisappearanceDuration));
            }
            if (DisappearanceAnimation.HasFlag(Disappearance.FadeOut))
            {
                StartCoroutine(FadeInOut(false, DisappearanceDuration));
            }
            if (DisappearanceAnimation.HasFlag(Disappearance.SizeDown))
            {
                StartCoroutine(SizeUpDown(false, DisappearanceDuration));
            }
        }
    }


    void SetAlpha(float alpha)
    {
        var mat = renderer.material;
        var c = ColorAndOpacity;
        mat.SetColor("_Color", new Color(c.r, c.g, c.b, alpha));
    }

    void SetScale(float scale)
    {
        transform.localScale = Vector3.one * scale / 10;
    }

    IEnumerator DisableRenderer(Renderer targetRenderer, float duration)
    {
        yield return new WaitForSeconds(duration);
        targetRenderer.enabled = false;
    }

    IEnumerator FadeInOut(bool fadeIn, float duration)
    {
        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0f;
            b = ColorAndOpacity.a;
        }
        else
        {
            a = ColorAndOpacity.a;
            b = 0f;
        }
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            SetAlpha(alpha);
            yield return null;
        }
    }

    IEnumerator SizeUpDown(bool sizeUp, float duration)
    {
        //Set Values depending on if sizeUp or sizeDown
        float a, b;
        if (sizeUp)
        {
            a = 0f;
            b = Scale;
        }
        else
        {
            a = Scale;
            b = 0f;
        }
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float scale = Mathf.Lerp(a, b, counter / duration);

            SetScale(scale);
            yield return null;
        }
    }
}
