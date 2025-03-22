using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.SocialPlatforms.Impl;
using System.IO;
using UnityEngine.UI;
using DG.Tweening.Core.Easing;

public class DataManager2 : Singleton<DataManager2>
{
    [SerializeField] private Player player;

    [SerializeField] private List<Level> listLevel = new List<Level>();
    [SerializeField] private List<StoreLevel> listStoreShelf = new List<StoreLevel>();

    [SerializeField] private Button testSaveBtn;
    [SerializeField] private Button playBtn;
    [SerializeField] private Button nextLevelBtn;

    [SerializeField] WoodStore wsPrefab;

    [SerializeField] private int levelIndex = 1;
    [SerializeField] private Scrollbar scrollbar;

    public Button NextLevelBtn { get => nextLevelBtn; set => nextLevelBtn = value; }
    public int LevelIndex { get => levelIndex; set => levelIndex = value; }
    public List<Level> ListLevel { get => listLevel; set => listLevel = value; }

    void Save()
    {
        // Wood Store 1
        WoodData wood0 = new WoodData(WoodType.Pink,0, false);
        WoodData wood1 = new WoodData(WoodType.Pink,1, false);
        WoodData wood2 = new WoodData(WoodType.Purple,2, false);
        WoodData wood3 = new WoodData(WoodType.Yellow,3, false);
        StoreData storeData0 = new StoreData(0,new List<WoodData> {wood0, wood1, wood2, wood3}, false);

        WoodData wood4 = new WoodData(WoodType.Blue,0, false);
        WoodData wood5 = new WoodData(WoodType.Purple,1, false);
        WoodData wood6 = new WoodData(WoodType.Yellow,2, false);
        WoodData wood7 = new WoodData(WoodType.Red,3, false);
        StoreData storeData1 = new StoreData(1, new List<WoodData> {wood4, wood5, wood6, wood7}, false);

        WoodData wood8 = new WoodData(WoodType.Red, 0, false);
        WoodData wood9 = new WoodData(WoodType.Blue, 1, false);
        WoodData wood10 = new WoodData(WoodType.Purple, 2, false);
        WoodData wood11 = new WoodData(WoodType.Blue, 3, false);
        StoreData storeData2 = new StoreData(2, new List<WoodData> { wood8, wood9, wood10, wood11 }, false);

        WoodData wood12 = new WoodData(WoodType.Red, 0, false);
        WoodData wood13 = new WoodData(WoodType.Yellow, 1, false);
        WoodData wood14 = new WoodData(WoodType.Yellow, 2, false);
        WoodData wood15 = new WoodData(WoodType.Pink, 3, false);
        StoreData storeData3 = new StoreData(3, new List<WoodData> { wood12, wood13, wood14, wood15 }, false);

        WoodData wood16 = new WoodData(WoodType.Purple, 0, false);
        WoodData wood17 = new WoodData(WoodType.Red, 1, false);
        WoodData wood18 = new WoodData(WoodType.Blue, 2, false);
        WoodData wood19 = new WoodData(WoodType.Pink, 3, false);
        StoreData storeData4 = new StoreData(4, new List<WoodData> { wood16, wood17, wood18, wood19 }, false);


        StoreData storeData5 = new StoreData(5, new List<WoodData> {}, false);
        StoreData storeData6 = new StoreData(6, new List<WoodData> {}, false);

        StoreData lockStore0 = new StoreData(7, new List<WoodData> {}, true);

        // Level Data
        LevelDataD level1 = new LevelDataD(1,new List<StoreData> { storeData0, storeData1, storeData2, storeData3, storeData4, storeData5, storeData6, lockStore0 }, 5);

        string jsonData1 = JsonConvert.SerializeObject(level1, Formatting.Indented);

        File.WriteAllText("Level 1.txt", jsonData1);

        // Wood Store 1
        WoodData wood20 = new WoodData(WoodType.Green, 0, true);
        WoodData wood21 = new WoodData(WoodType.Green, 1, true);
        WoodData wood22 = new WoodData(WoodType.Orange, 2, true);
        WoodData wood23 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData7 = new StoreData(0, new List<WoodData> { wood20, wood21, wood22, wood23 }, false);

        WoodData wood24 = new WoodData(WoodType.Green, 0, true);
        WoodData wood25 = new WoodData(WoodType.Blue, 1, true);
        WoodData wood26 = new WoodData(WoodType.Purple, 2, true);
        WoodData wood27 = new WoodData(WoodType.Orange, 3, false);
        StoreData storeData8 = new StoreData(1, new List<WoodData> { wood24, wood25, wood26, wood27 }, false);

        WoodData wood28 = new WoodData(WoodType.Blue, 0, true);
        WoodData wood29 = new WoodData(WoodType.Green, 1, true);
        WoodData wood30 = new WoodData(WoodType.Purple, 2, true);
        WoodData wood31 = new WoodData(WoodType.Orange, 3, false);
        StoreData storeData9 = new StoreData(2, new List<WoodData> { wood28, wood29, wood30, wood31 }, false);

        WoodData wood32 = new WoodData(WoodType.Blue, 0, true);
        WoodData wood33 = new WoodData(WoodType.Orange, 1, true);
        WoodData wood34 = new WoodData(WoodType.Blue, 2, true);
        WoodData wood35 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData10 = new StoreData(3, new List<WoodData> { wood32, wood33, wood34, wood35 }, false);

        StoreData storeData11 = new StoreData(4, new List<WoodData> { }, false);
        StoreData storeData12 = new StoreData(5, new List<WoodData> { }, false);

        StoreData lockStore1 = new StoreData(6, new List<WoodData> { }, true);

        // Level Data
        LevelDataD level2 = new LevelDataD(1, new List<StoreData> { storeData7, storeData8, storeData9, storeData10, storeData11, storeData12, lockStore1 }, 4);

        string jsonData2 = JsonConvert.SerializeObject(level2, Formatting.Indented);

        File.WriteAllText("Level 2.txt", jsonData2);
    }

