#region Kütüphaneler
using UnityEngine;
using UnityEngine.UI;
using static System.Math;
using Sirenix.OdinInspector;
#endregion

public class Menu : MonoBehaviour
{
    public static Menu menu; //singleton için
    public static GameManager gm;

    #region Deðiþkenler

    #region Büyük sayý constantlarý
    const double million = 1000000;
    const double billion = 1000000000;
    const double trillion = 1000000000000;
    const double quadrillion = 1000000000000000;
    const double quintillion = 1000000000000000000;
    #endregion

    #region Odun
    [BoxGroup("ODUN")]
    [FoldoutGroup("ODUN/Bool")]
    public bool odunMenajerAlindi;      //menajer alýnýnca true oluyor, true olunca üretim otomatikleþiyor
    [FoldoutGroup("ODUN/Bool")]
    public bool saveIcinCutButonBool;   //save load yapýldýðýnda menajer alýndýðý halde cut buton kalýyor, düzeltmek için


    [FoldoutGroup("ODUN/Upgrade Seviyeleri")]
    public int woodIncUpgLvl;           //odun gelir upg seviyesi
    [FoldoutGroup("ODUN/Upgrade Seviyeleri")]
    public int woodSpdUpgLvl;           //odun hýz upg seviyesi


    [FoldoutGroup("ODUN/Upgrade Ücretleri")]
    public float woodSpdUpgCost;        //odun hýz upg için gereken para
    [FoldoutGroup("ODUN/Upgrade Ücretleri")]
    public float woodIncUpgCost;        //odun gelir upg için gereken para


    [FoldoutGroup("ODUN/Speed Upgrade Textleri")]
    public Text woodSpdUpgLvlText;          //odun hýz upg seviye text
    [FoldoutGroup("ODUN/Speed Upgrade Textleri")]
    public Text woodSpdUpgCostText;         //odun hýz upg ücret text
    [FoldoutGroup("ODUN/Speed Upgrade Textleri")]
    public Text woodspdyouneeddollartext;   //para yetmiyorsa ne kadar gerektiðini yazýyor
    [FoldoutGroup("ODUN/Income Upgrade Textleri")]
    public Text woodIncUpgLvlText;          //odun gelir upg seviye text
    [FoldoutGroup("ODUN/Income Upgrade Textleri")]
    public Text woodincyouneeddollartext;   //para yetmiyorsa ne kadar gerektiðini yazýyor
    [FoldoutGroup("ODUN/Income Upgrade Textleri")]
    public Text woodIncUpgCostText;         //odun gelir upg ücret text


    [FoldoutGroup("ODUN/Gameobjectler")]
    public GameObject balta;
    [FoldoutGroup("ODUN/Gameobjectler")]
    public GameObject woodSpdUpgBuyBtn;         //odun hýz upg satýn al butonu
    [FoldoutGroup("ODUN/Gameobjectler")]
    public GameObject woodincUpgBtn;            //odun gelir upg butonu    
    [FoldoutGroup("ODUN/Gameobjectler")]
    public GameObject cutBtn;                   //cut butonu
    [FoldoutGroup("ODUN/Gameobjectler")]
    public GameObject buyWoodmanBtn;            //odun menajer butonu
    [FoldoutGroup("ODUN/Gameobjectler")]
    public GameObject woodmgrNotEnoMnyText;     //menajer için yeterli para yok text, menajer satýn alýnca setactive'ini kapatmak için


    [FoldoutGroup("ODUN/Fillbarlar")]
    public float odunTime;               //fillbar kontrolü
    [FoldoutGroup("ODUN/Fillbarlar")]
    public Image odunFillbar;            //fillbar pngsi
    [FoldoutGroup("ODUN/Fillbarlar")]
    public float oduntimer;              //Bunu time'a böldürerek fillbarý kontrol ediyorum
    [FoldoutGroup("ODUN/Fillbarlar")]
    public float odunZamanCarpan;        //fillbarýn ne kadar hýzlý dolacaðýný belirliyor
    #endregion

    #region Demir
    [BoxGroup("DEMÝR")]
    [FoldoutGroup("DEMÝR/Bool")]
    public bool demirOreMenajerAlindi;         //menajer alýnýnca true olarak üretimi otomatikleþtiriyor


    [FoldoutGroup("DEMÝR/Upgrade Seviyeleri")]
    public int demirOreSpdUpgLvl;           //DemirOre hýz upgrade seviyesi, kaç kere satýn alýndýðý
    [FoldoutGroup("DEMÝR/Upgrade Seviyeleri")]
    public int demirOreIncUpgLvl;           //DemirOre income upgrade seviyesi, kaç kere satýn alýndýðý


    [FoldoutGroup("DEMÝR/Upgrade Ücretleri")]
    public float demirOreSpdUpgCost;        //demirore hýz upgrade için gereken para
    [FoldoutGroup("DEMÝR/Upgrade Ücretleri")]
    public float demirOreIncUpgCost;        //demirore income upgrade için gereken para


    [FoldoutGroup("DEMÝR/Speed Upgrade Textleri")]
    public Text demirOreSpdUpgLvlText;          //demir ore hýz upg ücret text
    [FoldoutGroup("DEMÝR/Speed Upgrade Textleri")]
    public Text demirOreSpdUpgCostText;         //demir ore hýz upg seviye text
    [FoldoutGroup("DEMÝR/Speed Upgrade Textleri")]
    public Text demirOrespdyouneeddollartext;   //para yetmiyorsa ne kadar gerektiðini yazýyor
    [FoldoutGroup("DEMÝR/Income Upgrade Textleri")]
    public Text demirOreIncUpgLvlText;          //demir ore gelir upg ücret text
    [FoldoutGroup("DEMÝR/Income Upgrade Textleri")]
    public Text demirOreIncUpgCostText;         //demir ore hýz upg seviye text
    [FoldoutGroup("DEMÝR/Income Upgrade Textleri")]
    public Text demirOreincyouneeddollartext;   //para yetmiyorsa ne kadar gerektiðini yazýyor


    [FoldoutGroup("DEMÝR/GameObjectler")]
    public GameObject digBtn;                     //Demir ore kaz butonu
    [FoldoutGroup("DEMÝR/GameObjectler")]
    public GameObject buyMinerBtn;                //Workers menüsünde madenci satýn al butonu, alýnýnca kapanýyor
    [FoldoutGroup("DEMÝR/GameObjectler")]
    public GameObject demirOreMgrNotEnoMnyText;   //Menajer satýn al butonu kapalýyken "þu kadar para lazým" yazan text, satýn alýnýnca kapanýyor
    [FoldoutGroup("DEMÝR/GameObjectler")]
    public GameObject demirOreSpdUpgBuyBtn;       //demir ore hýz upgrade butonu
    [FoldoutGroup("DEMÝR/GameObjectler")]
    public GameObject demirOreIncUpgBuyBtn;       //demir ore income upgrade butonu


    [FoldoutGroup("DEMÝR/Fillbarlar")]
    public float demirTime;              //fillbar kontrolü
    [FoldoutGroup("DEMÝR/Fillbarlar")]
    public Image demirFillbar;           //fillbar pngsi
    [FoldoutGroup("DEMÝR/Fillbarlar")]
    public float demirTimer;             //Bunu time'a böldürerek fillbarý kontrol ediyorum
    [FoldoutGroup("DEMÝR/Fillbarlar")]
    public float demirZamanCarpan;       //fillbarýn ne kadar hýzlý dolacaðýný belirliyor
    #endregion

    #region Kereste
    [BoxGroup("KERESTE")]
    [FoldoutGroup("KERESTE/Bool")]
    public bool keresteMenajerAlindi;   //kereste otomatikleþtirilince true oluyor
    [FoldoutGroup("KERESTE/Bool")]
    public bool keresteAlindi;          //kereste binasý alýnýnca tuþu tekrar açýlmasýn diye


    [FoldoutGroup("KERESTE/Upgrade Seviyeleri")]
    public int timberIncUpgLvl;         //kereste gelir upg seviyesi
    [FoldoutGroup("KERESTE/Upgrade Seviyeleri")]
    public int timberSpdUpgLvl;         //kereste hýz upg seviyesi


    [FoldoutGroup("KERESTE/Upgrade Ücretleri")]
    public float timberSpdUpgCost;      //kereste hýz upg için gereken para
    [FoldoutGroup("KERESTE/Upgrade Ücretleri")]
    public float timberIncUpgCost;      //kereste gelir upg için gereken para


    [FoldoutGroup("KERESTE/Speed Upgrade Textleri")]
    public Text timberSpdUpgLvlText;        //kereste hýz upg ücret text
    [FoldoutGroup("KERESTE/Speed Upgrade Textleri")]
    public Text timberSpdUpgCostText;       //kereste hýz upg seviye text
    [FoldoutGroup("KERESTE/Speed Upgrade Textleri")]
    public Text timberspdyouneeddollartext; //para yetmiyorsa ne kadar gerektiðini yazýyor


