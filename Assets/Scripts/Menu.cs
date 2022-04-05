#region K�t�phaneler
using UnityEngine;
using UnityEngine.UI;
using static System.Math;
using Sirenix.OdinInspector;
#endregion

public class Menu : MonoBehaviour
{
    public static Menu menu; //singleton i�in
    public static GameManager gm;

    #region De�i�kenler

    #region Odun
    [BoxGroup("ODUN")]
    [FoldoutGroup("ODUN/Bool")]
    public bool odunMenajerAlindi;      //menajer al�n�nca true oluyor, true olunca �retim otomatikle�iyor
    [FoldoutGroup("ODUN/Bool")]
    public bool saveIcinCutButonBool;   //save load yap�ld���nda menajer al�nd��� halde cut buton kal�yor, d�zeltmek i�in


    [FoldoutGroup("ODUN/Upgrade Seviyeleri")]
    public int woodIncUpgLvl;           //odun gelir upg seviyesi
    [FoldoutGroup("ODUN/Upgrade Seviyeleri")]
    public int woodSpdUpgLvl;           //odun h�z upg seviyesi


    [FoldoutGroup("ODUN/Upgrade �cretleri")]
    public float woodSpdUpgCost;        //odun h�z upg i�in gereken para
    [FoldoutGroup("ODUN/Upgrade �cretleri")]
    public float woodIncUpgCost;        //odun gelir upg i�in gereken para


    [FoldoutGroup("ODUN/Speed Upgrade Textleri")]
    public Text woodSpdUpgLvlText;          //odun h�z upg seviye text
    [FoldoutGroup("ODUN/Speed Upgrade Textleri")]
    public Text woodSpdUpgCostText;         //odun h�z upg �cret text
    [FoldoutGroup("ODUN/Speed Upgrade Textleri")]
    public Text woodspdyouneeddollartext;   //para yetmiyorsa ne kadar gerekti�ini yaz�yor
    [FoldoutGroup("ODUN/Income Upgrade Textleri")]
    public Text woodIncUpgLvlText;          //odun gelir upg seviye text
    [FoldoutGroup("ODUN/Income Upgrade Textleri")]
    public Text woodincyouneeddollartext;   //para yetmiyorsa ne kadar gerekti�ini yaz�yor
    [FoldoutGroup("ODUN/Income Upgrade Textleri")]
    public Text woodIncUpgCostText;         //odun gelir upg �cret text


    [FoldoutGroup("ODUN/Gameobjectler")]
    public GameObject balta;
    [FoldoutGroup("ODUN/Gameobjectler")]
    public GameObject woodSpdUpgBuyBtn;         //odun h�z upg sat�n al butonu
    [FoldoutGroup("ODUN/Gameobjectler")]
    public GameObject woodincUpgBtn;            //odun gelir upg butonu    
    [FoldoutGroup("ODUN/Gameobjectler")]
    public GameObject cutBtn;                   //cut butonu
    [FoldoutGroup("ODUN/Gameobjectler")]
    public GameObject buyWoodmanBtn;            //odun menajer butonu
    [FoldoutGroup("ODUN/Gameobjectler")]
    public GameObject woodmgrNotEnoMnyText;     //menajer i�in yeterli para yok text, menajer sat�n al�nca setactive'ini kapatmak i�in


    [FoldoutGroup("ODUN/Fillbarlar")]
    public float odunTime;               //fillbar kontrol�
    [FoldoutGroup("ODUN/Fillbarlar")]
    public Image odunFillbar;            //fillbar pngsi
    [FoldoutGroup("ODUN/Fillbarlar")]
    public float oduntimer;              //Bunu time'a b�ld�rerek fillbar� kontrol ediyorum
    [FoldoutGroup("ODUN/Fillbarlar")]
    public float odunZamanCarpan;        //fillbar�n ne kadar h�zl� dolaca��n� belirliyor
    #endregion

    #region Demir
    [BoxGroup("DEM�R")]
    [FoldoutGroup("DEM�R/Bool")]
    public bool demirOreMenajerAlindi;         //menajer al�n�nca true olarak �retimi otomatikle�tiriyor


    [FoldoutGroup("DEM�R/Upgrade Seviyeleri")]
    public int demirOreSpdUpgLvl;           //DemirOre h�z upgrade seviyesi, ka� kere sat�n al�nd���
    [FoldoutGroup("DEM�R/Upgrade Seviyeleri")]
    public int demirOreIncUpgLvl;           //DemirOre income upgrade seviyesi, ka� kere sat�n al�nd���


    [FoldoutGroup("DEM�R/Upgrade �cretleri")]
    public float demirOreSpdUpgCost;        //demirore h�z upgrade i�in gereken para
    [FoldoutGroup("DEM�R/Upgrade �cretleri")]
    public float demirOreIncUpgCost;        //demirore income upgrade i�in gereken para


