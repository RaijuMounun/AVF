#region K�t�phaneler
using UnityEngine;
using UnityEngine.UI;
using static System.Math;
using Sirenix.OdinInspector;
#endregion

public class GameManager : MonoBehaviour
{
    #region De�i�kenler
    public static GameManager gm;
    public static Menu menu;

    [TabGroup("Kasa")]
    public double anaPara;              //ana param�z
    [TabGroup("Kasa")]
    public double odunStok;             //stoktaki odun say�s�
    [TabGroup("Kasa")]
    public double keresteStok;          //stoktaki kereste say�s�
    [TabGroup("Kasa")]
    public double demirOreStok;         //stoktaki demir say�s�
    [TabGroup("Kasa")]
    public double kulceStok;            //stoktaki k�l�e say�s�
    [TabGroup("Kasa")]
    public double civiStok;             //stoktaki �ivi say�s�
    [TabGroup("Kasa")]
    public double disliStok;            //stoktaki di�li say�s�

    [TabGroup("Kasa")]
    public double odunPara;             //bir odunun ka� paraya sat�laca��n� tutuyor
    [TabGroup("Kasa")]
    public double kerestePara;          //bir kerestenin ka� paraya sat�laca��n� tutuyor
    [TabGroup("Kasa")]
    public double demirOrePara;         //bir ham demirin ka� paraya sat�laca��n� tutuyor
    [TabGroup("Kasa")]
    public double kulcePara;            //bir k�l�enin ka� paraya sat�laca��n� tutuyor
    [TabGroup("Kasa")]
    public double civiPara;             //bir �ivinin ka� paraya sat�laca��n� tutuyor
    [TabGroup("Kasa")]
    public double disliPara;            //bir di�linin ka� paraya sat�laca��n� tutuyor

    [TabGroup("Text")]
    public Text cuzdanText;             //anaparam�z� tutan text
    [Space]
    [TabGroup("Text")]
    public Text odunFillbarYuzdeText;   //fillbar�n y�zde ka� doldu�unu yazan text
    [TabGroup("Text")]
    public Text odunStokText;           //odun say�s�n� tutan text
    [TabGroup("Text")]
    public Text SatButonText;           //sat tu�unda gelecek paray� yazan text
    [Space]
    [TabGroup("Text")]
    public Text keresteSatButonText;    //sat tu�unda gelecek paray� yazan text
    [TabGroup("Text")]
    public Text keresteStokText;        //kereste sto�u tutan text
    [TabGroup("Text")]
    public Text keresteFillbarYuzdeText;//fillbar�n y�zde ka� doldu�unu yazan text
    [Space]
    [TabGroup("Text")]
    public Text demirFillbarYuzdeText;  //fillbar�n y�zde ka� doldu�unu yazan text
    [TabGroup("Text")]
    public Text demirStokText;          //demir say�s�n� tutan text
    [TabGroup("Text")]
    public Text demirOreSatButonText;   //sat tu�unda gelecek paray� yazan text
    [Space]
    [TabGroup("Text")]
    public Text kulceSatButonText;      //sat tu�unda gelecek paray� yazan text
    [TabGroup("Text")]
    public Text kulceStokText;          //kulce sto�u tutan text
    [TabGroup("Text")]
    public Text kulceFillbarYuzdeText;  //fillbar�n y�zde ka� doldu�unu yazan text
    [Space]
    [TabGroup("Text")]
    public Text civiSatButonText;       //sat tu�unda gelecek paray� yazan text
    [TabGroup("Text")]
    public Text civiStokText;           //civi sto�u tutan text
    [TabGroup("Text")]
    public Text civiFillbarYuzdeText;   //fillbar�n y�zde ka� doldu�unu yazan text
    [Space]
    [TabGroup("Text")]
    public Text disliSatButonText;      //sat tu�unda gelecek paray� yazan text
    [TabGroup("Text")]
    public Text disliStokText;          //di�li sto�u tutan text
    [TabGroup("Text")]
    public Text disliFillbarYuzdeText;  //fillbar�n y�zde ka� doldu�unu yazan text


    [TabGroup("Bools")]
    public bool cameraOdunda;          //d�nya de�i�tirirken tu�ta �al��acak
    [TabGroup("Bools")]
    public bool menuAcik;               //tek fonksiyonla men�y� a��p kapat�yorum
    [TabGroup("Bools")]
    public bool kaynakEkle;             //aktif olunca kaynaklar art�yor
    [Space]
    [TabGroup("Bools")]
    public bool baltaUretimBool;        //tu�a bas�ld���nda true olarak update'teki �retim s�recini ba�lat�yor
    [TabGroup("Bools")]
    public bool keresteUretimBool;      //tu�a bas�ld���nda true olarak update'teki �retim s�recini ba�lat�yor
    [TabGroup("Bools")]
    public bool demirUretimBool;        //tu�a bas�ld���nda true olarak update'teki �retim s�recini ba�lat�yor
    [TabGroup("Bools")]
    public bool kulceUretimBool;        //tu�a bas�ld���nda true olarak update'teki �retim s�recini ba�lat�yor
    [TabGroup("Bools")]
    public bool civiUretimBool;         //tu�a bas�ld���nda true olarak update'teki �retim s�recini ba�lat�yor
    [TabGroup("Bools")]
    public bool disliUretimBool;         //tu�a bas�ld���nda true olarak update'teki �retim s�recini ba�lat�yor


