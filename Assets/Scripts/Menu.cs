#region K�t�phaneler
using UnityEngine;
using UnityEngine.UI;
using static System.Math;
using System;
using Sirenix.OdinInspector;
#endregion

public class Menu : MonoBehaviour
{
    public static Menu menu; //singleton i�in
    public static GameManager gm;
    public static SaveSystem Savesys;

    #region De�i�kenler

    #region B�y�k say� constantlar�
    const double million = 1000000;
    const double billion = 1000000000;
    const double trillion = 1000000000000;
    const double quadrillion = 1000000000000000;
    const double quintillion = 1000000000000000000;
    #endregion

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

    #region Masa
    [BoxGroup("MASA")]
    [FoldoutGroup("MASA/Booleans")]
    public bool masaMenajerAlindi;             //menajer al�n�nca true olarak �retimi otomatikle�tiriyor
    [FoldoutGroup("MASA/Booleans")]
    public bool masaAlindi;                    //kereste binas� al�n�nca tu�u tekrar a��lmas�n diye


    [FoldoutGroup("MASA/Upgrade Seviyeleri")]
    public int masaSpdUpgLvl;                  //kereste gelir upg seviyesi
    [FoldoutGroup("MASA/Upgrade Seviyeleri")]
    public int masaIncUpgLvl;                  //kereste h�z upg seviyesi


    [FoldoutGroup("MASA/Upgrade �cretleri")]
    public float masaSpdUpgCost;               //k�l�e h�z upg i�in gereken para
    [FoldoutGroup("MASA/Upgrade �cretleri")]
    public float masaIncUpgCost;               //k�l�e gelir upg i�in gereken para


    [FoldoutGroup("MASA/Speed upgrade textleri")]
    public Text masaSpdUpgLvlText;             //kulce h�z upg �cret text
    [FoldoutGroup("MASA/Speed upgrade textleri")]
    public Text masaSpdUpgCostText;            //kulce h�z upg seviye text
    [FoldoutGroup("MASA/Speed upgrade textleri")]
    public Text masaspdyouneeddollartext;      //para yetmiyorsa ne kadar gerekti�ini yaz�yor


    [FoldoutGroup("MASA/Income upgrade textleri")]
    public Text masaIncUpgLvlText;             //kulce gelir upg seviye text
    [FoldoutGroup("MASA/Income upgrade textleri")]
    public Text masaincyouneeddollartext;      //para yetmiyorsa ne kadar gerekti�ini yaz�yor
    [FoldoutGroup("MASA/Income upgrade textleri")]
    public Text masaIncUpgCostText;            //kulce h�z upg �cret text


    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaSpdUpgBuyBtn;        //h�z ve gelir upgrade butonlar�
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaincUpgBtn;           //h�z ve gelir upgrade butonlar�
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject buyMasaButton;            //K�l�e binas� sat�n al butonu
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject buyMasaciBtn;          //K�l�e menajer sat�n alma butonu
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaUretButon;           //bina al�n�nca k�l�e �reme butonu a��lacak
    [Space]
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaHizUpgUnite;       //bina sat�n al�nmam��sa bu upgradeler g�z�km�yor
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaIncUpgUnite;       //bina sat�n al�nmam��sa bu upgradeler g�z�km�yor
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaSatUnite;          //bina sat�n al�nmam��sa kereste sat k�sm� g�z�km�yor
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaciUnite;           //Bina sat�n al�nmam��sa marangoz al k�sm� g�z�km�yor
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaMgrNotEnoMnyText;   //menajer i�in yeterli para yok text, menajer sat�n al�nca setactive'ini kapatmak i�in
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaBinaNotEnoMnyText;  //bina i�in yeterli para yok text, menajer sat�n al�nca setactive'ini kapatmak i�in
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaBinaCitleri;     //Kereste binas� sat�n al�n�nca �itleri kapataca��m
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaBina;            //�itler kalk�nca yerine gelecek bina, sat�n al�n�nca a��lacak
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masafillbar;         //kereste binas�n�n fillbar� ve butonu sat�n al�n�nca a��ls�n diye
    [FoldoutGroup("MASA/GameObjectler")]
    public GameObject masaUi;              //bina sat�n al�nd���nda g�z�ks�n


    [FoldoutGroup("MASA/Fillbar")]
    public Image masaFillbar;         //fillbar pngsi
    [FoldoutGroup("MASA/Fillbar")]
    public float masatimer;           //Bunu time'a b�ld�rerek fillbar� kontrol ediyorum
    [FoldoutGroup("MASA/Fillbar")]
    public float masaZamanCarpan;     //fillbar�n ne kadar h�zl� dolaca��n� belirliyor
    [FoldoutGroup("MASA/Fillbar")]
    public float masaTime;              //fillbar kontrol�
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