    [FoldoutGroup("DEM�R/Speed Upgrade Textleri")]
    public Text demirOreSpdUpgLvlText;          //demir ore h�z upg �cret text
    [FoldoutGroup("DEM�R/Speed Upgrade Textleri")]
    public Text demirOreSpdUpgCostText;         //demir ore h�z upg seviye text
    [FoldoutGroup("DEM�R/Speed Upgrade Textleri")]
    public Text demirOrespdyouneeddollartext;   //para yetmiyorsa ne kadar gerekti�ini yaz�yor
    [FoldoutGroup("DEM�R/Income Upgrade Textleri")]
    public Text demirOreIncUpgLvlText;          //demir ore gelir upg �cret text
    [FoldoutGroup("DEM�R/Income Upgrade Textleri")]
    public Text demirOreIncUpgCostText;         //demir ore h�z upg seviye text
    [FoldoutGroup("DEM�R/Income Upgrade Textleri")]
    public Text demirOreincyouneeddollartext;   //para yetmiyorsa ne kadar gerekti�ini yaz�yor


    [FoldoutGroup("DEM�R/GameObjectler")]
    public GameObject digBtn;                     //Demir ore kaz butonu
    [FoldoutGroup("DEM�R/GameObjectler")]
    public GameObject buyMinerBtn;                //Workers men�s�nde madenci sat�n al butonu, al�n�nca kapan�yor
    [FoldoutGroup("DEM�R/GameObjectler")]
    public GameObject demirOreMgrNotEnoMnyText;   //Menajer sat�n al butonu kapal�yken "�u kadar para laz�m" yazan text, sat�n al�n�nca kapan�yor
    [FoldoutGroup("DEM�R/GameObjectler")]
    public GameObject demirOreSpdUpgBuyBtn;       //demir ore h�z upgrade butonu
    [FoldoutGroup("DEM�R/GameObjectler")]
    public GameObject demirOreIncUpgBuyBtn;       //demir ore income upgrade butonu


    [FoldoutGroup("DEM�R/Fillbarlar")]
    public float demirTime;              //fillbar kontrol�
    [FoldoutGroup("DEM�R/Fillbarlar")]
    public Image demirFillbar;           //fillbar pngsi
    [FoldoutGroup("DEM�R/Fillbarlar")]
    public float demirTimer;             //Bunu time'a b�ld�rerek fillbar� kontrol ediyorum
    [FoldoutGroup("DEM�R/Fillbarlar")]
    public float demirZamanCarpan;       //fillbar�n ne kadar h�zl� dolaca��n� belirliyor
    #endregion

    #region Kereste
    [BoxGroup("KERESTE")]
    [FoldoutGroup("KERESTE/Bool")]
    public bool keresteMenajerAlindi;   //kereste otomatikle�tirilince true oluyor
    [FoldoutGroup("KERESTE/Bool")]
    public bool keresteAlindi;          //kereste binas� al�n�nca tu�u tekrar a��lmas�n diye


    [FoldoutGroup("KERESTE/Upgrade Seviyeleri")]
    public int timberIncUpgLvl;         //kereste gelir upg seviyesi
    [FoldoutGroup("KERESTE/Upgrade Seviyeleri")]
    public int timberSpdUpgLvl;         //kereste h�z upg seviyesi


    [FoldoutGroup("KERESTE/Upgrade �cretleri")]
    public float timberSpdUpgCost;      //kereste h�z upg i�in gereken para
    [FoldoutGroup("KERESTE/Upgrade �cretleri")]
    public float timberIncUpgCost;      //kereste gelir upg i�in gereken para


    [FoldoutGroup("KERESTE/Speed Upgrade Textleri")]
    public Text timberSpdUpgLvlText;        //kereste h�z upg �cret text
    [FoldoutGroup("KERESTE/Speed Upgrade Textleri")]
    public Text timberSpdUpgCostText;       //kereste h�z upg seviye text
    [FoldoutGroup("KERESTE/Speed Upgrade Textleri")]
    public Text timberspdyouneeddollartext; //para yetmiyorsa ne kadar gerekti�ini yaz�yor