    [FoldoutGroup("KERESTE/Income Upgrade Textleri")]
    public Text timberIncUpgLvlText;        //kereste gelir upg seviye text
    [FoldoutGroup("KERESTE/Income Upgrade Textleri")]
    public Text timberincyouneeddollartext; //para yetmiyorsa ne kadar gerektiðini yazýyor
    [FoldoutGroup("KERESTE/Income Upgrade Textleri")]
    public Text timberIncUpgCostText;       //kereste hýz upg ücret text


    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject timberSpdUpgBuyBtn;     //hýz ve gelir upgrade butonlarý
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject timberincUpgBtn;        //hýz ve gelir upgrade butonlarý
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject buySawButton;           //Kereste binasý satýn al butonu
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject buyCarpenterBtn;        //Kereste menajer satýn alma butonu
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject keresteUretButon;       //bina alýnýnca kereste üreme butonu açýlacak
    [Space]
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject keresteHizUpgUnite;     //bina satýn alýnmamýþsa bu upgradeler gözükmüyor
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject keresteIncUpgUnite;     //bina satýn alýnmamýþsa bu upgradeler gözükmüyor
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject keresteSatUnite;        //bina satýn alýnmamýþsa kereste sat kýsmý gözükmüyor
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject carpenterUnite;         //Bina satýn alýnmamýþsa marangoz al kýsmý gözükmüyor
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject timberMgrNotEnoMnyText; //menajer için yeterli para yok text, menajer satýn alýnca setactive'ini kapatmak için
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject timberBinaNotEnoMnyText;//bina için yeterli para yok text, menajer satýn alýnca setactive'ini kapatmak için
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject keresteBinaCitleri;     //Kereste binasý satýn alýnýnca çitleri kapatacaðým
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject keresteBina;            //çitler kalkýnca yerine gelecek bina, satýn alýnýnca açýlacak
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject kerestefillbar;         //kereste binasýnýn fillbarý ve butonu satýn alýnýnca açýlsýn diye
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject keresteUi;              //bina satýn alýndýðýnda gözüksün
    
    
    [FoldoutGroup("KERESTE/Fillbar")]
    public Image keresteFillbar;         //fillbar pngsi
    [FoldoutGroup("KERESTE/Fillbar")]
    public float kerestetimer;           //Bunu time'a böldürerek fillbarý kontrol ediyorum
    [FoldoutGroup("KERESTE/Fillbar")]
    public float keresteZamanCarpan;     //fillbarýn ne kadar hýzlý dolacaðýný belirliyor
    [FoldoutGroup("KERESTE/Fillbar")]
    public float keresteTime;            //fillbar kontrolü
    #endregion

    #region Külçe
    [BoxGroup("KÜLÇE")]
    [FoldoutGroup("KÜLÇE/Booleans")]
    public bool kulceMenajerAlindi;             //menajer alýnýnca true olarak üretimi otomatikleþtiriyor
    [FoldoutGroup("KÜLÇE/Booleans")]
    public bool kulceAlindi;                    //kereste binasý alýnýnca tuþu tekrar açýlmasýn diye


    [FoldoutGroup("KÜLÇE/Upgrade Seviyeleri")]
    public int kulceSpdUpgLvl;                  //kereste gelir upg seviyesi
    [FoldoutGroup("KÜLÇE/Upgrade Seviyeleri")]
    public int kulceIncUpgLvl;                  //kereste hýz upg seviyesi


    [FoldoutGroup("KÜLÇE/Upgrade Ücretleri")]
    public float kulceSpdUpgCost;               //külçe hýz upg için gereken para
    [FoldoutGroup("KÜLÇE/Upgrade Ücretleri")]
    public float kulceIncUpgCost;               //külçe gelir upg için gereken para


    [FoldoutGroup("KÜLÇE/Speed upgrade textleri")]    
    public Text kulceSpdUpgLvlText;             //kulce hýz upg ücret text
    [FoldoutGroup("KÜLÇE/Speed upgrade textleri")]
    public Text kulceSpdUpgCostText;            //kulce hýz upg seviye text
    [FoldoutGroup("KÜLÇE/Speed upgrade textleri")]
    public Text kulcespdyouneeddollartext;      //para yetmiyorsa ne kadar gerektiðini yazýyor


    [FoldoutGroup("KÜLÇE/Income upgrade textleri")]
    public Text kulceIncUpgLvlText;             //kulce gelir upg seviye text
    [FoldoutGroup("KÜLÇE/Income upgrade textleri")]
    public Text kulceincyouneeddollartext;      //para yetmiyorsa ne kadar gerektiðini yazýyor
    [FoldoutGroup("KÜLÇE/Income upgrade textleri")]
    public Text kulceIncUpgCostText;            //kulce hýz upg ücret text


    [FoldoutGroup("KÜLÇE/GameObjectler")]
    public GameObject kulceSpdUpgBuyBtn;        //hýz ve gelir upgrade butonlarý
    [FoldoutGroup("KÜLÇE/GameObjectler")]
    public GameObject kulceincUpgBtn;           //hýz ve gelir upgrade butonlarý
    [FoldoutGroup("KÜLÇE/GameObjectler")]
    public GameObject buyOvenButton;            //Külçe binasý satýn al butonu
    [FoldoutGroup("KÜLÇE/GameObjectler")]
    public GameObject buyIronBakerBtn;          //Külçe menajer satýn alma butonu
    [FoldoutGroup("KÜLÇE/GameObjectler")]
    public GameObject kulceUretButon;           //bina alýnýnca külçe üreme butonu açýlacak
    [Space]
    [FoldoutGroup("KÜLÇE/GameObjectler")]
    public GameObject kulceHizUpgUnite;       //bina satýn alýnmamýþsa bu upgradeler gözükmüyor
    [FoldoutGroup("KÜLÇE/GameObjectler")]
    public GameObject kulceIncUpgUnite;       //bina satýn alýnmamýþsa bu upgradeler gözükmüyor
    [FoldoutGroup("KÜLÇE/GameObjectler")]
    public GameObject kulceSatUnite;          //bina satýn alýnmamýþsa kereste sat kýsmý gözükmüyor
    [FoldoutGroup("KÜLÇE/GameObjectler")]
    public GameObject ironBakerUnite;           //Bina satýn alýnmamýþsa marangoz al kýsmý gözükmüyor
    [FoldoutGroup("KÜLÇE/GameObjectler")]
    public GameObject kulceMgrNotEnoMnyText;   //menajer için yeterli para yok text, menajer satýn alýnca setactive'ini kapatmak için
    [FoldoutGroup("KÜLÇE/GameObjectler")]
    public GameObject kulceBinaNotEnoMnyText;  //bina için yeterli para yok text, menajer satýn alýnca setactive'ini kapatmak için
    [FoldoutGroup("KÜLÇE/GameObjectler")]
    public GameObject kulceBinaCitleri;     //Kereste binasý satýn alýnýnca çitleri kapatacaðým
    [FoldoutGroup("KÜLÇE/GameObjectler")]
    public GameObject kulceBina;            //çitler kalkýnca yerine gelecek bina, satýn alýnýnca açýlacak
    [FoldoutGroup("KÜLÇE/GameObjectler")]
    public GameObject kulcefillbar;         //kereste binasýnýn fillbarý ve butonu satýn alýnýnca açýlsýn diye
    [FoldoutGroup("KÜLÇE/GameObjectler")]
    public GameObject kulceUi;              //bina satýn alýndýðýnda gözüksün


    [FoldoutGroup("KÜLÇE/Fillbar")]
    public Image kulceFillbar;         //fillbar pngsi
    [FoldoutGroup("KÜLÇE/Fillbar")]
    public float kulcetimer;           //Bunu time'a böldürerek fillbarý kontrol ediyorum
    [FoldoutGroup("KÜLÇE/Fillbar")]
    public float kulceZamanCarpan;     //fillbarýn ne kadar hýzlý dolacaðýný belirliyor
    [FoldoutGroup("KÜLÇE/Fillbar")]
    public float kulceTime;              //fillbar kontrolü
    #endregion

    #region Masa
    [BoxGroup("MASA")]
    [FoldoutGroup("MASA/Booleans")]
    public bool masaMenajerAlindi;             //menajer alýnýnca true olarak üretimi otomatikleþtiriyor
    [FoldoutGroup("MASA/Booleans")]
    public bool masaAlindi;                    //kereste binasý alýnýnca tuþu tekrar açýlmasýn diye


    [FoldoutGroup("MASA/Upgrade Seviyeleri")]
    public int masaSpdUpgLvl;                  //kereste gelir upg seviyesi
    [FoldoutGroup("MASA/Upgrade Seviyeleri")]
    public int masaIncUpgLvl;                  //kereste hýz upg seviyesi