    #region Boya
    [BoxGroup("BOYA")]
    [FoldoutGroup("BOYA/Booleans")]
    public bool boyaMenajerAlindi;             //menajer al�n�nca true olarak �retimi otomatikle�tiriyor
    [FoldoutGroup("BOYA/Booleans")]
    public bool boyaAlindi;                    //di�li binas� al�n�nca tu�u tekrar a��lmas�n diye


    [FoldoutGroup("BOYA/Upgrade Seviyeleri")]
    public int boyaSpdUpgLvl;                  //di�li gelir upg seviyesi
    [FoldoutGroup("BOYA/Upgrade Seviyeleri")]
    public int boyaIncUpgLvl;                  //di�li h�z upg seviyesi


    [FoldoutGroup("BOYA/Upgrade �cretleri")]
    public float boyaSpdUpgCost;               //di�li h�z upg i�in gereken para
    [FoldoutGroup("BOYA/Upgrade �cretleri")]
    public float boyaIncUpgCost;               //di�li gelir upg i�in gereken para


    [FoldoutGroup("BOYA/Speed upgrade textleri")]
    public Text boyaSpdUpgLvlText;             //di�li h�z upg �cret text
    [FoldoutGroup("BOYA/Speed upgrade textleri")]
    public Text boyaSpdUpgCostText;            //di�li h�z upg seviye text
    [FoldoutGroup("BOYA/Speed upgrade textleri")]
    public Text boyaspdyouneeddollartext;      //para yetmiyorsa ne kadar gerekti�ini yaz�yor
    [FoldoutGroup("BOYA/Income upgrade textleri")]
    public Text boyaIncUpgLvlText;             //di�li gelir upg seviye text
    [FoldoutGroup("BOYA/Income upgrade textleri")]
    public Text boyaincyouneeddollartext;      //para yetmiyorsa ne kadar gerekti�ini yaz�yor
    [FoldoutGroup("BOYA/Income upgrade textleri")]
    public Text boyaIncUpgCostText;            //di�li h�z upg �cret text


    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaSpdUpgBuyBtn;        //h�z ve gelir upgrade butonlar�
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaincUpgBtn;           //h�z ve gelir upgrade butonlar�
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject buyBoyaButton;            //di�li binas� sat�n al butonu
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject buyBoyaMngrBtn;           //di�li menajer sat�n alma butonu
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaUretButon;           //bina al�n�nca di�li �retme butonu a��lacak
    [Space]
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaHizUpgUnite;         //bina sat�n al�nmam��sa bu upgradeler g�z�km�yor
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaIncUpgUnite;         //bina sat�n al�nmam��sa bu upgradeler g�z�km�yor
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaSatUnite;            //bina sat�n al�nmam��sa di�li sat k�sm� g�z�km�yor
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaMngrUnite;           //Bina sat�n al�nmam��sa di�li menajer al k�sm� g�z�km�yor
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaMgrNotEnoMnyText;    //menajer i�in yeterli para yok text, menajer sat�n al�nca setactive'ini kapatmak i�in
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaBinaNotEnoMnyText;   //bina i�in yeterli para yok text, menajer sat�n al�nca setactive'ini kapatmak i�in
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaBinaCitleri;         //di�li binas� sat�n al�n�nca �itleri kapataca��m
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaBina;                //�itler kalk�nca yerine gelecek bina, sat�n al�n�nca a��lacak
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyafillbar;             //di�li binas�n�n fillbar� ve butonu sat�n al�n�nca a��ls�n diye
    [FoldoutGroup("BOYA/GameObjectler")]
    public GameObject boyaUi;                  //bina sat�n al�nd���nda g�z�ks�n


    [FoldoutGroup("BOYA/Fillbar")]
    public Image boyaFillbar;         //fillbar pngsi
    [FoldoutGroup("BOYA/Fillbar")]
    public float boyatimer;           //Bunu time'a b�ld�rerek fillbar� kontrol ediyorum
    [FoldoutGroup("BOYA/Fillbar")]
    public float boyaZamanCarpan;     //fillbar�n ne kadar h�zl� dolaca��n� belirliyor
    [FoldoutGroup("BOYA/Fillbar")]
    public float boyaTime;            //fillbar kontrol�
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

    #region Offline Progress
    [BoxGroup("Offline Progress")]