    [TabGroup("Animator")]
    public Animator baltaAnimator;      //animasyonu durdurup ba�lat�yorum
    [TabGroup("Animator")]
    public Animator testereAnimator;    //animasyonu durdurup ba�lat�yorum
    [TabGroup("Animator")]
    public Animator kazmaAnimator;      //animasyonu durdurup ba�lat�yorum
    [TabGroup("Animator")]
    public Animator ovenAnimator;       //animasyonu durdurup ba�lat�yorum
    [TabGroup("Animator")]
    public Animator civiAnimator;       //animasyonu durdurup ba�lat�yorum
    [TabGroup("Animator")]
    public Animator disliAnimator;      //animasyonu durdurup ba�lat�yorum

    [TabGroup("GObj")]
    public GameObject kamera;
    [TabGroup("GObj")]
    public GameObject yeniMenu;
    [TabGroup("GObj")]
    public GameObject sellGoodsMenu;
    [TabGroup("GObj")]
    public GameObject speedUpgradesMenu;
    [TabGroup("GObj")]
    public GameObject incomeUpgradesMenu;
    [TabGroup("GObj")]
    public GameObject workersMenu;
    [TabGroup("GObj")]
    public GameObject buildingsMenu;

    [TabGroup("gmobj,fillb,btn")]
    public GameObject odunFillbarButonlar;
    [TabGroup("gmobj,fillb,btn")]
    public GameObject demirFillbarButonlar;
    
    #endregion

    #region Awake, singleton
    private void Awake()
    {
        gm = this;
    }
    #endregion

    #region Start
    private void Start()
    {
        menuAcik = false;
        cameraOdunda = true;
    }
    #endregion