    [FoldoutGroup("MASA/Upgrade Ücretleri")]
    public float masaSpdUpgCost;               //külçe hýz upg için gereken para
    [FoldoutGroup("MASA/Upgrade Ücretleri")]
    public float masaIncUpgCost;               //külçe gelir upg için gereken para


    [FoldoutGroup("MASA/Speed upgrade textleri")]
    public Text masaSpdUpgLvlText;             //kulce hýz upg ücret text
    [FoldoutGroup("MASA/Speed upgrade textleri")]
    public Text masaSpdUpgCostText;            //kulce hýz upg seviye text
    [FoldoutGroup("MASA/Speed upgrade textleri")]
    public Text masaspdyouneeddollartext;      //para yetmiyorsa ne kadar gerektiðini yazýyor


    [FoldoutGroup("MASA/Income upgrade textleri")]
    public Text masaIncUpgLvlText;             //kulce gelir upg seviye text
    [FoldoutGroup("MASA/Income upgrade textleri")]
    public Text masaincyouneeddollartext;      //para yetmiyorsa ne kadar gerektiðini yazýyor
    [FoldoutGroup("MASA/Income upgrade textleri")]
    public Text masaIncUpgCostText;            //kulce hýz upg ücret text


    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaSpdUpgBuyBtn;        //hýz ve gelir upgrade butonlarý
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaincUpgBtn;           //hýz ve gelir upgrade butonlarý
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject buyMasaButton;            //Külçe binasý satýn al butonu
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject buyMasaciBtn;          //Külçe menajer satýn alma butonu
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaUretButon;           //bina alýnýnca külçe üreme butonu açýlacak
    [Space]
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaHizUpgUnite;       //bina satýn alýnmamýþsa bu upgradeler gözükmüyor
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaIncUpgUnite;       //bina satýn alýnmamýþsa bu upgradeler gözükmüyor
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaSatUnite;          //bina satýn alýnmamýþsa kereste sat kýsmý gözükmüyor
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaciUnite;           //Bina satýn alýnmamýþsa marangoz al kýsmý gözükmüyor
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaMgrNotEnoMnyText;   //menajer için yeterli para yok text, menajer satýn alýnca setactive'ini kapatmak için
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaBinaNotEnoMnyText;  //bina için yeterli para yok text, menajer satýn alýnca setactive'ini kapatmak için
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaBinaCitleri;     //Kereste binasý satýn alýnýnca çitleri kapatacaðým
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaBina;            //çitler kalkýnca yerine gelecek bina, satýn alýnýnca açýlacak
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masafillbar;         //kereste binasýnýn fillbarý ve butonu satýn alýnýnca açýlsýn diye
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaUi;              //bina satýn alýndýðýnda gözüksün


    [FoldoutGroup("MASA/Fillbar")]
    public Image masaFillbar;         //fillbar pngsi
    [FoldoutGroup("MASA/Fillbar")]
    public float masatimer;           //Bunu time'a böldürerek fillbarý kontrol ediyorum
    [FoldoutGroup("MASA/Fillbar")]
    public float masaZamanCarpan;     //fillbarýn ne kadar hýzlý dolacaðýný belirliyor
    [FoldoutGroup("MASA/Fillbar")]
    public float masaTime;              //fillbar kontrolü
    #endregion

    #region Çivi
    [BoxGroup("CÝVÝ")]
    [FoldoutGroup("CÝVÝ/Booleans")]
    public bool civiMenajerAlindi;             //menajer alýnýnca true olarak üretimi otomatikleþtiriyor
    [FoldoutGroup("CÝVÝ/Booleans")]
    public bool civiAlindi;                    //çivi binasý alýnýnca tuþu tekrar açýlmasýn diye


    [FoldoutGroup("CÝVÝ/Upgrade Seviyeleri")]
    public int civiSpdUpgLvl;                  //civi gelir upg seviyesi
    [FoldoutGroup("CÝVÝ/Upgrade Seviyeleri")]
    public int civiIncUpgLvl;                  //civi hýz upg seviyesi


    [FoldoutGroup("CÝVÝ/Upgrade Ücretleri")]
    public float civiSpdUpgCost;               //civi hýz upg için gereken para
    [FoldoutGroup("CÝVÝ/Upgrade Ücretleri")]
    public float civiIncUpgCost;               //civi gelir upg için gereken para


    [FoldoutGroup("CÝVÝ/Speed upgrade textleri")]
    public Text civiSpdUpgLvlText;             //kulce hýz upg ücret text
    [FoldoutGroup("CÝVÝ/Speed upgrade textleri")]
    public Text civiSpdUpgCostText;            //kulce hýz upg seviye text
    [FoldoutGroup("CÝVÝ/Speed upgrade textleri")]
    public Text civispdyouneeddollartext;      //para yetmiyorsa ne kadar gerektiðini yazýyor


    [FoldoutGroup("CÝVÝ/Income upgrade textleri")]    
    public Text civiIncUpgLvlText;             //kulce gelir upg seviye text
    [FoldoutGroup("CÝVÝ/Income upgrade textleri")]
    public Text civiincyouneeddollartext;      //para yetmiyorsa ne kadar gerektiðini yazýyor
    [FoldoutGroup("CÝVÝ/Income upgrade textleri")]
    public Text civiIncUpgCostText;            //kulce hýz upg ücret text


    [FoldoutGroup("CÝVÝ/GameObjectler")]    
    public GameObject civiSpdUpgBuyBtn;        //hýz ve gelir upgrade butonlarý
    [FoldoutGroup("CÝVÝ/GameObjectler")]
    public GameObject civiincUpgBtn;           //hýz ve gelir upgrade butonlarý
    [FoldoutGroup("CÝVÝ/GameObjectler")]
    public GameObject buyNailButton;           //Çivi binasý satýn al butonu
    [FoldoutGroup("CÝVÝ/GameObjectler")]
    public GameObject buyNailMngrBtn;          //Çivi menajer satýn alma butonu
    [FoldoutGroup("CÝVÝ/GameObjectler")]
    public GameObject civiUretButon;           //bina alýnýnca çivi üretme butonu açýlacak
    [Space]
    [FoldoutGroup("CÝVÝ/GameObjectler")]
    public GameObject civiHizUpgUnite;         //bina satýn alýnmamýþsa bu upgradeler gözükmüyor
    [FoldoutGroup("CÝVÝ/GameObjectler")]
    public GameObject civiIncUpgUnite;         //bina satýn alýnmamýþsa bu upgradeler gözükmüyor
    [FoldoutGroup("CÝVÝ/GameObjectler")]
    public GameObject civiSatUnite;            //bina satýn alýnmamýþsa kereste sat kýsmý gözükmüyor
    [FoldoutGroup("CÝVÝ/GameObjectler")]
    public GameObject civiMngrUnite;           //Bina satýn alýnmamýþsa marangoz al kýsmý gözükmüyor
    [FoldoutGroup("CÝVÝ/GameObjectler")]
    public GameObject civiMgrNotEnoMnyText;    //menajer için yeterli para yok text, menajer satýn alýnca setactive'ini kapatmak için
    [FoldoutGroup("CÝVÝ/GameObjectler")]
    public GameObject civiBinaNotEnoMnyText;   //bina için yeterli para yok text, menajer satýn alýnca setactive'ini kapatmak için
    [FoldoutGroup("CÝVÝ/GameObjectler")]
    public GameObject civiBinaCitleri;         //Çivi binasý satýn alýnýnca çitleri kapatacaðým
    [FoldoutGroup("CÝVÝ/GameObjectler")]
    public GameObject civiBina;                //çitler kalkýnca yerine gelecek bina, satýn alýnýnca açýlacak
    [FoldoutGroup("CÝVÝ/GameObjectler")]
    public GameObject civifillbar;             //Çivi binasýnýn fillbarý ve butonu satýn alýnýnca açýlsýn diye
    [FoldoutGroup("CÝVÝ/GameObjectler")]
    public GameObject civiUi;                  //bina satýn alýndýðýnda gözüksün


    [FoldoutGroup("CÝVÝ/Fillbar")]
    public Image civiFillbar;         //fillbar pngsi
    [FoldoutGroup("CÝVÝ/Fillbar")]
    public float civitimer;           //Bunu time'a böldürerek fillbarý kontrol ediyorum
    [FoldoutGroup("CÝVÝ/Fillbar")]
    public float civiZamanCarpan;     //fillbarýn ne kadar hýzlý dolacaðýný belirliyor
    [FoldoutGroup("CÝVÝ/Fillbar")]
    public float civiTime;            //fillbar kontrolü
    #endregion