    [FoldoutGroup("KERESTE/Income Upgrade Textleri")]
    public Text timberIncUpgLvlText;        //kereste gelir upg seviye text
    [FoldoutGroup("KERESTE/Income Upgrade Textleri")]
    public Text timberincyouneeddollartext; //para yetmiyorsa ne kadar gerekti�ini yaz�yor
    [FoldoutGroup("KERESTE/Income Upgrade Textleri")]
    public Text timberIncUpgCostText;       //kereste h�z upg �cret text


    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject timberSpdUpgBuyBtn;     //h�z ve gelir upgrade butonlar�
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject timberincUpgBtn;        //h�z ve gelir upgrade butonlar�
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject buySawButton;           //Kereste binas� sat�n al butonu
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject buyCarpenterBtn;        //Kereste menajer sat�n alma butonu
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject keresteUretButon;       //bina al�n�nca kereste �reme butonu a��lacak
    [Space]
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject keresteHizUpgUnite;     //bina sat�n al�nmam��sa bu upgradeler g�z�km�yor
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject keresteIncUpgUnite;     //bina sat�n al�nmam��sa bu upgradeler g�z�km�yor
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject keresteSatUnite;        //bina sat�n al�nmam��sa kereste sat k�sm� g�z�km�yor
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject carpenterUnite;         //Bina sat�n al�nmam��sa marangoz al k�sm� g�z�km�yor
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject timberMgrNotEnoMnyText; //menajer i�in yeterli para yok text, menajer sat�n al�nca setactive'ini kapatmak i�in
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject timberBinaNotEnoMnyText;//bina i�in yeterli para yok text, menajer sat�n al�nca setactive'ini kapatmak i�in
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject keresteBinaCitleri;     //Kereste binas� sat�n al�n�nca �itleri kapataca��m
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject keresteBina;            //�itler kalk�nca yerine gelecek bina, sat�n al�n�nca a��lacak
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject kerestefillbar;         //kereste binas�n�n fillbar� ve butonu sat�n al�n�nca a��ls�n diye
    [FoldoutGroup("KERESTE/Gameobjectler")]
    public GameObject keresteUi;              //bina sat�n al�nd���nda g�z�ks�n
    
    
    [FoldoutGroup("KERESTE/Fillbar")]
    public Image keresteFillbar;         //fillbar pngsi
    [FoldoutGroup("KERESTE/Fillbar")]
    public float kerestetimer;           //Bunu time'a b�ld�rerek fillbar� kontrol ediyorum
    [FoldoutGroup("KERESTE/Fillbar")]
    public float keresteZamanCarpan;     //fillbar�n ne kadar h�zl� dolaca��n� belirliyor
    [FoldoutGroup("KERESTE/Fillbar")]
    public float keresteTime;            //fillbar kontrol�
    #endregion

    #region K�l�e
    [BoxGroup("K�L�E")]
    [FoldoutGroup("K�L�E/Booleans")]
    public bool kulceMenajerAlindi;             //menajer al�n�nca true olarak �retimi otomatikle�tiriyor
    [FoldoutGroup("K�L�E/Booleans")]
    public bool kulceAlindi;                    //kereste binas� al�n�nca tu�u tekrar a��lmas�n diye


    [FoldoutGroup("K�L�E/Upgrade Seviyeleri")]
    public int kulceSpdUpgLvl;                  //kereste gelir upg seviyesi
    [FoldoutGroup("K�L�E/Upgrade Seviyeleri")]
    public int kulceIncUpgLvl;                  //kereste h�z upg seviyesi


    [FoldoutGroup("K�L�E/Upgrade �cretleri")]
    public float kulceSpdUpgCost;               //k�l�e h�z upg i�in gereken para
    [FoldoutGroup("K�L�E/Upgrade �cretleri")]
    public float kulceIncUpgCost;               //k�l�e gelir upg i�in gereken para


    [FoldoutGroup("K�L�E/Speed upgrade textleri")]    
    public Text kulceSpdUpgLvlText;             //kulce h�z upg �cret text
    [FoldoutGroup("K�L�E/Speed upgrade textleri")]
    public Text kulceSpdUpgCostText;            //kulce h�z upg seviye text
    [FoldoutGroup("K�L�E/Speed upgrade textleri")]
    public Text kulcespdyouneeddollartext;      //para yetmiyorsa ne kadar gerekti�ini yaz�yor


    [FoldoutGroup("K�L�E/Income upgrade textleri")]
    public Text kulceIncUpgLvlText;             //kulce gelir upg seviye text
    [FoldoutGroup("K�L�E/Income upgrade textleri")]
    public Text kulceincyouneeddollartext;      //para yetmiyorsa ne kadar gerekti�ini yaz�yor
    [FoldoutGroup("K�L�E/Income upgrade textleri")]
    public Text kulceIncUpgCostText;            //kulce h�z upg �cret text


