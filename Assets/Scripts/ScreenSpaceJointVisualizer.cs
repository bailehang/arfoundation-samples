using System;
using System.Text;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class XRHumanBodyPose2DJoint
{

}

public class ScreenSpaceJointVisualizer : MonoBehaviour
{
    // 2D joint skeleton
    enum JointIndices
    {
        Invalid = -1,
        Head = 0, // parent: Neck1 [1]
        Neck1 = 1, // parent: Root [16]
        RightShoulder1 = 2, // parent: Neck1 [1]
        RightForearm = 3, // parent: RightShoulder1 [2]
        RightHand = 4, // parent: RightForearm [3]
        LeftShoulder1 = 5, // parent: Neck1 [1]
        LeftForearm = 6, // parent: LeftShoulder1 [5]
        LeftHand = 7, // parent: LeftForearm [6]
        RightUpLeg = 8, // parent: Root [16]
        RightLeg = 9, // parent: RightUpLeg [8]
        RightFoot = 10, // parent: RightLeg [9]
        LeftUpLeg = 11, // parent: Root [16]
        LeftLeg = 12, // parent: LeftUpLeg [11]
        LeftFoot = 13, // parent: LeftLeg [12]
        RightEye = 14, // parent: Head [0]
        LeftEye = 15, // parent: Head [0]
        Root = 16, // parent: <none> [-1]
    }

    [SerializeField]
    [Tooltip("The AR camera being used in the scene.")]
    Camera m_ARCamera;

    /// <summary>
    /// Get or set the <c>Camera</c>.
    /// </summary>
    public Camera arCamera
    {
        get { return m_ARCamera; }
        set { m_ARCamera = value; }
    }

    [SerializeField]
    [Tooltip("The ARHumanBodyManager which will produce human body anchors.")]
    ARHumanBodyManager m_HumanBodyManager;

    /// <summary>
    /// Get or set the <c>ARHumanBodyManager</c>.
    /// </summary>
    public ARHumanBodyManager humanBodyManager
    {
        get { return m_HumanBodyManager; }
        set { m_HumanBodyManager = value; }
    }

    [SerializeField]
    [Tooltip("A prefab that contains a LineRenderer component that will be used for rendering lines, representing the skeleton joints.")]
    GameObject m_LineRendererPrefab;

    /// <summary>
    /// Get or set the Line Renderer prefab.
    /// </summary>
    public GameObject lineRendererPrefab
    {
        get { return m_LineRendererPrefab; }
        set { m_LineRendererPrefab = value; }
    }

    Dictionary<int, GameObject> m_LineRenderers;
    static HashSet<int> s_JointSet = new HashSet<int>();

    void Awake()
    {
        m_LineRenderers = new Dictionary<int, GameObject>();
    }

    void UpdateRenderer(int joints, int index)
    {
       
    }

    void Update()
    {
        Debug.Assert(m_HumanBodyManager != null, "Human body manager cannot be null");
       
    }

    void HideJointLines()
    {
        foreach (var lineRenderer in m_LineRenderers)
        {
            lineRenderer.Value.SetActive(false);
        }
    }
}
