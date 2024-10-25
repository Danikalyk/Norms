using System;
using System.IO;

namespace Norms
{
    public static class config
    {
        public const string _connectionString = @"Data Source=zt019.office.rcl.ru\SQLEXPRESS;Initial Catalog=GAS_CUTTING;User ID=sa;Password=EmmojoyProoo!23";
        public static int openedWindows = 0;
        public static readonly string sqLiteConnectionString = $"Data Source={Path.Combine(Environment.CurrentDirectory, "Data", "gas_cutting.db")}";
        public static readonly string pluginFolder = $"{Path.Combine(Environment.CurrentDirectory, "Plugin")}";

        public static double xRazm = 0;
        public static double yRazm = 0;
        public static int selectedSheet = -1;

        public static string BEGIN_SHEET_TECH_3030 =
            "BEGIN_SHEET_TECH\r\n" +
            "C\r\n" +
            "ZA,MM,14\r\n" +
            "MM,AT,1,  10,1,1,,'Tabellenidentifikator'                 ,,'',T\r\n" +
            "MM,AT,1,  20,1,1,,'Blechmass X'                           ,,'mm',Z\r\n" +
            "MM,AT,1,  30,1,1,,'Blechmass Y'                           ,,'mm',Z\r\n" +
            "MM,AT,1,  40,1,1,,'Blechmass Z'                           ,,'mm',Z\r\n" +
            "MM,AT,1, 200,1,1,,'TRUMPF-Kennung'                        ,,'',Z\r\n" +
            "MM,AT,1, 220,1,1,,'Blechmass X real'                      ,,'mm',Z\r\n" +
            "MM,AT,1, 230,1,1,,'Blechmass Y real'                      ,,'mm',Z\r\n" +
            "MM,AT,1, 240,1,1,,'Materialkennung'                       ,,'',T\r\n" +
            "MM,AT,1, 260,1,1,,'Werkstoffdichte'                       ,,'kg/dm3',Z\r\n" +
            "MM,AT,1, 280,1,1,,'Dynamikstufe'                          ,,'',Z\r\n" +
            "MM,AT,1, 290,1,1,,'Werkstoffkennung'                      ,,'',T\r\n" +
            "MM,AT,1, 370,1,1,,'AdvancedEvaporateSwitch'               ,,'',Z\r\n" +
            "MM,AT,1, 380,1,1,,'AdvancedEvaporateCircleRadius'         ,,'mm',Z\r\n" +
            "MM,AT,1, 390,1,1,,'Surface Optical Reflection Property'   ,,'',Z\r\n" +
            "C\r\n";

        public static readonly string BEGIN_SHEET_TECH_5030 =
            "BEGIN_SHEET_TECH\r\n" +
            "C\r\n" +
            "ZA,MM,10\r\n" +
            "MM,AT,1,  10,1,1,,'Tabellenidentifikator'                 ,,'',T\r\n" +
            "MM,AT,1,  20,1,1,,'Blechmass X'                           ,,'mm',Z\r\n" +
            "MM,AT,1,  30,1,1,,'Blechmass Y'                           ,,'mm',Z\r\n" +
            "MM,AT,1,  40,1,1,,'Blechmass Z'                           ,,'mm',Z\r\n" +
            "MM,AT,1, 200,1,1,,'TRUMPF-Kennung'                        ,,'',Z\r\n" +
            "MM,AT,1, 220,1,1,,'Blechmass X real'                      ,,'mm',Z\r\n" +
            "MM,AT,1, 230,1,1,,'Blechmass Y real'                      ,,'mm',Z\r\n" +
            "MM,AT,1, 240,1,1,,'Materialkennung'                       ,,'',T\r\n" +
            "MM,AT,1, 260,1,1,,'Werkstoffdichte'                       ,,'kg/dm3',Z\r\n" +
            "MM,AT,1, 290,1,1,,'Werkstoffkennung'                      ,,'',T\r\n" +
            "C\r\n";

