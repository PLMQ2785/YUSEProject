using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Rendering.Universal;
public class SettingManager : MonoBehaviour
{

    #region public
    [Header("--Data Field--")]
    #endregion



    #region private
    [Header("--UI Component--")]
    [SerializeField] private TMP_Dropdown resolutionDropdown; // 해상도 목록
    [SerializeField] private Toggle fullScreenToggle;         // 전체화면 체크박스
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    //임시변수 
    private int resolutionIndex;
    private bool isFullScreen;

    List<Resolution> targetResolution = new List<Resolution>();
    #endregion

    #region Life Cycle
    void Start()
    {
        Init_Resolution();
        
        LoadAndApplySavedSettings();
        
        // 오디오 볼륨설정 초기화, 이벤트 연결 함수 호출
        Init_VolumeSettings();
        
        if (resolutionDropdown != null)
        {
            resolutionDropdown.onValueChanged.AddListener(SetResolution);
        }
        
        if (fullScreenToggle != null)
        {
            fullScreenToggle.onValueChanged.AddListener(PickFullScreen);
        }
    }


    void Update()
    {

    }
    #endregion

    #region ui click action
    public void SetResolution(int index)
    {
        resolutionIndex = index;
    }

    public void PickFullScreen(bool isFull)
    {
        isFullScreen = isFull;
    }
    
    // ApplyResolution -> ApplyAllSettings 
    public void ApplyAllSettings()
    {
        // 1. 해상도 적용
        if (resolutionIndex >= 0 && resolutionIndex < targetResolution.Count)
        {
            Resolution selected = targetResolution[resolutionIndex];
            Screen.SetResolution(selected.width, selected.height, isFullScreen);
            
            // 해상도 저장
            SaveManager.SaveResolutionSettings(selected.width, selected.height, isFullScreen);
        }

        // 2. 볼륨 저장 (슬라이더 값은 이미 AudioManager에 반영되어 있으므로 저장만 수행)
        if (AudioManager.Instance != null)
        {
            SaveManager.SaveVolume("Master", AudioManager.Instance.MasterVolume);
            SaveManager.SaveVolume("BGM", AudioManager.Instance.BgmVolume);
            SaveManager.SaveVolume("SFX", AudioManager.Instance.SfxVolume);
        }

        // 3. 최종 디스크 쓰기
        SaveManager.Save();
        
        Debug.Log("모든 설정이 적용되고 저장되었습니다.");
    }

    #endregion






    //처음 시작할때 존재하는 해상도 맞춰주는 함수
    private void Init_Resolution()
    {
        //초기화 
        targetResolution.Clear();
        resolutionDropdown.ClearOptions();

        //임시저장용
        List<string> options = new List<string>();

        //화면 관리자로부터 지원하는 해상도 받아오기
        Resolution[] allResolutions = Screen.resolutions;

        int currentResolutionIndex = 0;

        // 받아온해상도 분리해서 넣기
        for (int i = 0; i < allResolutions.Length; i++)
        {
            Resolution res = allResolutions[i];

            string option = res.width + "x" + res.height;

            //중복제거
            if (!options.Contains(option))
            {
                options.Add(option);
                targetResolution.Add(res);
            }
        }

        //option칸 채우기
        resolutionDropdown.AddOptions(options);

        // 현재 해상도 선택해두기

        for (int i = 0; i < targetResolution.Count; i++)
        {
            if (targetResolution[i].width == Screen.width && targetResolution[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        //전체 화면 토글 상태 맞추기
        fullScreenToggle.isOn = Screen.fullScreen;

        //시작할때 초기화 해줘야함 임시변수
        resolutionIndex = currentResolutionIndex;
        isFullScreen = Screen.fullScreen;
    }

    private void Init_VolumeSettings()
    {
        if (AudioManager.Instance != null)
        {
            // 1. AudioManager에서 현재(저장된) 볼륨 값 가져오기
            float currentMaster = AudioManager.Instance.MasterVolume;
            float currentBgm = AudioManager.Instance.BgmVolume;
            float currentSfx = AudioManager.Instance.SfxVolume;
            
            // 2. 슬라이더 UI에 값 반영
            if (masterSlider) masterSlider.value = currentMaster;
            if (bgmSlider) bgmSlider.value = currentBgm;
            if (sfxSlider) sfxSlider.value = currentSfx;
            
            // 3. 슬라이더 이벤트 리스너 연결 (값이 바뀔 때마다 AudioManager 호출)
            if (masterSlider)
            {
                masterSlider.onValueChanged.AddListener(AudioManager.Instance.SetMasterVolume);
            }

            if (bgmSlider)
            {
                bgmSlider.onValueChanged.AddListener(AudioManager.Instance.SetBgmVolume);
            }

            if (sfxSlider)
            {
                sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SetSfxVolume);
            }
            
            // // 슬라이더 초기값 설정
            // masterSlider.value = AudioManager.Instance.MasterVolume;
            // bgmSlider.value = AudioManager.Instance.BgmVolume;    
            // sfxSlider.value = AudioManager.Instance.SfxVolume;     
            //
            // // 초기값으로 음향 설정
            // AudioManager.Instance.SetMasterVolume(masterSlider.value);
            // AudioManager.Instance.SetBgmVolume(bgmSlider.value);
            // AudioManager.Instance.SetSfxVolume(sfxSlider.value);
            //
            // // 리스너 연결
            // masterSlider.onValueChanged.AddListener(AudioManager.Instance.SetMasterVolume);
            // bgmSlider.onValueChanged.AddListener(AudioManager.Instance.SetBgmVolume);
            // sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SetSfxVolume);
            
        }
        else
        {
            Debug.LogError("AudioManager 인스턴스를 찾을 수 없습니다.");
        }
    }
    
    private void LoadAndApplySavedSettings()
    {
        // 1. 해상도 불러오기
        var (width, height, isFull) = SaveManager.LoadResolutionSettings();
        
        // 화면 적용
        Screen.SetResolution(width, height, isFull);
        
        // UI 동기화 (임시 변수 업데이트)
        isFullScreen = isFull;
        fullScreenToggle.isOn = isFull;

        // 드롭다운에서 해당 해상도 찾아서 선택하기
        for (int i = 0; i < targetResolution.Count; i++)
        {
            if (targetResolution[i].width == width && targetResolution[i].height == height)
            {
                resolutionIndex = i;
                resolutionDropdown.value = i;
                resolutionDropdown.RefreshShownValue();
                break;
            }
        }
    }
}   
