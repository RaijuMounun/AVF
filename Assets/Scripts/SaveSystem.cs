using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;


public class SaveSystem : MonoBehaviour
{
    #region Singleton
    public static SaveSystem svsys;
    public static Menu menu; //singleton için
    public static GameManager gm;
    #endregion

    #region Awake
    private void Awake()
    {
        svsys = this;
    }
    #endregion

    #region Start
    private void Start()
    {
        Load();
    }
    #endregion

    #region Update
    private void Update()
    {
        Save();
    }
    #endregion

    #region Save
    public void Save()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/" + "Savegame.dat");
        SaveManagement save = new SaveManagement();
        #region Tutulacak deðiþkenler
        save.anaPara = GameManager.gm.anaPara;
        save.cameraOdunda = GameManager.gm.cameraOdunda;

        #region Odun
        save.odunStok = GameManager.gm.odunStok;
        save.odunPara = GameManager.gm.odunPara;
        save.baltaUretimBool = GameManager.gm.baltaUretimBool;
        save.woodSpdUpgCost = Menu.menu.woodSpdUpgCost;
        save.woodIncUpgCost = Menu.menu.woodIncUpgCost;
        save.odunTime = Menu.menu.odunTime;
        save.oduntimer = Menu.menu.oduntimer;
        save.odunZamanCarpan = Menu.menu.odunZamanCarpan;
        save.woodIncUpgLvl = Menu.menu.woodIncUpgLvl;
        save.woodSpdUpgLvl = Menu.menu.woodSpdUpgLvl;
        save.odunMenajerAlindi = Menu.menu.odunMenajerAlindi;
        #endregion

        #region Demir Ore
        save.demirOreStok = GameManager.gm.demirOreStok;
        save.demirOrePara = GameManager.gm.demirOrePara;
        save.demirUretimBool = GameManager.gm.demirUretimBool;
        save.demirTime = Menu.menu.demirTime;
        save.demirTimer = Menu.menu.demirTimer;
        save.demirZamanCarpan = Menu.menu.demirZamanCarpan;
        save.demirOreSpdUpgCost = Menu.menu.demirOreSpdUpgCost;
        save.demirOreIncUpgCost = Menu.menu.demirOreIncUpgCost;
        save.demirOreSpdUpgLvl = Menu.menu.demirOreSpdUpgLvl;
        save.demirOreIncUpgLvl = Menu.menu.demirOreIncUpgLvl;
        save.demirOreMenajerAlindi = Menu.menu.demirOreMenajerAlindi;
        #endregion

        #region Kereste
        save.keresteStok = GameManager.gm.keresteStok;
        save.kerestePara = GameManager.gm.kerestePara;
        save.keresteUretimBool = GameManager.gm.keresteUretimBool;
        save.keresteTime = Menu.menu.keresteTime;
        save.timberSpdUpgCost = Menu.menu.timberSpdUpgCost;
        save.timberIncUpgCost = Menu.menu.timberIncUpgCost;
        save.kerestetimer = Menu.menu.kerestetimer;
        save.keresteZamanCarpan = Menu.menu.keresteZamanCarpan;
        save.timberIncUpgLvl = Menu.menu.timberIncUpgLvl;
        save.timberSpdUpgLvl = Menu.menu.timberSpdUpgLvl;
        save.keresteMenajerAlindi = Menu.menu.keresteMenajerAlindi;
        save.keresteAlindi = Menu.menu.keresteAlindi;
        #endregion

