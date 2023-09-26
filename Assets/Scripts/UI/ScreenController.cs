using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScreenController : MonoBehaviour
{
    [SerializeField]
    List<BaseScreen> screens;

    public static ScreenController Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        //GetScreen<PauseScreen>().Open();
    }

    public T GetScreen<T>() where T : BaseScreen
    {
        return screens.OfType<T>().FirstOrDefault();
    }
    


    public void CloseAll()
    {
        foreach (var screen in screens)
        {
            screen.Close();
        }
    }
}