    [FoldoutGroup("Offline Progress/Genel")]
    public Text awayTimeText;
    [FoldoutGroup("Offline Progress/Genel")]
    public GameObject OfflineProgressGOBJ;
    [FoldoutGroup("Offline Progress/Genel")]
    public DateTime sonGiris;
    [FoldoutGroup("Offline Progress/Genel")]
    public TimeSpan ts;
    [FoldoutGroup("Offline Progress/Genel")]
    public string sonGirisZaman;
    [FoldoutGroup("Offline Progress/Genel")]
    public int tssikim;
    [FoldoutGroup("Offline Progress/Genel")]
    public bool odunOpDone;
    [FoldoutGroup("Offline Progress/Genel")]
    public bool DemirOpDone;
    [FoldoutGroup("Offline Progress/Genel")]
    public bool KeresteOpDone;
    [FoldoutGroup("Offline Progress/Genel")]
    public bool KulceOpDone;
    [FoldoutGroup("Offline Progress/Genel")]
    public bool MasaOpDone;
    [FoldoutGroup("Offline Progress/Genel")]
    public bool CiviOpDone;
    

    [FoldoutGroup("Offline Progress/Textler")]
    public Text Odun;
    [FoldoutGroup("Offline Progress/Textler")]
    public Text Demir;
    [FoldoutGroup("Offline Progress/Textler")]
    public Text Kereste;
    [FoldoutGroup("Offline Progress/Textler")]
    public Text Kulce;
    [FoldoutGroup("Offline Progress/Textler")]
    public Text Masa;
    [FoldoutGroup("Offline Progress/Textler")]
    public Text Civi;
    [FoldoutGroup("Offline Progress/Textler")]
    public Text Boya;
    [FoldoutGroup("Offline Progress/Textler")]
    public Text Disli;

    
    [FoldoutGroup("Offline Progress/xPerSec")]
    public float odunPerSec;
    [FoldoutGroup("Offline Progress/xPerSec")]
    public float demirPerSec;
    [FoldoutGroup("Offline Progress/xPerSec")]
    public float kerestePerSec;
    [FoldoutGroup("Offline Progress/xPerSec")]
    public float kulcePerSec;
    [FoldoutGroup("Offline Progress/xPerSec")]
    public float masaPerSec;
    [FoldoutGroup("Offline Progress/xPerSec")]
    public float civiPerSec;
    [FoldoutGroup("Offline Progress/xPerSec")]
    public float boyaPerSec;
    [FoldoutGroup("Offline Progress/xPerSec")]
    public float disliPerSec;
    #endregion

    #endregion

    #region Awake    
    private void Awake()
    {
        menu = this;
    }
    #endregion