        #region Külçe
        save.kulceStok = GameManager.gm.kulceStok;
        save.kulcePara = GameManager.gm.kulcePara;
        save.kulceUretimBool = GameManager.gm.kulceUretimBool;
        save.kulceSpdUpgCost = Menu.menu.kulceSpdUpgCost;
        save.kulceIncUpgCost = Menu.menu.kulceIncUpgCost;
        save.kulcetimer = Menu.menu.kulcetimer;
        save.kulceZamanCarpan = Menu.menu.kulceZamanCarpan;
        save.kulceTime = Menu.menu.kulceTime;
        save.kulceSpdUpgLvl = Menu.menu.kulceSpdUpgLvl;
        save.kulceIncUpgLvl = Menu.menu.kulceIncUpgLvl;
        save.kulceMenajerAlindi = Menu.menu.kulceMenajerAlindi;
        save.kulceAlindi = Menu.menu.kulceAlindi;
        #endregion

        #region Masa
        save.masaStok = GameManager.gm.masaStok;
        save.masaPara = GameManager.gm.masaPara;
        save.masaUretimBool = GameManager.gm.masaUretimBool;
        save.masaMenajerAlindi = Menu.menu.masaMenajerAlindi;
        save.masaAlindi = Menu.menu.masaAlindi;
        save.masaSpdUpgLvl = Menu.menu.masaSpdUpgLvl;
        save.masaIncUpgLvl = Menu.menu.masaIncUpgLvl;
        save.masaSpdUpgCost = Menu.menu.masaSpdUpgCost;
        save.masaIncUpgCost = Menu.menu.masaIncUpgCost;
        save.masatimer = Menu.menu.masatimer;
        save.masaZamanCarpan = Menu.menu.masaZamanCarpan;
        save.masaTime = Menu.menu.masaTime;
        #endregion

        #region Çivi
        save.civiStok = GameManager.gm.civiStok;
        save.civiPara = GameManager.gm.civiPara;
        save.civiUretimBool = GameManager.gm.civiUretimBool;
        save.civiSpdUpgCost = Menu.menu.civiSpdUpgCost;
        save.civiIncUpgCost = Menu.menu.civiIncUpgCost;
        save.civitimer = Menu.menu.civitimer;
        save.civiZamanCarpan = Menu.menu.civiZamanCarpan;
        save.civiTime = Menu.menu.civiTime;
        save.civiSpdUpgLvl = Menu.menu.civiSpdUpgLvl;
        save.civiIncUpgLvl = Menu.menu.civiIncUpgLvl;
        save.civiMenajerAlindi = Menu.menu.civiMenajerAlindi;
        save.civiAlindi = Menu.menu.civiAlindi;
        #endregion

        #region Boyalý Masa
        save.boyaStok = GameManager.gm.boyaStok;
        save.boyaPara = GameManager.gm.boyaPara;
        save.boyaUretimBool = GameManager.gm.boyaUretimBool;
        save.boyaMenajerAlindi = Menu.menu.boyaMenajerAlindi;
        save.boyaAlindi = Menu.menu.boyaAlindi;
        save.boyaSpdUpgLvl = Menu.menu.boyaSpdUpgLvl;
        save.boyaIncUpgLvl = Menu.menu.boyaIncUpgLvl;
        save.boyaSpdUpgCost = Menu.menu.boyaSpdUpgCost;
        save.boyaIncUpgCost = Menu.menu.boyaIncUpgCost;
        save.boyatimer = Menu.menu.boyatimer;
        save.boyaZamanCarpan = Menu.menu.boyaZamanCarpan;
        save.boyaTime = Menu.menu.boyaTime;
        #endregion

