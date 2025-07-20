using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject bnGameOver;
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        UIManager.Instance = this;
        this.bnGameOver = GameObject.Find("bnGameOver");
        this.bnGameOver.SetActive(false);
    }
}
