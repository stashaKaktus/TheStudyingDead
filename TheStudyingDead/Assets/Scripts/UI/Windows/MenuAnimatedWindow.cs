using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuAnimatedWindow : MonoBehaviour
{
    private CanvasGroup _panel;
    private Animator _animator;
    private Action _closeAction;

    void Start()
    {
        _panel= GetComponent<CanvasGroup>();
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("Normal");
    }

    public void Close()
    {
        _animator.SetTrigger("Close");
    }

    public void OpenMenu()
    {
        if (_panel.alpha == 1)
            Close();
        else _animator.SetTrigger("Show");
    }

    public void OnContinue()
    {
        Close();
    }

    public void OnStartNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Close();
    }

    public void OnShowControl()
    {
        var _canvas = _panel.GetComponentInParent<Canvas>();
        var panel = Resources.Load<GameObject>("UI/ControlPanel");
        Instantiate(panel, _canvas.transform);
    }

    public void OnShowOptions()
    {
        var _canvas = _panel.GetComponentInParent<Canvas>();
        var panel = Resources.Load<GameObject>("UI/OptionsPanel");
        Instantiate(panel, _canvas.transform);
    }

    public void OnShowMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        Close();
    }

    public void OnExit()
    {
        Application.Quit();
//        _closeAction = () =>
//        {
//            Application.Quit();
//#if UNITY_EDITOR
//            UnityEditor.EditorApplication.isPlaying = false;
//#endif
//            OpenMenu();

//            Close();
//        };
    }

    public void OnCloseAnimationComplete()
    {
        Destroy(gameObject);
        _closeAction?.Invoke();
    }
}