        #region Diþli
        save.disliStok = GameManager.gm.disliStok;
        save.disliPara = GameManager.gm.disliPara;
        save.disliSpdUpgCost = Menu.menu.disliSpdUpgCost;
        save.disliIncUpgCost = Menu.menu.disliIncUpgCost;
        save.dislitimer = Menu.menu.dislitimer;
        save.disliZamanCarpan = Menu.menu.disliZamanCarpan;
        save.disliTime = Menu.menu.disliTime;
        save.disliSpdUpgCost = Menu.menu.disliSpdUpgCost;
        save.disliIncUpgCost = Menu.menu.disliIncUpgCost;
        save.disliUretimBool = GameManager.gm.disliUretimBool;
        save.disliMenajerAlindi = Menu.menu.disliMenajerAlindi;
        save.disliAlindi = Menu.menu.disliAlindi;
        #endregion
        #endregion
        binary.Serialize(file, save);
        file.Close();
    }
    #endregion

    #region Load
    public void Load()
    {
        if (File.Exists(Application.dataPath + "/" + "Savegame.dat"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/" + "Savegame.dat", FileMode.Open);
            SaveManagement save = (SaveManagement)binary.Deserialize(file);
            file.Close();
            #region Objeler
            GameManager.gm.anaPara = save.anaPara;
            GameManager.gm.cameraOdunda = save.cameraOdunda;

            #region Odun
            GameManager.gm.odunStok = save.odunStok;
            GameManager.gm.odunPara = save.odunPara;
            GameManager.gm.baltaUretimBool = save.baltaUretimBool;
            Menu.menu.woodSpdUpgCost = save.woodSpdUpgCost;
            Menu.menu.woodIncUpgCost = save.woodIncUpgCost;
            Menu.menu.odunTime = save.odunTime;
            Menu.menu.oduntimer = save.oduntimer;
            Menu.menu.odunZamanCarpan = save.odunZamanCarpan;
            Menu.menu.odunMenajerAlindi = save.odunMenajerAlindi;
            Menu.menu.woodIncUpgLvl = save.woodIncUpgLvl;
            Menu.menu.woodSpdUpgLvl = save.woodSpdUpgLvl;
            #endregion

            #region Demir Ore
            GameManager.gm.demirOreStok = save.demirOreStok;
            GameManager.gm.demirOrePara = save.demirOrePara;
            GameManager.gm.demirUretimBool = save.demirUretimBool;
            Menu.menu.demirOreMenajerAlindi = save.demirOreMenajerAlindi;
            Menu.menu.demirOreSpdUpgLvl = save.demirOreSpdUpgLvl;
            Menu.menu.demirOreIncUpgLvl = save.demirOreIncUpgLvl;
            Menu.menu.demirZamanCarpan = save.demirZamanCarpan;
            Menu.menu.demirTime = save.demirTime;
            Menu.menu.demirTimer = save.demirTimer;
            Menu.menu.demirOreSpdUpgCost = save.demirOreSpdUpgCost;
            Menu.menu.demirOreIncUpgCost = save.demirOreIncUpgCost;
            #endregion

            #region Kereste
            GameManager.gm.keresteStok = save.keresteStok;
            GameManager.gm.kerestePara = save.kerestePara;
            GameManager.gm.keresteUretimBool = save.keresteUretimBool;
            Menu.menu.timberSpdUpgCost = save.timberSpdUpgCost;
            Menu.menu.timberIncUpgCost = save.timberIncUpgCost;
            Menu.menu.keresteTime = save.keresteTime;
            Menu.menu.kerestetimer = save.kerestetimer;
            Menu.menu.keresteZamanCarpan = save.keresteZamanCarpan;
            Menu.menu.keresteAlindi = save.keresteAlindi;
            Menu.menu.keresteMenajerAlindi = save.keresteMenajerAlindi;
            Menu.menu.timberIncUpgLvl = save.timberIncUpgLvl;
            Menu.menu.timberSpdUpgLvl = save.timberSpdUpgLvl;
            #endregion

            #region Külçe
            GameManager.gm.kulceStok = save.kulceStok;
            GameManager.gm.kulcePara = save.kulcePara;
            GameManager.gm.kulceUretimBool = save.kulceUretimBool;
            Menu.menu.kulceSpdUpgCost = save.kulceSpdUpgCost;
            Menu.menu.kulceIncUpgCost = save.kulceIncUpgCost;
            Menu.menu.kulcetimer = save.kulcetimer;
            Menu.menu.kulceTime = save.kulceTime;
            Menu.menu.kulceZamanCarpan = save.kulceZamanCarpan;
            Menu.menu.kulceSpdUpgLvl = save.kulceSpdUpgLvl;
            Menu.menu.kulceIncUpgLvl = save.kulceIncUpgLvl;
            Menu.menu.kulceMenajerAlindi = save.kulceMenajerAlindi;
            Menu.menu.kulceAlindi = save.kulceAlindi;
            #endregion

            #region Masa
            GameManager.gm.masaStok = save.masaStok;
            GameManager.gm.masaPara = save.masaPara;
            GameManager.gm.masaUretimBool = save.masaUretimBool;
            Menu.menu.masaMenajerAlindi = save.masaMenajerAlindi;
            Menu.menu.masaAlindi = save.masaAlindi;
            Menu.menu.masaSpdUpgLvl = save.masaSpdUpgLvl;
            Menu.menu.masaIncUpgLvl = save.masaIncUpgLvl;
            Menu.menu.masaSpdUpgCost = save.masaSpdUpgCost;
            Menu.menu.masaIncUpgCost = save.masaIncUpgCost;
            Menu.menu.masatimer = save.masatimer;
            Menu.menu.masaZamanCarpan = save.masaZamanCarpan;
            Menu.menu.masaTime = save.masaTime;
            #endregion

            #region Çivi
            GameManager.gm.civiStok = save.civiStok;
            GameManager.gm.civiPara = save.civiPara;
            GameManager.gm.civiUretimBool = save.civiUretimBool;
            Menu.menu.civiSpdUpgCost = save.civiSpdUpgCost;
            Menu.menu.civiIncUpgCost = save.civiIncUpgCost;
            Menu.menu.civiTime = save.civiTime;
            Menu.menu.civitimer = save.civitimer;
            Menu.menu.civiZamanCarpan = save.civiZamanCarpan;
            Menu.menu.civiSpdUpgLvl = save.civiSpdUpgLvl;
            Menu.menu.civiIncUpgLvl = save.civiIncUpgLvl;
            Menu.menu.civiMenajerAlindi = save.civiMenajerAlindi;
            Menu.menu.civiAlindi = save.civiAlindi;
            #endregion

            #region Boyalý Masa
            GameManager.gm.boyaStok = save.boyaStok;
            GameManager.gm.boyaPara = save.boyaPara;
            GameManager.gm.boyaStok = save.boyaStok;
            GameManager.gm.boyaPara = save.boyaPara;
            GameManager.gm.boyaUretimBool = save.boyaUretimBool;
            Menu.menu.boyaMenajerAlindi = save.boyaMenajerAlindi;
            Menu.menu.boyaAlindi = save.boyaAlindi;
            Menu.menu.boyaSpdUpgLvl = save.boyaSpdUpgLvl;
            Menu.menu.boyaIncUpgLvl = save.boyaIncUpgLvl;
            Menu.menu.boyaSpdUpgCost = save.boyaSpdUpgCost;
            Menu.menu.boyaIncUpgCost = save.boyaIncUpgCost;
            Menu.menu.boyatimer = save.boyatimer;
            Menu.menu.boyaZamanCarpan = save.boyaZamanCarpan;
            Menu.menu.boyaTime = save.boyaTime;
            #endregion

            #region Diþli
            GameManager.gm.disliStok = save.disliStok;
            GameManager.gm.disliPara = save.disliPara;
            GameManager.gm.disliUretimBool = save.disliUretimBool;
            Menu.menu.disliSpdUpgCost = save.disliSpdUpgCost;
            Menu.menu.disliIncUpgCost = save.disliIncUpgCost;
            Menu.menu.disliTime = save.disliTime;
            Menu.menu.dislitimer = save.dislitimer;
            Menu.menu.disliZamanCarpan = save.disliZamanCarpan;
            Menu.menu.disliSpdUpgLvl = save.disliSpdUpgLvl;
            Menu.menu.disliIncUpgLvl = save.disliIncUpgLvl;
            Menu.menu.disliMenajerAlindi = save.disliMenajerAlindi;
            Menu.menu.disliAlindi = save.disliAlindi;
            #endregion
            #endregion
        }
    }
    #endregion
}
[Serializable]
public class SaveManagement
{
    #region Objeler
    public double anaPara;
    public bool cameraOdunda;