    [FoldoutGroup("K�L�E/GameObjectler")]
    public GameObject kulceSpdUpgBuyBtn;        //h�z ve gelir upgrade butonlar�
    [FoldoutGroup("K�L�E/GameObjectler")]
    public GameObject kulceincUpgBtn;           //h�z ve gelir upgrade butonlar�
    [FoldoutGroup("K�L�E/GameObjectler")]
    public GameObject buyOvenButton;            //K�l�e binas� sat�n al butonu
    [FoldoutGroup("K�L�E/GameObjectler")]
    public GameObject buyIronBakerBtn;          //K�l�e menajer sat�n alma butonu
    [FoldoutGroup("K�L�E/GameObjectler")]
    public GameObject kulceUretButon;           //bina al�n�nca k�l�e �reme butonu a��lacak
    [Space]
    [FoldoutGroup("K�L�E/GameObjectler")]
    public GameObject kulceHizUpgUnite;       //bina sat�n al�nmam��sa bu upgradeler g�z�km�yor
    [FoldoutGroup("K�L�E/GameObjectler")]
    public GameObject kulceIncUpgUnite;       //bina sat�n al�nmam��sa bu upgradeler g�z�km�yor
    [FoldoutGroup("K�L�E/GameObjectler")]
    public GameObject kulceSatUnite;          //bina sat�n al�nmam��sa kereste sat k�sm� g�z�km�yor
    [FoldoutGroup("K�L�E/GameObjectler")]
    public GameObject ironBakerUnite;           //Bina sat�n al�nmam��sa marangoz al k�sm� g�z�km�yor
    [FoldoutGroup("K�L�E/GameObjectler")]
    public GameObject kulceMgrNotEnoMnyText;   //menajer i�in yeterli para yok text, menajer sat�n al�nca setactive'ini kapatmak i�in
    [FoldoutGroup("K�L�E/GameObjectler")]
    public GameObject kulceBinaNotEnoMnyText;  //bina i�in yeterli para yok text, menajer sat�n al�nca setactive'ini kapatmak i�in
    [FoldoutGroup("K�L�E/GameObjectler")]
    public GameObject kulceBinaCitleri;     //Kereste binas� sat�n al�n�nca �itleri kapataca��m
    [FoldoutGroup("K�L�E/GameObjectler")]
    public GameObject kulceBina;            //�itler kalk�nca yerine gelecek bina, sat�n al�n�nca a��lacak
    [FoldoutGroup("K�L�E/GameObjectler")]
    public GameObject kulcefillbar;         //kereste binas�n�n fillbar� ve butonu sat�n al�n�nca a��ls�n diye
    [FoldoutGroup("K�L�E/GameObjectler")]
    public GameObject kulceUi;              //bina sat�n al�nd���nda g�z�ks�n


    [FoldoutGroup("K�L�E/Fillbar")]
    public Image kulceFillbar;         //fillbar pngsi
    [FoldoutGroup("K�L�E/Fillbar")]
    public float kulcetimer;           //Bunu time'a b�ld�rerek fillbar� kontrol ediyorum
    [FoldoutGroup("K�L�E/Fillbar")]
    public float kulceZamanCarpan;     //fillbar�n ne kadar h�zl� dolaca��n� belirliyor
    [FoldoutGroup("K�L�E/Fillbar")]
    public float kulceTime;              //fillbar kontrol�
    #endregion

    #region �ivi
    [BoxGroup("C�V�")]
    [FoldoutGroup("C�V�/Booleans")]
    public bool civiMenajerAlindi;             //menajer al�n�nca true olarak �retimi otomatikle�tiriyor
    [FoldoutGroup("C�V�/Booleans")]
    public bool civiAlindi;                    //�ivi binas� al�n�nca tu�u tekrar a��lmas�n diye


    [FoldoutGroup("C�V�/Upgrade Seviyeleri")]
    public int civiSpdUpgLvl;                  //civi gelir upg seviyesi
    [FoldoutGroup("C�V�/Upgrade Seviyeleri")]
    public int civiIncUpgLvl;                  //civi h�z upg seviyesi


    [FoldoutGroup("C�V�/Upgrade �cretleri")]
    public float civiSpdUpgCost;               //civi h�z upg i�in gereken para
    [FoldoutGroup("C�V�/Upgrade �cretleri")]
    public float civiIncUpgCost;               //civi gelir upg i�in gereken para


    [FoldoutGroup("C�V�/Speed upgrade textleri")]
    public Text civiSpdUpgLvlText;             //kulce h�z upg �cret text
    [FoldoutGroup("C�V�/Speed upgrade textleri")]
    public Text civiSpdUpgCostText;            //kulce h�z upg seviye text
    [FoldoutGroup("C�V�/Speed upgrade textleri")]
    public Text civispdyouneeddollartext;      //para yetmiyorsa ne kadar gerekti�ini yaz�yor


    [FoldoutGroup("C�V�/Income upgrade textleri")]    
    public Text civiIncUpgLvlText;             //kulce gelir upg seviye text
    [FoldoutGroup("C�V�/Income upgrade textleri")]
    public Text civiincyouneeddollartext;      //para yetmiyorsa ne kadar gerekti�ini yaz�yor
    [FoldoutGroup("C�V�/Income upgrade textleri")]
    public Text civiIncUpgCostText;            //kulce h�z upg �cret text