    #region Boya
    [BoxGroup("BOYA")]
    [FoldoutGroup("BOYA/Booleans")]
    public bool boyaMenajerAlindi;             //menajer alýnýnca true olarak üretimi otomatikleþtiriyor
    [FoldoutGroup("BOYA/Booleans")]
    public bool boyaAlindi;                    //diþli binasý alýnýnca tuþu tekrar açýlmasýn diye


    [FoldoutGroup("BOYA/Upgrade Seviyeleri")]
    public int boyaSpdUpgLvl;                  //diþli gelir upg seviyesi
    [FoldoutGroup("BOYA/Upgrade Seviyeleri")]
    public int boyaIncUpgLvl;                  //diþli hýz upg seviyesi


    [FoldoutGroup("BOYA/Upgrade Ücretleri")]
    public float boyaSpdUpgCost;               //diþli hýz upg için gereken para
    [FoldoutGroup("BOYA/Upgrade Ücretleri")]
    public float boyaIncUpgCost;               //diþli gelir upg için gereken para


    [FoldoutGroup("BOYA/Speed upgrade textleri")]
    public Text boyaSpdUpgLvlText;             //diþli hýz upg ücret text
    [FoldoutGroup("BOYA/Speed upgrade textleri")]
    public Text boyaSpdUpgCostText;            //diþli hýz upg seviye text
    [FoldoutGroup("BOYA/Speed upgrade textleri")]
    public Text boyaspdyouneeddollartext;      //para yetmiyorsa ne kadar gerektiðini yazýyor
    [FoldoutGroup("BOYA/Income upgrade textleri")]
    public Text boyaIncUpgLvlText;             //diþli gelir upg seviye text
    [FoldoutGroup("BOYA/Income upgrade textleri")]
    public Text boyaincyouneeddollartext;      //para yetmiyorsa ne kadar gerektiðini yazýyor
    [FoldoutGroup("BOYA/Income upgrade textleri")]
    public Text boyaIncUpgCostText;            //diþli hýz upg ücret text


    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaSpdUpgBuyBtn;        //hýz ve gelir upgrade butonlarý
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaincUpgBtn;           //hýz ve gelir upgrade butonlarý
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject buyBoyaButton;            //diþli binasý satýn al butonu
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject buyBoyaMngrBtn;           //diþli menajer satýn alma butonu
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaUretButon;           //bina alýnýnca diþli üretme butonu açýlacak
    [Space]
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaHizUpgUnite;         //bina satýn alýnmamýþsa bu upgradeler gözükmüyor
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaIncUpgUnite;         //bina satýn alýnmamýþsa bu upgradeler gözükmüyor
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaSatUnite;            //bina satýn alýnmamýþsa diþli sat kýsmý gözükmüyor
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaMngrUnite;           //Bina satýn alýnmamýþsa diþli menajer al kýsmý gözükmüyor
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaMgrNotEnoMnyText;    //menajer için yeterli para yok text, menajer satýn alýnca setactive'ini kapatmak için
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaBinaNotEnoMnyText;   //bina için yeterli para yok text, menajer satýn alýnca setactive'ini kapatmak için
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaBinaCitleri;         //diþli binasý satýn alýnýnca çitleri kapatacaðým
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaBina;                //çitler kalkýnca yerine gelecek bina, satýn alýnýnca açýlacak
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyafillbar;             //diþli binasýnýn fillbarý ve butonu satýn alýnýnca açýlsýn diye
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaUi;                  //bina satýn alýndýðýnda gözüksün


    [FoldoutGroup("BOYA/Fillbar")]
    public Image boyaFillbar;         //fillbar pngsi
    [FoldoutGroup("BOYA/Fillbar")]
    public float boyatimer;           //Bunu time'a böldürerek fillbarý kontrol ediyorum
    [FoldoutGroup("BOYA/Fillbar")]
    public float boyaZamanCarpan;     //fillbarýn ne kadar hýzlý dolacaðýný belirliyor
    [FoldoutGroup("BOYA/Fillbar")]
    public float boyaTime;            //fillbar kontrolü
    #endregion

    #region Diþli
    [BoxGroup("DÝSLÝ")]
    [FoldoutGroup("DÝSLÝ/Booleans")]
    public bool disliMenajerAlindi;             //menajer alýnýnca true olarak üretimi otomatikleþtiriyor
    [FoldoutGroup("DÝSLÝ/Booleans")]
    public bool disliAlindi;                    //diþli binasý alýnýnca tuþu tekrar açýlmasýn diye


    [FoldoutGroup("DÝSLÝ/Upgrade Seviyeleri")]
    public int disliSpdUpgLvl;                  //diþli gelir upg seviyesi
    [FoldoutGroup("DÝSLÝ/Upgrade Seviyeleri")]
    public int disliIncUpgLvl;                  //diþli hýz upg seviyesi


    [FoldoutGroup("DÝSLÝ/Upgrade Ücretleri")]
    public float disliSpdUpgCost;               //diþli hýz upg için gereken para
    [FoldoutGroup("DÝSLÝ/Upgrade Ücretleri")]
    public float disliIncUpgCost;               //diþli gelir upg için gereken para


    [FoldoutGroup("DÝSLÝ/Speed upgrade textleri")]
    public Text disliSpdUpgLvlText;             //diþli hýz upg ücret text
    [FoldoutGroup("DÝSLÝ/Speed upgrade textleri")]
    public Text disliSpdUpgCostText;            //diþli hýz upg seviye text
    [FoldoutGroup("DÝSLÝ/Speed upgrade textleri")]
    public Text dislispdyouneeddollartext;      //para yetmiyorsa ne kadar gerektiðini yazýyor
    [FoldoutGroup("DÝSLÝ/Income upgrade textleri")]
    public Text disliIncUpgLvlText;             //diþli gelir upg seviye text
    [FoldoutGroup("DÝSLÝ/Income upgrade textleri")]
    public Text disliincyouneeddollartext;      //para yetmiyorsa ne kadar gerektiðini yazýyor
    [FoldoutGroup("DÝSLÝ/Income upgrade textleri")]
    public Text disliIncUpgCostText;            //diþli hýz upg ücret text


    [FoldoutGroup("DÝSLÝ/GameObjectler")]
    public GameObject disliSpdUpgBuyBtn;        //hýz ve gelir upgrade butonlarý
    [FoldoutGroup("DÝSLÝ/GameObjectler")]
    public GameObject disliincUpgBtn;           //hýz ve gelir upgrade butonlarý
    [FoldoutGroup("DÝSLÝ/GameObjectler")]
    public GameObject buyGearButton;            //diþli binasý satýn al butonu
    [FoldoutGroup("DÝSLÝ/GameObjectler")]
    public GameObject buyGearMngrBtn;           //diþli menajer satýn alma butonu
    [FoldoutGroup("DÝSLÝ/GameObjectler")]
    public GameObject disliUretButon;           //bina alýnýnca diþli üretme butonu açýlacak
    [Space]
    [FoldoutGroup("DÝSLÝ/GameObjectler")]
    public GameObject disliHizUpgUnite;         //bina satýn alýnmamýþsa bu upgradeler gözükmüyor
    [FoldoutGroup("DÝSLÝ/GameObjectler")]
    public GameObject disliIncUpgUnite;         //bina satýn alýnmamýþsa bu upgradeler gözükmüyor
    [FoldoutGroup("DÝSLÝ/GameObjectler")]
    public GameObject disliSatUnite;            //bina satýn alýnmamýþsa diþli sat kýsmý gözükmüyor
    [FoldoutGroup("DÝSLÝ/GameObjectler")]
    public GameObject disliMngrUnite;           //Bina satýn alýnmamýþsa diþli menajer al kýsmý gözükmüyor
    [FoldoutGroup("DÝSLÝ/GameObjectler")]
    public GameObject disliMgrNotEnoMnyText;    //menajer için yeterli para yok text, menajer satýn alýnca setactive'ini kapatmak için
    [FoldoutGroup("DÝSLÝ/GameObjectler")]
    public GameObject disliBinaNotEnoMnyText;   //bina için yeterli para yok text, menajer satýn alýnca setactive'ini kapatmak için
    [FoldoutGroup("DÝSLÝ/GameObjectler")]
    public GameObject disliBinaCitleri;         //diþli binasý satýn alýnýnca çitleri kapatacaðým
    [FoldoutGroup("DÝSLÝ/GameObjectler")]
    public GameObject disliBina;                //çitler kalkýnca yerine gelecek bina, satýn alýnýnca açýlacak
    [FoldoutGroup("DÝSLÝ/GameObjectler")]
    public GameObject dislifillbar;             //diþli binasýnýn fillbarý ve butonu satýn alýnýnca açýlsýn diye
    [FoldoutGroup("DÝSLÝ/GameObjectler")]
    public GameObject disliUi;                  //bina satýn alýndýðýnda gözüksün


