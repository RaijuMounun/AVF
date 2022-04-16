#region Kütüphaneler
using UnityEngine;
using UnityEngine.UI;
using static System.Math;
using Sirenix.OdinInspector;
#endregion

public class GameManager : MonoBehaviour
{//fillbarlara fonksiyon yaz
    #region Deðiþkenler
    public static GameManager gm;
    public static Menu menu;

    #region Büyük sayý constantlarý
    const double million = 1000000;
    const double billion = 1000000000;
    const double trillion = 1000000000000;
    const double quadrillion = 1000000000000000;
    const double quintillion = 1000000000000000000;
    #endregion

    [TabGroup("Kasa")]
    public double anaPara;              //ana paramýz
    [TabGroup("Kasa")]
    public double odunStok;             //stoktaki odun sayýsý
    [TabGroup("Kasa")]
    public double keresteStok;          //stoktaki kereste sayýsý
    [TabGroup("Kasa")]
    public double demirOreStok;         //stoktaki demir sayýsý
    [TabGroup("Kasa")]
    public double kulceStok;            //stoktaki külçe sayýsý
    [TabGroup("Kasa")]
    public double masaStok;           //stoktaki boyalý kereste sayýsý
    [TabGroup("Kasa")]
    public double civiStok;             //stoktaki çivi sayýsý
    [TabGroup("Kasa")]
    public double disliStok;            //stoktaki diþli sayýsý
    [TabGroup("Kasa")]
    public double boyaStok;           //stoktaki boyalý kereste sayýsý

    [TabGroup("Kasa")]
    public double odunPara;             //bir odunun kaç paraya satýlacaðýný tutuyor
    [TabGroup("Kasa")]
    public double kerestePara;          //bir kerestenin kaç paraya satýlacaðýný tutuyor
    [TabGroup("Kasa")]
    public double demirOrePara;         //bir ham demirin kaç paraya satýlacaðýný tutuyor
    [TabGroup("Kasa")]
    public double kulcePara;            //bir külçenin kaç paraya satýlacaðýný tutuyor
    [TabGroup("Kasa")]
    public double masaPara;           //bir boyalý kerestenin kaç paraya satýlacaðýný tutuyor
    [TabGroup("Kasa")]
    public double civiPara;             //bir çivinin kaç paraya satýlacaðýný tutuyor
    [TabGroup("Kasa")]
    public double disliPara;            //bir diþlinin kaç paraya satýlacaðýný tutuyor
    [TabGroup("Kasa")]
    public double boyaPara;           //bir boyalý kerestenin kaç paraya satýlacaðýný tutuyor

    [TabGroup("Text")]
    public Text cuzdanText;             //anaparamýzý tutan text
    [Space]
    [TabGroup("Text")]
    public Text odunFillbarYuzdeText;   //fillbarýn yüzde kaç dolduðunu yazan text
    [TabGroup("Text")]
    public Text odunStokText;           //odun sayýsýný tutan text
    [TabGroup("Text")]
    public Text SatButonText;           //sat tuþunda gelecek parayý yazan text
    [Space]
    [TabGroup("Text")]
    public Text keresteSatButonText;    //sat tuþunda gelecek parayý yazan text
    [TabGroup("Text")]
    public Text keresteStokText;        //kereste stoðu tutan text
    [TabGroup("Text")]
    public Text keresteFillbarYuzdeText;//fillbarýn yüzde kaç dolduðunu yazan text
    [Space]
    [TabGroup("Text")]
    public Text demirFillbarYuzdeText;  //fillbarýn yüzde kaç dolduðunu yazan text
    [TabGroup("Text")]
    public Text demirStokText;          //demir sayýsýný tutan text
    [TabGroup("Text")]
    public Text demirOreSatButonText;   //sat tuþunda gelecek parayý yazan text
    [Space]
    [TabGroup("Text")]
    public Text kulceSatButonText;      //sat tuþunda gelecek parayý yazan text
    [TabGroup("Text")]
    public Text kulceStokText;          //kulce stoðu tutan text
    [TabGroup("Text")]
    public Text kulceFillbarYuzdeText;  //fillbarýn yüzde kaç dolduðunu yazan text
    [Space]
    [TabGroup("Text")]
    public Text masaSatButonText;     //sat tuþunda gelecek parayý yazan text
    [TabGroup("Text")]
    public Text masaStokText;         //boyalý kereste stoðu tutan text
    [TabGroup("Text")]
    public Text masaFillbarYuzdeText; //fillbarýn yüzde kaç dolduðunu yazan text
    [Space]
    [TabGroup("Text")]
    public Text civiSatButonText;       //sat tuþunda gelecek parayý yazan text
    [TabGroup("Text")]
    public Text civiStokText;           //civi stoðu tutan text
    [TabGroup("Text")]
    public Text civiFillbarYuzdeText;   //fillbarýn yüzde kaç dolduðunu yazan text
    [Space]
    [TabGroup("Text")]
    public Text disliSatButonText;      //sat tuþunda gelecek parayý yazan text
    [TabGroup("Text")]
    public Text disliStokText;          //diþli stoðu tutan text
    [TabGroup("Text")]
    public Text disliFillbarYuzdeText;  //fillbarýn yüzde kaç dolduðunu yazan text
    [Space]
    [TabGroup("Text")]
    public Text boyaSatButonText;      //sat tuþunda gelecek parayý yazan text
    [TabGroup("Text")]
    public Text boyaStokText;          //diþli stoðu tutan text
    [TabGroup("Text")]
    public Text boyaFillbarYuzdeText;  //fillbarýn yüzde kaç dolduðunu yazan text