    public void Save15Levels()
    {
        WoodData wood0 = new WoodData(WoodType.Blue, 0, false);
        WoodData wood1 = new WoodData(WoodType.Blue, 1, false);
        WoodData wood2 = new WoodData(WoodType.Blue, 2, false);
        WoodData wood3 = new WoodData(WoodType.Yellow, 3, false);
        StoreData storeData0 = new StoreData(45, new List<WoodData> { wood0, wood1, wood2, wood3 }, false);

        WoodData wood4 = new WoodData(WoodType.Yellow, 0, false);
        WoodData wood5 = new WoodData(WoodType.Yellow, 1, false);
        WoodData wood6 = new WoodData(WoodType.Yellow, 2, false);
        WoodData wood7 = new WoodData(WoodType.Blue, 3, false);
        StoreData storeData1 = new StoreData(55, new List<WoodData> { wood4, wood5, wood6, wood7 }, false);

        StoreData storeData2 = new StoreData(65, new List<WoodData> { }, false);

        // Level Data
        LevelDataD level1 = new LevelDataD(1, new List<StoreData> { storeData0, storeData1, storeData2}, 2);

        string jsonData1 = JsonConvert.SerializeObject(level1, Formatting.Indented);

        File.WriteAllText("Level 1.txt", jsonData1);


        WoodData wood8 = new WoodData(WoodType.Blue, 0, false);
        WoodData wood9 = new WoodData(WoodType.Yellow, 1, false);
        WoodData wood10 = new WoodData(WoodType.Blue, 2, false);
        WoodData wood11 = new WoodData(WoodType.Yellow, 3, false);
        StoreData storeData3 = new StoreData(45, new List<WoodData> { wood8, wood9, wood10, wood11 }, false);

        WoodData wood12 = new WoodData(WoodType.Yellow, 0, false);
        WoodData wood13 = new WoodData(WoodType.Blue, 1, false);
        WoodData wood14 = new WoodData(WoodType.Yellow, 2, false);
        WoodData wood15 = new WoodData(WoodType.Blue, 3, false);
        StoreData storeData4 = new StoreData(55, new List<WoodData> { wood12, wood13, wood14, wood15 }, false);

        StoreData storeData5 = new StoreData(65, new List<WoodData> { }, false);

        // Level Data
        LevelDataD level2 = new LevelDataD(2, new List<StoreData> { storeData3, storeData4, storeData5 }, 2);

        string jsonData2 = JsonConvert.SerializeObject(level2, Formatting.Indented);

        File.WriteAllText("Level 2.txt", jsonData2);


        WoodData wood16 = new WoodData(WoodType.Blue, 0, false);
        WoodData wood17 = new WoodData(WoodType.Yellow, 1, false);
        WoodData wood18 = new WoodData(WoodType.Purple, 2, false);
        WoodData wood19 = new WoodData(WoodType.Blue, 3, false);
        StoreData storeData6 = new StoreData(15, new List<WoodData> { wood16, wood17, wood18, wood19 }, false);

        WoodData wood20 = new WoodData(WoodType.Yellow, 0, false);
        WoodData wood21 = new WoodData(WoodType.Purple, 1, false);
        WoodData wood22 = new WoodData(WoodType.Blue, 2, false);
        WoodData wood23 = new WoodData(WoodType.Blue, 3, false);
        StoreData storeData7 = new StoreData(25, new List<WoodData> { wood20, wood21, wood22, wood23 }, false);

        WoodData wood24 = new WoodData(WoodType.Purple, 0, false);
        WoodData wood25 = new WoodData(WoodType.Yellow, 1, false);
        WoodData wood26 = new WoodData(WoodType.Purple, 2, false);
        WoodData wood27 = new WoodData(WoodType.Yellow, 3, false);
        StoreData storeData8 = new StoreData(35, new List<WoodData> { wood24, wood25, wood26, wood27 }, false);

        StoreData storeData9 = new StoreData(45, new List<WoodData> { }, false);
        StoreData storeData10 = new StoreData(55, new List<WoodData> { }, false);
        StoreData lockStore0 = new StoreData(65, new List<WoodData> { }, true);

        // Level Data
        LevelDataD level3 = new LevelDataD(3, new List<StoreData> { storeData6, storeData7, storeData8, storeData9, storeData10, lockStore0}, 3);

        string jsonData3 = JsonConvert.SerializeObject(level3, Formatting.Indented);

        File.WriteAllText("Level 3.txt", jsonData3);


        WoodData wood28 = new WoodData(WoodType.Yellow, 0, false);
        WoodData wood29 = new WoodData(WoodType.Purple, 1, false);
        WoodData wood30 = new WoodData(WoodType.Yellow, 2, false);
        WoodData wood31 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData11 = new StoreData(15, new List<WoodData> { wood28, wood29, wood30, wood31 }, false);

        WoodData wood32 = new WoodData(WoodType.Blue, 0, false);
        WoodData wood33 = new WoodData(WoodType.Blue, 1, false);
        WoodData wood34 = new WoodData(WoodType.Yellow, 2, false);
        WoodData wood35 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData12 = new StoreData(25, new List<WoodData> { wood32, wood33, wood34, wood35 }, false);

        WoodData wood36 = new WoodData(WoodType.Blue, 0, false);
        WoodData wood37 = new WoodData(WoodType.Green, 1, false);
        WoodData wood38 = new WoodData(WoodType.Purple, 2, false);
        WoodData wood39 = new WoodData(WoodType.Green, 3, false);
        StoreData storeData13 = new StoreData(35, new List<WoodData> { wood36, wood37, wood38, wood39 }, false);

        WoodData wood40 = new WoodData(WoodType.Yellow, 0, false);
        WoodData wood41 = new WoodData(WoodType.Blue, 1, false);
        WoodData wood42 = new WoodData(WoodType.Green, 2, false);
        WoodData wood43 = new WoodData(WoodType.Green, 3, false);
        StoreData storeData14 = new StoreData(4, new List<WoodData> { wood40, wood41, wood42, wood43 }, false);

        StoreData storeData15 = new StoreData(5, new List<WoodData> { }, false);
        StoreData storeData16 = new StoreData(6, new List<WoodData> { }, false);
        StoreData lockStore1 = new StoreData(7, new List<WoodData> { }, true);

        // Level Data
        LevelDataD level4 = new LevelDataD(4, new List<StoreData> { storeData11, storeData12, storeData13, storeData14, storeData15, storeData16, lockStore1}, 4);

        string jsonData4 = JsonConvert.SerializeObject(level4, Formatting.Indented);

        File.WriteAllText("Level 4.txt", jsonData4);


        WoodData wood44 = new WoodData(WoodType.Green, 0, true);
        WoodData wood45 = new WoodData(WoodType.Green, 1, true);
        WoodData wood46 = new WoodData(WoodType.Orange, 2, true);
        WoodData wood47 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData17 = new StoreData(0, new List<WoodData> { wood44, wood45, wood46, wood47 }, false);

        WoodData wood48 = new WoodData(WoodType.Green, 0, true);
        WoodData wood49 = new WoodData(WoodType.Blue, 1, true);
        WoodData wood50 = new WoodData(WoodType.Purple, 2, true);
        WoodData wood51 = new WoodData(WoodType.Orange, 3, false);
        StoreData storeData18 = new StoreData(1, new List<WoodData> { wood48, wood49, wood50, wood51 }, false);

        WoodData wood52 = new WoodData(WoodType.Blue, 0, true);
        WoodData wood53 = new WoodData(WoodType.Green, 1, true);
        WoodData wood54 = new WoodData(WoodType.Purple, 2, true);
        WoodData wood55 = new WoodData(WoodType.Orange, 3, false);
        StoreData storeData19 = new StoreData(2, new List<WoodData> { wood52, wood53, wood54, wood55 }, false);

        WoodData wood56 = new WoodData(WoodType.Blue, 0, true);
        WoodData wood57 = new WoodData(WoodType.Orange, 1, true);
        WoodData wood58 = new WoodData(WoodType.Blue, 2, true);
        WoodData wood59 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData20 = new StoreData(3, new List<WoodData> { wood56, wood57, wood58, wood59 }, false);

        StoreData storeData21 = new StoreData(45, new List<WoodData> { }, false);
        StoreData storeData22 = new StoreData(55, new List<WoodData> { }, false);

        StoreData lockStore2 = new StoreData(65, new List<WoodData> { }, true);

        // Level Data
        LevelDataD level5 = new LevelDataD(5, new List<StoreData> { storeData17, storeData18, storeData19, storeData20, storeData21, storeData22, lockStore2 }, 4);

        string jsonData5 = JsonConvert.SerializeObject(level5, Formatting.Indented);

        File.WriteAllText("Level 5.txt", jsonData5);


        WoodData wood60 = new WoodData(WoodType.Purple, 0, false);
        WoodData wood61 = new WoodData(WoodType.Orange, 1, false);
        WoodData wood62 = new WoodData(WoodType.Yellow, 2, false);
        WoodData wood63 = new WoodData(WoodType.Green, 3, false);
        StoreData storeData23 = new StoreData(0, new List<WoodData> { wood60, wood61, wood62, wood63 }, false);

        WoodData wood64 = new WoodData(WoodType.Blue, 0, false);
        WoodData wood65 = new WoodData(WoodType.Blue, 1, false);
        WoodData wood66 = new WoodData(WoodType.Blue, 2, false);
        WoodData wood67 = new WoodData(WoodType.Orange, 3, false);
        StoreData storeData24 = new StoreData(1, new List<WoodData> { wood64, wood65, wood66, wood67 }, false);

        WoodData wood68 = new WoodData(WoodType.Blue, 0, false);
        WoodData wood69 = new WoodData(WoodType.Yellow, 1, false);
        WoodData wood70 = new WoodData(WoodType.Purple, 2, false);
        WoodData wood71 = new WoodData(WoodType.Yellow, 3, false);
        StoreData storeData25 = new StoreData(2, new List<WoodData> { wood68, wood69, wood70, wood71 }, false);

        WoodData wood72 = new WoodData(WoodType.Yellow, 0, false);
        WoodData wood73 = new WoodData(WoodType.Purple, 1, false);
        WoodData wood74 = new WoodData(WoodType.Orange, 2, false);
        WoodData wood75 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData26 = new StoreData(3, new List<WoodData> { wood72, wood73, wood74, wood75 }, false);

        WoodData wood76 = new WoodData(WoodType.Orange, 0, false);
        WoodData wood77 = new WoodData(WoodType.Green, 1, false);
        WoodData wood78 = new WoodData(WoodType.Green, 2, false);
        WoodData wood79 = new WoodData(WoodType.Green, 3, false);
        StoreData storeData27 = new StoreData(4, new List<WoodData> { wood76, wood77, wood78, wood79 }, false);


        StoreData storeData28 = new StoreData(5, new List<WoodData> { }, false);
        StoreData storeData29 = new StoreData(6, new List<WoodData> { }, false);

        StoreData lockStore3 = new StoreData(7, new List<WoodData> { }, true);

        // Level Data
        LevelDataD level6 = new LevelDataD(6, new List<StoreData> { storeData23, storeData24, storeData25, storeData26, storeData27, storeData28, storeData29, lockStore3 }, 5);

        string jsonData6 = JsonConvert.SerializeObject(level6, Formatting.Indented);

        File.WriteAllText("Level 6.txt", jsonData6);


        WoodData wood80 = new WoodData(WoodType.Green, 0, false);
        WoodData wood81 = new WoodData(WoodType.Yellow, 1, false);
        WoodData wood82 = new WoodData(WoodType.Orange, 2, false);
        WoodData wood83 = new WoodData(WoodType.Yellow, 3, false);
        StoreData storeData30 = new StoreData(0, new List<WoodData> { wood80, wood81, wood82, wood83 }, false);

        WoodData wood84 = new WoodData(WoodType.Purple, 0, false);
        WoodData wood85 = new WoodData(WoodType.Purple, 1, false);
        WoodData wood86 = new WoodData(WoodType.Blue, 2, false);
        WoodData wood87 = new WoodData(WoodType.Yellow, 3, false);
        StoreData storeData31 = new StoreData(1, new List<WoodData> { wood84, wood85, wood86, wood87 }, false);

        WoodData wood88 = new WoodData(WoodType.Blue, 0, false);
        WoodData wood89 = new WoodData(WoodType.Blue, 1, false);
        WoodData wood90 = new WoodData(WoodType.Orange, 2, false);
        WoodData wood91 = new WoodData(WoodType.Yellow, 3, false);
        StoreData storeData32 = new StoreData(2, new List<WoodData> { wood88, wood89, wood90, wood91 }, false);

        WoodData wood92 = new WoodData(WoodType.Green, 0, false);
        WoodData wood93 = new WoodData(WoodType.Orange, 1, false);
        WoodData wood94 = new WoodData(WoodType.Green, 2, false);
        WoodData wood95 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData33 = new StoreData(3, new List<WoodData> { wood92, wood93, wood94, wood95 }, false);

        WoodData wood96 = new WoodData(WoodType.Green, 0, false);
        WoodData wood97 = new WoodData(WoodType.Purple, 1, false);
        WoodData wood98 = new WoodData(WoodType.Orange, 2, false);
        WoodData wood99 = new WoodData(WoodType.Blue, 3, false);
        StoreData storeData34 = new StoreData(4, new List<WoodData> { wood96, wood97, wood98, wood99 }, false);


        StoreData storeData35= new StoreData(5, new List<WoodData> { }, false);
        StoreData storeData36 = new StoreData(6, new List<WoodData> { }, false);

        StoreData lockStore4 = new StoreData(7, new List<WoodData> { }, true);

        // Level Data
        LevelDataD level7 = new LevelDataD(6, new List<StoreData> { storeData30, storeData31, storeData32, storeData33, storeData34, storeData35, storeData36, lockStore4 }, 5);

        string jsonData7 = JsonConvert.SerializeObject(level7, Formatting.Indented);

        File.WriteAllText("Level 7.txt", jsonData7);


        WoodData wood100 = new WoodData(WoodType.Yellow, 0, false);
        WoodData wood101 = new WoodData(WoodType.Purple, 1, false);
        WoodData wood102 = new WoodData(WoodType.Green, 2, false);
        WoodData wood103 = new WoodData(WoodType.Green, 3, false);
        StoreData storeData37 = new StoreData(0, new List<WoodData> { wood100, wood101, wood102, wood103 }, false);

        WoodData wood104 = new WoodData(WoodType.Orange, 0, false);
        WoodData wood105 = new WoodData(WoodType.Yellow, 1, false);
        WoodData wood106 = new WoodData(WoodType.Yellow, 2, false);
        WoodData wood107 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData38 = new StoreData(1, new List<WoodData> { wood104, wood105, wood106, wood107 }, false);

        WoodData wood108 = new WoodData(WoodType.Orange, 0, false);
        WoodData wood109 = new WoodData(WoodType.Purple, 1, false);
        WoodData wood110 = new WoodData(WoodType.Purple, 2, false);
        WoodData wood111 = new WoodData(WoodType.Blue, 3, false);
        StoreData storeData39 = new StoreData(2, new List<WoodData> { wood108, wood109, wood110, wood111 }, false);

        WoodData wood112 = new WoodData(WoodType.Blue, 0, false);
        WoodData wood113 = new WoodData(WoodType.Orange, 1, false);
        WoodData wood114 = new WoodData(WoodType.Green, 2, false);
        WoodData wood115 = new WoodData(WoodType.Blue, 3, false);
        StoreData storeData40 = new StoreData(3, new List<WoodData> { wood112, wood113, wood114, wood115 }, false);

        WoodData wood116 = new WoodData(WoodType.Blue, 0, false);
        WoodData wood117 = new WoodData(WoodType.Orange, 1, false);
        WoodData wood118 = new WoodData(WoodType.Yellow, 2, false);
        WoodData wood119 = new WoodData(WoodType.Green, 3, false);
        StoreData storeData41 = new StoreData(4, new List<WoodData> { wood116, wood117, wood118, wood119 }, false);


        StoreData storeData42 = new StoreData(5, new List<WoodData> { }, false);
        StoreData storeData43 = new StoreData(6, new List<WoodData> { }, false);

        StoreData lockStore5 = new StoreData(7, new List<WoodData> { }, true);

        // Level Data
        LevelDataD level8 = new LevelDataD(8, new List<StoreData> { storeData37, storeData38, storeData39, storeData40, storeData41, storeData42, storeData43, lockStore5 }, 5);

        string jsonData8 = JsonConvert.SerializeObject(level8, Formatting.Indented);

        File.WriteAllText("Level 8.txt", jsonData8);


        WoodData wood120 = new WoodData(WoodType.Green, 0, true);
        WoodData wood121 = new WoodData(WoodType.Blue, 1, true);
        WoodData wood122 = new WoodData(WoodType.Green, 2, true);
        WoodData wood123 = new WoodData(WoodType.Pink, 3, false);
        StoreData storeData44 = new StoreData(0, new List<WoodData> { wood120, wood121, wood122, wood123 }, false);

        WoodData wood124 = new WoodData(WoodType.Purple, 0, true);
        WoodData wood125 = new WoodData(WoodType.Yellow, 1, true);
        WoodData wood126 = new WoodData(WoodType.Green, 2, true);
        WoodData wood127 = new WoodData(WoodType.Orange, 3, false);
        StoreData storeData45 = new StoreData(1, new List<WoodData> { wood124, wood125, wood126, wood127 }, false);

        WoodData wood128 = new WoodData(WoodType.Orange, 0, true);
        WoodData wood129 = new WoodData(WoodType.Pink, 1, true);
        WoodData wood130 = new WoodData(WoodType.Yellow, 2, true);
        WoodData wood131 = new WoodData(WoodType.Yellow, 3, false);
        StoreData storeData46 = new StoreData(2, new List<WoodData> { wood128, wood129, wood130, wood131 }, false);

        WoodData wood132 = new WoodData(WoodType.Pink, 0, true);
        WoodData wood133 = new WoodData(WoodType.Blue, 1, true);
        WoodData wood134 = new WoodData(WoodType.Orange, 2, true);
        WoodData wood135 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData47 = new StoreData(3, new List<WoodData> { wood132, wood133, wood134, wood135 }, false);

        WoodData wood136 = new WoodData(WoodType.Orange, 0, true);
        WoodData wood137 = new WoodData(WoodType.Green, 1, true);
        WoodData wood138 = new WoodData(WoodType.Purple, 2, true);
        WoodData wood139 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData48 = new StoreData(-15, new List<WoodData> { wood136, wood137, wood138, wood139 }, false);

        WoodData wood140 = new WoodData(WoodType.Blue, 0, true);
        WoodData wood141 = new WoodData(WoodType.Blue, 1, true);
        WoodData wood142 = new WoodData(WoodType.Yellow, 2, true);
        WoodData wood143 = new WoodData(WoodType.Pink, 3, false);
        StoreData storeData49 = new StoreData(45, new List<WoodData> { wood140, wood141, wood142, wood143 }, false);

        StoreData storeData50 = new StoreData(55, new List<WoodData> { }, false);
        StoreData storeData51 = new StoreData(65, new List<WoodData> { }, false);

        StoreData lockStore6 = new StoreData(75, new List<WoodData> { }, true);

        // Level Data
        LevelDataD level9 = new LevelDataD(9, new List<StoreData> { storeData44, storeData45, storeData46, storeData47, storeData48, storeData49, storeData50, storeData51, lockStore6 }, 6);

        string jsonData9 = JsonConvert.SerializeObject(level9, Formatting.Indented);

        File.WriteAllText("Level 9.txt", jsonData9);


        WoodData wood144 = new WoodData(WoodType.Green, 0, false);
        WoodData wood145 = new WoodData(WoodType.Yellow, 1, false);
        WoodData wood146 = new WoodData(WoodType.Pink, 2, false);
        WoodData wood147 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData52 = new StoreData(0, new List<WoodData> { wood144, wood145, wood146, wood147 }, false);

        WoodData wood148 = new WoodData(WoodType.Orange, 0, false);
        WoodData wood149 = new WoodData(WoodType.Green, 1, false);
        WoodData wood150 = new WoodData(WoodType.Pink, 2, false);
        WoodData wood151 = new WoodData(WoodType.Yellow, 3, false);
        StoreData storeData53 = new StoreData(1, new List<WoodData> { wood148, wood149, wood150, wood151 }, false);

        WoodData wood152 = new WoodData(WoodType.Green, 0, false);
        WoodData wood153 = new WoodData(WoodType.Orange, 1, false);
        WoodData wood154 = new WoodData(WoodType.Purple, 2, false);
        WoodData wood155 = new WoodData(WoodType.Orange, 3, false);
        StoreData storeData54 = new StoreData(2, new List<WoodData> { wood152, wood153, wood154, wood155 }, false);

        WoodData wood156 = new WoodData(WoodType.Orange, 0, false);
        WoodData wood157 = new WoodData(WoodType.Purple, 1, false);
        WoodData wood158 = new WoodData(WoodType.Yellow, 2, false);
        WoodData wood159 = new WoodData(WoodType.Yellow, 3, false);
        StoreData storeData55 = new StoreData(3, new List<WoodData> { wood156, wood157, wood158, wood159 }, false);

        WoodData wood160 = new WoodData(WoodType.Pink, 0, false);
        WoodData wood161 = new WoodData(WoodType.Green, 1, false);
        WoodData wood162 = new WoodData(WoodType.Pink, 2, false);
        WoodData wood163 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData56 = new StoreData(4, new List<WoodData> { wood160, wood161, wood162, wood163 }, false);


        StoreData storeData57 = new StoreData(5, new List<WoodData> { }, false);
        StoreData storeData58 = new StoreData(6, new List<WoodData> { }, false);

        StoreData lockStore7 = new StoreData(7, new List<WoodData> { }, true);

        // Level Data
        LevelDataD level10 = new LevelDataD(10, new List<StoreData> { storeData52, storeData53, storeData54, storeData55, storeData56, storeData57, storeData58, lockStore7 }, 5);

        string jsonData10 = JsonConvert.SerializeObject(level10, Formatting.Indented);

        File.WriteAllText("Level 10.txt", jsonData10);


        WoodData wood164 = new WoodData(WoodType.Blue, 0, false);
        WoodData wood165 = new WoodData(WoodType.Red, 1, false);
        WoodData wood166 = new WoodData(WoodType.Purple, 2, false);
        WoodData wood167 = new WoodData(WoodType.Pink, 3, false);
        StoreData storeData59 = new StoreData(-5, new List<WoodData> { wood164, wood165, wood166, wood167 }, false);

        WoodData wood168 = new WoodData(WoodType.Red, 0, false);
        WoodData wood169 = new WoodData(WoodType.Orange, 1, false);
        WoodData wood170 = new WoodData(WoodType.Green, 2, false);
        WoodData wood171 = new WoodData(WoodType.Orange, 3, false);
        StoreData storeData60 = new StoreData(15, new List<WoodData> { wood168, wood169, wood170, wood171 }, false);

        WoodData wood172 = new WoodData(WoodType.Purple, 0, false);
        WoodData wood173 = new WoodData(WoodType.Pink, 1, false);
        WoodData wood174 = new WoodData(WoodType.Red, 2, false);
        WoodData wood175 = new WoodData(WoodType.Blue, 3, false);
        StoreData storeData61 = new StoreData(25, new List<WoodData> { wood172, wood173, wood174, wood175 }, false);

        WoodData wood176 = new WoodData(WoodType.Pink, 0, false);
        WoodData wood177 = new WoodData(WoodType.Pink, 1, false);
        WoodData wood178 = new WoodData(WoodType.Green, 2, false);
        WoodData wood179 = new WoodData(WoodType.Blue, 3, false);
        StoreData storeData62 = new StoreData(35, new List<WoodData> { wood176, wood177, wood178, wood179 }, false);

        WoodData wood180 = new WoodData(WoodType.Orange, 0, false);
        WoodData wood181 = new WoodData(WoodType.Blue, 1, false);
        WoodData wood182 = new WoodData(WoodType.Yellow, 2, false);
        WoodData wood183 = new WoodData(WoodType.Yellow, 3, false);
        StoreData storeData63 = new StoreData(-45, new List<WoodData> { wood180, wood181, wood182, wood183 }, false);

        WoodData wood184 = new WoodData(WoodType.Orange, 0, false);
        WoodData wood185 = new WoodData(WoodType.Yellow, 1, false);
        WoodData wood186 = new WoodData(WoodType.Yellow, 2, false);
        WoodData wood187 = new WoodData(WoodType.Green, 3, false);
        StoreData storeData64 = new StoreData(-15, new List<WoodData> { wood184, wood185, wood186, wood187 }, false);

        WoodData wood188 = new WoodData(WoodType.Red, 0, false);
        WoodData wood189 = new WoodData(WoodType.Purple, 1, false);
        WoodData wood190 = new WoodData(WoodType.Purple, 2, false);
        WoodData wood191 = new WoodData(WoodType.Green, 3, false);
        StoreData storeData65 = new StoreData(45, new List<WoodData> { wood188, wood189, wood190, wood191 }, false);


        StoreData storeData66 = new StoreData(55, new List<WoodData> { }, false);
        StoreData storeData67 = new StoreData(65, new List<WoodData> { }, false);

        StoreData lockStore8 = new StoreData(75, new List<WoodData> { }, true);

        // Level Data
        LevelDataD level11 = new LevelDataD(11, new List<StoreData> { storeData59, storeData60, storeData61, storeData62, storeData63, storeData64, storeData65, storeData66, storeData67, lockStore8 }, 7);

        string jsonData11 = JsonConvert.SerializeObject(level11, Formatting.Indented);

        File.WriteAllText("Level 11.txt", jsonData11);


        WoodData wood192 = new WoodData(WoodType.Purple, 0, true);
        WoodData wood193 = new WoodData(WoodType.Orange, 1, true);
        WoodData wood194 = new WoodData(WoodType.Orange, 2, true);
        WoodData wood195 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData68 = new StoreData(0, new List<WoodData> { wood192, wood193, wood194, wood195 }, false);

        WoodData wood196 = new WoodData(WoodType.Green, 0, true);
        WoodData wood197 = new WoodData(WoodType.Blue, 1, true);
        WoodData wood198 = new WoodData(WoodType.Yellow, 2, true);
        WoodData wood199 = new WoodData(WoodType.Orange, 3, false);
        StoreData storeData69 = new StoreData(1, new List<WoodData> { wood196, wood197, wood198, wood199 }, false);

        WoodData wood200 = new WoodData(WoodType.Orange, 0, true);
        WoodData wood201 = new WoodData(WoodType.Blue, 1, true);
        WoodData wood202 = new WoodData(WoodType.Green, 2, true);
        WoodData wood203 = new WoodData(WoodType.Blue, 3, false);
        StoreData storeData70 = new StoreData(2, new List<WoodData> { wood200, wood201, wood202, wood203 }, false);

        WoodData wood204 = new WoodData(WoodType.Green, 0, true);
        WoodData wood205 = new WoodData(WoodType.Yellow, 1, true);
        WoodData wood206 = new WoodData(WoodType.Blue, 2, true);
        WoodData wood207 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData71 = new StoreData(3, new List<WoodData> { wood204, wood205, wood206, wood207 }, false);

        WoodData wood208 = new WoodData(WoodType.Yellow, 0, true);
        WoodData wood209 = new WoodData(WoodType.Purple, 1, true);
        WoodData wood210 = new WoodData(WoodType.Yellow, 2, true);
        WoodData wood211 = new WoodData(WoodType.Green, 3, false);
        StoreData storeData72 = new StoreData(4, new List<WoodData> { wood208, wood209, wood210, wood211 }, false);

        StoreData storeData73 = new StoreData(5, new List<WoodData> { }, false);
        StoreData storeData74 = new StoreData(6, new List<WoodData> { }, false);

        StoreData lockStore9 = new StoreData(7, new List<WoodData> { }, true);

        // Level Data
        LevelDataD level12 = new LevelDataD(12, new List<StoreData> { storeData68, storeData69, storeData70, storeData71, storeData72, storeData73, storeData74, lockStore9 }, 5);

        string jsonData12 = JsonConvert.SerializeObject(level12, Formatting.Indented);

        File.WriteAllText("Level 12.txt", jsonData12);


        WoodData wood212 = new WoodData(WoodType.Purple, 0, false);
        WoodData wood213 = new WoodData(WoodType.Green, 1, false);
        WoodData wood214 = new WoodData(WoodType.Yellow, 2, false);
        WoodData wood215 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData75 = new StoreData(0, new List<WoodData> { wood212, wood213, wood214, wood215 }, false);

        WoodData wood216 = new WoodData(WoodType.Green, 0, false);
        WoodData wood217 = new WoodData(WoodType.Red, 1, false);
        WoodData wood218 = new WoodData(WoodType.Red, 2, false);
        WoodData wood219 = new WoodData(WoodType.Pink, 3, false);
        StoreData storeData76 = new StoreData(1, new List<WoodData> { wood216, wood217, wood218, wood219 }, false);

        WoodData wood220 = new WoodData(WoodType.Pink, 0, false);
        WoodData wood221 = new WoodData(WoodType.Red, 1, false);
        WoodData wood222 = new WoodData(WoodType.Yellow, 2, false);
        WoodData wood223 = new WoodData(WoodType.Red, 3, false);
        StoreData storeData77 = new StoreData(2, new List<WoodData> { wood220, wood221, wood222, wood223 }, false);

        WoodData wood224 = new WoodData(WoodType.Yellow, 0, false);
        WoodData wood225 = new WoodData(WoodType.Yellow, 1, false);
        WoodData wood226 = new WoodData(WoodType.Pink, 2, false);
        WoodData wood227 = new WoodData(WoodType.Green, 3, false);
        StoreData storeData78 = new StoreData(3, new List<WoodData> { wood224, wood225, wood226, wood227 }, false);

        WoodData wood228 = new WoodData(WoodType.Purple, 0, false);
        WoodData wood229 = new WoodData(WoodType.Green, 1, false);
        WoodData wood230 = new WoodData(WoodType.Purple, 2, false);
        WoodData wood231 = new WoodData(WoodType.Pink, 3, false);
        StoreData storeData79 = new StoreData(4, new List<WoodData> { wood228, wood229, wood230, wood231 }, false);


        StoreData storeData80 = new StoreData(5, new List<WoodData> { }, false);
        StoreData storeData81 = new StoreData(6, new List<WoodData> { }, false);

        StoreData lockStore10 = new StoreData(7, new List<WoodData> { }, true);

        // Level Data
        LevelDataD level13 = new LevelDataD(13, new List<StoreData> { storeData75, storeData76, storeData77, storeData78, storeData79, storeData80, storeData81, lockStore10 }, 5);

        string jsonData13 = JsonConvert.SerializeObject(level13, Formatting.Indented);

        File.WriteAllText("Level 13.txt", jsonData13);


        WoodData wood232 = new WoodData(WoodType.Green, 0, true);
        WoodData wood233 = new WoodData(WoodType.Red, 1, true);
        WoodData wood234 = new WoodData(WoodType.Pink, 2, true);
        WoodData wood235 = new WoodData(WoodType.Pink, 3, false);
        StoreData storeData82 = new StoreData(-5, new List<WoodData> { wood232, wood233, wood234, wood235 }, false);

        WoodData wood236 = new WoodData(WoodType.Orange, 0, true);
        WoodData wood237 = new WoodData(WoodType.Green, 1, true);
        WoodData wood238 = new WoodData(WoodType.Yellow, 2, true);
        WoodData wood239 = new WoodData(WoodType.Orange, 3, false);
        StoreData storeData83 = new StoreData(15, new List<WoodData> { wood236, wood237, wood238, wood239 }, false);

        WoodData wood240 = new WoodData(WoodType.Yellow, 0, true);
        WoodData wood241 = new WoodData(WoodType.Purple, 1, true);
        WoodData wood242 = new WoodData(WoodType.Pink, 2, true);
        WoodData wood243 = new WoodData(WoodType.Green, 3, false);
        StoreData storeData84 = new StoreData(25, new List<WoodData> { wood240, wood241, wood242, wood243 }, false);

        WoodData wood244 = new WoodData(WoodType.Yellow, 0, true);
        WoodData wood245 = new WoodData(WoodType.Pink, 1, true);
        WoodData wood246 = new WoodData(WoodType.Blue, 2, true);
        WoodData wood247 = new WoodData(WoodType.Yellow, 3, false);
        StoreData storeData85 = new StoreData(35, new List<WoodData> { wood244, wood245, wood246, wood247 }, false);

        WoodData wood248 = new WoodData(WoodType.Blue, 0, true);
        WoodData wood249 = new WoodData(WoodType.Red, 1, true);
        WoodData wood250 = new WoodData(WoodType.Orange, 2, true);
        WoodData wood251 = new WoodData(WoodType.Blue, 3, false);
        StoreData storeData86 = new StoreData(-45, new List<WoodData> { wood248, wood249, wood250, wood251 }, false);

        WoodData wood252 = new WoodData(WoodType.Purple, 0, true);
        WoodData wood253 = new WoodData(WoodType.Red, 1, true);
        WoodData wood254 = new WoodData(WoodType.Green, 2, true);
        WoodData wood255 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData87 = new StoreData(-15, new List<WoodData> { wood252, wood253, wood254, wood255 }, false);

        WoodData wood256 = new WoodData(WoodType.Red, 0, true);
        WoodData wood257 = new WoodData(WoodType.Blue, 1, true);
        WoodData wood258 = new WoodData(WoodType.Purple, 2, true);
        WoodData wood259 = new WoodData(WoodType.Orange, 3, false);
        StoreData storeData88 = new StoreData(45, new List<WoodData> { wood256, wood257, wood258, wood259 }, false);

        StoreData storeData89 = new StoreData(55, new List<WoodData> { }, false);
        StoreData storeData90 = new StoreData(65, new List<WoodData> { }, false);

        StoreData lockStore11 = new StoreData(75, new List<WoodData> { }, true);

        // Level Data
        LevelDataD level14 = new LevelDataD(14, new List<StoreData> { storeData82, storeData83, storeData84, storeData85, storeData86, storeData87, storeData88, storeData89, storeData90, lockStore11 }, 7);

        string jsonData14 = JsonConvert.SerializeObject(level14, Formatting.Indented);

        File.WriteAllText("Level 14.txt", jsonData14);



        WoodData wood260 = new WoodData(WoodType.Red, 0, false);
        WoodData wood261 = new WoodData(WoodType.Pink, 1, false);
        WoodData wood262 = new WoodData(WoodType.Pink, 2, false);
        WoodData wood263 = new WoodData(WoodType.Purple, 3, false);
        StoreData storeData91 = new StoreData(-5, new List<WoodData> { wood260, wood261, wood262, wood263 }, false);

        WoodData wood264 = new WoodData(WoodType.Purple, 0, false);
        WoodData wood265 = new WoodData(WoodType.Blue, 1, false);
        WoodData wood266 = new WoodData(WoodType.Orange, 2, false);
        WoodData wood267 = new WoodData(WoodType.Yellow, 3, false);
        StoreData storeData92 = new StoreData(15, new List<WoodData> { wood264, wood265, wood266, wood267 }, false);

        WoodData wood268 = new WoodData(WoodType.Yellow, 0, false);
        WoodData wood269 = new WoodData(WoodType.Purple, 1, false);
        WoodData wood270 = new WoodData(WoodType.Yellow, 2, false);
        WoodData wood271 = new WoodData(WoodType.Yellow, 3, false);
        StoreData storeData93 = new StoreData(25, new List<WoodData> { wood268, wood269, wood270, wood271 }, false);

        WoodData wood272 = new WoodData(WoodType.Orange, 0, false);
        WoodData wood273 = new WoodData(WoodType.Pink, 1, false);
        WoodData wood274 = new WoodData(WoodType.Purple, 2, false);
        WoodData wood275 = new WoodData(WoodType.Orange, 3, false);
        StoreData storeData94 = new StoreData(35, new List<WoodData> { wood272, wood273, wood274, wood275 }, false);

        WoodData wood276 = new WoodData(WoodType.Blue, 0, false);
        WoodData wood277 = new WoodData(WoodType.Orange, 1, false);
        WoodData wood278 = new WoodData(WoodType.Red, 2, false);
        WoodData wood279 = new WoodData(WoodType.Blue, 3, false);
        StoreData storeData95 = new StoreData(-45, new List<WoodData> { wood276, wood277, wood278, wood279 }, false);

        WoodData wood280 = new WoodData(WoodType.Green, 0, false);
        WoodData wood281 = new WoodData(WoodType.Red, 1, false);
        WoodData wood282 = new WoodData(WoodType.Red, 2, false);
        WoodData wood283 = new WoodData(WoodType.Green, 3, false);
        StoreData storeData96 = new StoreData(-15, new List<WoodData> { wood280, wood281, wood282, wood283 }, false);

        WoodData wood284 = new WoodData(WoodType.Blue, 0, false);
        WoodData wood285 = new WoodData(WoodType.Green, 1, false);
        WoodData wood286 = new WoodData(WoodType.Pink, 2, false);
        WoodData wood287 = new WoodData(WoodType.Green, 3, false);
        StoreData storeData97 = new StoreData(45, new List<WoodData> { wood284, wood285, wood286, wood287 }, false);

        StoreData storeData98 = new StoreData(55, new List<WoodData> { }, false);
        StoreData storeData99 = new StoreData(65, new List<WoodData> { }, false);

        StoreData lockStore12 = new StoreData(75, new List<WoodData> { }, true);

        // Level Data
        LevelDataD level15 = new LevelDataD(15, new List<StoreData> { storeData91, storeData92, storeData93, storeData94, storeData95, storeData96, storeData97, storeData98, storeData99, lockStore12 }, 7);

        string jsonData15 = JsonConvert.SerializeObject(level15, Formatting.Indented);

        File.WriteAllText("Level 15.txt", jsonData15);
    }

