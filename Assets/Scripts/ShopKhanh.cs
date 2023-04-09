using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopKhanh : MonoBehaviour
{
    public Button btnClose;
    public Button btnSpecial;
    public Button btnMega;
    public Button btnMaster;
    public Button btnCoin500;
    public Button btnCoin1000;
    private void OnEnable()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        btnClose.onClick.AddListener(() => MenuManager.instance.shop.SetActive(false));
        btnSpecial.onClick.AddListener(() => GameController.Instance.iapController.BuyProduct(TypePackIAP.Special_Pack));
        btnMega.onClick.AddListener(() => GameController.Instance.iapController.BuyProduct(TypePackIAP.MegaPack));
        btnMaster.onClick.AddListener(() => GameController.Instance.iapController.BuyProduct(TypePackIAP.MasterPack));
        btnCoin500.onClick.AddListener(() => GameController.Instance.iapController.BuyProduct(TypePackIAP.CoinPack_500));
        btnCoin1000.onClick.AddListener(() => GameController.Instance.iapController.BuyProduct(TypePackIAP.CoinPack_1000));
    }

   
}