    #region Odun
    public double odunStok;
    public double odunPara;
    public float woodSpdUpgCost;
    public float woodIncUpgCost;
    public float odunTime;
    public float oduntimer;
    public float odunZamanCarpan;
    public int woodIncUpgLvl;
    public int woodSpdUpgLvl;
    public bool baltaUretimBool;
    public bool odunMenajerAlindi;
    #endregion

    #region Demir Ore
    public double demirOreStok;
    public double demirOrePara;
    public float demirTime;
    public float demirTimer;
    public float demirZamanCarpan;
    public float demirOreSpdUpgCost;
    public float demirOreIncUpgCost;
    public int demirOreSpdUpgLvl;
    public int demirOreIncUpgLvl;
    public bool demirUretimBool;
    public bool demirOreMenajerAlindi;
    #endregion

    #region Kereste
    public double keresteStok;
    public double kerestePara;
    public float keresteTime;
    public float timberSpdUpgCost;
    public float timberIncUpgCost;
    public float kerestetimer;
    public float keresteZamanCarpan;
    public int timberIncUpgLvl;
    public int timberSpdUpgLvl;
    public bool keresteUretimBool;
    public bool keresteMenajerAlindi;
    public bool keresteAlindi;
    #endregion

    #region Külçe
    public double kulceStok;
    public double kulcePara;
    public float kulceSpdUpgCost;
    public float kulceIncUpgCost;
    public float kulcetimer;
    public float kulceZamanCarpan;
    public float kulceTime;
    public int kulceSpdUpgLvl;
    public int kulceIncUpgLvl;
    public bool kulceUretimBool;
    public bool kulceMenajerAlindi;
    public bool kulceAlindi;
    #endregion

