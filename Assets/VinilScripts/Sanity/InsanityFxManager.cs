using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class InsanityFxManager : MonoBehaviour
{
    public Volume postProcessVolume;

    public float insanityPercentTrigger = 0.000001f;
    private ColorAdjustments _colorAdjustments;
    private Vignette _vignette;
    private DepthOfField _depthOfField;

    void Start()
    {
        if (!postProcessVolume) return;

        // Attempt to get URP volume components
        postProcessVolume.profile.TryGet(out _colorAdjustments);
        postProcessVolume.profile.TryGet(out _vignette);
        postProcessVolume.profile.TryGet(out _depthOfField);

        ApplyDefaultPostProcess();
    }

    public void OnInsanityUpdated(Component sender, object data)
    {
        float insanityPercent = (float)data;
        if (insanityPercent < insanityPercentTrigger || insanityPercent > 0.98f)
        {
            ApplyDefaultPostProcess();
        }
        else
        {
            SetPostProcessByInsanityPercent(insanityPercent);
        }
    }

    private void ApplyDefaultPostProcess()
    {
        if (_colorAdjustments != null)
        {
            _colorAdjustments.saturation.value = 0;
            _colorAdjustments.contrast.value = 0;
        }
        if (_vignette != null)
        {
            _vignette.active = false;
        }
        if (_depthOfField != null)
        {
            _depthOfField.active = false;
        }
    }

    private void SetPostProcessByInsanityPercent(float sanityPercent)
    {
        if (_colorAdjustments != null)
        {
            _colorAdjustments.saturation.value = (1 - sanityPercent) * -100f;
            _colorAdjustments.contrast.value = 0.5f - (sanityPercent * 0.5f);
        }
        if (_vignette != null)
        {
            _vignette.active = true;
            _vignette.intensity.value = (1 - sanityPercent) * 0.55f;
        }
        if (_depthOfField != null)
        {
            _depthOfField.active = true;
            _depthOfField.focusDistance.value = 10f * (1 - sanityPercent);
        }
    }
}