    #region Start
    private void Start()
    {
        odunOpDone = false;
        KeresteOpDone = false;
        MasaOpDone = false;
        DemirOpDone = false;
        KulceOpDone = false;
        CiviOpDone = false;

        gm = GameManager.gm;

        #region Offline Progress

        #region persec ayarlama
        odunPerSec = 1 / (odunTime / odunZamanCarpan);
        demirPerSec = 1 / (demirTime / demirZamanCarpan);
        kerestePerSec = 1 / (keresteTime / keresteZamanCarpan);
        kulcePerSec = 1 / (kulceTime / kulceZamanCarpan);
        masaPerSec = 1 / (masaTime / masaZamanCarpan);
        civiPerSec = 1 / (civiTime / civiZamanCarpan);
        boyaPerSec = 1 / (boyaTime / boyaZamanCarpan);
        disliPerSec = 1 / (disliTime / disliZamanCarpan);
        #endregion

        #region Kazan� atama
        if (sonGirisZaman != "")
        {
            OfflineProgressGOBJ.SetActive(true);
            sonGiris = DateTime.Parse(sonGirisZaman);
            ts = DateTime.Now - sonGiris;
            tssikim = (int)ts.TotalSeconds;
            awayTimeText.text = ts.Days + " Days " + ts.Hours + " Hours " + ts.Minutes + " Minutes " + ts.Seconds + " Seconds"          /*string.Format("{#} Days ", ts.Days) + string.Format("{#} Hours ", ts.Hours) + string.Format("{#} Minutes ", ts.Minutes) + string.Format("{#} Seconds", ts.Seconds)*/;

            #region Textler ve eklemeler

            #region Odun
            if (odunOpDone == false)
            {
                if (odunMenajerAlindi == true)
                {
                    gm.odunStok += (int)(tssikim * odunPerSec);
                    Odun.text = String.Format("{0:0}", (int)(tssikim * odunPerSec)) + " Woods";
                }
                else
                {
                    Odun.text = "0 Wood";
                }
                odunOpDone = true;
            }
            #endregion

            #region Demir
            if (DemirOpDone == false)
            {
                if (demirOreMenajerAlindi == true)
                {
                    gm.demirOreStok += (int)(tssikim * demirPerSec);
                    Demir.text = String.Format("{0:0}", (int)(tssikim * demirPerSec)) + " Iron Ores";
                }
                else
                {
                    Demir.text = "0 Iron Ore";
                }
                DemirOpDone = true;
            }
            
            #endregion

            #region Kereste
            if (odunOpDone == true)
            {
                if (keresteMenajerAlindi == true)
                {
                    if ((int)(tssikim * kerestePerSec) < gm.odunStok)
                    {
                        gm.keresteStok += (int)(tssikim * kerestePerSec);
                        Kereste.text = (int)(tssikim * kerestePerSec) + " Timbers";
                        gm.odunStok -= (int)(tssikim * kerestePerSec);
                    }
                    else
                    {
                        gm.keresteStok += (int)(tssikim * kerestePerSec) - ((int)(tssikim * kerestePerSec) - (gm.odunStok));
                        Kereste.text = String.Format("{0:0}", (int)(tssikim * kerestePerSec) - ((int)(tssikim * kerestePerSec) - (gm.odunStok))) + " Nails";
                        gm.odunStok = 0;
                    }
                }
                else
                {
                    Kereste.text = "0 Timbers";
                }
                KeresteOpDone = true;
            }
            #endregion

            #region K�l�e
            if (DemirOpDone == true)
            {
                if (kulceMenajerAlindi == true)
                {
                    if ((int)(tssikim * kulcePerSec) < gm.demirOreStok)
                    {
                        gm.kulceStok += (int)(tssikim * kulcePerSec);
                        Kulce.text = String.Format("{0:0}", (tssikim * kulcePerSec)) + " Ingots";
                        gm.demirOreStok -= (int)(tssikim * kulcePerSec);
                    }
                    else
                    {
                        gm.kulceStok += (int)(tssikim * kulcePerSec) - ((int)(tssikim * kulcePerSec) - (gm.demirOreStok));
                        Kulce.text = String.Format("{0:0}", (int)(tssikim * kulcePerSec) - ((int)(tssikim * kulcePerSec) - (gm.demirOreStok))) + " Nails";
                        gm.demirOreStok = 0;
                    }
                }
                else
                {
                    Kulce.text = "0 Ingot";
                }
                KulceOpDone = true;
            }
            
            #endregion

            #region Masa
            if (KeresteOpDone == true)
            {
                if (masaMenajerAlindi == true)
                {
                    if ((int)(tssikim * masaPerSec) < gm.keresteStok)
                    {
                        gm.masaStok += (int)(tssikim * masaPerSec);
                        Masa.text = String.Format("{0:0}", (tssikim * masaPerSec)) + " Tables";
                        gm.keresteStok -= (int)(tssikim * masaPerSec);
                    }
                    else
                    {
                        gm.masaStok += gm.keresteStok;
                        Masa.text = String.Format("{0:0}", gm.keresteStok) + " Nails";
                        gm.keresteStok = 0;
                    }
                }
                else
                {
                    Masa.text = "0 Table";
                }
                MasaOpDone = true;
            }

            #endregion

            #region �ivi
            if (KulceOpDone == true)
            {
                if (civiMenajerAlindi == true)
                {
                    if ((int)(tssikim * civiPerSec) < gm.kulceStok)
                    {
                        gm.civiStok += (int)(tssikim * civiPerSec);
                        Civi.text = String.Format("{0:0}", (int)(tssikim * civiPerSec)) + " Nails";
                        gm.kulceStok -= (int)(tssikim * civiPerSec);
                    }
                    else
                    {
                        gm.civiStok += (int)(tssikim * civiPerSec) - ((int)(tssikim * civiPerSec) - (gm.kulceStok));
                        Civi.text = String.Format("{0:0}", (int)(tssikim * civiPerSec) - ((int)(tssikim * civiPerSec) - (gm.kulceStok))) + " Nails";
                        gm.kulceStok = 0;
                    }
                }
                else
                {
                    Civi.text = "0 Nail";
                }
                CiviOpDone = true;
            }
            
            #endregion

            #region Boya
            if (MasaOpDone == true)
            {
                if (boyaMenajerAlindi == true)
                {
                    if ((int)(tssikim * boyaPerSec) < gm.masaStok)
                    {
                        gm.boyaStok += (int)(tssikim * boyaPerSec);
                        Boya.text = String.Format("{0:0}", (int)(tssikim * boyaPerSec)) + " Painted Tables";
                        gm.masaStok -= (int)(tssikim * boyaPerSec);
                    }
                    else
                    {
                        gm.boyaStok += (int)(tssikim * boyaPerSec) - ((int)(tssikim * boyaPerSec) - (gm.masaStok));
                        Boya.text = String.Format("{0:0}", (int)(tssikim * boyaPerSec) - ((int)(tssikim * boyaPerSec) - (gm.masaStok))) + " Painted Tables";
                        gm.masaStok = 0;
                    }
                }
                else
                {
                    Boya.text = "0 Painted Table";
                }
            }

            #endregion

            #region Di�li
            if ((KulceOpDone == true) && (CiviOpDone == true))
            {
                if (disliMenajerAlindi == true)
                {
                    if ((int)(tssikim * disliPerSec) < gm.kulceStok)
                    {
                        gm.disliStok += (int)(tssikim * disliPerSec);
                        Disli.text = String.Format("{0:0}", (int)(tssikim * disliPerSec)) + " Gears";
                        gm.kulceStok -= (int)(tssikim * disliPerSec);
                    }
                    else
                    {
                        gm.disliStok += (int)(tssikim * disliPerSec) - ((int)(tssikim * disliPerSec) - (gm.kulceStok));
                        Disli.text = String.Format("{0:0}", (int)(tssikim * disliPerSec) - ((int)(tssikim * disliPerSec) - (gm.kulceStok))) + " Gears";
                        gm.kulceStok = 0;
                    }
                }
                else
                {
                    Disli.text = "0 Gears";
                }
            }
            
            #endregion

            #endregion
        }
        else
        {
            OfflineProgressGOBJ.SetActive(false);
        }
        #endregion

        #endregion
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

        #region Binalar al�nmam��ken upgradeler kapal� kals�n
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

        #region Y�kseltme cost ve gereken para g�sterimleri
        //H�z y�kseltmeleri
        upgradeCostGosterimler(woodSpdUpgCost, woodSpdUpgCostText, "");
        upgradeCostGosterimler(demirOreSpdUpgCost, demirOreSpdUpgCostText, "");
        upgradeCostGosterimler(timberSpdUpgCost, timberSpdUpgCostText, "");
        upgradeCostGosterimler(kulceSpdUpgCost, kulceSpdUpgCostText, "");
        upgradeCostGosterimler(masaSpdUpgCost, masaSpdUpgCostText, "");
        upgradeCostGosterimler(civiSpdUpgCost, civiSpdUpgCostText, "");
        upgradeCostGosterimler(disliSpdUpgCost, disliSpdUpgCostText, "");
        upgradeCostGosterimler(boyaSpdUpgCost, boyaSpdUpgCostText, "");
        //H�z y�kseltmesine para yetmiyorsa
        upgradeCostGosterimler(woodSpdUpgCost, woodspdyouneeddollartext, "You Need $");
        upgradeCostGosterimler(demirOreSpdUpgCost, demirOrespdyouneeddollartext, "You Need $");
        upgradeCostGosterimler(timberSpdUpgCost, timberspdyouneeddollartext, "You Need $");
        upgradeCostGosterimler(kulceSpdUpgCost, kulcespdyouneeddollartext, "You Need $");
        upgradeCostGosterimler(masaSpdUpgCost, masaspdyouneeddollartext, "You Need $");
        upgradeCostGosterimler(civiSpdUpgCost, civispdyouneeddollartext, "You Need $");
        upgradeCostGosterimler(disliSpdUpgCost, dislispdyouneeddollartext, "You Need $");
        upgradeCostGosterimler(boyaSpdUpgCost, boyaspdyouneeddollartext, "You Need $");

        //income y�kseltmeleri
        upgradeCostGosterimler(woodIncUpgCost, woodIncUpgCostText, "");
        upgradeCostGosterimler(demirOreIncUpgCost, demirOreIncUpgCostText, "");
        upgradeCostGosterimler(timberIncUpgCost, timberIncUpgCostText, "");
        upgradeCostGosterimler(kulceIncUpgCost, kulceIncUpgCostText, "");
        upgradeCostGosterimler(masaIncUpgCost, masaIncUpgCostText, "");
        upgradeCostGosterimler(civiIncUpgCost, civiIncUpgCostText, "");
        upgradeCostGosterimler(disliIncUpgCost, disliIncUpgCostText, "");
        upgradeCostGosterimler(boyaIncUpgCost, boyaIncUpgCostText, "");
        //income y�kseltmesine para yetmiyorsa
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

        #region Para yetmiyorsa butonlar� kapat

        #region Odun
        //Menajer al butonu, para yetmiyorsa veya menajer al�nd�ysa kapat
        buyMenajerButon(odunMenajerAlindi, buyWoodmanBtn, 200);
        //K�l�e h�z ve income upgrade butonlar�, para yetmiyorsa kapal� tut
        upgButon(woodSpdUpgCost, woodSpdUpgBuyBtn);
        upgButon(woodIncUpgCost, woodincUpgBtn);
        #endregion

        #region Demir
        //Menajer al butonu, para yetmiyorsa veya menajer al�nd�ysa kapat
        buyMenajerButon(demirOreMenajerAlindi, buyMinerBtn, 500);        
        //K�l�e h�z ve income upgrade butonlar�, para yetmiyorsa kapal� tut
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
        
        upgButon(timberSpdUpgCost, timberSpdUpgBuyBtn); //K�l�e h�z upgrade butonu, para yetmiyorsa kapal� tut
        upgButon(timberIncUpgCost, timberincUpgBtn);  //K�l�e income upgrade butonu, para yetmiyorsa kapal� tut
        buyMenajerButon(keresteMenajerAlindi, buyCarpenterBtn, 1200);  //Menajer al butonu, para yetmiyorsa veya menajer al�nd�ysa kapat        
        menajerUniteleri(keresteAlindi, carpenterUnite);  //Men� �ivi menajer �nitesi, bina al�nmad�ysa kapal� kals�n        
        uretimButonubirdegisken(GameManager.gm.odunStok, keresteUretButon);  //Kereste �ret butonu, odun yoksa        
        uiGosterimleri(keresteAlindi, keresteUi, keresteSatUnite);  //Di�li ui, bina al�n�nca a��lacak
        #endregion

        #region K�l�e
        //K�l�e bina al butonu
        binaAlButonuUcDegis(GameManager.gm.demirOreStok, 100, GameManager.gm.odunStok, 50, 850, buyOvenButton, kulceAlindi, kulcefillbar);

        //K�l�e h�z ve income upgrade butonlar�, para yetmiyorsa kapal� tut
        upgButon(kulceSpdUpgCost, kulceSpdUpgBuyBtn);
        upgButon(kulceIncUpgCost, kulceincUpgBtn);

        //Menajer al butonu, para yetmiyorsa veya menajer al�nd�ysa kapat
        buyMenajerButon(kulceMenajerAlindi, buyIronBakerBtn, 1600);

        //Men� k�l�e menajer �nitesi, bina al�nmad�ysa kapal� kals�n
        menajerUniteleri(kulceAlindi, ironBakerUnite);

        //K�l�e �ret butonu, odun demirore yoksa
        uretimButonuikidegisken(GameManager.gm.odunStok, GameManager.gm.demirOreStok, kulceUretButon);

        //K�l�e ui, bina al�n�nca a��lacak
        uiGosterimleri(kulceAlindi, kulceUi, kulceSatUnite);
        #endregion

        #region Masa
        //Masa bina al butonu
        binaAlButonuUcDegis(GameManager.gm.civiStok, 50, GameManager.gm.odunStok, 60, 1000, buyMasaButton, masaAlindi, masafillbar);

        //Masa h�z ve income upgrade butonlar�, para yetmiyorsa kapal� tut
        upgButon(masaSpdUpgCost, masaSpdUpgBuyBtn);
        upgButon(masaIncUpgCost, masaincUpgBtn);

        //Menajer al butonu, para yetmiyorsa veya menajer al�nd�ysa kapat
        buyMenajerButon(masaMenajerAlindi, buyMasaciBtn, 2000);

        //Men� Masa menajer �nitesi, bina al�nmad�ysa kapal� kals�n
        menajerUniteleri(masaAlindi, masaciUnite);

        //Masa �ret butonu, odun civi yoksa
        uretimButonuikidegisken(GameManager.gm.keresteStok, GameManager.gm.civiStok, masaUretButon);

        //Masa ui, bina al�n�nca a��lacak
        uiGosterimleri(masaAlindi, masaUi, masaSatUnite);
        #endregion

        #region �ivi        
        //�ivi bina al butonu
        binaAlButonuUcDegis(GameManager.gm.kulceStok, 120, GameManager.gm.odunStok, 75, 1250, buyNailButton, civiAlindi, civifillbar);

        //�ivi h�z ve income upgrade butonlar�, para yetmiyorsa kapal� tut
        upgButon(civiSpdUpgCost, civiSpdUpgBuyBtn);
        upgButon(civiIncUpgCost, civiincUpgBtn);

        //Menajer al butonu, para yetmiyorsa veya menajer al�nd�ysa kapat
        buyMenajerButon(civiMenajerAlindi, buyNailMngrBtn, 2200);

        //Men� �ivi menajer �nitesi, bina al�nmad�ysa kapal� kals�n
        menajerUniteleri(civiAlindi, civiMngrUnite);

        //�ivi �ret butonu, odun k�l�e yoksa
        uretimButonuikidegisken(GameManager.gm.odunStok, GameManager.gm.kulceStok, civiUretButon);

        //�ivi ui, bina al�n�nca a��lacak
        uiGosterimleri(civiAlindi, civiUi, civiSatUnite);
        #endregion

        #region Di�li
        //Di�li bina al butonu
        binaAlButonuUcDegis(GameManager.gm.kulceStok, 150, GameManager.gm.odunStok, 100, 1500,buyGearButton, disliAlindi, dislifillbar);
        
        //Di�li h�z ve income upgrade butonlar�, para yetmiyorsa kapal� tut
        upgButon(disliSpdUpgCost, disliSpdUpgBuyBtn);
        upgButon(disliIncUpgCost, disliincUpgBtn);
        
        //Menajer al butonu, para yetmiyorsa veya menajer al�nd�ysa kapat
        buyMenajerButon(disliMenajerAlindi, buyGearMngrBtn, 3000);

        //Men� di�li menajer �nitesi, bina al�nmad�ysa kapal� kals�n
        menajerUniteleri(disliAlindi, disliMngrUnite);
                
        //di�li �ret butonu, odun k�l�e yoksa
        uretimButonuikidegisken(GameManager.gm.odunStok, GameManager.gm.kulceStok, disliUretButon);

        //Di�li ui, bina al�n�nca a��lacak
        uiGosterimleri(disliAlindi, disliUi, disliSatUnite);
        #endregion

        #region Boya
        //Boya bina al butonu
        binaAlButonuUcDegis(GameManager.gm.keresteStok, 50, GameManager.gm.odunStok, 50, 1750, buyBoyaButton, boyaAlindi, boyafillbar);

        //Boya h�z ve income upgrade butonlar�, para yetmiyorsa kapal� tut
        upgButon(boyaSpdUpgCost, boyaSpdUpgBuyBtn);
        upgButon(boyaIncUpgCost, boyaincUpgBtn);

        //Menajer al butonu, para yetmiyorsa veya menajer al�nd�ysa kapat
        buyMenajerButon(boyaMenajerAlindi, buyBoyaMngrBtn, 3500);

        //Men� boya menajer �nitesi, bina al�nmad�ysa kapal� kals�n
        menajerUniteleri(boyaAlindi, boyaMngrUnite);

        //Boya �ret butonu, odun k�l�e yoksa
        uretimButonuikidegisken(GameManager.gm.masaStok, GameManager.gm.masaStok, boyaUretButon);

        //Boya ui, bina al�n�nca a��lacak
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

        #region woodIncomeUpgCost ilk �� level fiyat�, KALDIRILACAK
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
        if (Input.GetKeyDown(KeyCode.Tab)) {GameManager.gm.ChangeWorldsButton();}
        if (Input.GetKeyDown(KeyCode.Escape)) {GameManager.gm.MenuButton();}
        #endregion

        #region Save Load'da sorun ��karanlar� d�zeltmek        
        //menajer al�nd�ysa �retim butonunu kapat, al�nmad�ysa a��k tut
        mgrButonKapat(odunMenajerAlindi, cutBtn);
        mgrButonKapat(demirOreMenajerAlindi, digBtn);

        //Bina al�n�nca �itleri kapat, binay� a�        
        binaAlindi(keresteAlindi, keresteBinaCitleri, keresteBina);
        binaAlindi(kulceAlindi, kulceBinaCitleri, kulceBina);
        binaAlindi(masaAlindi, masaBinaCitleri, masaBina);
        binaAlindi(civiAlindi, civiBinaCitleri, civiBina);
        binaAlindi(disliAlindi, disliBinaCitleri, disliBina);
        binaAlindi(boyaAlindi, boyaBinaCitleri, boyaBina);
        #endregion

        #region Saniyede kazan�lan malzeme
        odunPerSec = 1 / (odunTime / odunZamanCarpan);
        demirPerSec = 1 / (demirTime / demirZamanCarpan);
        kerestePerSec = 1 / (keresteTime / keresteZamanCarpan);
        kulcePerSec = 1 / (kulceTime / kulceZamanCarpan);
        masaPerSec = 1 / (masaTime / masaZamanCarpan);
        civiPerSec = 1 / (civiTime / civiZamanCarpan);
        boyaPerSec = 1 / (boyaTime / boyaZamanCarpan);
        disliPerSec = 1 / (disliTime / disliZamanCarpan);
        #endregion

        //Son ��k�� zaman�n� kaydet, burada kaydettirme sebebim; oyunu alt+f4, g�rev y�neticisi gibi y�ntemlerle kapatsalar dahi kayd�n tutulmas�        
        sonGirisZaman = DateTime.Now.ToString();
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

    #region Masa

    #region Masa sell button
    public void masaSatTus()
    {
        GameManager.gm.anaPara += GameManager.gm.masaStok * GameManager.gm.masaPara;
        GameManager.gm.masaStok = 0;
    }
    #endregion

    #region Buy Masac� Buton
    public void BuyMasaciButton()
    {
        if (GameManager.gm.anaPara >= 2000) //menajeri almak i�in yeterli para varsa
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
        if (GameManager.gm.anaPara >= masaSpdUpgCost) //param�z upgradei almaya yetiyorsa
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
        if (GameManager.gm.anaPara >= masaIncUpgCost) //anaparam�z upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= masaIncUpgCost;
            GameManager.gm.masaPara *= 1.3f;
            masaIncUpgLvl += 1;
            masaIncUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region Buy Masa Bina button, f�r�n binas�
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
        if (GameManager.gm.anaPara >= 3500) //menajeri almak i�in yeterli para varsa
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
        if (GameManager.gm.anaPara >= boyaSpdUpgCost) //param�z upgradei almaya yetiyorsa
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
        if (GameManager.gm.anaPara >= boyaIncUpgCost) //anaparam�z upgradei almaya yetiyorsa
        {
            GameManager.gm.anaPara -= boyaIncUpgCost;
            GameManager.gm.boyaPara *= 1.3f;
            boyaIncUpgLvl += 1;
            boyaIncUpgCost *= 2.3f;
        }//dengele
    }
    #endregion

    #region Buy boya button, di�li binas�
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

    #region Sell All button
    public void SellAll()
    {
        odunSatTus();
        DemirOreSatButon();
        timberSatTus();
        kulceSatTus();
        masaSatTus();
        civiSatTus();
        disliSatTus();
        boyaSatTus();
    }
    #endregion

    #region OfflineProgYayBtn
    public void YayButton()
    {
        OfflineProgressGOBJ.SetActive(false);
    }
    #endregion

    #endregion

    #region Genel kullan�m i�in fonskiyonlar

    #region Save Load'da sorun ��karanlar i�in fonskiyonlar

    #region Menajer al�nd�/�ret tu�u
    public void mgrButonKapat(bool mgralindi, GameObject cutBtn)
    {
        cutBtn.SetActive(!mgralindi);
    }
    #endregion

    #region Bina al�nd�ysa �itleri kapat binay� a�
    public void binaAlindi(bool binaalindi, GameObject binacitler, GameObject bina)
    {        
        binacitler.SetActive(!binaalindi);
        bina.SetActive(binaalindi);
    }
    #endregion
    #endregion

        #region UI g�stergeleri, bina al�n�nca a��lacaklar
    public void uiGosterimleri(bool binaAlindi, GameObject binaUi, GameObject binaSatUnite)
    {        
        binaUi.SetActive(binaAlindi);
        binaSatUnite.SetActive(binaAlindi);
    }
    #endregion

        #region Gereksinimlerin durumuna g�re �retim butonu
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

        #region Menajer �niteleri, bina al�nmad�ysa kapal� kal�yorlar
    public void menajerUniteleri(bool binaalindi, GameObject binaMgrUnit)
    {
        binaMgrUnit.SetActive(binaalindi);
    }
    #endregion

        #region Buy menajer buton, para yoksa veya menajer al�nd�ysa kapal� tut
    public void buyMenajerButon(bool menajeralindi, GameObject buyMgrBtn, double mgrPara)
    {
        if (GameManager.gm.anaPara < mgrPara || menajeralindi == true) {buyMgrBtn.SetActive(false);}
        else {buyMgrBtn.SetActive(true);}
    }
    #endregion

        #region Upgrade Butonlar�, para upgrade'e yetmiyorsa kapat
    public void upgButon(float upgCost, GameObject upgBtn)
    {
        if (GameManager.gm.anaPara >= upgCost) {upgBtn.SetActive(true);}
        else {upgBtn.SetActive(false);}
    }
    #endregion

        #region Bina sat�n al butonu
    public void binaAlButonuUcDegis(double gerek1, int gerek1miktar, double gerek2, int gerek2miktar, double para, GameObject binaAlButon, bool binaAlindi, GameObject fillbar)
    {
        if ((gerek1 >= gerek1miktar) && (GameManager.gm.anaPara >= para) && (gerek2 >= gerek2miktar)) {binaAlButon.SetActive(true);}
        else {binaAlButon.SetActive(false);}
        if (binaAlindi == true) {binaAlButon.SetActive(false);}
        else {fillbar.SetActive(false);}
    }
    #endregion

        #region Upgrade Cost G�sterimleri
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

    #region Offline Progress i�in getiriler ve text g�sterimleri
    private void OfflineProgress(bool mgrBool, double degisken, double ts, float persec, Text txt, String malzeme)
    {
        if (mgrBool == true)
        {
            degisken += (int)(ts * persec);
            txt.text = (int)(ts * persec) + malzeme;
        }
        else
        {
            txt.text = "0 " + malzeme;
        }        
    }
    #endregion

    #endregion

}
