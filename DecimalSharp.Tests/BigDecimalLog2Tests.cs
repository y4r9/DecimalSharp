using DecimalSharp.Core;
using NUnit.Framework;
using System;
using System.Globalization;

namespace DecimalSharp.Tests
{
    [TestFixture, Category("BigDecimalLog2")]
    public class BigDecimalLog2Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Log2()
        {
            var bigDecimalFactory = new BigDecimalFactory(new BigDecimalConfig()
            {
                Precision = 40,
                Rounding = RoundingMode.ROUND_HALF_UP,
                ToExpNeg = (long)-9e15,
                ToExpPos = (long)9e15,
                MaxE = (long)9e15,
                MinE = (long)-9e15
            });

            var t = (BigDecimalArgument<BigDecimal> n, string expected, long sd, RoundingMode rm) =>
            {
                var bigDecimalFactoryClone = bigDecimalFactory.Clone();
                bigDecimalFactoryClone.Config.Precision = sd;
                bigDecimalFactoryClone.Config.Rounding = rm;

                BigDecimalTests.assertEqual(expected, bigDecimalFactoryClone.Log2(n).ValueOf());
            };

            t("NaN", "NaN", 40, RoundingMode.ROUND_HALF_UP);
            t("-1e-234", "NaN", 40, RoundingMode.ROUND_HALF_UP);
            t("0", "-Infinity", 40, RoundingMode.ROUND_HALF_UP);
            t("-0", "-Infinity", 40, RoundingMode.ROUND_HALF_UP);
            t("1", "0", 40, RoundingMode.ROUND_HALF_UP);
            t("Infinity", "Infinity", 40, RoundingMode.ROUND_HALF_UP);

            // Test powers of 2
            for (var i = 0; i < 54; i++)
            {
                t(Math.Pow(2, i).ToString(CultureInfo.InvariantCulture), i.ToString(CultureInfo.InvariantCulture), 40, RoundingMode.ROUND_HALF_UP);
            }

            bigDecimalFactory.Config.ToExpNeg = 0;
            bigDecimalFactory.Config.ToExpPos = 0;

