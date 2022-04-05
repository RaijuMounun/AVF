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
        #region Double
        save.anaPara = GameManager.gm.anaPara;

        save.odunStok = GameManager.gm.odunStok;
        save.keresteStok = GameManager.gm.keresteStok;
        save.demirOreStok = GameManager.gm.demirOreStok;
        save.kulceStok = GameManager.gm.kulceStok;
        save.civiStok = GameManager.gm.civiStok;
        save.disliStok = GameManager.gm.disliStok;

        save.odunPara = GameManager.gm.odunPara;
        save.kerestePara = GameManager.gm.kerestePara;
        save.demirOrePara = GameManager.gm.demirOrePara;
        save.kulcePara = GameManager.gm.kulcePara;
        save.civiPara = GameManager.gm.civiPara;
        save.disliPara = GameManager.gm.disliPara;
        #endregion

        #region Float
        save.woodSpdUpgCost = Menu.menu.woodSpdUpgCost;
        save.woodIncUpgCost = Menu.menu.woodIncUpgCost;
        save.odunTime = Menu.menu.odunTime;
        save.keresteTime = Menu.menu.keresteTime;
        save.demirTime = Menu.menu.demirTime;
        save.oduntimer = Menu.menu.oduntimer;
        save.odunZamanCarpan = Menu.menu.odunZamanCarpan;
        save.demirTimer = Menu.menu.demirTimer;
        save.demirZamanCarpan = Menu.menu.demirZamanCarpan;
        save.demirOreSpdUpgCost = Menu.menu.demirOreSpdUpgCost;
        save.demirOreIncUpgCost = Menu.menu.demirOreIncUpgCost;
        save.timberSpdUpgCost = Menu.menu.timberSpdUpgCost;
        save.timberIncUpgCost = Menu.menu.timberIncUpgCost;
        save.kerestetimer = Menu.menu.kerestetimer;
        save.keresteZamanCarpan = Menu.menu.keresteZamanCarpan;
        save.kulceSpdUpgCost = Menu.menu.kulceSpdUpgCost;
        save.kulceIncUpgCost = Menu.menu.kulceIncUpgCost;
        save.kulcetimer = Menu.menu.kulcetimer;
        save.kulceZamanCarpan = Menu.menu.kulceZamanCarpan;
        save.kulceTime = Menu.menu.kulceTime;
        save.civiSpdUpgCost = Menu.menu.civiSpdUpgCost;
        save.civiIncUpgCost = Menu.menu.civiIncUpgCost;
        save.civitimer = Menu.menu.civitimer;
        save.civiZamanCarpan = Menu.menu.civiZamanCarpan;
        save.civiTime = Menu.menu.civiTime;
        save.disliSpdUpgCost = Menu.menu.disliSpdUpgCost;
        save.disliIncUpgCost = Menu.menu.disliIncUpgCost;
        save.dislitimer = Menu.menu.dislitimer;
        save.disliZamanCarpan = Menu.menu.disliZamanCarpan;
        save.disliTime = Menu.menu.disliTime;
        #endregion

        #region int
        save.woodIncUpgLvl = Menu.menu.woodIncUpgLvl;
        save.woodSpdUpgLvl = Menu.menu.woodSpdUpgLvl;
        save.demirOreSpdUpgLvl = Menu.menu.demirOreSpdUpgLvl;
        save.demirOreIncUpgLvl = Menu.menu.demirOreIncUpgLvl;
        save.timberIncUpgLvl = Menu.menu.timberIncUpgLvl;
        save.timberSpdUpgLvl = Menu.menu.timberSpdUpgLvl;
        save.kulceSpdUpgLvl = Menu.menu.kulceSpdUpgLvl;
        save.kulceIncUpgLvl = Menu.menu.kulceIncUpgLvl;
        save.civiSpdUpgLvl = Menu.menu.civiSpdUpgLvl;
        save.civiIncUpgLvl = Menu.menu.civiIncUpgLvl;
        save.disliSpdUpgCost = Menu.menu.disliSpdUpgCost;
        save.disliIncUpgCost = Menu.menu.disliIncUpgCost;
        #endregion

        #region Boolean
        save.cameraOdunda = GameManager.gm.cameraOdunda;
        save.baltaUretimBool = GameManager.gm.baltaUretimBool;
        save.keresteUretimBool = GameManager.gm.keresteUretimBool;
        save.demirUretimBool = GameManager.gm.demirUretimBool;
        save.civiUretimBool = GameManager.gm.civiUretimBool;
        save.kulceUretimBool = GameManager.gm.kulceUretimBool;
        save.disliUretimBool = GameManager.gm.disliUretimBool;

        save.odunMenajerAlindi = Menu.menu.odunMenajerAlindi;
        save.demirOreMenajerAlindi = Menu.menu.demirOreMenajerAlindi;
        save.keresteMenajerAlindi = Menu.menu.keresteMenajerAlindi;
        save.keresteAlindi = Menu.menu.keresteAlindi;
        save.kulceMenajerAlindi = Menu.menu.kulceMenajerAlindi;
        save.kulceAlindi = Menu.menu.kulceAlindi;
        save.civiMenajerAlindi = Menu.menu.civiMenajerAlindi;
        save.civiAlindi = Menu.menu.civiAlindi;
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

            GameManager.gm.odunStok = save.odunStok;
            GameManager.gm.keresteStok = save.keresteStok;
            GameManager.gm.demirOreStok = save.demirOreStok;
            GameManager.gm.kulceStok = save.kulceStok;
            GameManager.gm.civiStok = save.civiStok;
            GameManager.gm.disliStok = save.disliStok;

            GameManager.gm.odunPara = save.odunPara;
            GameManager.gm.kerestePara = save.kerestePara;
            GameManager.gm.demirOrePara = save.demirOrePara;
            GameManager.gm.kulcePara = save.kulcePara;
            GameManager.gm.civiPara = save.civiPara;
            GameManager.gm.disliPara = save.disliPara;

            GameManager.gm.baltaUretimBool = save.baltaUretimBool;
            GameManager.gm.keresteUretimBool = save.keresteUretimBool;
            GameManager.gm.demirUretimBool = save.demirUretimBool;
            GameManager.gm.kulceUretimBool = save.kulceUretimBool;
            GameManager.gm.civiUretimBool = save.civiUretimBool;
            GameManager.gm.disliUretimBool = save.disliUretimBool;

            ///////////////////////////////////////////////////////////

            Menu.menu.woodSpdUpgCost = save.woodSpdUpgCost;
            Menu.menu.woodIncUpgCost = save.woodIncUpgCost;
            Menu.menu.demirOreSpdUpgCost = save.demirOreSpdUpgCost;
            Menu.menu.demirOreIncUpgCost = save.demirOreIncUpgCost;
            Menu.menu.timberSpdUpgCost = save.timberSpdUpgCost;
            Menu.menu.timberIncUpgCost = save.timberIncUpgCost;
            Menu.menu.kulceSpdUpgCost = save.kulceSpdUpgCost;
            Menu.menu.kulceIncUpgCost = save.kulceIncUpgCost;
            Menu.menu.civiSpdUpgCost = save.civiSpdUpgCost;
            Menu.menu.civiIncUpgCost = save.civiIncUpgCost;
            Menu.menu.disliSpdUpgCost = save.disliSpdUpgCost;
            Menu.menu.disliIncUpgCost = save.disliIncUpgCost;

            Menu.menu.odunTime = save.odunTime;
            Menu.menu.oduntimer = save.oduntimer;
            Menu.menu.odunZamanCarpan = save.odunZamanCarpan;
            Menu.menu.keresteTime = save.keresteTime;
            Menu.menu.kerestetimer = save.kerestetimer;
            Menu.menu.keresteZamanCarpan = save.keresteZamanCarpan;
            Menu.menu.demirTime = save.demirTime;
            Menu.menu.demirTimer = save.demirTimer;
            Menu.menu.demirZamanCarpan = save.demirZamanCarpan;
            Menu.menu.kulcetimer = save.kulcetimer;
            Menu.menu.kulceTime = save.kulceTime;
            Menu.menu.kulceZamanCarpan = save.kulceZamanCarpan;
            Menu.menu.civiTime = save.civiTime;
            Menu.menu.civitimer = save.civitimer;
            Menu.menu.civiZamanCarpan = save.civiZamanCarpan;
            Menu.menu.disliTime = save.disliTime;
            Menu.menu.dislitimer = save.dislitimer;
            Menu.menu.disliZamanCarpan = save.disliZamanCarpan;

            Menu.menu.woodIncUpgLvl = save.woodIncUpgLvl;
            Menu.menu.woodSpdUpgLvl = save.woodSpdUpgLvl;
            Menu.menu.demirOreSpdUpgLvl = save.demirOreSpdUpgLvl;
            Menu.menu.demirOreIncUpgLvl = save.demirOreIncUpgLvl;
            Menu.menu.timberIncUpgLvl = save.timberIncUpgLvl;
            Menu.menu.timberSpdUpgLvl = save.timberSpdUpgLvl;
            Menu.menu.kulceSpdUpgLvl = save.kulceSpdUpgLvl;
            Menu.menu.kulceIncUpgLvl = save.kulceIncUpgLvl;
            Menu.menu.civiSpdUpgLvl = save.civiSpdUpgLvl;
            Menu.menu.civiIncUpgLvl = save.civiIncUpgLvl;
            Menu.menu.disliSpdUpgLvl = save.disliSpdUpgLvl;
            Menu.menu.disliIncUpgLvl = save.disliIncUpgLvl;

            Menu.menu.odunMenajerAlindi = save.odunMenajerAlindi;
            Menu.menu.demirOreMenajerAlindi = save.demirOreMenajerAlindi;
            Menu.menu.keresteMenajerAlindi = save.keresteMenajerAlindi;
            Menu.menu.kulceMenajerAlindi = save.kulceMenajerAlindi;
            Menu.menu.civiMenajerAlindi = save.civiMenajerAlindi;
            Menu.menu.disliMenajerAlindi = save.disliMenajerAlindi;

            Menu.menu.keresteAlindi = save.keresteAlindi;
            Menu.menu.kulceAlindi = save.kulceAlindi;
            Menu.menu.civiAlindi = save.civiAlindi;
            Menu.menu.disliAlindi = save.disliAlindi;
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
    public double odunStok;
    public double keresteStok;
    public double demirOreStok;
    public double kulceStok;
    public double civiStok;
    public double disliStok;
    public double odunPara;
    public double kerestePara;
    public double demirOrePara;
    public double kulcePara;
    public double civiPara;
    public double disliPara;

    public float woodSpdUpgCost;
    public float woodIncUpgCost;
    public float odunTime;
    public float keresteTime;
    public float demirTime;
    public float oduntimer;
    public float odunZamanCarpan;
    public float demirTimer;
    public float demirZamanCarpan;
    public float demirOreSpdUpgCost;
    public float demirOreIncUpgCost;
    public float timberSpdUpgCost;
    public float timberIncUpgCost;
    public float kerestetimer;
    public float keresteZamanCarpan;
    public float kulceSpdUpgCost;
    public float kulceIncUpgCost;
    public float kulcetimer;
    public float kulceZamanCarpan;
    public float kulceTime;
    public float civiSpdUpgCost;
    public float civiIncUpgCost;
    public float civitimer;
    public float civiZamanCarpan;
    public float civiTime;
    public float disliSpdUpgCost;
    public float disliIncUpgCost;
    public float dislitimer;
    public float disliZamanCarpan;
    public float disliTime;

    public int woodIncUpgLvl;
    public int woodSpdUpgLvl;
    public int demirOreSpdUpgLvl;
    public int demirOreIncUpgLvl;
    public int timberIncUpgLvl;
    public int timberSpdUpgLvl;
    public int kulceSpdUpgLvl;
    public int kulceIncUpgLvl;
    public int civiSpdUpgLvl;
    public int civiIncUpgLvl;
    public int disliSpdUpgLvl;
    public int disliIncUpgLvl;

    public bool cameraOdunda;
    public bool baltaUretimBool;
    public bool keresteUretimBool;
    public bool demirUretimBool;
    public bool civiUretimBool;
    public bool kulceUretimBool;
    public bool disliUretimBool;
    public bool odunMenajerAlindi;
    public bool demirOreMenajerAlindi;
    public bool keresteMenajerAlindi;
    public bool kulceMenajerAlindi;
    public bool kulceAlindi;
    public bool keresteAlindi;
    public bool civiMenajerAlindi;
    public bool civiAlindi;
    public bool disliMenajerAlindi;
    public bool disliAlindi;
    #endregion
}