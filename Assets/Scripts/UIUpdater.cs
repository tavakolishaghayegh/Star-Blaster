using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI ScoreText;
    ScoreKeeper scoreKeeper;

  void Start()
  {
    scoreKeeper=FindAnyObjectByType<ScoreKeeper>();
    healthSlider.maxValue=playerHealth.GetHealth();
  }
  void Update()
  {
    ScoreText.text=scoreKeeper.GetScore().ToString("000000000");
    healthSlider.value=playerHealth.GetHealth();

  }






}
