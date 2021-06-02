using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyInteraction : MonoBehaviour
{
    public GameObject player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(player);
            StartCoroutine("KillAndReload");
        }
    }

    private IEnumerator KillAndReload()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