    [FoldoutGroup("C�V�/GameObjectler")]    
    public GameObject civiSpdUpgBuyBtn;        //h�z ve gelir upgrade butonlar�
    [FoldoutGroup("C�V�/GameObjectler")]
    public GameObject civiincUpgBtn;           //h�z ve gelir upgrade butonlar�
    [FoldoutGroup("C�V�/GameObjectler")]
    public GameObject buyNailButton;           //�ivi binas� sat�n al butonu
    [FoldoutGroup("C�V�/GameObjectler")]
    public GameObject buyNailMngrBtn;          //�ivi menajer sat�n alma butonu
    [FoldoutGroup("C�V�/GameObjectler")]
    public GameObject civiUretButon;           //bina al�n�nca �ivi �retme butonu a��lacak
    [Space]
    [FoldoutGroup("C�V�/GameObjectler")]
    public GameObject civiHizUpgUnite;         //bina sat�n al�nmam��sa bu upgradeler g�z�km�yor
    [FoldoutGroup("C�V�/GameObjectler")]
    public GameObject civiIncUpgUnite;         //bina sat�n al�nmam��sa bu upgradeler g�z�km�yor
    [FoldoutGroup("C�V�/GameObjectler")]
    public GameObject civiSatUnite;            //bina sat�n al�nmam��sa kereste sat k�sm� g�z�km�yor
    [FoldoutGroup("C�V�/GameObjectler")]
    public GameObject civiMngrUnite;           //Bina sat�n al�nmam��sa marangoz al k�sm� g�z�km�yor
    [FoldoutGroup("C�V�/GameObjectler")]
    public GameObject civiMgrNotEnoMnyText;    //menajer i�in yeterli para yok text, menajer sat�n al�nca setactive'ini kapatmak i�in
    [FoldoutGroup("C�V�/GameObjectler")]
    public GameObject civiBinaNotEnoMnyText;   //bina i�in yeterli para yok text, menajer sat�n al�nca setactive'ini kapatmak i�in
    [FoldoutGroup("C�V�/GameObjectler")]
    public GameObject civiBinaCitleri;         //�ivi binas� sat�n al�n�nca �itleri kapataca��m
    [FoldoutGroup("C�V�/GameObjectler")]
    public GameObject civiBina;                //�itler kalk�nca yerine gelecek bina, sat�n al�n�nca a��lacak
    [FoldoutGroup("C�V�/GameObjectler")]
    public GameObject civifillbar;             //�ivi binas�n�n fillbar� ve butonu sat�n al�n�nca a��ls�n diye
    [FoldoutGroup("C�V�/GameObjectler")]
    public GameObject civiUi;                  //bina sat�n al�nd���nda g�z�ks�n


    [FoldoutGroup("C�V�/Fillbar")]
    public Image civiFillbar;         //fillbar pngsi
    [FoldoutGroup("C�V�/Fillbar")]
    public float civitimer;           //Bunu time'a b�ld�rerek fillbar� kontrol ediyorum
    [FoldoutGroup("C�V�/Fillbar")]
    public float civiZamanCarpan;     //fillbar�n ne kadar h�zl� dolaca��n� belirliyor
    [FoldoutGroup("C�V�/Fillbar")]
    public float civiTime;            //fillbar kontrol�
    #endregion

    #region Di�li
    [BoxGroup("D�SL�")]
    [FoldoutGroup("D�SL�/Booleans")]
    public bool disliMenajerAlindi;             //menajer al�n�nca true olarak �retimi otomatikle�tiriyor
    [FoldoutGroup("D�SL�/Booleans")]
    public bool disliAlindi;                    //di�li binas� al�n�nca tu�u tekrar a��lmas�n diye


    [FoldoutGroup("D�SL�/Upgrade Seviyeleri")]
    public int disliSpdUpgLvl;                  //di�li gelir upg seviyesi
    [FoldoutGroup("D�SL�/Upgrade Seviyeleri")]
    public int disliIncUpgLvl;                  //di�li h�z upg seviyesi


    [FoldoutGroup("D�SL�/Upgrade �cretleri")]
    public float disliSpdUpgCost;               //di�li h�z upg i�in gereken para
    [FoldoutGroup("D�SL�/Upgrade �cretleri")]
    public float disliIncUpgCost;               //di�li gelir upg i�in gereken para


    [FoldoutGroup("D�SL�/Speed upgrade textleri")]
    public Text disliSpdUpgLvlText;             //di�li h�z upg �cret text
    [FoldoutGroup("D�SL�/Speed upgrade textleri")]
    public Text disliSpdUpgCostText;            //di�li h�z upg seviye text
    [FoldoutGroup("D�SL�/Speed upgrade textleri")]
    public Text dislispdyouneeddollartext;      //para yetmiyorsa ne kadar gerekti�ini yaz�yor
    [FoldoutGroup("D�SL�/Income upgrade textleri")]
    public Text disliIncUpgLvlText;             //di�li gelir upg seviye text
    [FoldoutGroup("D�SL�/Income upgrade textleri")]
    public Text disliincyouneeddollartext;      //para yetmiyorsa ne kadar gerekti�ini yaz�yor
    [FoldoutGroup("D�SL�/Income upgrade textleri")]
    public Text disliIncUpgCostText;            //di�li h�z upg �cret text