            t("7.47572e73", "2.4e+2", 2, RoundingMode.ROUND_FLOOR);
            t("2.4e1", "4.5849626e+0", 8, RoundingMode.ROUND_UP);
            t("4.443333e5", "1.9e+1", 2, RoundingMode.ROUND_CEIL);
            t("5e-2", "-4.321928094e+0", 10, RoundingMode.ROUND_CEIL);
            t("3.89999999999999996202830641978029954e-2", "-4.68038206e+0", 9, RoundingMode.ROUND_CEIL);
            t("4.087056706550000000000000000000000000459999999999994e-839", "-2.7850666e+3", 8, RoundingMode.ROUND_HALF_DOWN);
            t("7.103772438222211905867777771222222222222222288888888806e-81", "-2.66e+2", 3, RoundingMode.ROUND_HALF_EVEN);
            t("2e-1", "-2.321928095e+0", 10, RoundingMode.ROUND_HALF_DOWN);
            t("7.0327e30", "1.02e+2", 3, RoundingMode.ROUND_FLOOR);
            t("7.74113385511898770142564798256591111493439379377358402241596885033503e2", "9.5965e+0", 5, RoundingMode.ROUND_UP);
            t("5.0168236102e-7", "-2.092672e+1", 7, RoundingMode.ROUND_DOWN);
            t("3.88888888888888888888888888888888888888888888888888888888888885105520953776999999999999999959888e626", "2.09e+3", 3, RoundingMode.ROUND_UP);
            t("3.33333341e-109", "-3.603532e+2", 8, RoundingMode.ROUND_FLOOR);
            t("9e7", "2.64234e+1", 6, RoundingMode.ROUND_HALF_DOWN);
            t("9.9e-7", "-1.9946e+1", 5, RoundingMode.ROUND_DOWN);
            t("2.9998837933e43", "1.4443e+2", 5, RoundingMode.ROUND_HALF_EVEN);
            t("2.280014556961415390190701451555357370581333198813706555078628347239292735244389509334786213e3", "1.1155e+1", 5, RoundingMode.ROUND_HALF_UP);
            t("9.5e-90", "-2.957e+2", 4, RoundingMode.ROUND_HALF_EVEN);
            t("2e893", "2.9674818e+3", 8, RoundingMode.ROUND_HALF_EVEN);
            t("8e-27", "-9e+1", 1, RoundingMode.ROUND_HALF_DOWN);
            t("1.37e910", "3.0234e+3", 5, RoundingMode.ROUND_HALF_UP);
            t("8.12836e-7", "-2e+1", 2, RoundingMode.ROUND_HALF_UP);
            t("1.74e-601", "-2e+3", 2, RoundingMode.ROUND_FLOOR);
            t("2e-66", "-2.1824e+2", 5, RoundingMode.ROUND_CEIL);
            t("4.647228466399999999999999999999999999999999999999999999999999999998943563999999999999999999999999999999919327168257748860613941487999999999999999999999e-80", "-2.6353787e+2", 8, RoundingMode.ROUND_CEIL);
            t("6.414199e737", "2.5e+3", 2, RoundingMode.ROUND_HALF_EVEN);
            t("9.17e305", "1.01e+3", 3, RoundingMode.ROUND_DOWN);
            t("2.239999999999999999999999933510665347417652e-99", "-3.27707382e+2", 9, RoundingMode.ROUND_CEIL);
            t("1.3897263212335753192678233873729694699999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999e-233", "-7.74e+2", 3, RoundingMode.ROUND_FLOOR);
            t("1e29", "9.63e+1", 3, RoundingMode.ROUND_FLOOR);
            t("1e-4", "-1.329e+1", 4, RoundingMode.ROUND_HALF_UP);
            t("3.2e-67", "-2.208912e+2", 7, RoundingMode.ROUND_FLOOR);
            t("8e94", "3.1526124e+2", 9, RoundingMode.ROUND_DOWN);
            t("7.106731e51", "1.722475e+2", 7, RoundingMode.ROUND_HALF_UP);
            t("6.8249734444444444444444444444444444348116222222222222222222222222222222274858072062638524585118791096784e-3", "-7.195e+0", 4, RoundingMode.ROUND_HALF_DOWN);
            t("7.9313e-38", "-1.2e+2", 2, RoundingMode.ROUND_CEIL);
            t("9.463228512135835081894413860589e-58", "-1.8943e+2", 6, RoundingMode.ROUND_FLOOR);
            t("9.9e-71", "-2.4e+2", 2, RoundingMode.ROUND_FLOOR);
            t("3e-96", "-4e+2", 1, RoundingMode.ROUND_FLOOR);
            t("6.99448765077869176308972395456786641951135010547854119007664428296218e94", "3.1e+2", 2, RoundingMode.ROUND_DOWN);
            t("6e-473", "-1.568687e+3", 7, RoundingMode.ROUND_CEIL);
            t("8e-36", "-1.165e+2", 4, RoundingMode.ROUND_DOWN);
            t("3.2289084e203", "6.760424e+2", 7, RoundingMode.ROUND_DOWN);
            t("7.22e8", "2.94274236e+1", 9, RoundingMode.ROUND_UP);
            t("2.255555555555555830850499999e-684", "-2.2710253e+3", 8, RoundingMode.ROUND_CEIL);
            t("6.1558656863559636e853", "2.836e+3", 4, RoundingMode.ROUND_FLOOR);
            t("6.47999624483501572920131e2", "1e+1", 1, RoundingMode.ROUND_CEIL);
            t("8e2", "9.64385619e+0", 10, RoundingMode.ROUND_HALF_UP);
            t("3.7087506033220685595355297226e77", "3e+2", 1, RoundingMode.ROUND_HALF_DOWN);
            t("2.999e-2", "-5.059375e+0", 7, RoundingMode.ROUND_HALF_EVEN);
            t("7.622e972", "3e+3", 1, RoundingMode.ROUND_HALF_UP);
            t("9e897", "2e+3", 1, RoundingMode.ROUND_DOWN);
            t("1.11782576e-27", "-8.9531363e+1", 8, RoundingMode.ROUND_DOWN);
            t("4.2e579", "1.9254668e+3", 8, RoundingMode.ROUND_HALF_EVEN);
            t("4.29366e-6", "-1.78293607e+1", 9, RoundingMode.ROUND_FLOOR);
            t("2.5e11", "3.786314e+1", 7, RoundingMode.ROUND_UP);
            t("2.2e6", "2.10690721e+1", 10, RoundingMode.ROUND_UP);
            t("4.4284847498990825381935141920011840774884214901069306287301873764242619177749447748037035404379e-85", "-2.802e+2", 4, RoundingMode.ROUND_HALF_DOWN);
            t("1e3", "9.96578e+0", 6, RoundingMode.ROUND_DOWN);
            t("6.6e-7", "-2.0532e+1", 5, RoundingMode.ROUND_UP);
            t("8.690141627234254718597780859040018785362077868070223409444967282935124914698055875807134592002580083956972525898044027571687514089085870800669920198834746935239137077743100824925289e7", "2.63728764e+1", 9, RoundingMode.ROUND_HALF_EVEN);
            t("8.713956786790365525728798671055089827452503531619162658e-1", "-1.9860013e-1", 8, RoundingMode.ROUND_DOWN);
            t("5.252777777777777777777777777820165941111111162978472887747802033488044444444444444444444444444444e1", "5.71501e+0", 6, RoundingMode.ROUND_HALF_DOWN);
            t("9.69573459777908e-362", "-1.1992e+3", 5, RoundingMode.ROUND_CEIL);
            t("7.5569e-740", "-2.45531e+3", 6, RoundingMode.ROUND_HALF_DOWN);
            t("9.74035e-490", "-1.6e+3", 2, RoundingMode.ROUND_DOWN);
            t("8e-9", "-2.68973529e+1", 9, RoundingMode.ROUND_UP);
            t("1e344", "1.14e+3", 3, RoundingMode.ROUND_DOWN);
            t("3.3e-557", "-1.848591483e+3", 10, RoundingMode.ROUND_FLOOR);
            t("2.73e60", "2.0076459e+2", 8, RoundingMode.ROUND_HALF_DOWN);
            t("7.6e1", "6.2e+0", 2, RoundingMode.ROUND_FLOOR);
            t("7.0060379466068591e-849", "-2.817508354e+3", 10, RoundingMode.ROUND_FLOOR);
            t("7e917", "3.049e+3", 5, RoundingMode.ROUND_HALF_DOWN);
            t("1.64573410691885658042240459216310152314034696136140858593166940573494665902734186270099e26", "8.708886174e+1", 10, RoundingMode.ROUND_CEIL);
            t("7.796e-44", "-1.4321e+2", 5, RoundingMode.ROUND_UP);
            t("5e7", "2.55754247e+1", 9, RoundingMode.ROUND_DOWN);
            t("8.0569e-32", "-1.033e+2", 4, RoundingMode.ROUND_UP);
            t("2.28881e-557", "-1.8491e+3", 5, RoundingMode.ROUND_CEIL);
            t("7.09e-724", "-2.4022502e+3", 8, RoundingMode.ROUND_HALF_EVEN);
            t("1.59e3", "1.063481105e+1", 10, RoundingMode.ROUND_HALF_UP);
            t("1.8e-537", "-1.783e+3", 5, RoundingMode.ROUND_HALF_UP);
            t("5.02569e-2", "-4.3145345e+0", 9, RoundingMode.ROUND_DOWN);
            t("9.999979e-51", "-1.66096e+2", 6, RoundingMode.ROUND_HALF_DOWN);
            t("9.95e10", "3.65e+1", 3, RoundingMode.ROUND_HALF_DOWN);
            t("3.1e652", "2.168e+3", 4, RoundingMode.ROUND_HALF_DOWN);
            t("7e-182", "-6.017835583e+2", 10, RoundingMode.ROUND_CEIL);
            t("5.99999309522985100000000000000000099e5", "1.919460131e+1", 10, RoundingMode.ROUND_HALF_UP);
            t("9.9e460", "1.53139436e+3", 9, RoundingMode.ROUND_CEIL);
            t("1.1447008929998e5", "1.6805e+1", 5, RoundingMode.ROUND_HALF_UP);
            t("9.097e-19", "-5.9e+1", 2, RoundingMode.ROUND_CEIL);
            t("6.5e52", "1.75e+2", 3, RoundingMode.ROUND_DOWN);
            t("9.1022e-66", "-2.16061039e+2", 9, RoundingMode.ROUND_HALF_EVEN);
            t("5.5e26", "8.9e+1", 2, RoundingMode.ROUND_CEIL);
            t("5.9747169006993667897425525812121903668273701374897278125927633480174019986342932352404691395386370402376825534060778783e-14", "-4.39282e+1", 6, RoundingMode.ROUND_FLOOR);
            t("1.94061431409530657832815982480968096203289511358215661231397940293523261488675432814243049614887343783e8", "2.753e+1", 4, RoundingMode.ROUND_FLOOR);
            t("9.1129e87", "2.922e+2", 4, RoundingMode.ROUND_UP);
            t("8e-6", "-1.6931569e+1", 8, RoundingMode.ROUND_UP);
            t("6.958e-344", "-1.14e+3", 3, RoundingMode.ROUND_HALF_EVEN);
            t("7.6e5", "1.9535e+1", 5, RoundingMode.ROUND_FLOOR);
            t("8.96822222222222222222222222119508e-1", "-1.57106e-1", 6, RoundingMode.ROUND_HALF_UP);
            t("7.1e7", "2.6e+1", 2, RoundingMode.ROUND_FLOOR);
            t("9e-157", "-5.1837e+2", 5, RoundingMode.ROUND_HALF_DOWN);
            t("7.3000000000000004188645678064142e249", "8.30028e+2", 8, RoundingMode.ROUND_UP);
            t("3e482", "1.602754e+3", 7, RoundingMode.ROUND_FLOOR);
            t("4e-393", "-1.30352e+3", 6, RoundingMode.ROUND_UP);
            t("8.0683580222567551105228998180452489561929821735260733495394659472e-8", "-2.35e+1", 3, RoundingMode.ROUND_DOWN);
            t("2.5571e4", "1.46422e+1", 6, RoundingMode.ROUND_HALF_DOWN);
            t("6e-6", "-1.7e+1", 2, RoundingMode.ROUND_HALF_EVEN);
            t("1.863556445038493157629183718741040476555555567232e-19", "-6.221857529e+1", 10, RoundingMode.ROUND_HALF_UP);
            t("3.4999322222222222222222222222222222e6", "2.1739e+1", 5, RoundingMode.ROUND_UP);
            t("8.29442480297413880904354267107722332538975e7", "2.63057e+1", 6, RoundingMode.ROUND_CEIL);
            t("1.6075e519", "1.7247655e+3", 9, RoundingMode.ROUND_HALF_DOWN);
            t("5.1e1", "5.67242535e+0", 9, RoundingMode.ROUND_UP);
            t("9e64", "2.158e+2", 4, RoundingMode.ROUND_HALF_DOWN);
            t("1e-64", "-2.126034e+2", 8, RoundingMode.ROUND_HALF_UP);
            t("1.2e9", "3.0160387e+1", 8, RoundingMode.ROUND_HALF_EVEN);
            t("7.05241041246611819500000000000000000054212400000000000000000000000000000000000042232977062045088556972000000790972e6", "2.27496851e+1", 9, RoundingMode.ROUND_UP);
            t("9.99e6", "2.325205325e+1", 10, RoundingMode.ROUND_CEIL);
            t("5.5e8", "2.9034e+1", 5, RoundingMode.ROUND_DOWN);

