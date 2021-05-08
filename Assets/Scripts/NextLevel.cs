using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int numbScene;//id сцены
    public void NewLevel()
    {
        SceneManager.LoadScene(numbScene);//обращение к индексу сцены и ее перезагрузка
    }
}