    [FoldoutGroup("D�SL�/GameObjectler")]
    public GameObject disliSpdUpgBuyBtn;        //h�z ve gelir upgrade butonlar�
    [FoldoutGroup("D�SL�/GameObjectler")]
    public GameObject disliincUpgBtn;           //h�z ve gelir upgrade butonlar�
    [FoldoutGroup("D�SL�/GameObjectler")]
    public GameObject buyGearButton;            //di�li binas� sat�n al butonu
    [FoldoutGroup("D�SL�/GameObjectler")]
    public GameObject buyGearMngrBtn;           //di�li menajer sat�n alma butonu
    [FoldoutGroup("D�SL�/GameObjectler")]
    public GameObject disliUretButon;           //bina al�n�nca di�li �retme butonu a��lacak
    [Space]
    [FoldoutGroup("D�SL�/GameObjectler")]
    public GameObject disliHizUpgUnite;         //bina sat�n al�nmam��sa bu upgradeler g�z�km�yor
    [FoldoutGroup("D�SL�/GameObjectler")]
    public GameObject disliIncUpgUnite;         //bina sat�n al�nmam��sa bu upgradeler g�z�km�yor
    [FoldoutGroup("D�SL�/GameObjectler")]
    public GameObject disliSatUnite;            //bina sat�n al�nmam��sa di�li sat k�sm� g�z�km�yor
    [FoldoutGroup("D�SL�/GameObjectler")]
    public GameObject disliMngrUnite;           //Bina sat�n al�nmam��sa di�li menajer al k�sm� g�z�km�yor
    [FoldoutGroup("D�SL�/GameObjectler")]
    public GameObject disliMgrNotEnoMnyText;    //menajer i�in yeterli para yok text, menajer sat�n al�nca setactive'ini kapatmak i�in
    [FoldoutGroup("D�SL�/GameObjectler")]
    public GameObject disliBinaNotEnoMnyText;   //bina i�in yeterli para yok text, menajer sat�n al�nca setactive'ini kapatmak i�in
    [FoldoutGroup("D�SL�/GameObjectler")]
    public GameObject disliBinaCitleri;         //di�li binas� sat�n al�n�nca �itleri kapataca��m
    [FoldoutGroup("D�SL�/GameObjectler")]
    public GameObject disliBina;                //�itler kalk�nca yerine gelecek bina, sat�n al�n�nca a��lacak
    [FoldoutGroup("D�SL�/GameObjectler")]
    public GameObject dislifillbar;             //di�li binas�n�n fillbar� ve butonu sat�n al�n�nca a��ls�n diye
    [FoldoutGroup("D�SL�/GameObjectler")]
    public GameObject disliUi;                  //bina sat�n al�nd���nda g�z�ks�n


    [FoldoutGroup("D�SL�/Fillbar")]
    public Image disliFillbar;         //fillbar pngsi
    [FoldoutGroup("D�SL�/Fillbar")]
    public float dislitimer;           //Bunu time'a b�ld�rerek fillbar� kontrol ediyorum
    [FoldoutGroup("D�SL�/Fillbar")]
    public float disliZamanCarpan;     //fillbar�n ne kadar h�zl� dolaca��n� belirliyor
    [FoldoutGroup("D�SL�/Fillbar")]
    public float disliTime;            //fillbar kontrol�
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

        #region Binalar al�nmam��ken upgradeler kapal� kals�n
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

        #region wood spd upg cost g�sterim
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

        #region you need $ cost g�sterim speed upgrade
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

        #region wood inc upg cost g�sterim
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

        #region you need $ cost g�sterim income upgrade
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

        #region demir ore h�z upg cost g�sterim
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

        #region you need $ cost g�sterim h�z upgrade
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

        #region demir ore income upg cost g�sterim
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

        #region you need $ cost g�sterim income upgrade
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

        #region timber spd upg cost g�sterim
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

        #region you need $ cost g�sterim speed upgrade
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

        #region timber inc upg cost g�sterim
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

        #region you need $ cost g�sterim income upgrade
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

        //K�l�e///////////////////////////////////////////

        #region K�l�e spd upg cost G�sterim
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

        #region you need $ cost g�sterim speed upgrade
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

        #region kulce inc upg cost g�sterim
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

        #region you need $ cost g�sterim income upgrade
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

        //�ivi///////////////////////////////////////////

        #region �ivi spd upg cost g�sterim
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

        #region You need $ cost g�sterim speed upgrade
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

        #region civi inc upg upg cost g�sterim
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

        #region you need $ cost g�sterim income upgrade
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

        //Di�li/////////////////////////////////////////

        #region Di�li spd upg cost g�sterim
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

        #region You need $ cost g�sterim income upgrade
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

        #region Disli inc upg cost g�sterim
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

        #region You need $ cost g�sterim income upgrade
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

        #region Para yetmiyorsa butonlar� kapat

        #region Odun

        #region Odun menajer sat�n al butonu
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

        #region Odun H�z Upg sat�n al butonu
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