    private void Start()
    {
        LoadLevel();

        testSaveBtn.onClick.AddListener(Save15Levels);
        playBtn.onClick.AddListener(LoadData);
        NextLevelBtn.onClick.AddListener(ClickNextLevel);
    }

    public void LoadData()
    {
        SoundManager.Instance.Play("Tap");

        if (LevelIndex > 15)
        {
            return;
        }
        else
        {
            TutorialManager.Instance.ListWS.Clear();

            CheckMoveLeft();

            string levelString = "Level " + LevelIndex;

            string jsonFromFile = Resources.Load(levelString).ToString();

            //string jsonFromFile = File.ReadAllText(levelString);
            LevelDataD loadLevelData = JsonConvert.DeserializeObject<LevelDataD>(jsonFromFile);

            if (loadLevelData.storeDatas.Count > 0)
            {
                GameManager.Instance.WinCount = 0;
                GameManager.Instance.WinCountData = loadLevelData.winCount;

                for (int i = 0; i < loadLevelData.storeDatas.Count; i++)
                {
                    WoodStore storeclone = Instantiate(wsPrefab);
                    storeclone.SetData(loadLevelData.storeDatas[i]);
                    storeclone.transform.SetParent(ListLevel[LevelIndex - 1].gameObject.transform);
                    ListLevel[levelIndex - 1].gameObject.SetActive(true);

                    if (levelIndex == 1 || levelIndex == 2)
                    {
                        TutorialManager.Instance.ListWS.Add(storeclone);
                    }
                }

                if (levelIndex == 1)
                {
                    TutorialManager.Instance.HandTut.gameObject.SetActive(true);
                    TutorialManager.Instance.HandTut.MoveObject();
                }
            }

            UIManager.Instance.TurnOffHomePanel();
            UIManager.Instance.TurnOnPlayPanel();
            GameManager.Instance.Key.BoxCollider2D.enabled = true;

            StartCoroutine(listLevel[levelIndex - 1].DelayfixScale());
        }
    }