            t("2.29000000000000000000000000000000941e-6064216", "-2.01448883085178626255335140463713074934932720849229068205713832098265563766344027535592e+7", 87, RoundingMode.ROUND_UP);
            t("2.98121814045205686710601835e22573260", "7.4e+7", 2, RoundingMode.ROUND_FLOOR);
            t("8.5e-26514", "-8.80745140450022749520253952874708807185261282873713855273316844696e+4", 66, RoundingMode.ROUND_FLOOR);
            t("4.27277644444444444445229244718482e59564", "1.9786942021770672585709275516796947196558597384271229335e+5", 56, RoundingMode.ROUND_HALF_DOWN);
            t("9.30924698789794524252424189e-7268098", "-2.41440957239301736069970890748362821264083887286824083322114198346358e+7", 69, RoundingMode.ROUND_CEIL);
            t("6.82822995960930271945935479943097116891923770438150513664283749e-73845404", "-2.4530911945439596112646746942354967782562830688718370848616148064936766e+8", 71, RoundingMode.ROUND_FLOOR);
            t("5.84609801261197461197367777868584502410357518694058115837e53773873", "1.786329420370789890141941994715176283881591558233e+8", 49, RoundingMode.ROUND_UP);
            t("8.688278e-5896", "-1.9582968977189900276130445857722403691239834352860488495115901049392035059e+4", 74, RoundingMode.ROUND_FLOOR);
            t("7.49799999999999999e773359", "2.6e+6", 2, RoundingMode.ROUND_UP);
            t("6.0058011661556442485511374048366250078225418753938770464520434234268903107102453944e10744", "3.56933818082e+4", 12, RoundingMode.ROUND_HALF_DOWN);
            t("8.68630429338007830362222222222222222222222222222222222222224311111492169e-9760", "-3.2418899463607355742502233209726140919e+4", 38, RoundingMode.ROUND_DOWN);
            t("9.52746022222222222222222222222222215664191409361214604694703455030696517727356425411864400894463350397433931235528e804991", "2.67412547112315240639400188262314420772255929501992193312106238120468244451376588594e+6", 84, RoundingMode.ROUND_DOWN);
            t("6.911111111111111111666e1", "6.1108457686882901783628093e+0", 27, RoundingMode.ROUND_DOWN);
            t("8.753466841179514488439739259716095758693108071675972857e23", "7.95342006969539499843372117e+1", 27, RoundingMode.ROUND_HALF_EVEN);
            t("6.9293897393471771424368590682187732e-4011970", "-1.33274730661169490860155583127171941591541636281413977719351949586860441308997446e+7", 82, RoundingMode.ROUND_HALF_UP);
            t("7.248721120952201811052791965700072860844575521374565607742276202674760812016031176300339165917842693831800259732548923e81275591", "2.69991672029200938697950079481902822412413739547133179600205778809e+8", 66, RoundingMode.ROUND_HALF_EVEN);
            t("8.839e-750866", "-2.494319717012534627980253814671911210803171821097666700403887940328806381876e+6", 76, RoundingMode.ROUND_HALF_EVEN);
            t("2.019694038441111111055555e78", "2.601245281582228388774544331608154321133400916160739209330622912088316832563990039571098875e+2", 91, RoundingMode.ROUND_UP);
            t("6.999992707421e-9095", "-3.02101286695814990981946878100430318253824323913669024362543485421644529066733767002654624094e+4", 93, RoundingMode.ROUND_HALF_EVEN);
            t("6.573152030373740763721111111111111111111111111111111111111111111111056e-77071", "-2.56021603615710387e+5", 18, RoundingMode.ROUND_DOWN);
            t("7.000003608682e589878", "1.959535108111633331253094708685915889078e+6", 40, RoundingMode.ROUND_CEIL);

            Assert.Pass();
        }
    }
}