        #region demir ore h�z upg sat�n al butonu
        if (GameManager.gm.anaPara < demirOreSpdUpgCost)
        {
            demirOreSpdUpgBuyBtn.SetActive(false);
        }
        else
        {
            demirOreSpdUpgBuyBtn.SetActive(true);
        }
        #endregion

        #region Demir Ore income upg sat�n al butonu
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

        #region kereste h�z upg sat�n al butonu
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

        #region Men� Carpenter �nitesi
        if (keresteAlindi == false)
        {
            carpenterUnite.SetActive(false);
        }
        else
        {
            carpenterUnite.SetActive(true);
        }
        #endregion

        #region kereste �ret butonu, odun yoksa
        if (GameManager.gm.odunStok <= 0)
        {
            keresteUretButon.SetActive(false);
        }
        else
        {
            keresteUretButon.SetActive(true);
        }
        #endregion

        #region kereste ui, bina al�n�nca a��lacak
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

        #region K�l�e

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

        #region k�l�e h�z upg sat�n al butonu
        if (GameManager.gm.anaPara < kulceSpdUpgCost)
        {
            kulceSpdUpgBuyBtn.SetActive(false);
        }
        else
        {
            kulceSpdUpgBuyBtn.SetActive(true);
        }
        #endregion

        #region K�l�e income upg butonu
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

        #region Men� IronBaker �nitesi
        if (kulceAlindi == false)
        {
            ironBakerUnite.SetActive(false);
        }
        else
        {
            ironBakerUnite.SetActive(true);
        }
        #endregion

        #region K�l�e �ret butonu, odun demir yoksa
        if ((GameManager.gm.odunStok <= 0) && (GameManager.gm.demirOreStok <= 0))
        {
            kulceUretButon.SetActive(false);
        }
        else
        {
            kulceUretButon.SetActive(true);
        }
        #endregion

        #region K�l�e ui, bina al�n�nca a��lacak
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

        #region �ivi

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

        #region civi h�z upg sat�n al butonu
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

        #region Men� CiviManager �nitesi
        if (civiAlindi == false)
        {
            civiMngrUnite.SetActive(false);
        }
        else
        {
            civiMngrUnite.SetActive(true);
        }
        #endregion

        #region civi �ret butonu, odun k�l�e yoksa
        if ((GameManager.gm.odunStok <= 0) | (GameManager.gm.kulceStok <= 0))
        {
            civiUretButon.SetActive(false);
        }
        else
        {
            civiUretButon.SetActive(true);
        }
        #endregion

        #region civi ui, bina al�n�nca a��lacak
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

        #region Di�li

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

        #region disli h�z upg sat�n al butonu
        if (GameManager.gm.anaPara < disliSpdUpgCost)
        {
            disliSpdUpgBuyBtn.SetActive(false);
        }
        else
        {
            disliSpdUpgBuyBtn.SetActive(true);
        }
        #endregion

        #region Di�li income upgrade button
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

        #region Men� dislimenager �nitesi
        if (disliAlindi == false)
        {
            disliMngrUnite.SetActive(false);
        }
        else
        {
            disliMngrUnite.SetActive(true);
        }
        #endregion

        #region Di�li �ret butonu, odun k�l�e yoksa
        if ((GameManager.gm.odunStok <= 0) | (GameManager.gm.kulceStok <= 0))
        {
            disliUretButon.SetActive(false);
        }
        else
        {
            disliUretButon.SetActive(true);
        }
        #endregion

        #region Di�li ui, bina al�n�nca a��lacak
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

        #region woodIncomeUpgCost ilk �� level fiyat�
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

