using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public GameObject heartContainer;
    private float fillValue;
    public static float initialHealth;

void Start()
    {
        // Сохранить изначальное значение здоровья
        initialHealth = Game.MaxHealth;
    }
    void Update()
    {
        fillValue = (float)Game.Health;
        fillValue = fillValue / Game.MaxHealth;
        heartContainer.GetComponent<Image>().fillAmount = fillValue;
        if (Game.Health <= 0f)
    {
        Die();
    }
    }


    void Die()
{
    Debug.Log("Die");
     StartCoroutine(RestartWithDelay(1f)); // Пример с задержкой в 2 секунды
    // SceneManager.LoadScene(6);
}
 IEnumerator RestartWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Сбросить здоровье до изначального значения
        Game.Health = initialHealth;

        // Перезагрузить текущую сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

