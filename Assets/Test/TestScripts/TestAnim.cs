using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class TestAnim : MonoBehaviour
{
    public Animator anim;

    public float AnimTimer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(loadSceance(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator loadSceance(int SceneIndex)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(AnimTimer);

        SceneManager.LoadScene(SceneIndex);
    }
}