        #region Tab ile d�nyalar aras� ge�i�, esc ile men� a�ma
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameManager.gm.ChangeWorldsButton();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.gm.MenuButton();
        }
        #endregion

        #region Save Load'da sorun ��karanlar� d�zeltmek
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

    #region Buton Fonksiyonlar�

    #region Odun

    #region odun Sell Button
    public void odunSatTus()
    {//odun say�s�n� odunun fiyat�yla �arp�p sonucu anaparaya ekliyorum ve odun sto�unu s�f�rl�yorum
        GameManager.gm.anaPara += GameManager.gm.odunStok * GameManager.gm.odunPara;
        GameManager.gm.odunStok = 0;
    }
    #endregion

    #region Hire Forester Button
    public void HireForesterTus()
    {
        if (GameManager.gm.anaPara >= 200) //param�z menajeri almaya yetiyorsa
        {
            GameManager.gm.anaPara -= 200;
            odunMenajerAlindi = true; //bu true olunca otomatikle�iyor
            GameManager.gm.baltaUretimBool = true;
            cutBtn.SetActive(false);             //
            buyWoodmanBtn.SetActive(false);      //kes butonunu, menajer sat�n al butonunu ve menajere para yetmiyorsa yazan texti kapat�yorum
            woodmgrNotEnoMnyText.SetActive(false);   //
        }
    }
    #endregion

    #region Wood Speed Upgrade Button
    public void WoodSpeedUpgButton()
    {
        if (GameManager.gm.anaPara >= woodSpdUpgCost) //param�z upgradei almaya yetiyorsa
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
        if (GameManager.gm.anaPara >= woodIncUpgCost) //anaparam�z upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= woodIncUpgCost;
            GameManager.gm.odunPara *= 1.15f;
            woodIncUpgLvl += 1;

            if (woodIncUpgLvl >= 3) //ilk �� seviye fiyat�n� elimle belirledim, sonrakiler bu denkleme g�re hesaplan�yor
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
        if (GameManager.gm.anaPara >= 500) //param�z menajeri almaya yetiyorsa
        {
            GameManager.gm.anaPara -= 500;
            demirOreMenajerAlindi = true; //bu true olunca otomatikle�iyor
            GameManager.gm.demirUretimBool = true;
            digBtn.SetActive(false);                     //
            buyMinerBtn.SetActive(false);                //kaz butonunu, menajer sat�n al butonunu ve menajere para yetmiyorsa yazan texti kapat�yorum
            demirOreMgrNotEnoMnyText.SetActive(false);   //
        }
    }
    #endregion

    #region Demir Speed Upgrade Button
    public void DemirOreSpeedUpgButton()
    {
        if (GameManager.gm.anaPara >= demirOreSpdUpgCost) //param�z upgradei almaya yetiyorsa
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
        if (GameManager.gm.anaPara >= demirOreIncUpgCost) //anaparam�z upgradei almaya yetiyorsa
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
        if (GameManager.gm.anaPara >= 1200) //menajeri almak i�in yeterli para varsa
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
        if (GameManager.gm.anaPara >= timberSpdUpgCost) //param�z upgradei almaya yetiyorsa
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
        if (GameManager.gm.anaPara >= timberIncUpgCost) //anaparam�z upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= timberIncUpgCost;
            GameManager.gm.kerestePara *= 1.3f;
            timberIncUpgLvl += 1;
            timberIncUpgCost = timberIncUpgCost * 2.3f;
        }//dengele
    }
    #endregion

    #region Buy Saw button, kereste binas� 
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

    #region K�l�e

    #region K�l�e sell button 
    public void kulceSatTus()
    {
        GameManager.gm.anaPara += GameManager.gm.kulceStok * GameManager.gm.kulcePara;
        GameManager.gm.kulceStok = 0;
    }
    #endregion

    #region Buy IronBaker Button
    public void BuyIronBakerButton()
    {
        if (GameManager.gm.anaPara >= 1800) //menajeri almak i�in yeterli para varsa
        {
            GameManager.gm.anaPara -= 1800;
            kulceMenajerAlindi = true;
            buyIronBakerBtn.SetActive(false);
            kulceMgrNotEnoMnyText.SetActive(false);
        }
    }
    #endregion

    #region K�l�e speed upg button
    public void KulceSpeedUpgButton()
    {
        if (GameManager.gm.anaPara >= kulceSpdUpgCost) //param�z upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= kulceSpdUpgCost;
            kulceSpdUpgLvl += 1;
            kulceZamanCarpan *= 1.3f;
            kulceSpdUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region K�l�e income upg button
    public void KulceIncomeUpgButton()
    {
        if (GameManager.gm.anaPara >= kulceIncUpgCost) //anaparam�z upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= kulceIncUpgCost;
            GameManager.gm.kulcePara *= 1.3f;
            kulceIncUpgLvl += 1;
            kulceIncUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region Buy Oven button, f�r�n binas�
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

    #region �ivi

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
        if (GameManager.gm.anaPara >= 2200) //menajeri almak i�in yeterli para varsa
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
        if (GameManager.gm.anaPara >= civiSpdUpgCost) //param�z upgradei almaya yetiyorsa
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
        if (GameManager.gm.anaPara >= civiIncUpgCost) //anaparam�z upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= civiIncUpgCost;
            GameManager.gm.civiPara *= 1.3f;
            civiIncUpgLvl += 1;
            civiIncUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region Buy nail button, civi binas�
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

    #region Di�li

    #region Di�li sell button
    public void disliSatTus()
    {
        GameManager.gm.anaPara += GameManager.gm.disliStok * GameManager.gm.disliPara;
        GameManager.gm.disliStok = 0;
    }
    #endregion

    #region Buy Dislimngr Button
    public void BuyDisliMngrButton()
    {
        if (GameManager.gm.anaPara >= 3000) //menajeri almak i�in yeterli para varsa
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
        if (GameManager.gm.anaPara >= disliSpdUpgCost) //param�z upgradei almaya yetiyorsa
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
        if (GameManager.gm.anaPara >= disliIncUpgCost) //anaparam�z upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= disliIncUpgCost;
            GameManager.gm.disliPara *= 1.3f;
            disliIncUpgLvl += 1;
            disliIncUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region Buy gear button, di�li binas�
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
