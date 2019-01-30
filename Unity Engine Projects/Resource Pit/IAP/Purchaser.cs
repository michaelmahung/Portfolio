using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class Purchaser : MonoBehaviour, IStoreListener
{
    private static Purchaser _instance;
    public static Purchaser Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("Purchaser");
                go.AddComponent<Purchaser>();
            }
            return _instance;
        }
    }


    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    public string InitialPhase1 = "initial_phase_1";
    public string InitialPhase2 = "initial_phase_2";
    public string InitialPhase3 = "initial_phase_3";
    public string Tier1Member = "tier_1_member";
    public string Tier2Member = "tier_2_member";
    public string Tier3Member = "tier_3_member";
    public string OnDemandText = "on_demand_text";
    public string OnDemandCall = "on_demand_call";

    public bool OnPhase1;
    public bool OnPhase2;
    public bool OnPhase3;

    private static string kProductNameAppleSubscription = "com.unity3d.subscription.new";

    private static string kProductNameGooglePlaySubscription = "com.unity3d.subscription.original";

    private IAPCheck oldIAP;

    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);
        oldIAP = Camera.main.GetComponent<IAPCheck>();
    }

    void Start()
    {
        if (m_StoreController == null)
        {
            InitializePurchasing();
        }

        OnPhase3 = true;
    }

    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    #region Initializing Purchasing

    public void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(InitialPhase1, ProductType.NonConsumable);

        builder.AddProduct(InitialPhase2, ProductType.NonConsumable);

        builder.AddProduct(InitialPhase3, ProductType.Consumable);

        builder.AddProduct(OnDemandText, ProductType.Consumable);

        builder.AddProduct(OnDemandCall, ProductType.Consumable);

        builder.AddProduct(Tier1Member, ProductType.Subscription, new IDs(){
            { kProductNameAppleSubscription, AppleAppStore.Name },
            { kProductNameGooglePlaySubscription, GooglePlay.Name },
        });

        builder.AddProduct(Tier2Member, ProductType.Subscription, new IDs(){
            { kProductNameAppleSubscription, AppleAppStore.Name },
            { kProductNameGooglePlaySubscription, GooglePlay.Name },
        });

        builder.AddProduct(Tier3Member, ProductType.Subscription, new IDs(){
            { kProductNameAppleSubscription, AppleAppStore.Name },
            { kProductNameGooglePlaySubscription, GooglePlay.Name },
        });

        UnityPurchasing.Initialize(this, builder);
    }

    #endregion

    public void PurchaseIAP(string id)
    {
        BuyProductID(id);
    }

    #region Processing Purchase

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        oldIAP = Camera.main.GetComponent<IAPCheck>();

        if (String.Equals(args.purchasedProduct.definition.id, InitialPhase1, StringComparison.Ordinal))
        {
            oldIAP.BuyApplicationType(InitialPhase1);
            Debug.LogFormat("Bought {0}!", InitialPhase1);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, InitialPhase2, StringComparison.Ordinal))
        {
            oldIAP.BuyApplicationType(InitialPhase2);
            Debug.LogFormat("Bought {0}!", InitialPhase2);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, InitialPhase3, StringComparison.Ordinal))
        {
            oldIAP.BuyApplicationType(InitialPhase3);
            Debug.LogFormat("Bought {0}!", InitialPhase3);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Tier1Member, StringComparison.Ordinal))
        {
            oldIAP.BuyApplicationType(Tier1Member);
            Debug.LogFormat("Bought {0}!", Tier1Member);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Tier2Member, StringComparison.Ordinal))
        {
            oldIAP.BuyApplicationType(Tier2Member);
            Debug.LogFormat("Bought {0}!", Tier2Member);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Tier3Member, StringComparison.Ordinal))
        {
            oldIAP.BuyApplicationType(Tier3Member);
            Debug.LogFormat("Bought {0}!", Tier3Member);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, OnDemandText, StringComparison.Ordinal))
        {
            oldIAP.BuyApplicationType(OnDemandText);
            Debug.LogFormat("Bought {0}!", OnDemandText);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, OnDemandCall, StringComparison.Ordinal))
        {
            oldIAP.BuyApplicationType(OnDemandCall);
            Debug.LogFormat("Bought {0}!", OnDemandCall);
        }
        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }

        return PurchaseProcessingResult.Complete;
    }

    #endregion

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);

            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }


    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) => {
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }


    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");

        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}