        public static readonly string BEGIN_MACHINE_LOAD_DATA =
            "BEGIN_MACHINE_LOAD_DATA\r\n" +
            "C\r\n" +
            "ZA,MM,9\r\n" +
            "MM,AT,1,  10,1,1,,'Load Name'                             ,,'',T\r\n" +
            "MM,AT,1,  50,1,1,,'Loading Type'                          ,,'',Z\r\n" +
            "MM,AT,1,  60,1,1,,'Calibration Active'                    ,,'Bool',Z\r\n" +
            "MM,AT,1, 100,1,1,,'Pallet Changer Type'                   ,,'',Z\r\n" +
            "MM,AT,1, 110,1,1,,'Sheet Stop'                            ,,'',Z\r\n" +
            "MM,AT,1, 120,1,1,,'Measure Sheet Position'                ,,'',Z\r\n" +
            "MM,AT,1, 130,1,1,,'Measuring Range X'                     ,,'mm',Z\r\n" +
            "MM,AT,1, 140,1,1,,'Measuring Range Y'                     ,,'mm',Z\r\n" +
            "MM,AT,1, 150,1,1,,'Measuring Corner'                      ,,'',Z\r\n" +
            "C\r\n" +
            "ZA,DA,1\r\n" +
            "DA,'SHL-1',1,1,1,1,0,50.00,50.00,1\r\n" +
            "C\r\n" +
            "ENDE_MACHINE_LOAD_DATA\r\n" +
            "C\r\n";

        public static readonly string BEGIN_SHEET_LOAD =
            "BEGIN_SHEET_LOAD\r\n" +
            "C\r\n" +
            "ZA,MM,24\r\n" +
            "MM,AT,1,  10,1,1,,'Tabellenidentifikator'                 ,,'',T\r\n" +
            "MM,AT,1,  70,1,1,,'TRUMPF-Kennung'                        ,,'',Z\r\n" +
            "MM,AT,1, 100,1,1,,'maximale Bearbeitungsposition X'       ,,'mm',Z\r\n" +
            "MM,AT,1, 110,1,1,,'maximale Bearbeitungsposition Y'       ,,'mm',Z\r\n" +
            "MM,AT,1, 500,1,1,,'Beladegeraet'                          ,,'',Z\r\n" +
            "MM,AT,1, 520,1,1,,'LIFT_SAUGERGRUPPE_1'                   ,,'',Z\r\n" +
            "MM,AT,1, 530,1,1,,'LIFT_SAUGERGRUPPE_2'                   ,,'',Z\r\n" +
            "MM,AT,1, 540,1,1,,'LIFT_SAUGERGRUPPE_3'                   ,,'',Z\r\n" +
            "MM,AT,1, 550,1,1,,'LIFT_SAUGERGRUPPE_4'                   ,,'',Z\r\n" +
            "MM,AT,1, 580,1,1,,'Lift Doppelblechdet aktiv'             ,,'Bool',Z\r\n" +
            "MM,AT,1, 590,1,1,,'Lift abschaelen'                       ,,'Bool',Z\r\n" +
            "MM,AT,1, 620,1,1,,'Blechanschlag'                         ,,'',Z\r\n" +
            "MM,AT,1, 630,1,1,,'Blechlage vermessen'                   ,,'',Z\r\n" +
            "MM,AT,1, 640,1,1,,'Messbereich X'                         ,,'mm',Z\r\n" +
            "MM,AT,1, 650,1,1,,'Messbereich Y'                         ,,'mm',Z\r\n" +
            "MM,AT,1, 660,1,1,,'Kalibrierung'                          ,,'Bool',Z\r\n" +
            "MM,AT,1, 690,1,1,,'Palettenwechselart'                    ,,'',Z\r\n" +
            "MM,AT,1, 700,1,1,,'Messecke'                              ,,'',Z\r\n" +
            "MM,AT,1, 720,1,1,,'Spreizmagnet (Lift)'                   ,,'Bool',Z\r\n" +
            "MM,AT,1, 730,1,1,,'Drehzylinder  (Lift)'                  ,,'Bool',Z\r\n" +
            "MM,AT,1, 810,1,1,,'Einzelsaugeranwahl'                    ,,'',Z\r\n" +
            "MM,AT,1, 820,1,1,,'Blech beim Beladen ausrichten'         ,,'',Z\r\n" +
            "MM,AT,1, 830,1,1,,'Codierung Einzelsauger 1'              ,,'',T\r\n" +
            "MM,AT,1, 840,1,1,,'Codierung Einzelsauger 2'              ,,'',T\r\n" +
            "C\r\n" +
            "ZA,DA,1\r\n" +
            "DA,'SHL-1',1,1240,1500,1,1,1,1,1,1,0,1,0,50.00,50.00,1,1,1,1,1,\r\n" +
            "*  0,0,'00000000','00000000'\r\n" +
            "C\r\n" +
            "ENDE_SHEET_LOAD\r\n" +
            "C \r\n";