    [TabGroup("Bools")]
    public bool cameraOdunda;          //dünya deðiþtirirken tuþta çalýþacak
    [TabGroup("Bools")]
    public bool menuAcik;               //tek fonksiyonla menüyü açýp kapatýyorum
    [TabGroup("Bools")]
    public bool kaynakEkle;             //aktif olunca kaynaklar artýyor
    [Space]
    [TabGroup("Bools")]
    public bool baltaUretimBool;        //tuþa basýldýðýnda true olarak update'teki üretim sürecini baþlatýyor
    [TabGroup("Bools")]
    public bool keresteUretimBool;      //tuþa basýldýðýnda true olarak update'teki üretim sürecini baþlatýyor
    [TabGroup("Bools")]
    public bool demirUretimBool;        //tuþa basýldýðýnda true olarak update'teki üretim sürecini baþlatýyor
    [TabGroup("Bools")]
    public bool kulceUretimBool;        //tuþa basýldýðýnda true olarak update'teki üretim sürecini baþlatýyor
    [TabGroup("Bools")]
    public bool masaUretimBool;       //tuþa basýldýðýnda true olarak update'teki üretim sürecini baþlatýyor
    [TabGroup("Bools")]
    public bool civiUretimBool;         //tuþa basýldýðýnda true olarak update'teki üretim sürecini baþlatýyor
    [TabGroup("Bools")]
    public bool disliUretimBool;         //tuþa basýldýðýnda true olarak update'teki üretim sürecini baþlatýyor
    [TabGroup("Bools")]
    public bool boyaUretimBool;         //tuþa basýldýðýnda true olarak update'teki üretim sürecini baþlatýyor


    [TabGroup("Animator")]
    public Animator baltaAnimator;      //animasyonu durdurup baþlatýyorum
    [TabGroup("Animator")]
    public Animator testereAnimator;    //animasyonu durdurup baþlatýyorum
    [TabGroup("Animator")]
    public Animator kazmaAnimator;      //animasyonu durdurup baþlatýyorum
    [TabGroup("Animator")]
    public Animator ovenAnimator;       //animasyonu durdurup baþlatýyorum
    [TabGroup("Animator")]
    public Animator cekicAnimator;      //animasyonu durdurup baþlatýyorum
    [TabGroup("Animator")]
    public Animator civiAnimator;       //animasyonu durdurup baþlatýyorum
    [TabGroup("Animator")]
    public Animator disliAnimator;      //animasyonu durdurup baþlatýyorum
    [TabGroup("Animator")]
    public Animator fircaAnimator;      //animasyonu durdurup baþlatýyorum

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
        #region Malzemeler
        #region Odun

