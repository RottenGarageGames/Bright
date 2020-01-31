using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    #if UNITY_EDITOR
    [MenuItem("GameObject/UI/Linear Progress Bar")]
    public static void AddLinearProgressBar()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/Linear Progress Bar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }
    [MenuItem("GameObject/UI/Radial Progress Bar")]
    public static void AddRadialProgressBar()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/Radial Progress Bar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }
    #endif
    // Start is called before the first frame update
    public int Minimum;
    public int Maximum;
    public int Current;
    public Image mask;
    public Image Fill;
    public Color BarColor;


    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }
    void GetCurrentFill()
    {
        float currentOffset = Current - Minimum;
        float maximumOffset = Maximum - Minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;
        Fill.color = BarColor;
    }
    public void SetCurrentFill(int fillAmount)
    {
        Current = fillAmount;
    }
}