    public void ClickNextLevel()
    {
        //listLevel[levelIndex - 1].gameObject.SetActive(false);

        DeleteLevel();

        LevelIndex++;
        GameManager.Instance.Key.Index = 0;
        GameManager.Instance.UnLockCount = 4;

        LoadData();

        NextLevelBtn.gameObject.SetActive(false);
    }

    public void ReplayLevel()
    {
        DeleteLevel();

        GameManager.Instance.Key.Index = 0;
        GameManager.Instance.UnLockCount = 4;

        LoadData();

        //StartCoroutine(listLevel[levelIndex - 1].DelayfixScale());
    }

    public void DeleteLevel()
    {
        GameManager.Instance.IsDone = true;

        foreach (Transform child in ListLevel[LevelIndex - 1].gameObject.transform)
        {
            Destroy(child.gameObject);
        }

        ListLevel[levelIndex - 1].gameObject.SetActive(false);
    }

    public void PlayerMoveToNextLevel()
    {
        if (levelIndex < 15)
        {
            levelIndex++;
        }

        GameManager.Instance.Key.BoxCollider2D.enabled = false;
        GameManager.Instance.Key.Index = 0;
        GameManager.Instance.UnLockCount = 4;

        if (levelIndex <= 15)
        {
            listStoreShelf[levelIndex - 1].ThisBtn.enabled = true;
            listStoreShelf[levelIndex - 2].CheckMark.SetActive(true);

            player.Move(listStoreShelf[levelIndex - 1]);

            UIManager.Instance.UpdateText(levelIndex);
        }
    }