        #region Balta Üretim
        if (baltaUretimBool == true)
        {
            baltaAnimator.enabled = true; //balta animasyonu baþlatýyor
            Menu.menu.oduntimer += Menu.menu.odunZamanCarpan * Time.deltaTime;
            if (Menu.menu.oduntimer >= Menu.menu.odunTime)
            {//timer artarken timera baðlý olarak fillbar da doluyor
                odunStok += 1; //fillbar dolunca odun üretiyor
                Menu.menu.oduntimer = 0;  //fillbarý sýfýrla
                if (Menu.menu.odunMenajerAlindi == false) //menajer alýnmadýysa üretimi aktif tutan boolu kapatýyor
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
        //Odun Sat buton text
        textlerSatButon(odunStok, odunPara, SatButonText);
        
        //Odun stok gösterim
        StokGosterimler(odunStok, odunStokText);
        #endregion

        #endregion

        //////////////////////////////////////////////

        #region Demir

        #region Demir Üretim
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
        //Demir Ore stok Gösterim
        StokGosterimler(demirOreStok, demirStokText);

        //Demir Ore sat buton text
        textlerSatButon(demirOreStok, demirOrePara, demirOreSatButonText);
        #endregion

        #endregion

        //////////////////////////////////////////////

        #region Kereste

        #region Kereste Üretim
        if (Menu.menu.keresteMenajerAlindi == false)//menajer yokken burasý
        {
            if (keresteUretimBool == true)
            {
                #region Fillbar
                Menu.menu.kerestetimer += Menu.menu.keresteZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.keresteFillbar.fillAmount = Menu.menu.kerestetimer / Menu.menu.keresteTime;
                keresteFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.kerestetimer / Menu.menu.keresteTime) * 100));
                #endregion

                testereAnimator.enabled = true;

                if (Menu.menu.kerestetimer >= Menu.menu.keresteTime) //fillbar dolduðunda
                {
                    Menu.menu.kerestetimer = 0; //fillbarý sýfýrla
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
        else //menajer varken burasý
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

                if (Menu.menu.kerestetimer >= Menu.menu.keresteTime) //fillbar dolduðunda
                {
                    Menu.menu.kerestetimer = 0; //fillbarý sýfýrla
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
        //Kereste Stok gösterim
        StokGosterimler(keresteStok, keresteStokText);

        //Kereste sat buton text
        textlerSatButon(keresteStok, kerestePara, keresteSatButonText);
        #endregion

        #endregion

        /////////////////////////////////////////////

        #region Külçe

        #region Külçe Üretim
        if (Menu.menu.kulceMenajerAlindi == false)//menajer yokken burasý
        {
            if (kulceUretimBool == true)
            {
                #region Fillbar
                Menu.menu.kulcetimer += Menu.menu.kulceZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.kulceFillbar.fillAmount = Menu.menu.kulcetimer / Menu.menu.kulceTime;
                kulceFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.kulcetimer / Menu.menu.kulceTime) * 100));
                #endregion

                ovenAnimator.enabled = true;

                if (Menu.menu.kulcetimer >= Menu.menu.kulceTime) //fillbar dolduðunda
                {
                    Menu.menu.kulcetimer = 0; //fillbarý sýfýrla
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
        else //menajer varken burasý
        {
            if ((demirOreStok >= 1))
            {
                kulceUretimBool = true;
                Menu.menu.kulceUretButon.SetActive(false);
                ovenAnimator.enabled = true;

                #region Fillbar
                Menu.menu.kulcetimer += Menu.menu.kulceZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.kulceFillbar.fillAmount = Menu.menu.kulcetimer / Menu.menu.kulceTime;
                kulceFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.kulcetimer / Menu.menu.kulceTime) * 100));
                #endregion

                if (Menu.menu.kulcetimer >= Menu.menu.kulceTime) //fillbar dolduðunda
                {
                    Menu.menu.kulcetimer = 0; //fillbarý sýfýrla
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

        #region Külçe Text
        //Külçe stok gösterim
        StokGosterimler(kulceStok, kulceStokText);        

        //Külçe sat buton text
        textlerSatButon(kulceStok, kulcePara, kulceSatButonText);
        #endregion

        #endregion

        ////////////////////////////////////////////

        #region Masa

        #region Masa Üretim
        if (Menu.menu.masaMenajerAlindi == false)//menajer yokken burasý
        {
            if (masaUretimBool == true)
            {
                #region Fillbar
                Menu.menu.masatimer += Menu.menu.masaZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.masaFillbar.fillAmount = Menu.menu.masatimer / Menu.menu.masaTime;
                masaFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.masatimer / Menu.menu.masaTime) * 100));
                #endregion

                cekicAnimator.enabled = true;

                if (Menu.menu.masatimer >= Menu.menu.masaTime) //fillbar dolduðunda
                {
                    Menu.menu.masatimer = 0; //fillbarý sýfýrla
                    masaStok += 1;
                    masaUretimBool = false;
                }
                if (Menu.menu.masatimer == 0)
                {
                    keresteStok -= 1;
                }
            }
            else
            {
                masaFillbarYuzdeText.text = "%0";
                Menu.menu.masaFillbar.fillAmount = 0;
                cekicAnimator.enabled = false;
            }
        }
        else //menajer varken burasý
        {
            if ((keresteStok >= 1))
            {
                masaUretimBool = true;
                Menu.menu.masaUretButon.SetActive(false);
                cekicAnimator.enabled = true;

                #region Fillbar
                Menu.menu.masatimer += Menu.menu.masaZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.masaFillbar.fillAmount = Menu.menu.masatimer / Menu.menu.masaTime;
                masaFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.masatimer / Menu.menu.masaTime) * 100));
                #endregion

                if (Menu.menu.masatimer >= Menu.menu.masaTime) //fillbar dolduðunda
                {
                    Menu.menu.masatimer = 0; //fillbarý sýfýrla
                    masaStok += 1;                    
                }
                if (Menu.menu.masatimer == 0)
                {
                    keresteStok -= 1;
                }
            }
            else
            {
                Menu.menu.masaFillbar.fillAmount = 0;
                masaFillbarYuzdeText.text = "%0";
                cekicAnimator.enabled = false;
            }
        }
        #endregion

        #region Masa Text
        //Çivi stok gösterim
        StokGosterimler(masaStok, masaStokText);

        //Çivi sat buton text
        textlerSatButon(masaStok, masaPara, masaSatButonText);
        #endregion

        #endregion

        ////////////////////////////////////////////

        #region Çivi

        #region Çivi Üretim
        if (Menu.menu.civiMenajerAlindi == false)//menajer yokken burasý
        {
            if (civiUretimBool == true)
            {
                #region Fillbar
                Menu.menu.civitimer += Menu.menu.civiZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.civiFillbar.fillAmount = Menu.menu.civitimer / Menu.menu.civiTime;
                civiFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.civitimer / Menu.menu.civiTime) * 100));
                #endregion

                civiAnimator.enabled = true;

                if (Menu.menu.civitimer >= Menu.menu.civiTime) //fillbar dolduðunda
                {
                    Menu.menu.civitimer = 0; //fillbarý sýfýrla
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
        else //menajer varken burasý
        {
            if ((kulceStok >= 1))
            {
                civiUretimBool = true;
                Menu.menu.civiUretButon.SetActive(false);
                civiAnimator.enabled = true;

                #region Fillbar
                Menu.menu.civitimer += Menu.menu.civiZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.civiFillbar.fillAmount = Menu.menu.civitimer / Menu.menu.civiTime;
                civiFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.civitimer / Menu.menu.civiTime) * 100));
                #endregion

                if (Menu.menu.civitimer >= Menu.menu.civiTime) //fillbar dolduðunda
                {
                    Menu.menu.civitimer = 0; //fillbarý sýfýrla
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

        #region Çivi Text
        //Çivi stok gösterim
        StokGosterimler(civiStok, civiStokText);

        //Çivi sat buton text
        textlerSatButon(civiStok, civiPara, civiSatButonText);
        #endregion

        #endregion

        ////////////////////////////////////////////

        #region Diþli

        #region Diþli Üretim
        //Uretimler(Menu.menu.disliMenajerAlindi, disliUretimBool, Menu.menu.dislitimer, Menu.menu.disliZamanCarpan, Menu.menu.disliTime, Menu.menu.disliFillbar, disliFillbarYuzdeText, disliAnimator, disliStok, odunStok, kulceStok, Menu.menu.disliUretButon);
        if (Menu.menu.disliMenajerAlindi == false)//menajer yokken burasý
        {
            if (disliUretimBool == true)
            {
                #region Fillbar
                Menu.menu.dislitimer += Menu.menu.disliZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.disliFillbar.fillAmount = Menu.menu.dislitimer / Menu.menu.disliTime;
                disliFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.dislitimer / Menu.menu.disliTime) * 100));
                #endregion

                disliAnimator.enabled = true;

                if (Menu.menu.dislitimer >= Menu.menu.disliTime) //fillbar dolduðunda
                {
                    Menu.menu.dislitimer = 0; //fillbarý sýfýrla
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
        else //menajer varken burasý
        {
            if ((kulceStok >= 1))
            {
                disliUretimBool = true;
                Menu.menu.disliUretButon.SetActive(false);
                disliAnimator.enabled = true;

                #region Fillbar
                Menu.menu.dislitimer += Menu.menu.disliZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.disliFillbar.fillAmount = Menu.menu.dislitimer / Menu.menu.disliTime;
                disliFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.dislitimer / Menu.menu.disliTime) * 100));
                #endregion

                if (Menu.menu.dislitimer >= Menu.menu.disliTime) //fillbar dolduðunda
                {
                    Menu.menu.dislitimer = 0; //fillbarý sýfýrla
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

        #region Diþli Text
        //Diþli Stok Gösterim
        StokGosterimler(disliStok, disliStokText);

        //Diþli Sat Buton Text        
        textlerSatButon(disliStok, disliPara, disliSatButonText);
        #endregion

        #endregion

        ////////////////////////////////////////////

        #region Boya

        #region Boya Üretim
        if (Menu.menu.boyaMenajerAlindi == false)//menajer yokken burasý
        {
            if (boyaUretimBool == true)
            {
                #region Fillbar
                Menu.menu.boyatimer += Menu.menu.boyaZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.boyaFillbar.fillAmount = Menu.menu.boyatimer / Menu.menu.boyaTime;
                boyaFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.boyatimer / Menu.menu.boyaTime) * 100));
                #endregion

                fircaAnimator.enabled = true;

                if (Menu.menu.boyatimer >= Menu.menu.boyaTime) //fillbar dolduðunda
                {
                    Menu.menu.boyatimer = 0; //fillbarý sýfýrla
                    boyaStok += 1;
                    boyaUretimBool = false;
                }
            }
            else
            {
                boyaFillbarYuzdeText.text = "%0";
                Menu.menu.boyaFillbar.fillAmount = 0;
                fircaAnimator.enabled = false;
            }
        }
        else //menajer varken burasý
        {
            if (masaStok >= 1)
            {
                boyaUretimBool = true;
                Menu.menu.boyaUretButon.SetActive(false);
                fircaAnimator.enabled = true;

                #region Fillbar
                Menu.menu.boyatimer += Menu.menu.boyaZamanCarpan * Time.deltaTime; //fillbar dolumu
                Menu.menu.boyaFillbar.fillAmount = Menu.menu.boyatimer / Menu.menu.boyaTime;
                boyaFillbarYuzdeText.text = string.Format("%" + "{0:#}", ((Menu.menu.boyatimer / Menu.menu.boyaTime) * 100));
                #endregion

                if (Menu.menu.boyatimer >= Menu.menu.boyaTime) //fillbar dolduðunda
                {
                    Menu.menu.boyatimer = 0; //fillbarý sýfýrla
                    boyaStok += 1;
                }
                if (Menu.menu.boyatimer == 0)
                {
                    masaStok -= 1;
                }
            }
            else
            {
                Menu.menu.boyaFillbar.fillAmount = 0;
                boyaFillbarYuzdeText.text = "%0";
                fircaAnimator.enabled = false;
            }
        }
        #endregion

        #region Boya Text
        //Boya stok gösterim
        StokGosterimler(boyaStok, boyaStokText);

        //Boya sat buton text
        textlerSatButon(boyaStok, boyaPara, boyaSatButonText);
        #endregion

        #endregion

        ////////////////////////////////////////////
        #endregion        

        #region Textler
        // anaPara gösterim
        textlerBuyukSayilar(anaPara, cuzdanText);

        //Sýfýrsa textler bozulmasýn        
        SifirsaBozma(anaPara, cuzdanText);
        SifirsaBozma(odunStok, odunStokText);
        SifirsaBozma(kulceStok, kulceStokText);
        SifirsaBozma(masaStok, masaStokText);
        SifirsaBozma(disliStok, disliStokText);
        SifirsaBozma(civiStok, civiStokText);
        SifirsaBozma(boyaStok, boyaStokText);
        #endregion

        #region Dünyaya göre kamera pozisyonu ve gui
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
            masaStok += 1;
            keresteStok += 1;
            civiStok += 1;
            disliStok += 1;
            boyaStok += 1;
        }
        #endregion

    }
    #endregion

    #region Buton Fonksiyonlarý

    #region baltaUretim
    public void baltaUretim()
    {
        baltaUretimBool = true;
    }
    #endregion

    #region Demir Üretim
    public void demirUretim()
    {
        demirUretimBool = true;
    }
    #endregion

    #region Kereste üretim
    public void KeresteUretim()
    {
        if (keresteUretimBool == false)
        {
            keresteUretimBool = true;
            odunStok -= 1;
        }
    }
    #endregion

    #region Külçe Üretim
    public void KulceUretim()
    {
        if (kulceUretimBool == false)
        {
            kulceUretimBool = true;
            demirOreStok -= 1;
        }
    }
    #endregion

    #region Masa Üretim
    public void MasaUretim()
    {
        if (masaUretimBool == false)
        {
            masaUretimBool = true;
        }
    }
    #endregion

    #region Çivi Üretim
    public void CiviUretim()
    {
        if (civiUretimBool == false)
        {
            kulceStok -= 1;
            civiUretimBool = true;
        }
    }
    #endregion

    #region Diþli Üretim
    public void DisliUretim()
    {
        if (disliUretimBool == false)
        {
            disliUretimBool = true;
            kulceStok -= 1;
        }
    }
    #endregion

    #region Boya Üretim
    public void BoyaUretim()
    {
        if (boyaUretimBool == false)
        {
            boyaUretimBool = true;
            masaStok -= 1;
        }
    }
    #endregion

    #region Menü Tuþlarý

    #region Sell Goods Tuþ
    public void sellgoodsTus()
    {
        speedUpgradesMenu.SetActive(false);
        incomeUpgradesMenu.SetActive(false);
        workersMenu.SetActive(false);
        buildingsMenu.SetActive(false);

        sellGoodsMenu.SetActive(true);
    }
    #endregion

    #region Speed Upgrades Tuþ
    public void speedUpgradesTus()
    {
        incomeUpgradesMenu.SetActive(false);
        workersMenu.SetActive(false);
        buildingsMenu.SetActive(false);
        sellGoodsMenu.SetActive(false);

        speedUpgradesMenu.SetActive(true);
    }
    #endregion

    #region income Upgrades Tuþ
    public void incomeUpgradesTus()
    {
        workersMenu.SetActive(false);
        buildingsMenu.SetActive(false);
        sellGoodsMenu.SetActive(false);
        speedUpgradesMenu.SetActive(false);

        incomeUpgradesMenu.SetActive(true);
    }
    #endregion

    #region Workers Tuþ
    public void workersTus()
    {
        buildingsMenu.SetActive(false);
        sellGoodsMenu.SetActive(false);
        speedUpgradesMenu.SetActive(false);
        incomeUpgradesMenu.SetActive(false);

        workersMenu.SetActive(true);
    }
    #endregion

    #region Buildings Tuþ
    public void buildingsTus()
    {
        sellGoodsMenu.SetActive(false);
        speedUpgradesMenu.SetActive(false);
        incomeUpgradesMenu.SetActive(false);
        workersMenu.SetActive(false);

        buildingsMenu.SetActive(true);
    }
    #endregion

    #region Menu Butonu ve menüyü kapat butonu
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
        kaynakEkle = !kaynakEkle;
    }
    #endregion

    #endregion

    #region Text Fonksiyonlarý

    #region Büyük sayýlar
    public void textlerBuyukSayilar(double Degisen, Text DegisenText)
    {
        if (Degisen < million)
        {DegisenText.text = string.Format("${0:#.0}", Degisen);}
        else if ((Degisen >= million) && (Degisen < billion))
        {DegisenText.text = (Degisen / million).ToString("F") + " Mil.";}
        else if ((Degisen >= billion) && (Degisen < trillion))
        {DegisenText.text = (Degisen / billion).ToString("F") + " Bil.";}
        else if ((Degisen >= trillion) && (Degisen < quadrillion))
        {DegisenText.text = (Degisen / trillion).ToString("F") + " Tril.";}
        else if ((Degisen >= quadrillion) & (Degisen < quintillion))
        {DegisenText.text = (Degisen / quadrillion).ToString("F") + " Quadril.";}
        else if ((Degisen >= quintillion) && (Degisen < 1000000000000000000000f))
        {DegisenText.text = (Degisen / quintillion).ToString("F") + " Quintil.";}
        else if (Degisen <= 0)
        {DegisenText.text = "0";}
    }
    #endregion

    #region Büyük sayýlar sat buton text
    public void textlerSatButon(double stok, double para, Text satText)
    {
        if ((stok * para < 1000) && (stok * para > 0))
        {satText.text = string.Format("${0:#.0}", stok * para);}
        else if ((stok * para >= 1000) && (stok * para < million))
        {satText.text = "$" + ((stok * para) / 1000).ToString("F") + " K";}
        else if ((stok * para >= million) && (stok * para < billion))
        {satText.text = "$" + ((stok * para) / million).ToString("F") + " Mil.";}
        else if ((stok * para >= billion) && (stok * para < trillion))
        {satText.text = "$" + ((stok * para) / billion).ToString("F") + " Bil.";}
        else if ((stok * para >= trillion) && (stok * para < quadrillion))
        {satText.text = "$" + ((stok * para) / trillion).ToString("F") + " Tril.";}
        else if ((stok * para >= quadrillion) && (stok * para < quintillion))
        {satText.text = "$" + ((stok * para) / quadrillion).ToString("F") + " Quadril.";}
        else if ((stok * para >= quintillion) && (stok * para < 1000000000000000000000f))
        {satText.text = "$" + ((stok * para) / quintillion).ToString("F") + " Quintil.";}
        else if ((stok * para) <= 0)
        {satText.text = "$0";}
    }
    #endregion

    #region Stok gösterimler
    public void StokGosterimler(double stok, Text stoktext)
    {
        if (stok <= 0)
        {stoktext.text = "0";}
        else if ((stok > 0) && (stok < million))
        {stoktext.text = string.Format("{0:#}", stok);}
        else if ((stok >= million) && (stok < billion))
        {stoktext.text = (stok / million).ToString("F") + " Mil.";}
        else if ((stok >= billion) && (stok < trillion))
        {stoktext.text = (stok / billion).ToString("F") + " Bil.";}
        else if ((stok >= trillion) && (stok < quadrillion))
        {stoktext.text = (stok / trillion).ToString("F") + " Tril.";}
        else if ((stok >= quadrillion) & (stok < quintillion))
        {stoktext.text = (stok / quadrillion).ToString("F") + " Quadril.";}
        else if ((stok >= quintillion) && (stok < 1000000000000000000000f))
        {stoktext.text = (stok / quintillion).ToString("F") + " Quintil.";}
    }
    #endregion

    #region Uretimler, çalýþmýyor
    public void Uretimler(bool mngrAlindiBool, bool uretBool, float timer, float zamancarpan, float time, Image fillbarImg, Text fillYuzdeText, Animator anim, double stok, double gerekstok1, double gerekstok2, GameObject uretbuton)
    {
        if (mngrAlindiBool == false)//menajer yokken burasý
        {
            if (uretBool == true)
            {
                #region Fillbar
                timer += zamancarpan * Time.deltaTime; //fillbar dolumu
                fillbarImg.fillAmount = timer / time;
                fillYuzdeText.text = string.Format("%" + "{0:#}", ((timer / time) * 100));
                #endregion

                anim.enabled = true;

                if (timer >= time) //fillbar dolduðunda
                {
                    timer = 0; //fillbarý sýfýrla
                    stok += 1;
                    uretBool = false;
                }
            }
            else
            {
                fillYuzdeText.text = "%0";
                fillbarImg.fillAmount = 0;
                anim.enabled = false;
            }
        }
        else //menajer varken burasý
        {
            if ((gerekstok1 >= 1) && (gerekstok2 >= 1))
            {
                uretBool = true;
                uretbuton.SetActive(false);
                anim.enabled = true;

                #region Fillbar
                timer += zamancarpan * Time.deltaTime; //fillbar dolumu
                fillbarImg.fillAmount = timer / time;
                fillYuzdeText.text = string.Format("%" + "{0:#}", ((timer / time) * 100));
                #endregion

                if (timer >= time) //fillbar dolduðunda
                {
                    timer = 0; //fillbarý sýfýrla
                    gerekstok1 -= 1;
                    gerekstok2 -= 1;
                    stok += 1;
                }
            }
            else
            {
                fillbarImg.fillAmount = 0;
                fillYuzdeText.text = "%0";
                anim.enabled = false;
            }
        }
    }
    #endregion

    #region Eðer sýfýrsa textler bozulmasýn
    public void SifirsaBozma(double degisen, Text degisenText)
    {
        if (degisen <= 0)
        {
            degisen = 0;
            degisenText.text = "0";
        }
    }
    #endregion

    #endregion
}