    [FoldoutGroup("DÝSLÝ/Fillbar")]
    public Image disliFillbar;         //fillbar pngsi
    [FoldoutGroup("DÝSLÝ/Fillbar")]
    public float dislitimer;           //Bunu time'a böldürerek fillbarý kontrol ediyorum
    [FoldoutGroup("DÝSLÝ/Fillbar")]
    public float disliZamanCarpan;     //fillbarýn ne kadar hýzlý dolacaðýný belirliyor
    [FoldoutGroup("DÝSLÝ/Fillbar")]
    public float disliTime;            //fillbar kontrolü
    #endregion    

    #endregion

    #region Awake    
    private void Awake()
    {
        menu = this;
    }
#endregion    

    #region Update
    private void Update()
    {
        #region Upgrade Textleri

        #region Upgrade level textleri
        woodSpdUpgLvlText.text = "x" + woodSpdUpgLvl;
        woodIncUpgLvlText.text = "x" + woodIncUpgLvl;
        timberSpdUpgLvlText.text = "x" + timberSpdUpgLvl;
        timberIncUpgLvlText.text = "x" + timberIncUpgLvl;
        demirOreSpdUpgLvlText.text = "x" + demirOreSpdUpgLvl;
        demirOreIncUpgLvlText.text = "x" + demirOreIncUpgLvl;
        kulceSpdUpgLvlText.text = "x" + kulceSpdUpgLvl;
        kulceIncUpgLvlText.text = "x" + kulceIncUpgLvl;
        masaSpdUpgLvlText.text = "x" + masaSpdUpgLvl;
        masaIncUpgLvlText.text = "x" + masaIncUpgLvl;
        civiSpdUpgLvlText.text = "x" + civiSpdUpgLvl;
        civiIncUpgLvlText.text = "x" + civiIncUpgLvl;
        disliSpdUpgLvlText.text = "x" + disliSpdUpgLvl;
        disliIncUpgLvlText.text = "x" + disliIncUpgLvl;
        boyaSpdUpgLvlText.text = "x" + boyaSpdUpgLvl;
        boyaIncUpgLvlText.text = "x" + boyaIncUpgLvl;
        #endregion

        #region Binalar alýnmamýþken upgradeler kapalý kalsýn
        keresteHizUpgUnite.SetActive(keresteAlindi);
        keresteIncUpgUnite.SetActive(keresteAlindi);
        kulceHizUpgUnite.SetActive(kulceAlindi);
        kulceIncUpgUnite.SetActive(kulceAlindi);
        masaHizUpgUnite.SetActive(masaAlindi);
        masaIncUpgUnite.SetActive(masaAlindi);
        civiHizUpgUnite.SetActive(civiAlindi);
        civiIncUpgUnite.SetActive(civiAlindi);
        disliHizUpgUnite.SetActive(disliAlindi);
        disliIncUpgUnite.SetActive(disliAlindi);
        boyaHizUpgUnite.SetActive(boyaAlindi);
        boyaIncUpgUnite.SetActive(boyaAlindi);
        #endregion

        #region Yükseltme cost ve gereken para gösterimleri
        //Hýz yükseltmeleri
        upgradeCostGosterimler(woodSpdUpgCost, woodSpdUpgCostText, "");
        upgradeCostGosterimler(demirOreSpdUpgCost, demirOreSpdUpgCostText, "");
        upgradeCostGosterimler(timberSpdUpgCost, timberSpdUpgCostText, "");
        upgradeCostGosterimler(kulceSpdUpgCost, kulceSpdUpgCostText, "");
        upgradeCostGosterimler(masaSpdUpgCost, masaSpdUpgCostText, "");
        upgradeCostGosterimler(civiSpdUpgCost, civiSpdUpgCostText, "");
        upgradeCostGosterimler(disliSpdUpgCost, disliSpdUpgCostText, "");
        upgradeCostGosterimler(boyaSpdUpgCost, boyaSpdUpgCostText, "");
        //Hýz yükseltmesine para yetmiyorsa
        upgradeCostGosterimler(woodSpdUpgCost, woodspdyouneeddollartext, "You Need $");
        upgradeCostGosterimler(demirOreSpdUpgCost, demirOrespdyouneeddollartext, "You Need $");
        upgradeCostGosterimler(timberSpdUpgCost, timberspdyouneeddollartext, "You Need $");
        upgradeCostGosterimler(kulceSpdUpgCost, kulcespdyouneeddollartext, "You Need $");
        upgradeCostGosterimler(masaSpdUpgCost, masaspdyouneeddollartext, "You Need $");
        upgradeCostGosterimler(civiSpdUpgCost, civispdyouneeddollartext, "You Need $");
        upgradeCostGosterimler(disliSpdUpgCost, dislispdyouneeddollartext, "You Need $");
        upgradeCostGosterimler(boyaSpdUpgCost, boyaspdyouneeddollartext, "You Need $");

        //income yükseltmeleri
        upgradeCostGosterimler(woodIncUpgCost, woodIncUpgCostText, "");
        upgradeCostGosterimler(demirOreIncUpgCost, demirOreIncUpgCostText, "");
        upgradeCostGosterimler(timberIncUpgCost, timberIncUpgCostText, "");
        upgradeCostGosterimler(kulceIncUpgCost, kulceIncUpgCostText, "");
        upgradeCostGosterimler(masaIncUpgCost, masaIncUpgCostText, "");
        upgradeCostGosterimler(civiIncUpgCost, civiIncUpgCostText, "");
        upgradeCostGosterimler(disliIncUpgCost, disliIncUpgCostText, "");
        upgradeCostGosterimler(boyaIncUpgCost, boyaIncUpgCostText, "");
        //income yükseltmesine para yetmiyorsa
        upgradeCostGosterimler(woodIncUpgCost, woodincyouneeddollartext, "You Need $");
        upgradeCostGosterimler(demirOreIncUpgCost, demirOreincyouneeddollartext, "You Need $");
        upgradeCostGosterimler(timberIncUpgCost, timberincyouneeddollartext, "You Need $");
        upgradeCostGosterimler(kulceIncUpgCost, kulceincyouneeddollartext, "You Need $");
        upgradeCostGosterimler(masaIncUpgCost, masaincyouneeddollartext, "You Need $");
        upgradeCostGosterimler(civiIncUpgCost, civiincyouneeddollartext, "You Need $");
        upgradeCostGosterimler(disliIncUpgCost, disliincyouneeddollartext, "You Need $");
        upgradeCostGosterimler(boyaIncUpgCost, boyaincyouneeddollartext, "You Need $");
        #endregion

        #endregion//Upgrade Textleri

        #region Para yetmiyorsa butonlarý kapat

        #region Odun
        //Menajer al butonu, para yetmiyorsa veya menajer alýndýysa kapat
        buyMenajerButon(odunMenajerAlindi, buyWoodmanBtn, 200);        
        //Külçe hýz ve income upgrade butonlarý, para yetmiyorsa kapalý tut
        upgButon(woodSpdUpgCost, woodSpdUpgBuyBtn);
        upgButon(woodIncUpgCost, woodincUpgBtn);
        #endregion

        #region Demir
        //Menajer al butonu, para yetmiyorsa veya menajer alýndýysa kapat
        buyMenajerButon(demirOreMenajerAlindi, buyMinerBtn, 500);        
        //Külçe hýz ve income upgrade butonlarý, para yetmiyorsa kapalý tut
        upgButon(demirOreSpdUpgCost, demirOreSpdUpgBuyBtn);
        upgButon(demirOreIncUpgCost, demirOreIncUpgBuyBtn);
        #endregion

        #region Kereste

        #region Buy saw building button
        if ((GameManager.gm.odunStok >= 100) && (GameManager.gm.anaPara >= 350)) {buySawButton.SetActive(true);}
        else {buySawButton.SetActive(false);}
        if (keresteAlindi == true) {buySawButton.SetActive(false);}
        else {kerestefillbar.SetActive(false);}
        #endregion
        
        upgButon(timberSpdUpgCost, timberSpdUpgBuyBtn); //Külçe hýz upgrade butonu, para yetmiyorsa kapalý tut
        upgButon(timberIncUpgCost, timberincUpgBtn);  //Külçe income upgrade butonu, para yetmiyorsa kapalý tut
        buyMenajerButon(keresteMenajerAlindi, buyCarpenterBtn, 1200);  //Menajer al butonu, para yetmiyorsa veya menajer alýndýysa kapat        
        menajerUniteleri(keresteAlindi, carpenterUnite);  //Menü çivi menajer ünitesi, bina alýnmadýysa kapalý kalsýn        
        uretimButonubirdegisken(GameManager.gm.odunStok, keresteUretButon);  //Kereste üret butonu, odun yoksa        
        uiGosterimleri(keresteAlindi, keresteUi, keresteSatUnite);  //Diþli ui, bina alýnýnca açýlacak
        #endregion

        #region Külçe
        //Külçe bina al butonu
        binaAlButonuUcDegis(GameManager.gm.demirOreStok, 100, GameManager.gm.odunStok, 50, 850, buyOvenButton, kulceAlindi, kulcefillbar);

        //Külçe hýz ve income upgrade butonlarý, para yetmiyorsa kapalý tut
        upgButon(kulceSpdUpgCost, kulceSpdUpgBuyBtn);
        upgButon(kulceIncUpgCost, kulceincUpgBtn);

        //Menajer al butonu, para yetmiyorsa veya menajer alýndýysa kapat
        buyMenajerButon(kulceMenajerAlindi, buyIronBakerBtn, 1600);

        //Menü külçe menajer ünitesi, bina alýnmadýysa kapalý kalsýn
        menajerUniteleri(kulceAlindi, ironBakerUnite);

        //Külçe üret butonu, odun demirore yoksa
        uretimButonuikidegisken(GameManager.gm.odunStok, GameManager.gm.demirOreStok, kulceUretButon);

        //Külçe ui, bina alýnýnca açýlacak
        uiGosterimleri(kulceAlindi, kulceUi, kulceSatUnite);
        #endregion

        #region Masa
        //Masa bina al butonu
        binaAlButonuUcDegis(GameManager.gm.civiStok, 50, GameManager.gm.odunStok, 60, 1000, buyMasaButton, masaAlindi, masafillbar);

        //Masa hýz ve income upgrade butonlarý, para yetmiyorsa kapalý tut
        upgButon(masaSpdUpgCost, masaSpdUpgBuyBtn);
        upgButon(masaIncUpgCost, masaincUpgBtn);

        //Menajer al butonu, para yetmiyorsa veya menajer alýndýysa kapat
        buyMenajerButon(masaMenajerAlindi, buyMasaciBtn, 2000);

        //Menü Masa menajer ünitesi, bina alýnmadýysa kapalý kalsýn
        menajerUniteleri(masaAlindi, masaciUnite);

        //Masa üret butonu, odun civi yoksa
        uretimButonuikidegisken(GameManager.gm.keresteStok, GameManager.gm.civiStok, masaUretButon);

        //Masa ui, bina alýnýnca açýlacak
        uiGosterimleri(masaAlindi, masaUi, masaSatUnite);
        #endregion

        #region Çivi        
        //Çivi bina al butonu
        binaAlButonuUcDegis(GameManager.gm.kulceStok, 120, GameManager.gm.odunStok, 75, 1250, buyNailButton, civiAlindi, civifillbar);

        //Çivi hýz ve income upgrade butonlarý, para yetmiyorsa kapalý tut
        upgButon(civiSpdUpgCost, civiSpdUpgBuyBtn);
        upgButon(civiIncUpgCost, civiincUpgBtn);

        //Menajer al butonu, para yetmiyorsa veya menajer alýndýysa kapat
        buyMenajerButon(civiMenajerAlindi, buyNailMngrBtn, 2200);

        //Menü çivi menajer ünitesi, bina alýnmadýysa kapalý kalsýn
        menajerUniteleri(civiAlindi, civiMngrUnite);

        //Çivi üret butonu, odun külçe yoksa
        uretimButonuikidegisken(GameManager.gm.odunStok, GameManager.gm.kulceStok, civiUretButon);

        //Çivi ui, bina alýnýnca açýlacak
        uiGosterimleri(civiAlindi, civiUi, civiSatUnite);
        #endregion

        #region Diþli
        //Diþli bina al butonu
        binaAlButonuUcDegis(GameManager.gm.kulceStok, 150, GameManager.gm.odunStok, 100, 1500,buyGearButton, disliAlindi, dislifillbar);
        
        //Diþli hýz ve income upgrade butonlarý, para yetmiyorsa kapalý tut
        upgButon(disliSpdUpgCost, disliSpdUpgBuyBtn);
        upgButon(disliIncUpgCost, disliincUpgBtn);
        
        //Menajer al butonu, para yetmiyorsa veya menajer alýndýysa kapat
        buyMenajerButon(disliMenajerAlindi, buyGearMngrBtn, 3000);

        //Menü diþli menajer ünitesi, bina alýnmadýysa kapalý kalsýn
        menajerUniteleri(disliAlindi, disliMngrUnite);
                
        //diþli üret butonu, odun külçe yoksa
        uretimButonuikidegisken(GameManager.gm.odunStok, GameManager.gm.kulceStok, disliUretButon);

        //Diþli ui, bina alýnýnca açýlacak
        uiGosterimleri(disliAlindi, disliUi, disliSatUnite);
        #endregion

        #region Boya
        //Boya bina al butonu
        binaAlButonuUcDegis(GameManager.gm.keresteStok, 50, GameManager.gm.odunStok, 50, 1750, buyBoyaButton, boyaAlindi, boyafillbar);

        //Boya hýz ve income upgrade butonlarý, para yetmiyorsa kapalý tut
        upgButon(boyaSpdUpgCost, boyaSpdUpgBuyBtn);
        upgButon(boyaIncUpgCost, boyaincUpgBtn);

        //Menajer al butonu, para yetmiyorsa veya menajer alýndýysa kapat
        buyMenajerButon(boyaMenajerAlindi, buyBoyaMngrBtn, 3500);

        //Menü boya menajer ünitesi, bina alýnmadýysa kapalý kalsýn
        menajerUniteleri(boyaAlindi, boyaMngrUnite);

        //Boya üret butonu, odun külçe yoksa
        uretimButonuikidegisken(GameManager.gm.masaStok, GameManager.gm.masaStok, boyaUretButon);

        //Boya ui, bina alýnýnca açýlacak
        uiGosterimleri(boyaAlindi, boyaUi, boyaSatUnite);
        #endregion

        #endregion

        #region woodSpeedUpgCost fiyat hesaplama, KALDIRILACAK
        if (woodSpdUpgLvl == 0)
        {
            woodSpdUpgCost = 10;
        }
        else if (woodSpdUpgLvl == 1)
        {
            woodSpdUpgCost = 20;
        }
        else if (woodSpdUpgLvl == 2)
        {
            woodSpdUpgCost = 40;
        }        
        #endregion

        #region woodIncomeUpgCost ilk üç level fiyatý, KALDIRILACAK
        if (woodIncUpgLvl == 0)
        {
            woodIncUpgCost = 100;
        }
        else if (woodIncUpgLvl == 1)
        {
            woodIncUpgCost = 250;
        }
        else if (woodIncUpgLvl == 2)
        {
            woodIncUpgCost = 600;
        }
        #endregion

        #region Tab ile dünyalar arasý geçiþ, esc ile menü açma
        if (Input.GetKeyDown(KeyCode.Tab)) {GameManager.gm.ChangeWorldsButton();}
        if (Input.GetKeyDown(KeyCode.Escape)) {GameManager.gm.MenuButton();}
        #endregion

        #region Save Load'da sorun çýkaranlarý düzeltmek        
        //menajer alýndýysa üretim butonunu kapat, alýnmadýysa açýk tut
        mgrButonKapat(odunMenajerAlindi, cutBtn);
        mgrButonKapat(demirOreMenajerAlindi, digBtn);

        //Bina alýnýnca çitleri kapat, binayý aç        
        binaAlindi(keresteAlindi, keresteBinaCitleri, keresteBina);
        binaAlindi(kulceAlindi, kulceBinaCitleri, kulceBina);
        binaAlindi(masaAlindi, masaBinaCitleri, masaBina);
        binaAlindi(civiAlindi, civiBinaCitleri, civiBina);
        binaAlindi(disliAlindi, disliBinaCitleri, disliBina);
        binaAlindi(boyaAlindi, boyaBinaCitleri, boyaBina);
        #endregion

    }
    #endregion

