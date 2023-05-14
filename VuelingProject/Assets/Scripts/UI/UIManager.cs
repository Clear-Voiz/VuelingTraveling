using TMPro;
using UnityEngine;

namespace UI
{
   public class UIManager : MonoBehaviour
   {
      public static UIManager Instance { get; private set; }
      public int currency;
      public TextMeshProUGUI currencyDisplayer;

      private void Awake()
      {
         Instance = this;
      }
   }
}