    public void CheckMoveLeft()
    {
        if (levelIndex == 10)
        {
            UIManager.Instance.TurnOnMoveLeft(20);
        }
        else if (levelIndex == 15)
        {
            UIManager.Instance.TurnOnMoveLeft(26);
        }
        else
        {
            UIManager.Instance.MoveLeftPanel.SetActive(false);
        }
    }

    public void SaveLevel()
    {
        int index = PlayerPrefs.GetInt("Level", 1);

        if (levelIndex >= index && levelIndex < 15)
        {
            PlayerPrefs.SetFloat("Scroll", scrollbar.value);
            PlayerPrefs.SetInt("Level", levelIndex + 1);
            PlayerPrefs.Save(); 
        }
    }

    public void LoadLevel()
    {
        levelIndex = PlayerPrefs.GetInt("Level", 1);
        scrollbar.value = PlayerPrefs.GetFloat("Scroll", 0f);

        player.transform.position = listStoreShelf[levelIndex - 1].MainPos.position;
        listStoreShelf[levelIndex - 1].ThisBtn.enabled = true;

        if (levelIndex > 1)
        {
            LoadPlayedLevel();
        }
    }

    public void LoadPlayedLevel()
    {
        for (int i = 0; i < levelIndex - 1; i++)
        {
            listStoreShelf[i].ThisBtn.enabled = true;
            listStoreShelf[i].CheckMark.SetActive(true);
        }
    }
}