        public static readonly string LTT_STAMM_3030_RULES =
            "MM,AT,1,2510,1,1,,'Approachmode Large Contour'            ,,'',Z\r\n" +
            "MM,AT,1,2520,1,1,,'Approachmode Medium Contour'           ,,'',Z\r\n" +
            "MM,AT,1,2530,1,1,,'Approachmode Small Contour'            ,,'',Z\r\n" +
            "MM,AT,1,2540,1,1,,'PierceLine-N Einstellmass vollsyn.'    ,,'mm',Z\r\n" +
            "MM,AT,1,2550,1,1,,'PierceLine-N Zeit vollsyn.'            ,,'s',Z\r\n" +
            "MM,AT,1,2560,1,1,,'PierceLine-N Gasdruck vollsyn.'        ,,'bar',Z\r\n" +
            "MM,AT,1,2570,1,1,,'PierceLine-R Einstellmass vollsyn.'    ,,'mm',Z\r\n" +
            "MM,AT,1,2580,1,1,,'PierceLine-R Zeit vollsyn.'            ,,'s',Z\r\n" +
            "MM,AT,1,2590,1,1,,'PierceLine-R Gasdruck vollsyn.'        ,,'bar',Z\r\n" +
            "MM,AT,1,2600,1,1,,'Base Name'                             ,,'',T\r\n" +
            "MM,AT,1,2610,1,1,,'Dimension Machine Min.'                ,,'mm',Z\r\n" +
            "MM,AT,1,2620,1,1,,'Dimension Machine Max.'                ,,'mm',Z\r\n" +
            "MM,AT,1,2630,1,1,,'ISO-Material Name'                     ,,'',T\r\n" +
            "MM,AT,1,2640,1,1,,'Laser Type'                            ,,'',T\r\n" +
            "MM,AT,1,2650,1,1,,'Filter FoilType'                       ,,'',Z\r\n" +
            "MM,AT,1,2660,1,1,,'Filter Suitable For Coating'           ,,'',Z\r\n" +
            "MM,AT,1,2670,1,1,,'Filter Processing Technology 1'        ,,'',Z\r\n" +
            "MM,AT,1,2680,1,1,,'Filter Processing Technology 2'        ,,'',Z\r\n" +
            "MM,AT,1,2700,1,1,,'Cut Change Mode Large'                 ,,'',Z\r\n" +
            "MM,AT,1,2710,1,1,,'Cut Change Mode Medium'                ,,'',Z\r\n" +
            "MM,AT,1,2720,1,1,,'Cut Change Mode Small'                 ,,'',Z\r\n" +
            "MM,AT,1,2730,1,1,,'Cut Change Path Length Large'          ,,'mm',Z\r\n" +
            "MM,AT,1,2740,1,1,,'Cut Change Path Length Medium'         ,,'mm',Z\r\n" +
            "MM,AT,1,2750,1,1,,'Cut Change Path Length Small'          ,,'mm',Z\r\n" +
            "MM,AT,1,2760,1,1,,'Cut Change Start Setting Value Large'  ,,'mm',Z\r\n" +
            "MM,AT,1,2770,1,1,,'Cut Change Start Setting Value Medium' ,,'mm',Z\r\n" +
            "MM,AT,1,2780,1,1,,'Cut Change Start Setting Value Small'  ,,'mm',Z\r\n" +
            "MM,AT,1,2790,1,1,,'EINST_NOR_QUERBLASEN'                  ,,'Bool',Z\r\n" +
            "MM,AT,1,2800,1,1,,'EINST_SAN_QUERBLASEN'                  ,,'Bool',Z\r\n";


    }
}
