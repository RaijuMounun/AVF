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
        civiSpdUpgLvlText.text = "x" + civiSpdUpgLvl;
        civiIncUpgLvlText.text = "x" + civiIncUpgLvl;
        disliSpdUpgLvlText.text = "x" + disliSpdUpgLvl;
        disliIncUpgLvlText.text = "x" + disliIncUpgLvl;
        #endregion

        #region Binalar alýnmamýþken upgradeler kapalý kalsýn
        if (keresteAlindi == false)
        {
            keresteHizUpgUnite.SetActive(false);
            keresteIncUpgUnite.SetActive(false);
        }
        else
        {
            keresteHizUpgUnite.SetActive(true);
            keresteIncUpgUnite.SetActive(true);
        }
        if (kulceAlindi == false)
        {
            kulceHizUpgUnite.SetActive(false);
            kulceIncUpgUnite.SetActive(false);
        }
        else
        {
            kulceHizUpgUnite.SetActive(true);
            kulceIncUpgUnite.SetActive(true);
        }
        if (civiAlindi == false)
        {
            civiHizUpgUnite.SetActive(false);
            civiIncUpgUnite.SetActive(false);
        }
        else
        {
            civiHizUpgUnite.SetActive(true);
            civiIncUpgUnite.SetActive(true);
        }
        if (disliAlindi == false)
        {
            disliHizUpgUnite.SetActive(false);
            disliIncUpgUnite.SetActive(false);
        }
        else
        {
            disliHizUpgUnite.SetActive(true);
            disliIncUpgUnite.SetActive(true);
        }
        #endregion

        //Odun////////////////////////////////////////

        #region wood spd upg cost gösterim
        if (woodSpdUpgCost < 1000000)
        {
            woodSpdUpgCostText.text = string.Format("${0:#.0}", woodSpdUpgCost);
        }
        else if (woodSpdUpgCost >= 1000000)
        {
            woodSpdUpgCostText.text = (woodSpdUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (woodSpdUpgCost >= 1000000000)
        {
            woodSpdUpgCostText.text = (woodSpdUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (woodSpdUpgCost >= 1000000000000)
        {
            woodSpdUpgCostText.text = (woodSpdUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (woodSpdUpgCost >= 1000000000000000)
        {
            woodSpdUpgCostText.text = (woodSpdUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (woodSpdUpgCost >= 1000000000000000000)
        {
            woodSpdUpgCostText.text = (woodSpdUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion        

        #region you need $ cost gösterim speed upgrade
        if (woodSpdUpgCost < 1000000)
        {
            woodspdyouneeddollartext.text = string.Format("You Need ${0:#.0}", woodSpdUpgCost);
        }
        else if (woodSpdUpgCost >= 1000000)
        {
            woodspdyouneeddollartext.text = "You Need $" + (woodSpdUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (woodSpdUpgCost >= 1000000000)
        {
            woodspdyouneeddollartext.text = "You Need $" + (woodSpdUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (woodSpdUpgCost >= 1000000000000)
        {
            woodspdyouneeddollartext.text = "You Need $" + (woodSpdUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (woodSpdUpgCost >= 1000000000000000)
        {
            woodspdyouneeddollartext.text = "You Need $" + (woodSpdUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (woodSpdUpgCost >= 1000000000000000000)
        {
            woodspdyouneeddollartext.text = "You Need $" + (woodSpdUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region wood inc upg cost gösterim
        if (woodIncUpgCost < 1000000)
        {
            woodIncUpgCostText.text = string.Format("${0:#.0}", woodIncUpgCost);
        }
        else if (woodIncUpgCost >= 1000000)
        {
            woodIncUpgCostText.text = (woodIncUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (woodIncUpgCost >= 1000000000)
        {
            woodIncUpgCostText.text = (woodIncUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (woodIncUpgCost >= 1000000000000)
        {
            woodIncUpgCostText.text = (woodIncUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (woodIncUpgCost >= 1000000000000000)
        {
            woodIncUpgCostText.text = (woodIncUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (woodIncUpgCost >= 1000000000000000000)
        {
            woodIncUpgCostText.text = (woodIncUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region you need $ cost gösterim income upgrade
        if (woodIncUpgCost < 1000000)
        {
            woodincyouneeddollartext.text = string.Format("You Need ${0:#.0}", woodIncUpgCost);
        }
        else if (woodIncUpgCost >= 1000000)
        {
            woodincyouneeddollartext.text = "You Need $" + (woodIncUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (woodIncUpgCost >= 1000000000)
        {
            woodincyouneeddollartext.text = "You Need $" + (woodIncUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (woodIncUpgCost >= 1000000000000)
        {
            woodincyouneeddollartext.text = "You Need $" + (woodIncUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (woodIncUpgCost >= 1000000000000000)
        {
            woodincyouneeddollartext.text = "You Need $" + (woodIncUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (woodIncUpgCost >= 1000000000000000000)
        {
            woodincyouneeddollartext.text = "You Need $" + (woodIncUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        //Demir ore////////////////////////////////////////////

        #region demir ore hýz upg cost gösterim
        if (demirOreSpdUpgCost < 1000000)
        {
            demirOreSpdUpgCostText.text = string.Format("${0:#.0}", demirOreSpdUpgCost);
        }
        else if (demirOreSpdUpgCost >= 1000000)
        {
            demirOreSpdUpgCostText.text = (demirOreSpdUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (demirOreSpdUpgCost >= 1000000000)
        {
            demirOreSpdUpgCostText.text = (demirOreSpdUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (demirOreSpdUpgCost >= 1000000000000)
        {
            demirOreSpdUpgCostText.text = (demirOreSpdUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (demirOreSpdUpgCost >= 1000000000000000)
        {
            demirOreSpdUpgCostText.text = (demirOreSpdUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (demirOreSpdUpgCost >= 1000000000000000000)
        {
            demirOreSpdUpgCostText.text = (demirOreSpdUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region you need $ cost gösterim hýz upgrade
        if (demirOreSpdUpgCost < 1000000)
        {
            demirOrespdyouneeddollartext.text = string.Format("You Need ${0:#.0}", demirOreSpdUpgCost);
        }
        else if (demirOreSpdUpgCost >= 1000000)
        {
            demirOrespdyouneeddollartext.text = "You Need $" + (demirOreSpdUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (demirOreSpdUpgCost >= 1000000000)
        {
            demirOrespdyouneeddollartext.text = "You Need $" + (demirOreSpdUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (demirOreSpdUpgCost >= 1000000000000)
        {
            demirOrespdyouneeddollartext.text = "You Need $" + (demirOreSpdUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (demirOreSpdUpgCost >= 1000000000000000)
        {
            demirOrespdyouneeddollartext.text = "You Need $" + (demirOreSpdUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (demirOreSpdUpgCost >= 1000000000000000000)
        {
            demirOrespdyouneeddollartext.text = "You Need $" + (demirOreSpdUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region demir ore income upg cost gösterim
        if (demirOreIncUpgCost < 1000000)
        {
            demirOreIncUpgCostText.text = string.Format("${0:#.0}", demirOreIncUpgCost);
        }
        else if (demirOreIncUpgCost >= 1000000)
        {
            demirOreIncUpgCostText.text = (demirOreIncUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (demirOreIncUpgCost >= 1000000000)
        {
            demirOreIncUpgCostText.text = (demirOreIncUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (demirOreIncUpgCost >= 1000000000000)
        {
            demirOreIncUpgCostText.text = (demirOreIncUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (demirOreIncUpgCost >= 1000000000000000)
        {
            demirOreIncUpgCostText.text = (demirOreIncUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (demirOreIncUpgCost >= 1000000000000000000)
        {
            demirOreIncUpgCostText.text = (demirOreIncUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region you need $ cost gösterim income upgrade
        if (demirOreIncUpgCost < 1000000)
        {
            demirOreincyouneeddollartext.text = string.Format("You Need ${0:#.0}", demirOreIncUpgCost);
        }
        else if (demirOreIncUpgCost >= 1000000)
        {
            demirOreincyouneeddollartext.text = "You Need $" + (demirOreIncUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (demirOreIncUpgCost >= 1000000000)
        {
            demirOreincyouneeddollartext.text = "You Need $" + (demirOreIncUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (demirOreIncUpgCost >= 1000000000000)
        {
            demirOreincyouneeddollartext.text = "You Need $" + (demirOreIncUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (demirOreIncUpgCost >= 1000000000000000)
        {
            demirOreincyouneeddollartext.text = "You Need $" + (demirOreIncUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (demirOreIncUpgCost >= 1000000000000000000)
        {
            demirOreincyouneeddollartext.text = "You Need $" + (demirOreIncUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        //Kereste///////////////////////////////////////////

        #region timber spd upg cost gösterim
        if (timberSpdUpgCost < 1000000)
        {
            timberSpdUpgCostText.text = string.Format("${0:#.0}", timberSpdUpgCost);
        }
        else if (timberSpdUpgCost >= 1000000)
        {
            timberSpdUpgCostText.text = (timberSpdUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (timberSpdUpgCost >= 1000000000)
        {
            timberSpdUpgCostText.text = (timberSpdUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (timberSpdUpgCost >= 1000000000000)
        {
            timberSpdUpgCostText.text = (timberSpdUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (timberSpdUpgCost >= 1000000000000000)
        {
            timberSpdUpgCostText.text = (timberSpdUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (timberSpdUpgCost >= 1000000000000000000)
        {
            timberSpdUpgCostText.text = (timberSpdUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region you need $ cost gösterim speed upgrade
        if (timberSpdUpgCost < 1000000)
        {
            timberspdyouneeddollartext.text = string.Format("You Need ${0:#.0}", timberSpdUpgCost);
        }
        else if (timberSpdUpgCost >= 1000000)
        {
            timberspdyouneeddollartext.text = "You Need $" + (timberSpdUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (timberSpdUpgCost >= 1000000000)
        {
            timberspdyouneeddollartext.text = "You Need $" + (timberSpdUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (timberSpdUpgCost >= 1000000000000)
        {
            timberspdyouneeddollartext.text = "You Need $" + (timberSpdUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (timberSpdUpgCost >= 1000000000000000)
        {
            timberspdyouneeddollartext.text = "You Need $" + (timberSpdUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (timberSpdUpgCost >= 1000000000000000000)
        {
            timberspdyouneeddollartext.text = "You Need $" + (timberSpdUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region timber inc upg cost gösterim
        if (timberIncUpgCost < 1000000)
        {
            timberIncUpgCostText.text = string.Format("${0:#.0}", timberIncUpgCost);
        }
        else if (timberIncUpgCost >= 1000000)
        {
            timberIncUpgCostText.text = (timberIncUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (timberIncUpgCost >= 1000000000)
        {
            timberIncUpgCostText.text = (timberIncUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (timberIncUpgCost >= 1000000000000)
        {
            timberIncUpgCostText.text = (timberIncUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (timberIncUpgCost >= 1000000000000000)
        {
            timberIncUpgCostText.text = (timberIncUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (timberIncUpgCost >= 1000000000000000000)
        {
            timberIncUpgCostText.text = (timberIncUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region you need $ cost gösterim income upgrade
        if (timberIncUpgCost < 1000000)
        {
            timberincyouneeddollartext.text = string.Format("You Need ${0:#.0}", timberIncUpgCost);
        }
        else if (timberIncUpgCost >= 1000000)
        {
            timberincyouneeddollartext.text = "You Need $" + (timberIncUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (timberIncUpgCost >= 1000000000)
        {
            timberincyouneeddollartext.text = "You Need $" + (timberIncUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (timberIncUpgCost >= 1000000000000)
        {
            timberincyouneeddollartext.text = "You Need $" + (timberIncUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (timberIncUpgCost >= 1000000000000000)
        {
            timberincyouneeddollartext.text = "You Need $" + (timberIncUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (timberIncUpgCost >= 1000000000000000000)
        {
            timberincyouneeddollartext.text = "You Need $" + (timberIncUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        //Külçe///////////////////////////////////////////

        #region Külçe spd upg cost Gösterim
        if (kulceSpdUpgCost < 1000000)
        {
            kulceSpdUpgCostText.text = string.Format("${0:#.0}", kulceSpdUpgCost);
        }
        else if (kulceSpdUpgCost >= 1000000)
        {
            kulceSpdUpgCostText.text = (kulceSpdUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (kulceSpdUpgCost >= 1000000000)
        {
            kulceSpdUpgCostText.text = (kulceSpdUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (kulceSpdUpgCost >= 1000000000000)
        {
            kulceSpdUpgCostText.text = (kulceSpdUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (kulceSpdUpgCost >= 1000000000000000)
        {
            kulceSpdUpgCostText.text = (kulceSpdUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (kulceSpdUpgCost >= 1000000000000000000)
        {
            kulceSpdUpgCostText.text = (kulceSpdUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region you need $ cost gösterim speed upgrade
        if (kulceSpdUpgCost < 1000000)
        {
            kulcespdyouneeddollartext.text = string.Format("You Need ${0:#.0}", kulceSpdUpgCost);
        }
        else if (kulceSpdUpgCost >= 1000000)
        {
            kulcespdyouneeddollartext.text = "You Need $" + (kulceSpdUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (kulceSpdUpgCost >= 1000000000)
        {
            kulcespdyouneeddollartext.text = "You Need $" + (kulceSpdUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (kulceSpdUpgCost >= 1000000000000)
        {
            kulcespdyouneeddollartext.text = "You Need $" + (kulceSpdUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (kulceSpdUpgCost >= 1000000000000000)
        {
            kulcespdyouneeddollartext.text = "You Need $" + (kulceSpdUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (kulceSpdUpgCost >= 1000000000000000000)
        {
            kulcespdyouneeddollartext.text = "You Need $" + (kulceSpdUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region kulce inc upg cost gösterim
        if (kulceIncUpgCost < 1000000)
        {
            kulceIncUpgCostText.text = string.Format("${0:#.0}", kulceIncUpgCost);
        }
        else if (kulceIncUpgCost >= 1000000)
        {
            kulceIncUpgCostText.text = (kulceIncUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (kulceIncUpgCost >= 1000000000)
        {
            kulceIncUpgCostText.text = (kulceIncUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (kulceIncUpgCost >= 1000000000000)
        {
            kulceIncUpgCostText.text = (kulceIncUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (kulceIncUpgCost >= 1000000000000000)
        {
            kulceIncUpgCostText.text = (kulceIncUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (kulceIncUpgCost >= 1000000000000000000)
        {
            kulceIncUpgCostText.text = (kulceIncUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region you need $ cost gösterim income upgrade
        if (kulceIncUpgCost < 1000000)
        {
            kulceincyouneeddollartext.text = string.Format("You Need ${0:#.0}", kulceIncUpgCost);
        }
        else if (kulceIncUpgCost >= 1000000)
        {
            kulceincyouneeddollartext.text = "You Need $" + (kulceIncUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (kulceIncUpgCost >= 1000000000)
        {
            kulceincyouneeddollartext.text = "You Need $" + (kulceIncUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (kulceIncUpgCost >= 1000000000000)
        {
            kulceincyouneeddollartext.text = "You Need $" + (kulceIncUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (kulceIncUpgCost >= 1000000000000000)
        {
            kulceincyouneeddollartext.text = "You Need $" + (kulceIncUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (kulceIncUpgCost >= 1000000000000000000)
        {
            kulceincyouneeddollartext.text = "You Need $" + (kulceIncUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        //Çivi///////////////////////////////////////////

        #region Çivi spd upg cost gösterim
        if (civiSpdUpgCost < 1000000)
        {
            civiSpdUpgCostText.text = string.Format("${0:#.0}", civiSpdUpgCost);
        }
        else if (civiSpdUpgCost >= 1000000)
        {
            civiSpdUpgCostText.text = (civiSpdUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (civiSpdUpgCost >= 1000000000)
        {
            civiSpdUpgCostText.text = (civiSpdUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (civiSpdUpgCost >= 1000000000000)
        {
            civiSpdUpgCostText.text = (civiSpdUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (civiSpdUpgCost >= 1000000000000000)
        {
            civiSpdUpgCostText.text = (civiSpdUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (civiSpdUpgCost >= 1000000000000000000)
        {
            civiSpdUpgCostText.text = (civiSpdUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region You need $ cost gösterim speed upgrade
        if (civiSpdUpgCost < 1000000)
        {
            civispdyouneeddollartext.text = string.Format("You Need ${0:#.0}", civiSpdUpgCost);
        }
        else if (civiSpdUpgCost >= 1000000)
        {
            civispdyouneeddollartext.text = "You Need $" + (civiSpdUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (civiSpdUpgCost >= 1000000000)
        {
            civispdyouneeddollartext.text = "You Need $" + (civiSpdUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (civiSpdUpgCost >= 1000000000000)
        {
            civispdyouneeddollartext.text = "You Need $" + (civiSpdUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (civiSpdUpgCost >= 1000000000000000)
        {
            civispdyouneeddollartext.text = "You Need $" + (civiSpdUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (civiSpdUpgCost >= 1000000000000000000)
        {
            civispdyouneeddollartext.text = "You Need $" + (civiSpdUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region civi inc upg upg cost gösterim
        if (civiIncUpgCost < 1000000)
        {
            civiIncUpgCostText.text = string.Format("${0:#.0}", civiIncUpgCost);
        }
        else if (civiIncUpgCost >= 1000000)
        {
            civiIncUpgCostText.text = (civiIncUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (civiIncUpgCost >= 1000000000)
        {
            civiIncUpgCostText.text = (civiIncUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (civiIncUpgCost >= 1000000000000)
        {
            civiIncUpgCostText.text = (civiIncUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (civiIncUpgCost >= 1000000000000000)
        {
            civiIncUpgCostText.text = (civiIncUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (civiIncUpgCost >= 1000000000000000000)
        {
            civiIncUpgCostText.text = (civiIncUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region you need $ cost gösterim income upgrade
        if (civiIncUpgCost < 1000000)
        {
            kulceincyouneeddollartext.text = string.Format("You Need ${0:#.0}", civiIncUpgCost);
        }
        else if (civiIncUpgCost >= 1000000)
        {
            civiincyouneeddollartext.text = "You Need $" + (civiIncUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (civiIncUpgCost >= 1000000000)
        {
            civiincyouneeddollartext.text = "You Need $" + (civiIncUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (civiIncUpgCost >= 1000000000000)
        {
            civiincyouneeddollartext.text = "You Need $" + (civiIncUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (civiIncUpgCost >= 1000000000000000)
        {
            civiincyouneeddollartext.text = "You Need $" + (civiIncUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (civiIncUpgCost >= 1000000000000000000)
        {
            civiincyouneeddollartext.text = "You Need $" + (civiIncUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        //Diþli/////////////////////////////////////////

        #region Diþli spd upg cost gösterim
        if (disliSpdUpgCost < 1000000)
        {
            disliSpdUpgCostText.text = string.Format("${0:#.0}", disliSpdUpgCost);
        }
        else if (disliSpdUpgCost >= 1000000)
        {
            disliSpdUpgCostText.text = (disliSpdUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (disliSpdUpgCost >= 1000000000)
        {
            disliSpdUpgCostText.text = (disliSpdUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (disliSpdUpgCost >= 1000000000000)
        {
            disliSpdUpgCostText.text = (disliSpdUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (disliSpdUpgCost >= 1000000000000000)
        {
            disliSpdUpgCostText.text = (disliSpdUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (disliSpdUpgCost >= 1000000000000000000)
        {
            disliSpdUpgCostText.text = (disliSpdUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region You need $ cost gösterim income upgrade
        if (disliSpdUpgCost < 1000000)
        {
            dislispdyouneeddollartext.text = string.Format("You Need ${0:#.0}", disliSpdUpgCost);
        }
        else if (disliSpdUpgCost >= 1000000)
        {
            dislispdyouneeddollartext.text = "You Need $" + (disliSpdUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (disliSpdUpgCost >= 1000000000)
        {
            dislispdyouneeddollartext.text = "You Need $" + (disliSpdUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (disliSpdUpgCost >= 1000000000000)
        {
            dislispdyouneeddollartext.text = "You Need $" + (disliSpdUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (disliSpdUpgCost >= 1000000000000000)
        {
            dislispdyouneeddollartext.text = "You Need $" + (disliSpdUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (disliSpdUpgCost >= 1000000000000000000)
        {
            dislispdyouneeddollartext.text = "You Need $" + (disliSpdUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region Disli inc upg cost gösterim
        if (disliIncUpgCost < 1000000)
        {
            disliIncUpgCostText.text = string.Format("${0:#.0}", disliIncUpgCost);
        }
        else if (disliIncUpgCost >= 1000000)
        {
            disliIncUpgCostText.text = (disliIncUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (disliIncUpgCost >= 1000000000)
        {
            disliIncUpgCostText.text = (disliIncUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (disliIncUpgCost >= 1000000000000)
        {
            disliIncUpgCostText.text = (disliIncUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (disliIncUpgCost >= 1000000000000000)
        {
            disliIncUpgCostText.text = (disliIncUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (disliIncUpgCost >= 1000000000000000000)
        {
            disliIncUpgCostText.text = (disliIncUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region You need $ cost gösterim income upgrade
        if (disliIncUpgCost < 1000000)
        {
            disliincyouneeddollartext.text = string.Format("You Need ${0:#.0}", disliIncUpgCost);
        }
        else if (disliIncUpgCost >= 1000000)
        {
            disliincyouneeddollartext.text = "You Need $" + (disliIncUpgCost / 1000000).ToString("F") + " Mil.";
        }
        else if (disliIncUpgCost >= 1000000000)
        {
            disliincyouneeddollartext.text = "You Need $" + (disliIncUpgCost / 1000000000).ToString("F") + " Bil.";
        }
        else if (disliIncUpgCost >= 1000000000000)
        {
            disliincyouneeddollartext.text = "You Need $" + (disliIncUpgCost / 1000000000000).ToString("F") + " Tril.";
        }
        else if (disliIncUpgCost >= 1000000000000000)
        {
            disliincyouneeddollartext.text = "You Need $" + (disliIncUpgCost / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if (disliIncUpgCost >= 1000000000000000000)
        {
            disliincyouneeddollartext.text = "You Need $" + (disliIncUpgCost / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #endregion//Upgrade Textleri

        #region Para yetmiyorsa butonlarý kapat

        #region Odun

        #region Odun menajer satýn al butonu
        if (GameManager.gm.anaPara < 200)
        {
            buyWoodmanBtn.SetActive(false);
        }
        else
        {
            buyWoodmanBtn.SetActive(true);
        }
        if (odunMenajerAlindi == true)
        {
            buyWoodmanBtn.SetActive(false);
        }
        #endregion

        #region Odun Hýz Upg satýn al butonu
        if (GameManager.gm.anaPara < woodSpdUpgCost)
        {
            woodSpdUpgBuyBtn.SetActive(false);
        }
        else
        {
            woodSpdUpgBuyBtn.SetActive(true);
        }
        #endregion

        #region odun income upg butonu
        if (GameManager.gm.anaPara >= woodIncUpgCost)
        {
            woodincUpgBtn.SetActive(true);
        }
        else
        {
            woodincUpgBtn.SetActive(false);
        }
        #endregion

        #endregion

        #region Demir

        #region Hire miner buton
        if (demirOreMenajerAlindi == true)
        {
            buyMinerBtn.SetActive(false);
        }
        else
        {
            if (GameManager.gm.anaPara >= 500)
            {
                buyMinerBtn.SetActive(true);
            }
            else
            {
                buyMinerBtn.SetActive(false);
            }
        }
        
        #endregion

        #region demir ore hýz upg satýn al butonu
        if (GameManager.gm.anaPara < demirOreSpdUpgCost)
        {
            demirOreSpdUpgBuyBtn.SetActive(false);
        }
        else
        {
            demirOreSpdUpgBuyBtn.SetActive(true);
        }
        #endregion

        #region Demir Ore income upg satýn al butonu
        if (GameManager.gm.anaPara >= demirOreIncUpgCost)
        {
            demirOreIncUpgBuyBtn.SetActive(true);
        }
        else
        {
            demirOreIncUpgBuyBtn.SetActive(false);
        }
        #endregion

        #endregion

        #region Kereste

        #region Buy saw building button
        if ((GameManager.gm.odunStok >= 100) && (GameManager.gm.anaPara >= 350))
        {
            buySawButton.SetActive(true);
        }
        else
        {
            buySawButton.SetActive(false);
        }
        if (keresteAlindi == true)
        {
            buySawButton.SetActive(false);
        }
        else
        {
            kerestefillbar.SetActive(false);
        }
        #endregion

        #region kereste hýz upg satýn al butonu
        if (GameManager.gm.anaPara < timberSpdUpgCost)
        {
            timberSpdUpgBuyBtn.SetActive(false);
        }
        else
        {
            timberSpdUpgBuyBtn.SetActive(true);
        }
        #endregion        

        #region kereste getiri upg butonu
        if (GameManager.gm.anaPara >= timberIncUpgCost)
        {
            timberincUpgBtn.SetActive(true);
        }
        else
        {
            timberincUpgBtn.SetActive(false);
        }
        #endregion

        #region Buy Carpenter butonu
        if (keresteMenajerAlindi == true)
        {
            buyCarpenterBtn.SetActive(false);
        }
        else
        {
            if (GameManager.gm.anaPara < 1200)
            {
                buyCarpenterBtn.SetActive(false);
            }
            else
            {
                buyCarpenterBtn.SetActive(true);
            }
        }
        #endregion

        #region Menü Carpenter ünitesi
        if (keresteAlindi == false)
        {
            carpenterUnite.SetActive(false);
        }
        else
        {
            carpenterUnite.SetActive(true);
        }
        #endregion

        #region kereste üret butonu, odun yoksa
        if (GameManager.gm.odunStok <= 0)
        {
            keresteUretButon.SetActive(false);
        }
        else
        {
            keresteUretButon.SetActive(true);
        }
        #endregion

        #region kereste ui, bina alýnýnca açýlacak
        if (keresteAlindi == false)
        {
            keresteUi.SetActive(false);
            keresteSatUnite.SetActive(false);
        }
        else
        {
            keresteUi.SetActive(true);
            keresteSatUnite.SetActive(true);
        }
        #endregion

        #endregion

        #region Külçe

        #region Buy Oven building button
        if ((GameManager.gm.demirOreStok >= 100) && (GameManager.gm.anaPara >= 850) && (GameManager.gm.odunStok >= 50))
        {
            buyOvenButton.SetActive(true);
        }
        else
        {
            buyOvenButton.SetActive(false);
        }
        if (kulceAlindi == true)
        {
            buyOvenButton.SetActive(false);
        }
        else
        {
            kulcefillbar.SetActive(false);
        }
        #endregion

        #region külçe hýz upg satýn al butonu
        if (GameManager.gm.anaPara < kulceSpdUpgCost)
        {
            kulceSpdUpgBuyBtn.SetActive(false);
        }
        else
        {
            kulceSpdUpgBuyBtn.SetActive(true);
        }
        #endregion

        #region Külçe income upg butonu
        if (GameManager.gm.anaPara >= kulceIncUpgCost)
        {
            kulceincUpgBtn.SetActive(true);
        }
        else
        {
            kulceincUpgBtn.SetActive(false);
        }
        #endregion

        #region Buy IronBaker buton
        if (kulceMenajerAlindi == true)
        {
            buyIronBakerBtn.SetActive(false);
        }
        else
        {
            if (GameManager.gm.anaPara < 1600)
            {
                buyIronBakerBtn.SetActive(false);
            }
            else
            {
                buyIronBakerBtn.SetActive(true);
            }
        }
        #endregion

        #region Menü IronBaker ünitesi
        if (kulceAlindi == false)
        {
            ironBakerUnite.SetActive(false);
        }
        else
        {
            ironBakerUnite.SetActive(true);
        }
        #endregion

        #region Külçe üret butonu, odun demir yoksa
        if ((GameManager.gm.odunStok <= 0) && (GameManager.gm.demirOreStok <= 0))
        {
            kulceUretButon.SetActive(false);
        }
        else
        {
            kulceUretButon.SetActive(true);
        }
        #endregion

        #region Külçe ui, bina alýnýnca açýlacak
        if (kulceAlindi == false)
        {
            kulceUi.SetActive(false);
            kulceSatUnite.SetActive(false);
        }
        else
        {
            kulceUi.SetActive(true);
            kulceSatUnite.SetActive(true);
        }
        #endregion

        #endregion

        #region Çivi

        #region Buy Nail building button
        if ((GameManager.gm.kulceStok >= 120) && (GameManager.gm.anaPara >= 1250) && (GameManager.gm.odunStok >= 75))
        {
            buyNailButton.SetActive(true);
        }
        else
        {
            buyNailButton.SetActive(false);
        }
        if (civiAlindi == true)
        {
            buyNailButton.SetActive(false);
        }
        else
        {
            civifillbar.SetActive(false);
        }
        #endregion

        #region civi hýz upg satýn al butonu
        if (GameManager.gm.anaPara < civiSpdUpgCost)
        {
            civiSpdUpgBuyBtn.SetActive(false);
        }
        else
        {
            civiSpdUpgBuyBtn.SetActive(true);
        }
        #endregion

        #region civi income upg butonu
        if (GameManager.gm.anaPara >= civiIncUpgCost)
        {
            civiincUpgBtn.SetActive(true);
        }
        else
        {
            civiincUpgBtn.SetActive(false);
        }
        #endregion

        #region Buy civimngr buton
        if (civiMenajerAlindi == true)
        {
            buyNailMngrBtn.SetActive(false);
        }
        else
        {
            if (GameManager.gm.anaPara < 2200)
            {
                buyNailMngrBtn.SetActive(false);
            }
            else
            {
                buyNailMngrBtn.SetActive(true);
            }
        }
        #endregion

        #region Menü CiviManager ünitesi
        if (civiAlindi == false)
        {
            civiMngrUnite.SetActive(false);
        }
        else
        {
            civiMngrUnite.SetActive(true);
        }
        #endregion

        #region civi üret butonu, odun külçe yoksa
        if ((GameManager.gm.odunStok <= 0) | (GameManager.gm.kulceStok <= 0))
        {
            civiUretButon.SetActive(false);
        }
        else
        {
            civiUretButon.SetActive(true);
        }
        #endregion

        #region civi ui, bina alýnýnca açýlacak
        if (civiAlindi == false)
        {
            civiUi.SetActive(false);
            civiSatUnite.SetActive(false);
        }
        else
        {
            civiUi.SetActive(true);
            civiSatUnite.SetActive(true);
        }
        #endregion

        #endregion

        #region Diþli

        #region Buy Gear Building Button
        if ((GameManager.gm.kulceStok >= 150) && (GameManager.gm.anaPara >= 1500) && (GameManager.gm.odunStok >= 100))
        {
            buyGearButton.SetActive(true);
        }
        else
        {
            buyGearButton.SetActive(false);
        }
        if (disliAlindi == true)
        {
            buyGearButton.SetActive(false);
        }
        else
        {
            dislifillbar.SetActive(false);
        }
        #endregion

        #region disli hýz upg satýn al butonu
        if (GameManager.gm.anaPara < disliSpdUpgCost)
        {
            disliSpdUpgBuyBtn.SetActive(false);
        }
        else
        {
            disliSpdUpgBuyBtn.SetActive(true);
        }
        #endregion

        #region Diþli income upgrade button
        if (GameManager.gm.anaPara >= disliIncUpgCost)
        {
            disliincUpgBtn.SetActive(true);
        }
        else
        {
            disliincUpgBtn.SetActive(false);
        }
        #endregion

        #region Buy dislimngr buton
        if (disliMenajerAlindi == true)
        {
            buyGearMngrBtn.SetActive(false);
        }
        else
        {
            if (GameManager.gm.anaPara < 2200)
            {
                buyGearMngrBtn.SetActive(false);
            }
            else
            {
                buyGearMngrBtn.SetActive(true);
            }
        }
        #endregion

        #region Menü dislimenager ünitesi
        if (disliAlindi == false)
        {
            disliMngrUnite.SetActive(false);
        }
        else
        {
            disliMngrUnite.SetActive(true);
        }
        #endregion

        #region Diþli üret butonu, odun külçe yoksa
        if ((GameManager.gm.odunStok <= 0) | (GameManager.gm.kulceStok <= 0))
        {
            disliUretButon.SetActive(false);
        }
        else
        {
            disliUretButon.SetActive(true);
        }
        #endregion

        #region Diþli ui, bina alýnýnca açýlacak
        if (disliAlindi == false)
        {
            disliUi.SetActive(false);
            disliSatUnite.SetActive(false);
        }
        else
        {
            disliUi.SetActive(true);
            disliSatUnite.SetActive(true);
        }
        #endregion

        #endregion

        #endregion

        #region woodSpeedUpgCost fiyat hesaplama
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

        #region woodIncomeUpgCost ilk üç level fiyatý
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameManager.gm.ChangeWorldsButton();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.gm.MenuButton();
        }
        #endregion

        #region Save Load'da sorun çýkaranlarý düzeltmek
        if (odunMenajerAlindi == true)
        {
            cutBtn.SetActive(false);
        }
        else
        {
            cutBtn.SetActive(true);
        }
        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        if (demirOreMenajerAlindi == true)
        {
            digBtn.SetActive(false);
        }
        else
        {
            digBtn.SetActive(true);
        }
        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        if (keresteAlindi == true)
        {
            keresteBinaCitleri.SetActive(false);
            keresteBina.SetActive(true);
        }
        else
        {
            keresteBinaCitleri.SetActive(true);
            keresteBina.SetActive(false);
        }
        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        if (kulceAlindi == true)
        {
            kulceBinaCitleri.SetActive(false);
            kulceBina.SetActive(true);
        }
        else
        {
            kulceBinaCitleri.SetActive(true);
            kulceBina.SetActive(false);
        }
        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        if (civiAlindi == true)
        {
            civiBinaCitleri.SetActive(false);
            civiBina.SetActive(true);
        }
        else
        {
            civiBinaCitleri.SetActive(true);
            civiBina.SetActive(false);
        }
        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        if (disliAlindi == true)
        {
            disliBinaCitleri.SetActive(false);
            disliBina.SetActive(true);
        }
        else
        {
            disliBinaCitleri.SetActive(true);
            disliBina.SetActive(false);
        }
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

    #endregion

}