    #region Masa
    public double masaStok;
    public double masaPara;
    public bool  masaUretimBool;
    public bool  masaMenajerAlindi;
    public bool  masaAlindi;
    public int   masaSpdUpgLvl;
    public int   masaIncUpgLvl;
    public float masaSpdUpgCost;
    public float masaIncUpgCost;
    public float masatimer;
    public float masaZamanCarpan;
    public float masaTime;
    #endregion

    #region Çivi
    public double civiPara;
    public double civiStok;
    public float civiSpdUpgCost;
    public float civiIncUpgCost;
    public float civitimer;
    public float civiZamanCarpan;
    public float civiTime;
    public int civiSpdUpgLvl;
    public int civiIncUpgLvl;
    public bool civiUretimBool;
    public bool civiMenajerAlindi;
    public bool civiAlindi;
    #endregion

    #region Boyalý Masa
    public double boyaStok;
    public double boyaPara;
    public bool   boyaUretimBool;
    public bool   boyaMenajerAlindi;
    public bool   boyaAlindi;
    public int    boyaSpdUpgLvl;
    public int    boyaIncUpgLvl;
    public float  boyaSpdUpgCost;
    public float  boyaIncUpgCost;
    public float  boyatimer;
    public float  boyaZamanCarpan;
    public float  boyaTime;

    #endregion

    #region Diþli
    public double disliStok;
    public double disliPara;
    public float disliSpdUpgCost;
    public float disliIncUpgCost;
    public float dislitimer;
    public float disliZamanCarpan;
    public float disliTime;
    public int disliSpdUpgLvl;
    public int disliIncUpgLvl;
    public bool disliUretimBool;
    public bool disliMenajerAlindi;
    public bool disliAlindi;
    #endregion

    #endregion
}