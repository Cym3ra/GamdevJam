using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    [SerializeField] Animator fadeAnim;
    [SerializeField] GameObject winMenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fadeAnim.SetBool("FadeOut", true);
            StartCoroutine(WinMenu());
        }
    }

    IEnumerator WinMenu()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
        winMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