    #region Update
    void Update()
    {
        #region Odun

        #region Balta �retim
        if (baltaUretimBool == true)
        {
            baltaAnimator.enabled = true; //balta animasyonu ba�lat�yor
            Menu.menu.oduntimer += Menu.menu.odunZamanCarpan * Time.deltaTime;
            if (Menu.menu.oduntimer >= Menu.menu.odunTime)
            {//timer artarken timera ba�l� olarak fillbar da doluyor
                odunStok += 1; //fillbar dolunca odun �retiyor
                Menu.menu.oduntimer = 0;  //fillbar� s�f�rla
                if (Menu.menu.odunMenajerAlindi == false) //menajer al�nmad�ysa �retimi aktif tutan boolu kapat�yor
                {
                    baltaUretimBool = false;
                }
            }
            #region Fillbar
            Menu.menu.odunFillbar.fillAmount = Menu.menu.oduntimer / Menu.menu.odunTime;
            odunFillbarYuzdeText.text = string.Format("{0:#} %", ((Menu.menu.oduntimer / Menu.menu.odunTime) * 100));
            #endregion
        }
        else
        {
            baltaAnimator.enabled = false;
            odunFillbarYuzdeText.text = "0%";
        }
        #endregion

        #region Odun Textleri

        #region odun Satbuton text g�sterim
        if ((odunStok * odunPara < 1000) && (odunStok * odunPara > 0))
        {
            SatButonText.text = string.Format("${0:#.0}", odunStok * odunPara);
        }
        else if ((odunStok * odunPara >= 1000) && (odunPara * odunStok < 1000000))
        {
            SatButonText.text = "$" + ((odunStok * odunPara) / 1000).ToString("F") + " K";
        }
        else if ((odunStok * odunPara >= 1000000) && (odunStok * odunPara < 1000000000))
        {
            SatButonText.text = "$" + ((odunStok * odunPara) / 1000000).ToString("F") + " Mil.";
        }
        else if ((odunStok * odunPara >= 1000000000) && (odunStok * odunPara < 1000000000000))
        {
            SatButonText.text = "$" + ((odunStok * odunPara) / 1000000000).ToString("F") + " Bil.";
        }
        else if ((odunStok * odunPara >= 1000000000000) && (odunStok * odunPara < 1000000000000000))
        {
            SatButonText.text = "$" + ((odunStok * odunPara) / 1000000000000).ToString("F") + " Tril.";
        }
        else if ((odunStok * odunPara >= 1000000000000000) && (odunStok * odunPara < 1000000000000000000))
        {
            SatButonText.text = "$" + ((odunStok * odunPara) / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if ((odunStok * odunPara >= 1000000000000000000) && (odunStok * odunPara < 1000000000000000000000f))
        {
            SatButonText.text = "$" + ((odunStok * odunPara) / 1000000000000000000).ToString("F") + " Quintil.";
        }
        else if ((odunStok * odunPara) <= 0)
        {
            SatButonText.text = "$0";
        }
        #endregion

        #region OdunSTok g�sterim
        if (odunStok < 1000000)
        {
            odunStokText.text = string.Format("{0:#}", odunStok);
        }
        else if ((odunStok >= 1000000) && (odunStok < 1000000000))
        {
            odunStokText.text = (odunStok / 1000000).ToString("F") + " Mil.";
        }
        else if ((odunStok >= 1000000000) && (odunStok < 1000000000000))
        {
            odunStokText.text = (odunStok / 1000000000).ToString("F") + " Bil.";
        }
        else if ((odunStok >= 1000000000000) && (odunStok < 1000000000000000))
        {
            odunStokText.text = (odunStok / 1000000000000).ToString("F") + " Tril.";
        }
        else if ((odunStok >= 1000000000000000) & (odunStok < 1000000000000000000))
        {
            odunStokText.text = (odunStok / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if ((odunStok >= 1000000000000000000) && (odunStok < 1000000000000000000000f))
        {
            odunStokText.text = (odunStok / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #endregion

        #endregion

        //////////////////////////////////////////////

        #region Demir

        #region Demir �retim
        if (demirUretimBool == true)
        {
            kazmaAnimator.enabled = true;
            Menu.menu.demirTimer += Menu.menu.demirZamanCarpan * Time.deltaTime;
            if (Menu.menu.demirTimer >= Menu.menu.demirTime)
            {
                demirOreStok += 1;
                Menu.menu.demirTimer = 0;
                if (Menu.menu.demirOreMenajerAlindi == false)
                {
                    demirUretimBool = false;
                }                
            }
            #region Fillbar
            Menu.menu.demirFillbar.fillAmount = Menu.menu.demirTimer / Menu.menu.demirTime;
            demirFillbarYuzdeText.text = string.Format("{0:#} %", ((Menu.menu.demirTimer / Menu.menu.demirTime) * 100));
            #endregion
        }
        else
        {
            kazmaAnimator.enabled = false;
            demirFillbarYuzdeText.text = "0%";
        }
        #endregion

        #region Demir Textleri

        #region DemirStok G�sterim
        if (demirOreStok <= 0)
        {
            demirStokText.text = "0";
        }
        else if ((demirOreStok < 1000000) && (demirOreStok > 0))
        {
            demirStokText.text = string.Format("{0:#}", demirOreStok);
        }
        else if ((demirOreStok >= 1000000) && (demirOreStok < 1000000000))
        {
            demirStokText.text = (demirOreStok / 1000000).ToString("F") + " Mil.";
        }
        else if ((demirOreStok >= 1000000000) && (demirOreStok < 1000000000000))
        {
            demirStokText.text = (demirOreStok / 1000000000).ToString("F") + " Bil.";
        }
        else if ((demirOreStok >= 1000000000000) && (demirOreStok < 1000000000000000))
        {
            demirStokText.text = (demirOreStok / 1000000000000).ToString("F") + " Tril.";
        }
        else if ((demirOreStok >= 1000000000000000) & (demirOreStok < 1000000000000000000))
        {
            demirStokText.text = (demirOreStok / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if ((demirOreStok >= 1000000000000000000) && (demirOreStok < 1000000000000000000000f))
        {
            demirStokText.text = (demirOreStok / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region Demir SatButon G�sterim
        if ((demirOreStok * demirOrePara < 1000) && (demirOreStok * demirOrePara > 0))
        {
            demirOreSatButonText.text = string.Format("${0:#.0}", demirOreStok * demirOrePara);
        }
        else if ((demirOreStok * demirOrePara >= 1000) && (demirOrePara * demirOreStok < 1000000))
        {
            demirOreSatButonText.text = "$" + ((demirOreStok * demirOrePara) / 1000).ToString("F") + " K";
        }
        else if ((demirOreStok * demirOrePara >= 1000000) && (demirOreStok * demirOrePara < 1000000000))
        {
            demirOreSatButonText.text = "$" + ((demirOreStok * demirOrePara) / 1000000).ToString("F") + " Mil.";
        }
        else if ((demirOreStok * demirOrePara >= 1000000000) && (demirOreStok * demirOrePara < 1000000000000))
        {
            demirOreSatButonText.text = "$" + ((demirOreStok * demirOrePara) / 1000000000).ToString("F") + " Bil.";
        }
        else if ((demirOreStok * demirOrePara >= 1000000000000) && (demirOreStok * demirOrePara < 1000000000000000))
        {
            demirOreSatButonText.text = "$" + ((demirOreStok * demirOrePara) / 1000000000000).ToString("F") + " Tril.";
        }
        else if ((demirOreStok * demirOrePara >= 1000000000000000) && (demirOreStok * demirOrePara < 1000000000000000000))
        {
            demirOreSatButonText.text = "$" + ((demirOreStok * demirOrePara) / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if ((demirOreStok * demirOrePara >= 1000000000000000000) && (demirOreStok * demirOrePara < 1000000000000000000000f))
        {
            demirOreSatButonText.text = "$" + ((demirOreStok * demirOrePara) / 1000000000000000000).ToString("F") + " Quintil.";
        }
        else if ((demirOreStok * demirOrePara) <= 0)
        {
            demirOreSatButonText.text = "$0";
        }
        #endregion

        #endregion

        #endregion

        //////////////////////////////////////////////

        #region Kereste

        #region Kereste �retim
        if (Menu.menu.keresteMenajerAlindi == false)//menajer yokken buras�
        {
            if (keresteUretimBool == true)
            {
                #region Fillbar
                Menu.menu.kerestetimer += Menu.menu.keresteZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.keresteFillbar.fillAmount = Menu.menu.kerestetimer / Menu.menu.keresteTime;
                keresteFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.kerestetimer / Menu.menu.keresteTime) * 100));
                #endregion

                testereAnimator.enabled = true;

                if (Menu.menu.kerestetimer >= Menu.menu.keresteTime) //fillbar doldu�unda
                {
                    Menu.menu.kerestetimer = 0; //fillbar� s�f�rla
                    keresteStok += 1;
                    keresteUretimBool = false;
                }
            }
            else
            {                
                keresteFillbarYuzdeText.text = "%0";
                Menu.menu.keresteFillbar.fillAmount = 0;
                testereAnimator.enabled = false;
            }
        }
        else //menajer varken buras�
        {
            if (odunStok >= 1)
            {
                keresteUretimBool = true;
                Menu.menu.keresteUretButon.SetActive(false);
                testereAnimator.enabled = true;

                #region Fillbar
                Menu.menu.kerestetimer += Menu.menu.keresteZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.keresteFillbar.fillAmount = Menu.menu.kerestetimer / Menu.menu.keresteTime;
                keresteFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.kerestetimer / Menu.menu.keresteTime) * 100));
                #endregion

                if (Menu.menu.kerestetimer >= Menu.menu.keresteTime) //fillbar doldu�unda
                {
                    Menu.menu.kerestetimer = 0; //fillbar� s�f�rla
                    odunStok -= 1;
                    keresteStok += 1;
                }
            }
            else
            {
                Menu.menu.keresteFillbar.fillAmount = 0;
                keresteFillbarYuzdeText.text = "%0";
                testereAnimator.enabled = false;
            }
        }
        #endregion

        #region Kereste Textleri

        #region KeresteStok g�sterim
        if (keresteStok <= 0)
        {
            keresteStokText.text = "0";
        }
        else if ((keresteStok > 0) && (keresteStok < 1000000))
        {
            keresteStokText.text = string.Format("{0:#}", keresteStok);
        }
        else if ((keresteStok >= 1000000) && (keresteStok < 1000000000))
        {
            keresteStokText.text = (keresteStok / 1000000).ToString("F") + " Mil.";
        }
        else if ((keresteStok >= 1000000000) && (keresteStok < 1000000000000))
        {
            keresteStokText.text = (keresteStok / 1000000000).ToString("F") + " Bil.";
        }
        else if ((keresteStok >= 1000000000000) && (keresteStok < 1000000000000000))
        {
            keresteStokText.text = (keresteStok / 1000000000000).ToString("F") + " Tril.";
        }
        else if ((keresteStok >= 1000000000000000) & (keresteStok < 1000000000000000000))
        {
            keresteStokText.text = (keresteStok / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if ((keresteStok >= 1000000000000000000) && (keresteStok < 1000000000000000000000f))
        {
            keresteStokText.text = (keresteStok / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region Kereste sat buton text
        if ((keresteStok * kerestePara < 1000) && (keresteStok * kerestePara > 0))
        {
            keresteSatButonText.text = string.Format("${0:#.0}", keresteStok * kerestePara);
        }
        else if ((keresteStok * kerestePara >= 1000) && (kerestePara * keresteStok < 1000000))
        {
            keresteSatButonText.text = "$" + ((keresteStok * kerestePara) / 1000).ToString("F") + " K";
        }
        else if ((keresteStok * kerestePara >= 1000000) && (keresteStok * kerestePara < 1000000000))
        {
            keresteSatButonText.text = "$" + ((keresteStok * kerestePara) / 1000000).ToString("F") + " Mil.";
        }
        else if ((keresteStok * kerestePara >= 1000000000) && (keresteStok * kerestePara < 1000000000000))
        {
            keresteSatButonText.text = "$" + ((keresteStok * kerestePara) / 1000000000).ToString("F") + " Bil.";
        }
        else if ((keresteStok * kerestePara >= 1000000000000) && (keresteStok * kerestePara < 1000000000000000))
        {
            keresteSatButonText.text = "$" + ((keresteStok * kerestePara) / 1000000000000).ToString("F") + " Tril.";
        }
        else if ((keresteStok * kerestePara >= 1000000000000000) && (keresteStok * kerestePara < 1000000000000000000))
        {
            keresteSatButonText.text = "$" + ((keresteStok * kerestePara) / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if ((keresteStok * kerestePara >= 1000000000000000000) && (keresteStok * kerestePara < 1000000000000000000000f))
        {
            keresteSatButonText.text = "$" + ((keresteStok * kerestePara) / 1000000000000000000).ToString("F") + " Quintil.";
        }
        else if ((keresteStok * kerestePara) <= 0)
        {
            keresteSatButonText.text = "$0";
        }
        #endregion

        #endregion

        #endregion

        /////////////////////////////////////////////

        #region K�l�e

        #region K�l�e �retim
        if (Menu.menu.kulceMenajerAlindi == false)//menajer yokken buras�
        {
            if (kulceUretimBool == true)
            {
                #region Fillbar
                Menu.menu.kulcetimer += Menu.menu.kulceZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.kulceFillbar.fillAmount = Menu.menu.kulcetimer / Menu.menu.kulceTime;
                kulceFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.kulcetimer / Menu.menu.kulceTime) * 100));
                #endregion

                ovenAnimator.enabled = true;

                if (Menu.menu.kulcetimer >= Menu.menu.kulceTime) //fillbar doldu�unda
                {
                    Menu.menu.kulcetimer = 0; //fillbar� s�f�rla
                    kulceStok += 1;
                    kulceUretimBool = false;
                }
            }
            else
            {
                kulceFillbarYuzdeText.text = "%0";
                Menu.menu.kulceFillbar.fillAmount = 0;
                ovenAnimator.enabled = false;
            }
        }
        else //menajer varken buras�
        {
            if ((odunStok >= 1) && (demirOreStok >= 1))
            {
                kulceUretimBool = true;
                Menu.menu.kulceUretButon.SetActive(false);
                ovenAnimator.enabled = true;

                #region Fillbar
                Menu.menu.kulcetimer += Menu.menu.kulceZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.kulceFillbar.fillAmount = Menu.menu.kulcetimer / Menu.menu.kulceTime;
                kulceFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.kulcetimer / Menu.menu.kulceTime) * 100));
                #endregion

                if (Menu.menu.kulcetimer >= Menu.menu.kulceTime) //fillbar doldu�unda
                {
                    Menu.menu.kulcetimer = 0; //fillbar� s�f�rla
                    odunStok -= 1;
                    demirOreStok -= 1;
                    kulceStok += 1;
                }
            }
            else
            {
                Menu.menu.kulceFillbar.fillAmount = 0;
                kulceFillbarYuzdeText.text = "%0";
                ovenAnimator.enabled = false;
            }
        }
        #endregion

        #region K�l�e Text

        #region K�l�eStok g�sterim
        if (kulceStok <= 0)
        {
            kulceStokText.text = "0";
        }
        else if ((kulceStok > 0) && (kulceStok < 1000000))
        {
            kulceStokText.text = string.Format("{0:#}", kulceStok);
        }
        else if ((kulceStok >= 1000000) && (kulceStok < 1000000000))
        {
            kulceStokText.text = (kulceStok / 1000000).ToString("F") + " Mil.";
        }
        else if ((kulceStok >= 1000000000) && (kulceStok < 1000000000000))
        {
            kulceStokText.text = (kulceStok / 1000000000).ToString("F") + " Bil.";
        }
        else if ((kulceStok >= 1000000000000) && (kulceStok < 1000000000000000))
        {
            kulceStokText.text = (kulceStok / 1000000000000).ToString("F") + " Tril.";
        }
        else if ((kulceStok >= 1000000000000000) & (kulceStok < 1000000000000000000))
        {
            kulceStokText.text = (kulceStok / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if ((kulceStok >= 1000000000000000000) && (kulceStok < 1000000000000000000000f))
        {
            kulceStokText.text = (kulceStok / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region K�l�e sat buton text
        if ((kulceStok * kulcePara < 1000) && (kulceStok * kulcePara > 0))
        {
            kulceSatButonText.text = string.Format("${0:#.0}", kulceStok * kulcePara);
        }
        else if ((kulceStok * kulcePara >= 1000) && (kulcePara * kulceStok < 1000000))
        {
            kulceSatButonText.text = "$" + ((kulceStok * kulcePara) / 1000).ToString("F") + " K";
        }
        else if ((kulceStok * kulcePara >= 1000000) && (kulceStok * kulcePara < 1000000000))
        {
            kulceSatButonText.text = "$" + ((kulceStok * kulcePara) / 1000000).ToString("F") + " Mil.";
        }
        else if ((kulceStok * kulcePara >= 1000000000) && (kulceStok * kulcePara < 1000000000000))
        {
            kulceSatButonText.text = "$" + ((kulceStok * kulcePara) / 1000000000).ToString("F") + " Bil.";
        }
        else if ((kulceStok * kulcePara >= 1000000000000) && (kulceStok * kulcePara < 1000000000000000))
        {
            kulceSatButonText.text = "$" + ((kulceStok * kulcePara) / 1000000000000).ToString("F") + " Tril.";
        }
        else if ((kulceStok * kulcePara >= 1000000000000000) && (kulceStok * kulcePara < 1000000000000000000))
        {
            kulceSatButonText.text = "$" + ((kulceStok * kulcePara) / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if ((kulceStok * kulcePara >= 1000000000000000000) && (kulceStok * kulcePara < 1000000000000000000000f))
        {
            kulceSatButonText.text = "$" + ((kulceStok * kulcePara) / 1000000000000000000).ToString("F") + " Quintil.";
        }
        else if ((kulceStok * kulcePara) <= 0)
        {
            kulceSatButonText.text = "$0";
        }
        #endregion

        #endregion

        #endregion

        ////////////////////////////////////////////

        #region �ivi

        #region �ivi �retim
        if (Menu.menu.civiMenajerAlindi == false)//menajer yokken buras�
        {
            if (civiUretimBool == true)
            {
                #region Fillbar
                Menu.menu.civitimer += Menu.menu.civiZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.civiFillbar.fillAmount = Menu.menu.civitimer / Menu.menu.civiTime;
                civiFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.civitimer / Menu.menu.civiTime) * 100));
                #endregion

                civiAnimator.enabled = true;

                if (Menu.menu.civitimer >= Menu.menu.civiTime) //fillbar doldu�unda
                {
                    Menu.menu.civitimer = 0; //fillbar� s�f�rla
                    civiStok += 1;
                    civiUretimBool = false;
                }
            }
            else
            {
                civiFillbarYuzdeText.text = "%0";
                Menu.menu.civiFillbar.fillAmount = 0;
                civiAnimator.enabled = false;
            }
        }
        else //menajer varken buras�
        {
            if ((odunStok >= 1) && (kulceStok >= 1))
            {
                civiUretimBool = true;
                Menu.menu.civiUretButon.SetActive(false);
                civiAnimator.enabled = true;

                #region Fillbar
                Menu.menu.civitimer += Menu.menu.civiZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.civiFillbar.fillAmount = Menu.menu.civitimer / Menu.menu.civiTime;
                civiFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.civitimer / Menu.menu.civiTime) * 100));
                #endregion

                if (Menu.menu.civitimer >= Menu.menu.civiTime) //fillbar doldu�unda
                {
                    Menu.menu.civitimer = 0; //fillbar� s�f�rla
                    odunStok -= 1;
                    kulceStok -= 1;
                    civiStok += 1;
                }
            }
            else
            {
                Menu.menu.civiFillbar.fillAmount = 0;
                civiFillbarYuzdeText.text = "%0";
                civiAnimator.enabled = false;
            }
        }
        #endregion

        #region �ivi Text

        #region �iviStok G�sterim
        if (civiStok <= 0)
        {
            civiStokText.text = "0";
        }
        else if ((civiStok > 0) && (civiStok < 1000000))
        {
            civiStokText.text = string.Format("{0:#}", civiStok);
        }
        else if ((civiStok >= 1000000) && (civiStok < 1000000000))
        {
            civiStokText.text = (civiStok / 1000000).ToString("F") + " Mil.";
        }
        else if ((civiStok >= 1000000000) && (civiStok < 1000000000000))
        {
            civiStokText.text = (civiStok / 1000000000).ToString("F") + " Bil.";
        }
        else if ((civiStok >= 1000000000000) && (civiStok < 1000000000000000))
        {
            civiStokText.text = (civiStok / 1000000000000).ToString("F") + " Tril.";
        }
        else if ((civiStok >= 1000000000000000) & (civiStok < 1000000000000000000))
        {
            civiStokText.text = (civiStok / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if ((civiStok >= 1000000000000000000) && (civiStok < 1000000000000000000000f))
        {
            civiStokText.text = (civiStok / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region civi Sat Buton Text
        if ((civiStok * civiPara < 1000) && (civiStok * civiPara > 0))
        {
            civiSatButonText.text = string.Format("${0:#.0}", civiStok * civiPara);
        }
        else if ((civiStok * civiPara >= 1000) && (civiPara * civiStok < 1000000))
        {
            civiSatButonText.text = "$" + ((civiStok * civiPara) / 1000).ToString("F") + " K";
        }
        else if ((civiStok * civiPara >= 1000000) && (civiStok * civiPara < 1000000000))
        {
            civiSatButonText.text = "$" + ((civiStok * civiPara) / 1000000).ToString("F") + " Mil.";
        }
        else if ((civiStok * civiPara >= 1000000000) && (civiStok * civiPara < 1000000000000))
        {
            civiSatButonText.text = "$" + ((civiStok * civiPara) / 1000000000).ToString("F") + " Bil.";
        }
        else if ((civiStok * civiPara >= 1000000000000) && (civiStok * civiPara < 1000000000000000))
        {
            civiSatButonText.text = "$" + ((civiStok * civiPara) / 1000000000000).ToString("F") + " Tril.";
        }
        else if ((civiStok * civiPara >= 1000000000000000) && (civiStok * civiPara < 1000000000000000000))
        {
            civiSatButonText.text = "$" + ((civiStok * civiPara) / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if ((civiStok * civiPara >= 1000000000000000000) && (civiStok * civiPara < 1000000000000000000000f))
        {
            civiSatButonText.text = "$" + ((civiStok * civiPara) / 1000000000000000000).ToString("F") + " Quintil.";
        }
        else if ((civiStok * civiPara) <= 0)
        {
            civiSatButonText.text = "$0";
        }
        #endregion

        #endregion

        #endregion

        ////////////////////////////////////////////

        #region Di�li

        #region Di�li �retim
        if (Menu.menu.disliMenajerAlindi == false)//menajer yokken buras�
        {
            if (disliUretimBool == true)
            {
                #region Fillbar
                Menu.menu.dislitimer += Menu.menu.disliZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.disliFillbar.fillAmount = Menu.menu.dislitimer / Menu.menu.disliTime;
                disliFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.dislitimer / Menu.menu.disliTime) * 100));
                #endregion

                disliAnimator.enabled = true;

                if (Menu.menu.dislitimer >= Menu.menu.disliTime) //fillbar doldu�unda
                {
                    Menu.menu.dislitimer = 0; //fillbar� s�f�rla
                    disliStok += 1;
                    disliUretimBool = false;
                }
            }
            else
            {
                disliFillbarYuzdeText.text = "%0";
                Menu.menu.disliFillbar.fillAmount = 0;
                disliAnimator.enabled = false;
            }
        }
        else //menajer varken buras�
        {
            if ((odunStok >= 1) && (kulceStok >= 1))
            {
                disliUretimBool = true;
                Menu.menu.disliUretButon.SetActive(false);
                disliAnimator.enabled = true;

                #region Fillbar
                Menu.menu.dislitimer += Menu.menu.disliZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.disliFillbar.fillAmount = Menu.menu.dislitimer / Menu.menu.disliTime;
                disliFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.dislitimer / Menu.menu.disliTime) * 100));
                #endregion

                if (Menu.menu.dislitimer >= Menu.menu.disliTime) //fillbar doldu�unda
                {
                    Menu.menu.dislitimer = 0; //fillbar� s�f�rla
                    odunStok -= 1;
                    kulceStok -= 1;
                    disliStok += 1;
                }
            }
            else
            {
                Menu.menu.disliFillbar.fillAmount = 0;
                disliFillbarYuzdeText.text = "%0";
                disliAnimator.enabled = false;
            }
        }
        #endregion

        #region Di�li Text

        #region Di�liStok G�sterim
        if (disliStok <= 0)
        {
            disliStokText.text = "0";
        }
        else if ((disliStok > 0) && (disliStok < 1000000))
        {
            disliStokText.text = string.Format("{0:#}", disliStok);
        }
        else if ((disliStok >= 1000000) && (disliStok < 1000000000))
        {
            disliStokText.text = (disliStok / 1000000).ToString("F") + " Mil.";
        }
        else if ((disliStok >= 1000000000) && (disliStok < 1000000000000))
        {
            disliStokText.text = (disliStok / 1000000000).ToString("F") + " Bil.";
        }
        else if ((disliStok >= 1000000000000) && (disliStok < 1000000000000000))
        {
            disliStokText.text = (disliStok / 1000000000000).ToString("F") + " Tril.";
        }
        else if ((disliStok >= 1000000000000000) & (disliStok < 1000000000000000000))
        {
            disliStokText.text = (disliStok / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if ((disliStok >= 1000000000000000000) && (disliStok < 1000000000000000000000f))
        {
            disliStokText.text = (disliStok / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion

        #region Di�li Sat Buton Text
        if ((disliStok * disliPara < 1000) && (disliStok * disliPara > 0))
        {
            disliSatButonText.text = string.Format("${0:#.0}", disliStok * disliPara);
        }
        else if ((disliStok * disliPara >= 1000) && (disliStok * disliPara < 1000000))
        {
            disliSatButonText.text = "$" + ((disliStok * disliPara) / 1000).ToString("F") + " K";
        }
        else if ((disliStok * disliPara >= 1000000) && (disliStok * disliPara < 1000000000))
        {
            disliSatButonText.text = "$" + ((disliStok * disliPara) / 1000000).ToString("F") + " Mil.";
        }
        else if ((disliStok * disliPara >= 1000000000) && (disliStok * disliPara < 1000000000000))
        {
            disliSatButonText.text = "$" + ((disliStok * disliPara) / 1000000000).ToString("F") + " Bil.";
        }
        else if ((disliStok * disliPara >= 1000000000000) && (disliStok * disliPara < 1000000000000000))
        {
            disliSatButonText.text = "$" + ((disliStok * disliPara) / 1000000000000).ToString("F") + " Tril.";
        }
        else if ((disliStok * disliPara >= 1000000000000000) && (disliStok * disliPara < 1000000000000000000))
        {
            disliSatButonText.text = "$" + ((disliStok * disliPara) / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if ((disliStok * disliPara >= 1000000000000000000) && (disliStok * disliPara < 1000000000000000000000f))
        {
            disliSatButonText.text = "$" + ((disliStok * disliPara) / 1000000000000000000).ToString("F") + " Quintil.";
        }
        else if ((disliStok * disliPara) <= 0)
        {
            disliSatButonText.text = "$0";
        }
        #endregion

        #endregion

        #endregion

        ////////////////////////////////////////////


        #region Textler

        #region AnaPara g�sterim
        if (anaPara < 1000000)
        {
            cuzdanText.text = string.Format("${0:#.0}", anaPara);
        }
        else if ((anaPara >= 1000000) && (anaPara < 1000000000))
        {
            cuzdanText.text = (anaPara / 1000000).ToString("F") + " Mil.";
        }
        else if ((anaPara >= 1000000000)&&(anaPara< 1000000000000))
        {
            cuzdanText.text = (anaPara / 1000000000).ToString("F") + " Bil.";
        }
        else if ((anaPara >= 1000000000000)&&(anaPara< 1000000000000000))
        {
            cuzdanText.text = (anaPara / 1000000000000).ToString("F") + " Tril.";
        }
        else if ((anaPara >= 1000000000000000)&(anaPara< 1000000000000000000))
        {
            cuzdanText.text = (anaPara / 1000000000000000).ToString("F") + " Quadril.";
        }
        else if ((anaPara >= 1000000000000000000)&&(anaPara< 1000000000000000000000f))
        {
            cuzdanText.text = (anaPara / 1000000000000000000).ToString("F") + " Quintil.";
        }
        #endregion       

        #region e�er s�f�rsa textler bozulmas�n
        if (odunStok <= 0)
        {
            odunStok = 0;
            odunStokText.text = "0";
        }
        if (anaPara <= 0)
        {
            anaPara = 0;
            cuzdanText.text = "$0";
        }
        if (kulceStok <= 0)
        {
            kulceStok = 0;
            kulceStokText.text = "0";
        }
        if (civiStok <= 0)
        {
            civiStok = 0;
            civiStokText.text = "0";
        }
        if (disliStok <= 0)
        {
            disliStok = 0;
            disliStokText.text = "0";
        }
        #endregion

        #endregion

        #region D�nyaya g�re kamera pozisyonu ve gui
        if (cameraOdunda == false)
        {
            kamera.transform.position = new Vector3(-86, 24, 0);
            odunFillbarButonlar.SetActive(false);
            demirFillbarButonlar.SetActive(true);
        }
        else
        {
            kamera.transform.position = new Vector3(-22, 24, -37);
            odunFillbarButonlar.SetActive(true);
            demirFillbarButonlar.SetActive(false);
        }
        #endregion

        #region Kaynak ekle
        if (kaynakEkle == true)
        {
            anaPara += 10;
            odunStok += 1;
            demirOreStok += 1;
            kulceStok += 1;
            keresteStok += 1;
            civiStok += 1;
            disliStok += 1;
        }
        #endregion

    }
    #endregion

    #region Buton Fonksiyonlar�

    #region baltaUretim
    public void baltaUretim()
    {
        baltaUretimBool = true;
    }
    #endregion

    #region Demir �retim
    public void demirUretim()
    {
        demirUretimBool = true;
    }
    #endregion

    #region Kereste �retim
    public void KeresteUretim()
    {
        if (keresteUretimBool == false)
        {
            odunStok -= 1;
        }
        keresteUretimBool = true;
    }
    #endregion

    #region K�l�e �retim
    public void KulceUretim()
    {
        if (kulceUretimBool == false)
        {
            demirOreStok -= 1;
            odunStok -= 1;
        }
        kulceUretimBool = true;
    }
    #endregion

    #region �ivi �retim
    public void CiviUretim()
    {
        if (civiUretimBool == false)
        {
            kulceStok -= 1;
            odunStok -= 1;
        }
        civiUretimBool = true;
    }
    #endregion

    #region Di�li �retim
    public void DisliUretim()
    {
        if (disliUretimBool == false)
        {
            kulceStok -= 1;
            odunStok -= 1;
        }
        disliUretimBool = true;
    }
    #endregion

    #region Men� Tu�lar�

    #region Sell Goods Tu�
    public void sellgoodsTus()
    {
        speedUpgradesMenu.SetActive(false);
        incomeUpgradesMenu.SetActive(false);
        workersMenu.SetActive(false);
        buildingsMenu.SetActive(false);

        sellGoodsMenu.SetActive(true);
    }
    #endregion

    #region Speed Upgrades Tu�
    public void speedUpgradesTus()
    {
        incomeUpgradesMenu.SetActive(false);
        workersMenu.SetActive(false);
        buildingsMenu.SetActive(false);
        sellGoodsMenu.SetActive(false);

        speedUpgradesMenu.SetActive(true);
    }
    #endregion

    #region income Upgrades Tu�
    public void incomeUpgradesTus()
    {
        workersMenu.SetActive(false);
        buildingsMenu.SetActive(false);
        sellGoodsMenu.SetActive(false);
        speedUpgradesMenu.SetActive(false);

        incomeUpgradesMenu.SetActive(true);
    }
    #endregion

    #region Workers Tu�
    public void workersTus()
    {
        buildingsMenu.SetActive(false);
        sellGoodsMenu.SetActive(false);
        speedUpgradesMenu.SetActive(false);
        incomeUpgradesMenu.SetActive(false);

        workersMenu.SetActive(true);
    }
    #endregion

    #region Buildings Tu�
    public void buildingsTus()
    {
        sellGoodsMenu.SetActive(false);
        speedUpgradesMenu.SetActive(false);
        incomeUpgradesMenu.SetActive(false);
        workersMenu.SetActive(false);

        buildingsMenu.SetActive(true);
    }
    #endregion

    #region Menu Butonu ve men�y� kapat butonu
    public void MenuButton()
    {
        if (menuAcik == false)
        {
            yeniMenu.SetActive(true);
            menuAcik = true;
        }
        else if (menuAcik == true)
        {
            yeniMenu.SetActive(false);
            menuAcik = false;
        }
    }
    #endregion        

    #region Change worlds button
    public void ChangeWorldsButton()
    {
        if (cameraOdunda == false)
        {
            cameraOdunda = true;
        }
        else
        {
            cameraOdunda = false;
        }
    }
    #endregion

    #region Oyunu Kapat
    public void OyunuKapat()
    {
        Application.Quit();
    }
    #endregion

    #endregion

    #region Test butonu
    public void KaynakEkle()
    {
        if (kaynakEkle == false)
        {
            kaynakEkle = true;
        }
        else
        {
            kaynakEkle = false;
        }
    }
    #endregion

    #endregion
}