    #region Buton Fonksiyonlarý

    #region Odun

    #region odun Sell Button
    public void odunSatTus()
    {//odun sayýsýný odunun fiyatýyla çarpýp sonucu anaparaya ekliyorum ve odun stoðunu sýfýrlýyorum
        GameManager.gm.anaPara += GameManager.gm.odunStok * GameManager.gm.odunPara;
        GameManager.gm.odunStok = 0;
    }
    #endregion

    #region Hire Forester Button
    public void HireForesterTus()
    {
        if (GameManager.gm.anaPara >= 200) //paramýz menajeri almaya yetiyorsa
        {
            GameManager.gm.anaPara -= 200;
            odunMenajerAlindi = true; //bu true olunca otomatikleþiyor
            GameManager.gm.baltaUretimBool = true;
            cutBtn.SetActive(false);             //
            buyWoodmanBtn.SetActive(false);      //kes butonunu, menajer satýn al butonunu ve menajere para yetmiyorsa yazan texti kapatýyorum
            woodmgrNotEnoMnyText.SetActive(false);   //
        }
    }
    #endregion

    #region Wood Speed Upgrade Button
    public void WoodSpeedUpgButton()
    {
        if (GameManager.gm.anaPara >= woodSpdUpgCost) //paramýz upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= woodSpdUpgCost;
            woodSpdUpgLvl += 1;
            odunZamanCarpan *= 1.15f;

            if (woodSpdUpgLvl >= 3)
            {
                woodSpdUpgCost *= 1.6f;
            }
        }//dengele
    }
    #endregion

    #region Wood income upgrade button    
    public void WoodIncomeUpgButton()
    {
        if (GameManager.gm.anaPara >= woodIncUpgCost) //anaparamýz upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= woodIncUpgCost;
            GameManager.gm.odunPara *= 1.15f;
            woodIncUpgLvl += 1;

            if (woodIncUpgLvl >= 3) //ilk üç seviye fiyatýný elimle belirledim, sonrakiler bu denkleme göre hesaplanýyor
            {
                woodIncUpgCost = woodIncUpgCost * 1.6f;
            }
        }//dengele
    }
    #endregion

    #endregion

    #region Demir

    #region Demir Ore Sat Buton
    public void DemirOreSatButon()
    {
        GameManager.gm.anaPara += GameManager.gm.demirOreStok * GameManager.gm.demirOrePara;
        GameManager.gm.demirOreStok = 0;
    }
    #endregion

    #region Hire Forester Button
    public void HireMinerTus()
    {
        if (GameManager.gm.anaPara >= 500) //paramýz menajeri almaya yetiyorsa
        {
            GameManager.gm.anaPara -= 500;
            demirOreMenajerAlindi = true; //bu true olunca otomatikleþiyor
            GameManager.gm.demirUretimBool = true;
            digBtn.SetActive(false);                     //
            buyMinerBtn.SetActive(false);                //kaz butonunu, menajer satýn al butonunu ve menajere para yetmiyorsa yazan texti kapatýyorum
            demirOreMgrNotEnoMnyText.SetActive(false);   //
        }
    }
    #endregion

    #region Demir Speed Upgrade Button
    public void DemirOreSpeedUpgButton()
    {
        if (GameManager.gm.anaPara >= demirOreSpdUpgCost) //paramýz upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= demirOreSpdUpgCost;
            demirOreSpdUpgLvl += 1;
            demirZamanCarpan *= 1.15f;
            demirOreSpdUpgCost *= 1.6f;            
        }//dengele
    }
    #endregion

    #region Demir income upgrade button
    public void DemirOreIncomeUpgButton()
    {
        if (GameManager.gm.anaPara >= demirOreIncUpgCost) //anaparamýz upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= demirOreIncUpgCost;
            GameManager.gm.demirOrePara *= 1.15f;
            demirOreIncUpgLvl += 1;
            demirOreIncUpgCost = demirOreIncUpgCost * 1.6f;
        }//dengele
    }
    #endregion

    #endregion

    #region Kereste

    #region Timber sell button
    public void timberSatTus()
    {
        GameManager.gm.anaPara += GameManager.gm.keresteStok * GameManager.gm.kerestePara;
        GameManager.gm.keresteStok = 0;
    }
    #endregion

    #region Buy Carpenter Button
    public void BuyCarpenterButton()
    {
        if (GameManager.gm.anaPara >= 1200) //menajeri almak için yeterli para varsa
        {
            GameManager.gm.anaPara -= 1200;
            keresteMenajerAlindi = true;
            buyCarpenterBtn.SetActive(false);
            timberMgrNotEnoMnyText.SetActive(false);
        }
    }
    #endregion

    #region Timber Speed Upgrade Button
    public void TimberSpeedUpgButton()
    {
        if (GameManager.gm.anaPara >= timberSpdUpgCost) //paramýz upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= timberSpdUpgCost;
            timberSpdUpgLvl += 1;
            keresteZamanCarpan *= 1.3f;
            timberSpdUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region Timber income upgrade button
    public void TimberIncomeUpgButton()
    {
        if (GameManager.gm.anaPara >= timberIncUpgCost) //anaparamýz upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= timberIncUpgCost;
            GameManager.gm.kerestePara *= 1.3f;
            timberIncUpgLvl += 1;
            timberIncUpgCost = timberIncUpgCost * 2.3f;
        }//dengele
    }
    #endregion

    #region Buy Saw button, kereste binasý 
    public void BuySawBuildingButton()
    {
        GameManager.gm.anaPara -= 350;
        GameManager.gm.odunStok -= 100;
        keresteAlindi = true;

        keresteBinaCitleri.SetActive(false);
        keresteBina.SetActive(true);
        keresteUretButon.SetActive(true);
        kerestefillbar.SetActive(true);
        timberBinaNotEnoMnyText.SetActive(false);
    }
    #endregion

    #endregion

    #region Külçe

    #region Külçe sell button 
    public void kulceSatTus()
    {
        GameManager.gm.anaPara += GameManager.gm.kulceStok * GameManager.gm.kulcePara;
        GameManager.gm.kulceStok = 0;
    }
    #endregion

    #region Buy IronBaker Button
    public void BuyIronBakerButton()
    {
        if (GameManager.gm.anaPara >= 1800) //menajeri almak için yeterli para varsa
        {
            GameManager.gm.anaPara -= 1800;
            kulceMenajerAlindi = true;
            buyIronBakerBtn.SetActive(false);
            kulceMgrNotEnoMnyText.SetActive(false);
        }
    }
    #endregion

    #region Külçe speed upg button
    public void KulceSpeedUpgButton()
    {
        if (GameManager.gm.anaPara >= kulceSpdUpgCost) //paramýz upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= kulceSpdUpgCost;
            kulceSpdUpgLvl += 1;
            kulceZamanCarpan *= 1.3f;
            kulceSpdUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region Külçe income upg button
    public void KulceIncomeUpgButton()
    {
        if (GameManager.gm.anaPara >= kulceIncUpgCost) //anaparamýz upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= kulceIncUpgCost;
            GameManager.gm.kulcePara *= 1.3f;
            kulceIncUpgLvl += 1;
            kulceIncUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region Buy Oven button, fýrýn binasý
    public void BuyOvenBuildingButton()
    {
        GameManager.gm.anaPara -= 600;
        GameManager.gm.odunStok -= 50;
        GameManager.gm.demirOreStok -= 150;
        kulceAlindi = true;

        kulceBinaCitleri.SetActive(false);
        kulceBina.SetActive(true);
        kulceUretButon.SetActive(true);
        kulcefillbar.SetActive(true);
        kulceBinaNotEnoMnyText.SetActive(false);
    }
    #endregion

    #endregion

    #region Masa

    #region Masa sell button
    public void masaSatTus()
    {
        GameManager.gm.anaPara += GameManager.gm.masaStok * GameManager.gm.masaPara;
        GameManager.gm.masaStok = 0;
    }
    #endregion

    #region Buy Masacý Buton
    public void BuyMasaciButton()
    {
        if (GameManager.gm.anaPara >= 2000) //menajeri almak için yeterli para varsa
        {
            GameManager.gm.anaPara -= 2000;
            masaMenajerAlindi = true;
            buyMasaciBtn.SetActive(false);
            masaMgrNotEnoMnyText.SetActive(false);
        }
    }
    #endregion

    #region Masa speed upg button
    public void MasaSpeedUpgButton()
    {
        if (GameManager.gm.anaPara >= masaSpdUpgCost) //paramýz upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= masaSpdUpgCost;
            masaSpdUpgLvl += 1;
            masaZamanCarpan *= 1.3f;
            masaSpdUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region Masa income upg button
    public void MasaIncomeUpgButton()
    {
        if (GameManager.gm.anaPara >= masaIncUpgCost) //anaparamýz upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= masaIncUpgCost;
            GameManager.gm.masaPara *= 1.3f;
            masaIncUpgLvl += 1;
            masaIncUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region Buy Masa Bina button, fýrýn binasý
    public void BuyMasaBuildingButton()
    {
        GameManager.gm.anaPara -= 1000;
        GameManager.gm.civiStok -= 50;
        GameManager.gm.odunStok -= 60;
        masaAlindi = true;

        masaBinaCitleri.SetActive(false);
        masaBina.SetActive(true);
        masaUretButon.SetActive(true);
        masafillbar.SetActive(true);
        masaBinaNotEnoMnyText.SetActive(false);
    }
    #endregion

    #endregion

    #region Çivi

    #region civi sell button 
    public void civiSatTus()
    {
        GameManager.gm.anaPara += GameManager.gm.civiStok * GameManager.gm.civiPara;
        GameManager.gm.civiStok = 0;
    }
    #endregion

    #region Buy civimngr Button
    public void BuyCiviMngrButton()
    {
        if (GameManager.gm.anaPara >= 2200) //menajeri almak için yeterli para varsa
        {
            GameManager.gm.anaPara -= 2200;
            civiMenajerAlindi = true;
            buyNailMngrBtn.SetActive(false);
            civiMgrNotEnoMnyText.SetActive(false);
        }
    }
    #endregion

    #region civi speed upg button
    public void civiSpeedUpgButton()
    {
        if (GameManager.gm.anaPara >= civiSpdUpgCost) //paramýz upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= civiSpdUpgCost;
            civiSpdUpgLvl += 1;
            civiZamanCarpan *= 1.3f;
            civiSpdUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region civi income upg button
    public void civiIncomeUpgButton()
    {
        if (GameManager.gm.anaPara >= civiIncUpgCost) //anaparamýz upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= civiIncUpgCost;
            GameManager.gm.civiPara *= 1.3f;
            civiIncUpgLvl += 1;
            civiIncUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region Buy nail button, civi binasý
    public void BuyNailBuildingButton()
    {
        GameManager.gm.anaPara -= 1250;
        GameManager.gm.odunStok -= 75;
        GameManager.gm.kulceStok -= 120;
        civiAlindi = true;

        civiBinaCitleri.SetActive(false);
        civiBina.SetActive(true);
        civiUretButon.SetActive(true);
        civifillbar.SetActive(true);
        civiBinaNotEnoMnyText.SetActive(false);
    }
    #endregion

    #endregion

    #region Diþli

    #region Diþli sell button
    public void disliSatTus()
    {
        GameManager.gm.anaPara += GameManager.gm.disliStok * GameManager.gm.disliPara;
        GameManager.gm.disliStok = 0;
    }
    #endregion

    #region Buy Dislimngr Button
    public void BuyDisliMngrButton()
    {
        if (GameManager.gm.anaPara >= 3000) //menajeri almak için yeterli para varsa
        {
            GameManager.gm.anaPara -= 3000;
            disliMenajerAlindi = true;
            buyGearMngrBtn.SetActive(false);
            disliMgrNotEnoMnyText.SetActive(false);
        }
    }
    #endregion

    #region Disli speed upg button
    public void disliSpeedUpgButton()
    {
        if (GameManager.gm.anaPara >= disliSpdUpgCost) //paramýz upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= disliSpdUpgCost;
            disliSpdUpgLvl += 1;
            disliZamanCarpan *= 1.3f;
            disliSpdUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region Disli income upg button
    public void disliIncomeUpgButton()
    {
        if (GameManager.gm.anaPara >= disliIncUpgCost) //anaparamýz upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= disliIncUpgCost;
            GameManager.gm.disliPara *= 1.3f;
            disliIncUpgLvl += 1;
            disliIncUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region Buy gear button, diþli binasý
    public void BuyGearBuildingButton()
    {
        GameManager.gm.anaPara -= 1650;
        GameManager.gm.odunStok -= 100;
        GameManager.gm.kulceStok -= 160;
        disliAlindi = true;

        disliBinaCitleri.SetActive(false);
        disliBina.SetActive(true);
        disliUretButon.SetActive(true);
        dislifillbar.SetActive(true);
        disliBinaNotEnoMnyText.SetActive(false);
    }
    #endregion

    #endregion

    #region Boya

    #region Boya sell button
    public void boyaSatTus()
    {
        GameManager.gm.anaPara += GameManager.gm.boyaStok * GameManager.gm.boyaPara;
        GameManager.gm.boyaStok = 0;
    }
    #endregion

    #region Buy Boyamngr Button
    public void BuyBoyaMngrButton()
    {
        if (GameManager.gm.anaPara >= 3500) //menajeri almak için yeterli para varsa
        {
            GameManager.gm.anaPara -= 3500;
            boyaMenajerAlindi = true;
            buyBoyaMngrBtn.SetActive(false);
            boyaMgrNotEnoMnyText.SetActive(false);
        }
    }
    #endregion

    #region Boya speed upg button
    public void boyaSpeedUpgButton()
    {
        if (GameManager.gm.anaPara >= boyaSpdUpgCost) //paramýz upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= boyaSpdUpgCost;
            boyaSpdUpgLvl += 1;
            boyaZamanCarpan *= 1.3f;
            boyaSpdUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region Boya income upg button
    public void boyaIncomeUpgButton()
    {
        if (GameManager.gm.anaPara >= boyaIncUpgCost) //anaparamýz upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= boyaIncUpgCost;
            GameManager.gm.boyaPara *= 1.3f;
            boyaIncUpgLvl += 1;
            boyaIncUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region Buy boya button, diþli binasý
    public void BuyBoyaBuildingButton()
    {
        GameManager.gm.anaPara -= 1750;
        GameManager.gm.odunStok -= 50;
        GameManager.gm.keresteStok -= 50;
        boyaAlindi = true;

        boyaBinaCitleri.SetActive(false);
        boyaBina.SetActive(true);
        boyaUretButon.SetActive(true);
        boyafillbar.SetActive(true);
        boyaBinaNotEnoMnyText.SetActive(false);
    }
    #endregion

    #endregion

    #endregion

    #region Genel kullaným için fonskiyonlar

    #region Save Load'da sorun çýkaranlar için fonskiyonlar

    #region Menajer alýndý/üret tuþu
    public void mgrButonKapat(bool mgralindi, GameObject cutBtn)
    {
        cutBtn.SetActive(!mgralindi);
    }
    #endregion

    #region Bina alýndýysa çitleri kapat binayý aç
    public void binaAlindi(bool binaalindi, GameObject binacitler, GameObject bina)
    {        
        binacitler.SetActive(!binaalindi);
        bina.SetActive(binaalindi);
    }
    #endregion
    #endregion

        #region UI göstergeleri, bina alýnýnca açýlacaklar
    public void uiGosterimleri(bool binaAlindi, GameObject binaUi, GameObject binaSatUnite)
    {        
        binaUi.SetActive(binaAlindi);
        binaSatUnite.SetActive(binaAlindi);
    }
    #endregion

        #region Gereksinimlerin durumuna göre üretim butonu
    public void uretimButonuikidegisken(double stok1, double stok2, GameObject uretButon)
    {
        if ((stok1 <= 0) | (stok2 <= 0)) {uretButon.SetActive(false);}
        else {uretButon.SetActive(true);}
    }
    public void uretimButonubirdegisken(double stok, GameObject uretButon)
    {
        if (stok <= 0) {uretButon.SetActive(false);}
        else {uretButon.SetActive(true);}
    }
    #endregion

        #region Menajer üniteleri, bina alýnmadýysa kapalý kalýyorlar
    public void menajerUniteleri(bool binaalindi, GameObject binaMgrUnit)
    {
        binaMgrUnit.SetActive(binaalindi);
    }
    #endregion

        #region Buy menajer buton, para yoksa veya menajer alýndýysa kapalý tut
    public void buyMenajerButon(bool menajeralindi, GameObject buyMgrBtn, double mgrPara)
    {
        if (GameManager.gm.anaPara < mgrPara || menajeralindi == true) {buyMgrBtn.SetActive(false);}
        else {buyMgrBtn.SetActive(true);}
    }
    #endregion

        #region Upgrade Butonlarý, para upgrade'e yetmiyorsa kapat
    public void upgButon(float upgCost, GameObject upgBtn)
    {
        if (GameManager.gm.anaPara >= upgCost) {upgBtn.SetActive(true);}
        else {upgBtn.SetActive(false);}
    }
    #endregion

        #region Bina satýn al butonu
    public void binaAlButonuUcDegis(double gerek1, int gerek1miktar, double gerek2, int gerek2miktar, double para, GameObject binaAlButon, bool binaAlindi, GameObject fillbar)
    {
        if ((gerek1 >= gerek1miktar) && (GameManager.gm.anaPara >= para) && (gerek2 >= gerek2miktar)) {binaAlButon.SetActive(true);}
        else {binaAlButon.SetActive(false);}
        if (binaAlindi == true) {binaAlButon.SetActive(false);}
        else {fillbar.SetActive(false);}
    }
    #endregion

        #region Upgrade Cost Gösterimleri
    public void upgradeCostGosterimler(float cost, Text costText, string basYazi)
    {
        if (cost < million)
        {costText.text = string.Format(basYazi + "{0:#.0}", cost);}
        else if (cost >= million)
        {costText.text = basYazi + (cost / million).ToString("F") + " Mil.";}
        else if (cost >= billion)
        {costText.text = basYazi + (cost / billion).ToString("F") + " Bil.";}
        else if (cost >= trillion)
        {costText.text = basYazi + (cost / trillion).ToString("F") + " Tril.";}
        else if (cost >= quadrillion)
        {costText.text = basYazi + (cost / quadrillion).ToString("F") + " Quadril.";}
        else if (cost >= quintillion)
        { costText.text = basYazi + (cost / quintillion).ToString("F") + " Quintil."; }
    }
    #endregion

    #endregion

}
