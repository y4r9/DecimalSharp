using DecimalSharp.Core;
using NUnit.Framework;

namespace DecimalSharp.Tests.Light
{
    [TestFixture, Category("BigDecimalLightToString")]
    public class BigDecimalLightToStringTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public new void ToString()
        {
            var bigDecimalFactory = new BigDecimalLightFactory(new BigDecimalLightConfig()
            {
                Precision = 20,
                Rounding = RoundingMode.ROUND_HALF_UP,
                ToExpNeg = (long)-9e15,
                ToExpPos = (long)9e15
            });

            var t = (string expected, BigDecimalArgument<BigDecimalLight> n) =>
            {
                BigDecimalTests.assertEqual(expected, bigDecimalFactory.BigDecimal(n).ToString());
            };

            t("0", 0);
            t("0", "0");
            t("1", 1);
            t("9", 9);
            t("90", 90);
            t("90.12", 90.12);
            t("0.1", 0.1);
            t("0.01", 0.01);
            t("0.0123", 0.0123);
            t("111111111111111111111", "111111111111111111111");
            t("1111111111111111111111", "1111111111111111111111");
            t("11111111111111111111111", "11111111111111111111111");
            t("0.00001", 0.00001);
            t("0.000001", 0.000001);

            t("0", -0);
            t("0", "-0");
            t("-1", -1);
            t("-9", -9);
            t("-90", -90);
            t("-90.12", -90.12);
            t("-0.1", -0.1);
            t("-0.01", -0.01);
            t("-0.0123", -0.0123);
            t("-111111111111111111111", "-111111111111111111111");
            t("-1111111111111111111111", "-1111111111111111111111");
            t("-11111111111111111111111", "-11111111111111111111111");
            t("-0.00001", -0.00001);
            t("-0.000001", -0.000001);

            // Exponential format
            bigDecimalFactory.Config.ToExpNeg = 0;
            bigDecimalFactory.Config.ToExpPos = 0;

            t("1e-7", 0.0000001);
            t("1.2e-7", 0.00000012);
            t("1.23e-7", 0.000000123);
            t("1e-8", 0.00000001);
            t("1.2e-8", 0.000000012);
            t("1.23e-8", 0.0000000123);
            t("-1e-7", -0.0000001);
            t("-1.2e-7", -0.00000012);
            t("-1.23e-7", -0.000000123);
            t("-1e-8", -0.00000001);
            t("-1.2e-8", -0.000000012);
            t("-1.23e-8", -0.0000000123);

