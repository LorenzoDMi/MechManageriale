using UnityEngine;
using UnityEngine.UI;

public class TabBarController : MonoBehaviour
{
    [System.Serializable]
    public class TabToggle
    {
        public Toggle toggle;       // il componente Toggle (es. Toggle_Piloti)
        public Image background;    // il figlio "Background" del toggle
        public GameObject panel;    // il Panel_Piloti/Hangar/HQ collegato
        public Color colorOn = new Color(0.2f, 0.6f, 1f);
        public Color colorOff = new Color(0.3f, 0.3f, 0.3f);
    }

    [Header("Tab (Piloti, Hangar, HQ)")]
    public TabToggle[] tabs;

    [Header("Bottoni overlay")]
    public Button buttonOpzioni;
    public GameObject panelOpzioni;
    public Button buttonChiudiOpzioni;

    public Button buttonData;
    public GameObject panelData;
    public Button buttonChiudiData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Setup dei 3 tab
        foreach (var tab in tabs)
        {
            SetTabColor(tab, tab.toggle.isOn);
            tab.panel.SetActive(tab.toggle.isOn);

            tab.toggle.onValueChanged.AddListener((isOn) =>
            {
                SetTabColor(tab, isOn);
                tab.panel.SetActive(isOn);
            });
        }

        // Setup overlay Opzioni
        panelOpzioni.SetActive(false);
        buttonOpzioni.onClick.AddListener(() => panelOpzioni.SetActive(true));
        buttonChiudiOpzioni.onClick.AddListener(() => panelOpzioni.SetActive(false));

        // Setup overlay Data
        panelData.SetActive(false);
        buttonData.onClick.AddListener(() => panelData.SetActive(true));
        buttonChiudiData.onClick.AddListener(() => panelData.SetActive(false));
    }

    void SetTabColor(TabToggle tab, bool isOn)
    {
        tab.background.color = isOn ? tab.colorOn : tab.colorOff;
    }
}
