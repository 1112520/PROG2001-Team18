using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectSceneSwitcher : MonoBehaviour
{
    [Header("物体切换设置")]
    [Tooltip("需要切换显示的物体数组")]
    public GameObject[] switchableObjects;

    [Header("物体名称设置")]
    [Tooltip("每个物体显示的名称（顺序需与物体数组一致）")]
    public string[] objectNames;

    [Header("场景设置")]
    [Tooltip("每个物体对应的场景名称（顺序需与物体数组一致）")]
    public string[] targetScenes;

    [Header("UI引用")]
    [Tooltip("左切换按钮（可选）")]
    public Button leftButton;
    [Tooltip("右切换按钮（可选）")]
    public Button rightButton;
    [Tooltip("进入场景按钮（可选）")]
    public Button enterButton;
    [Tooltip("显示当前物体名称的Text组件")]
    public Text nameText;

    private int currentIndex = 0;

    void Start()
    {
        // 验证数组长度
        if (switchableObjects.Length != objectNames.Length)
        {
            Debug.LogError("物体数组和名称数组长度不一致！");
        }

        if (switchableObjects.Length != targetScenes.Length)
        {
            Debug.LogError("物体数组和场景数组长度不一致！");
        }

        // 初始化显示
        UpdateDisplay();

        // 自动绑定按钮事件
        if (leftButton != null)
            leftButton.onClick.AddListener(SwitchToPrevious);

        if (rightButton != null)
            rightButton.onClick.AddListener(SwitchToNext);

        if (enterButton != null)
            enterButton.onClick.AddListener(LoadTargetScene);
    }

    /// <summary>
    /// 切换到上一个物体
    /// </summary>
    public void SwitchToPrevious()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = switchableObjects.Length - 1;

        UpdateDisplay();
    }

    /// <summary>
    /// 切换到下一个物体
    /// </summary>
    public void SwitchToNext()
    {
        currentIndex++;
        if (currentIndex >= switchableObjects.Length)
            currentIndex = 0;

        UpdateDisplay();
    }

    /// <summary>
    /// 更新显示当前物体和名称
    /// </summary>
    private void UpdateDisplay()
    {
        // 显示/隐藏物体
        for (int i = 0; i < switchableObjects.Length; i++)
        {
            if (switchableObjects[i] != null)
                switchableObjects[i].SetActive(i == currentIndex);
        }

        // 更新物体名称文本
        if (nameText != null && currentIndex < objectNames.Length)
        {
            nameText.text = objectNames[currentIndex];
        }
    }

    /// <summary>
    /// 加载当前物体对应的场景
    /// </summary>
    public void LoadTargetScene()
    {
        if (targetScenes == null || currentIndex >= targetScenes.Length)
        {
            Debug.LogError("场景数组未配置或索引越界");
            return;
        }

        string sceneName = targetScenes[currentIndex];

        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError($"索引 {currentIndex} 的场景名为空");
            return;
        }

        // 检查场景是否存在
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"场景 '{sceneName}' 不存在，请检查Build Settings");
        }
    }

    /// <summary>
    /// 跳转到指定索引的物体
    /// </summary>
    /// <param name="index">目标物体索引</param>
    public void JumpToObject(int index)
    {
        if (index >= 0 && index < switchableObjects.Length)
        {
            currentIndex = index;
            UpdateDisplay();
        }
        else
        {
            Debug.LogError($"跳转索引 {index} 越界，有效范围：0-{switchableObjects.Length - 1}");
        }
    }

    void OnDestroy()
    {
        // 清理事件绑定
        if (leftButton != null)
            leftButton.onClick.RemoveListener(SwitchToPrevious);

        if (rightButton != null)
            rightButton.onClick.RemoveListener(SwitchToNext);

        if (enterButton != null)
            enterButton.onClick.RemoveListener(LoadTargetScene);
    }
}