            t("5.73447902457635174479825134e+14", "573447902457635.174479825134");
            t("1.07688e+1", "10.7688");
            t("3.171194102379077141557759899307946350455841e+27", "3171194102379077141557759899.307946350455841");
            t("4.924353466898191177698653319742594890634579e+37", "49243534668981911776986533197425948906.34579");
            t("6.85558243926569397328633907445409866949445343654692955e+18", "6855582439265693973.28633907445409866949445343654692955");
            t("1e+0", "1");
            t("2.1320000803e+7", "21320000.803");
            t("5.0878741e+4", "50878.741");
            t("5.1932898288391e+8", "519328982.88391");
            t("5.690616778176956027307884725933410349604387915634524e+49", "56906167781769560273078847259334103496043879156345.24");
            t("3.25099780528575457273246693147645e+15", "3250997805285754.572732466931476450");
            t("3e+0", "3");
            t("2.5811494197573291905990947355226e+13", "25811494197573.291905990947355226");
            t("5.60372259169833930471746454125e+13", "56037225916983.3930471746454125");
            t("1.2615810663732236602461593613783e+7", "12615810.663732236602461593613783");
            t("1.4654366449266911507705477499035407722184965108377032e+11", "146543664492.66911507705477499035407722184965108377032");
            t("6.4986735507448912857131832908423940757e+38", "649867355074489128571318329084239407570.0");
            t("3.6146989180120676857245474944e+3", "3614.6989180120676857245474944");
            t("9.928654762302286149994896625074e+4", "99286.54762302286149994896625074");
            t("3.46424170787806074650506079e+3", "3464.24170787806074650506079");
            t("1.25934313355319666474752550204680303068865719647e+33", "1259343133553196664747525502046803.03068865719647");
            t("1.23014105337660651106978059198916100450966081493207e+27", "1230141053376606511069780591.98916100450966081493207");
            t("1.386164712267169624993434287237e+23", "138616471226716962499343.4287237");
            t("2.66076369930322488334961932e+3", "2660.76369930322488334961932");
            t("9.37582568e+4", "93758.2568");
            t("1.39853642894726883996875746770529e+28", "13985364289472688399687574677.0529");
            t("3.19099e+5", "319099.0");
            t("3.04557106798789396303998723e+19", "30455710679878939630.3998723");
            t("1.3024612569115368830867934222004329653604418e+9", "1302461256.9115368830867934222004329653604418");
            t("2.358787483447172786e+5", "235878.7483447172786");
            t("5.10614446965318674547416709785208086304398889160563e+28", "51061444696531867454741670978.5208086304398889160563");
            t("1.46685947134456101512731611558e+23", "146685947134456101512731.6115580");
            t("3.69960105771344554151928256518906564810300119e+25", "36996010577134455415192825.6518906564810300119");
            t("2.68683153074628e+10", "26868315307.4628");
            t("2.35656504568492312232737219553793859212e+15", "2356565045684923.12232737219553793859212");
            t("7.753292442361215e+14", "775329244236121.5");
            t("1.56e+0", "1.56");
            t("1.272818730367215461852227991200704e+21", "1272818730367215461852.227991200704");
            t("1.13900700292988027871648046839423153789e+7", "11390070.0292988027871648046839423153789");
            t("3.3431e+0", "3.3431");
            t("1.4546654966819402705e+14", "145466549668194.02705");
            t("3.05345735395805567424714891401667575466462830113819e+48", "3053457353958055674247148914016675754664628301138.19");
            t("5.1218945854639324441304933666460587e+2", "512.18945854639324441304933666460587");
            t("9.95299900896e+5", "995299.9008960");
            t("1.21564537151562431991786620635e+0", "1.21564537151562431991786620635");
            t("4.016e+1", "40.16");
            t("1.86570326e+7", "18657032.6");
            t("1.3381001727e+5", "133810.01727");
            t("2.639841700687441886800225725227e+12", "2639841700687.441886800225725227");
            t("2.45e+0", "2.45");
            t("2.8945e+2", "289.45");
            t("1.23e+0", "1.23");
            t("1.559806666149836070330006415033e+24", "1559806666149836070330006.415033");
            t("3.14984566145310751826289711761375061645611777700983e+3", "3149.84566145310751826289711761375061645611777700983");
            t("3.0940691333892283249774116223987e+5", "309406.91333892283249774116223987");
            t("6.572766274013360381079275191108732606370177179594282e+5", "657276.6274013360381079275191108732606370177179594282");
            t("1.470126973337024e+6", "1470126.973337024");
            t("5.6499e+2", "564.99");
            t("2.8416297367859233303497847667971781197616950846e+28", "28416297367859233303497847667.971781197616950846");
            t("2.1364951568189836563102481625533538320051163977e+41", "213649515681898365631024816255335383200511.63977");
            t("8.76108618687537137080904679797e+19", "87610861868753713708.0904679797");
            t("6.27683573474251182408654509953633505286e+6", "6276835.73474251182408654509953633505286");
            t("8.91411e+0", "8.91411");
            t("9.034542832410912578330021146413119399e+28", "90345428324109125783300211464.13119399");
            t("7.026094393430852002585511641212897686956090955e+39", "7026094393430852002585511641212897686956.090955");
            t("1.8812221093491505758565988678062e+11", "188122210934.91505758565988678062");
            t("9.435538492497050138580201734902181057468044875e+43", "94355384924970501385802017349021810574680448.75");
            t("5.36793419620790391866461e+20", "536793419620790391866.461");
            t("2.315089265590404012562599592854156357726817712e+26", "231508926559040401256259959.2854156357726817712");
            t("7.499170741828885273030006066196546588710962e+17", "749917074182888527.3030006066196546588710962");
            t("3.3962128305986e+5", "339621.28305986");
            t("8.17980456510031304e+9", "8179804565.10031304");
            t("4.394575876858124185382e+13", "43945758768581.24185382");
            t("7.881617323629751701107428e+9", "7881617323.629751701107428");
            t("4.89e+0", "4.89");
            t("9.85209894663520857685703881781194082356123765e+39", "9852098946635208576857038817811940823561.23765");
            t("6.849329685e+5", "684932.9685");
            t("2.8262252277815736355279617243060700437627773361e+7", "28262252.277815736355279617243060700437627773361");
            t("1.503736721902e+9", "1503736721.902");
            t("2.65213505469049775997232325076980590625670234690917845e+41", "265213505469049775997232325076980590625670.234690917845");
            t("4.23752645959719196604760963802412828187442060555521e+2", "423.752645959719196604760963802412828187442060555521");
            t("9.023159535576504097005203913521871601640521009e+36", "9023159535576504097005203913521871601.640521009");
            t("4.69339457186380276410136272120035011198438772754725e+14", "469339457186380.276410136272120035011198438772754725");
            t("1.2819429130391792511503973184804508867728894e+6", "1281942.9130391792511503973184804508867728894");
            t("1.9778e+3", "1977.8");
            t("2.456680359828937628024631306792185367572610021e+43", "24566803598289376280246313067921853675726100.21");
            t("5.25389225018085571689046925802871155628e+1", "52.5389225018085571689046925802871155628");
            t("1.733700532107e+8", "173370053.2107");
            t("1.9561099921e+5", "195610.99921");
            t("3.3409e+2", "334.09");
            t("6.09858715556186e+0", "6.09858715556186");
            t("3.20634106832106387482375790792609337383007782520694e+24", "3206341068321063874823757.90792609337383007782520694");
            t("1.46347126003930100207988814e+20", "146347126003930100207.98881400");
            t("2.717780449744210117995586561524987067807146882e+43", "27177804497442101179955865615249870678071468.82");
            t("2.86757572635270377540170639151e+22", "28675757263527037754017.0639151");
            t("1.3488325541508602487577920722101277063863557818e+14", "134883255415086.02487577920722101277063863557818");
            t("1.96013732736436392e+13", "19601373273643.6392");
            t("4.798185890466e+2", "479.8185890466");
            t("1.696622337138949329874242519485119916519994150606e+39", "1696622337138949329874242519485119916519.994150606");
            t("5.50000572984970761183142593570950897913860587074643e+13", "55000057298497.0761183142593570950897913860587074643");
            t("4.9e+1", "49");
            t("2.353405108244768666141e+9", "2353405108.2447686661410");
            t("1.237978927714857736527530290155529e+0", "1.237978927714857736527530290155529");
            t("5.54113012e+1", "55.411301200");
            t("1.639709023131e+11", "163970902313.1");
            t("2.15324060127001207725970506357881e+19", "21532406012700120772.5970506357881");
            t("2.373532121822929762731612214095513784533409e+29", "237353212182292976273161221409.5513784533409");
            t("4.5883026736677354807679611737881799804e+16", "45883026736677354.807679611737881799804");
            t("2.5996714820346689325468319633061e+21", "2599671482034668932546.8319633061");
            t("8.22641928e+6", "8226419.280");
            t("2.56006014528479284199702229871263269e+20", "256006014528479284199.702229871263269");
            t("4.301260132991159779386275268219519443685e+24", "4301260132991159779386275.268219519443685");
            t("1.052721790360165649330888881e+22", "10527217903601656493308.88881");
            t("6.85257703973809064426443728e+0", "6.85257703973809064426443728");
            t("1.341206836e+5", "134120.6836");
            t("1.293696083809745995580141432072678134217648017629e+25", "12936960838097459955801414.32072678134217648017629");
            t("9.81886611183e+9", "9818866111.83");
            t("1.3e+1", "13");
            t("2.185212134168411755342025405260683400574952243371e+1", "21.8521213416841175534202540526068340057495224337100");
            t("5.09812942277266e+1", "50.9812942277266");
            t("1.15841228150473459450904593187073359993e+37", "11584122815047345945090459318707335999.3");
            t("2.946408e+1", "29.46408");
            t("7.8843253757257e+6", "7884325.3757257");
            t("4.149829532631829e+7", "41498295.32631829");
            t("9.76844406944663415436782518894675931581135161845733e+46", "97684440694466341543678251889467593158113516184.5733");
            t("1.320634109357604978481e+7", "13206341.09357604978481");
            t("1.2300117044692162331376535732386421937e+8", "123001170.44692162331376535732386421937");
            t("1.79343822239530391558796001578394154846951511735e+42", "1793438222395303915587960015783941548469515.11735");
            t("3.46227335968923941657647562338569e+7", "34622733.5968923941657647562338569");
            t("3.6081901133629252234652167e+18", "3608190113362925223.4652167");
            t("3.41769614577210353834283168068494e+24", "3417696145772103538342831.68068494");
            t("1.036693895e+8", "103669389.5");
            t("9.840862048026534392868878603161623504069221701e+27", "9840862048026534392868878603.161623504069221701");
            t("2.56437211238605e+10", "25643721123.86050");
            t("2.645333616435501e+6", "2645333.616435501");
            t("3.75834254646606787747061360998e+1", "37.5834254646606787747061360998");
            t("1.21582101247e+6", "1215821.01247");
            t("5.43e+1", "54.3");
            t("3.1461380403028457753654142032015e+27", "3146138040302845775365414203.2015");
            t("2.73039e+4", "27303.9");
            t("3.349112077000398203735762417e+25", "33491120770003982037357624.170");
            t("2.293912475527946909960963698602754526495697363e+31", "22939124755279469099609636986027.54526495697363");
            t("7.800578368e+8", "780057836.8");
            t("3.503304265046835170500513083432983735273e+28", "35033042650468351705005130834.32983735273");
            t("6.521027589563589728e+9", "6521027589.563589728");
            t("1.26604818273232e+3", "1266.04818273232");
            t("4.5844253800756959854340115e+7", "45844253.800756959854340115");
            t("2.5103887704609158215979351198183e+20", "251038877046091582159.79351198183");
            t("6.5170765018089001398157674630438543e+17", "651707650180890013.98157674630438543");
            t("7.85679659655762637941070216699747e+18", "7856796596557626379.41070216699747");
            t("6.55113755834849587145e+18", "6551137558348495871.45");
            t("1.37856413555592382324487860882977704999616e+32", "137856413555592382324487860882977.704999616");
            t("7.51530486314140193e+5", "751530.486314140193");
            t("1.3712642461229590011e+7", "13712642.4612295900110");
            t("8.945222111405724e+2", "894.5222111405724");
            t("1.74501389497524149414213254563953197394499747444317e+44", "174501389497524149414213254563953197394499747.444317");
            t("7.1583294041845987824307132e+11", "715832940418.45987824307132");
            t("1.282007923703783860923747442697572540049e+13", "12820079237037.83860923747442697572540049");
            t("5.660625174793381639446229222e+11", "566062517479.3381639446229222");
            t("2.094745267e+4", "20947.45267");
            t("8.4497877437844686621097450218313191175e+13", "84497877437844.6866210974502183131911750");
            t("1.707217105197425488000493702652714920318758323999364e+23", "170721710519742548800049.3702652714920318758323999364");
            t("2.5487434814078948112667918801256335353406914111636153e+36", "2548743481407894811266791880125633535.3406914111636153");
            t("7.975944255792483246376368330364e+8", "797594425.5792483246376368330364");
            t("1.1038710051127692465453332862048e+20", "110387100511276924654.53332862048");
            t("2.0214122542287381656860062564183697682e+13", "20214122542287.381656860062564183697682");
            t("7.853012025112e+4", "78530.12025112");
            t("7.97061651146928e+3", "7970.61651146928");
            t("1.5712956919727392305361179349388e+10", "15712956919.727392305361179349388");
            t("8.2480059e+3", "8248.0059");
            t("2.71929146422591231877279340940781443961397491e+19", "27192914642259123187.7279340940781443961397491");
            t("2.131e+2", "213.10");
            t("5.53443299017925367e+6", "5534432.99017925367");
            t("9.0599636453e+8", "905996364.53");
            t("2.86841011915001378943e+0", "2.86841011915001378943");
            t("3.50691916034642635201767965866239485795145676493e+28", "35069191603464263520176796586.6239485795145676493");
            t("1.20268235416561427028396813141142129291e+18", "1202682354165614270.283968131411421292910");
            t("4.8878729e+4", "48878.7290");
            t("9.04344910891e+4", "90434.4910891");
            t("3.87232843764031e+2", "387.232843764031");
            t("2.246212201353343e+11", "224621220135.33430");
            t("4.92916234816086643529027167741689023e+4", "49291.6234816086643529027167741689023");
            t("2.1773818234639052045922630496e+22", "21773818234639052045922.630496");
            t("4.78705362683815125848e+0", "4.787053626838151258480");
            t("2.700762078698436846755198719005e+28", "27007620786984368467551987190.05");
            t("3.04897901998664513240359358574664525651334171e+36", "3048979019986645132403593585746645256.51334171");
            t("3.807300704307638993582e+18", "3807300704307638993.582");
            t("7.9846840795076707340124614425632613353204e+3", "7984.6840795076707340124614425632613353204");
            t("6.69918558928e+4", "66991.8558928");
            t("5.11e+1", "51.1");
            t("1.8e+1", "18");
            t("2.629676971e+2", "262.9676971");
            t("6.8402048967767212280354493672372347369800788279670097e+39", "6840204896776721228035449367237234736980.0788279670097");
            t("4.684145127602661593941009299096573092581e+21", "4684145127602661593941.009299096573092581");
            t("1.3010133600355313564757759338788842e+18", "1301013360035531356.4757759338788842");
            t("1.58527974113934732993372979240170059e+30", "1585279741139347329933729792401.70059");
            t("1.8249338722142728063286e+2", "182.49338722142728063286");
            t("1.5941e+0", "1.59410");
            t("2.0337546838170082473539926326926478252219475e+29", "203375468381700824735399263269.26478252219475");
            t("4.626173e+3", "4626.173");
            t("6.04857e+0", "6.04857");
            t("9.55039030589038069713466331e+0", "9.55039030589038069713466331");
            t("3.13977842e+6", "3139778.42");
            t("4.4046554138751e+10", "44046554138.751");
            t("2.27133088062335544441002965096e+25", "22713308806233554444100296.5096");
            t("1.72895143e+4", "17289.5143");
            t("2.59665963383099309886519729836757e+20", "259665963383099309886.5197298367570");
            t("5.42804375404301025317704270939778493719619031067122726e+24", "5428043754043010253177042.70939778493719619031067122726");
            t("4.0526054186532354119711729303068171063825508e+2", "405.26054186532354119711729303068171063825508");
            t("1.26960267394273418410687782475849e+9", "1269602673.94273418410687782475849");
            t("5.657206212494798707700546288522044895183104747814298e+7", "56572062.12494798707700546288522044895183104747814298");
            t("4.80834664047405196104320584899449259286e+21", "4808346640474051961043.20584899449259286");
            t("5.6639294733687553228095e+12", "5663929473368.7553228095");
            t("3.08469899797006019074738182718775120203832280411e+44", "308469899797006019074738182718775120203832280.4110");
            t("6.7324018330891115163882850963905830707247414517739e+20", "673240183308911151638.82850963905830707247414517739");
            t("7.8e+1", "78");
            t("3.7511576e+4", "37511.576");
            t("4.9744737445922007872559411117007e+20", "497447374459220078725.59411117007");
            t("1.4264855114407053894401398660016825255242638071603e+2", "142.64855114407053894401398660016825255242638071603");
            t("1.7972e+1", "17.972");
            t("1.08223075909551421423442320791403363148864e+12", "1082230759095.51421423442320791403363148864");
            t("1.27992032328728568e+16", "12799203232872856.8");
            t("3.23410998756876789482263723951851692122375679e+9", "3234109987.56876789482263723951851692122375679");
            t("8.309058187826413886051933894555524364e+5", "830905.8187826413886051933894555524364");
            t("5.9126904485324084868266487306831291316268437628598e+40", "59126904485324084868266487306831291316268.437628598");
            t("3.579918283412251816470339246643e+16", "35799182834122518.16470339246643");
            t("8.292403288e+1", "82.92403288");
            t("7.39431e+2", "739.431");
            t("3.880259e+2", "388.0259");
            t("8.356612898392420429137009991722851e+18", "8356612898392420429.137009991722851");
            t("5.395903069e+4", "53959.03069");
            t("2.084656696443025813e+12", "2084656696443.025813");
            t("7.54671420639507228408101673007042651462774881888e+46", "75467142063950722840810167300704265146277488188.8");
            t("6.9e+1", "69");
            t("8.921e+2", "892.10");
            t("2.51196408e+4", "25119.6408");
            t("4.2502325992166027236666111862782e+15", "4250232599216602.7236666111862782");
            t("1.48181688637265610577148846528720697801886e+17", "148181688637265610.577148846528720697801886");
            t("6.578849006577789439801702e+0", "6.578849006577789439801702");
            t("4.346905625146927213132990652e+22", "43469056251469272131329.90652");
            t("5.5037893e+0", "5.5037893");
            t("2.47731675267438120023934691987e+15", "2477316752674381.20023934691987");
            t("3.37487366652276710575333974697197457e+9", "3374873666.52276710575333974697197457");
            t("1.0385387059229329627650733271e+0", "1.0385387059229329627650733271");
            t("9.83004944893186643985967600066862369294062e+17", "983004944893186643.985967600066862369294062");
            t("4.24581658127100743607231740518633563667839856744e+26", "424581658127100743607231740.518633563667839856744");
            t("3.14222253457223322124561584676953981561133e+2", "314.222253457223322124561584676953981561133");
            t("1.1553833141891499623566322265502695096447390786748e+48", "1155383314189149962356632226550269509644739078674.8");
            t("5.2811e+1", "52.811");
            t("9.925202445922857021945001443270353221818473047344e+2", "992.5202445922857021945001443270353221818473047344");
            t("1.5758941e+4", "15758.9410");
            t("6.6630010328564980059488916358767e+30", "6663001032856498005948891635876.7");
            t("1.49898377473153728100588907982263779724221092732531e+44", "149898377473153728100588907982263779724221092.732531");
            t("4.175238908185616536855e+20", "417523890818561653685.5");
            t("1.192838736272799853174021036238e+21", "1192838736272799853174.021036238");
            t("1.145038e+3", "1145.038");
            t("4.0973786626728889384598402998014750474268e+9", "4097378662.6728889384598402998014750474268");
            t("5.5038104e+4", "55038.104");
            t("6.83895535917805849194871290958068199407518e+2", "683.895535917805849194871290958068199407518");
            t("2.9716066182e+0", "2.9716066182");
            t("1e+0", "1");
            t("1.78063428481384259205331358231117935e+0", "1.780634284813842592053313582311179350");
            t("6.277714976103425712837719e+22", "62777149761034257128377.1900");
            t("1.37376909692642287134486582232200547809845780076e+26", "137376909692642287134486582.232200547809845780076");
            t("7.0255659498942180908195e+16", "70255659498942180.908195");
            t("1.36758412477e+6", "1367584.12477");
            t("2.8993016541323392639291954727329719281958174e+23", "289930165413233926392919.54727329719281958174");
            t("2.44e+0", "2.44");
            t("5.39870374073212675286058196342904027304008232e+40", "53987037407321267528605819634290402730400.8232");
            t("6.4507160654825e+9", "6450716065.4825");
            t("1.21664e+3", "1216.64");
            t("3.13108416362400780440861428855476299376486503e+0", "3.13108416362400780440861428855476299376486503");
            t("7.2960499529336221198242592384915903149558006256202995e+17", "729604995293362211.98242592384915903149558006256202995");
            t("5.67239328846178836850536139916737284448973e+0", "5.67239328846178836850536139916737284448973");
            t("7.20020305957519743064e+3", "7200.203059575197430640");
            t("1.85115423780064073715032545790701546649748120114e+27", "1851154237800640737150325457.90701546649748120114");
            t("1.25021250836778893386687012660759710902e+21", "1250212508367788933866.87012660759710902");
            t("2.3323707491301665555664068537483355865980611e+25", "23323707491301665555664068.5374833558659806110");
            t("2.5088131581298507401113299236e+4", "25088.131581298507401113299236");
            t("9.612326850563943155774866e+17", "961232685056394315.5774866");
            t("1.54114517176248297154289225338049499367447824e+22", "15411451717624829715428.9225338049499367447824");
            t("5.22e+0", "5.22");
            t("4.04698305476309533783897e+21", "4046983054763095337838.97");
            t("2.620876536774240989563272117908814902188002596311e+24", "2620876536774240989563272.117908814902188002596311");
            t("1.7290754650750439926458970782158e+10", "17290754650.750439926458970782158");
            t("8.570789332248e+6", "8570789.332248");
            t("1.21e+1", "12.1");
            t("9.749134061639126502181192178140679940393318673720443e+45", "9749134061639126502181192178140679940393318673.720443");
            t("1.26878e+5", "126878.0");
            t("1.2391599841950849289559651456348e+9", "1239159984.1950849289559651456348");
            t("1.72220118427662724614289256133342842086e+22", "17222011842766272461428.9256133342842086");
            t("1.512063585971680294584184272035496e+15", "1512063585971680.294584184272035496");

            Assert.Pass();
        }
    }
}