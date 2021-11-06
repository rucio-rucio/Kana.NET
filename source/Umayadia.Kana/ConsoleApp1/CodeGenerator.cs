using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CodeGenerator
    {
        public void GenerateToNarrowTest()
        {
            using var writer = new System.IO.StreamWriter(@"C:\temp\umaNarrowTest.txt");

            var codePoints = new List<int>();

            codePoints.Add(0x2018);
            codePoints.Add(0x2019);
            codePoints.Add(0x201C);
            codePoints.Add(0x201D);

            codePoints.Add(0x3000); //全角スペース
                                    //▼全角カタカナ領域
            codePoints.Add(0x3001);
            codePoints.Add(0x3002);
            codePoints.Add(0x300C);
            codePoints.Add(0x300D);

            codePoints.AddRange(Sequence(0x3099, 0x309C));
            codePoints.AddRange(Sequence(0x30A1, 0x30EF));
            codePoints.AddRange(Sequence(0x30F2, 0x30F4));
            codePoints.Add(0x30F7);
            codePoints.AddRange(Sequence(0x30FA, 0x30FC));
            //▲全角カタカナ領域



            codePoints.AddRange(Sequence(0xFF01, 0xFF5E));
            codePoints.Add(0xFF5F);
            codePoints.Add(0xFF60);
            codePoints.Add(0xFFE0);
            codePoints.Add(0xFFE1);
            codePoints.Add(0xFFE5); //全角円マーク


            IEnumerable<int> Sequence(int start, int end)
            {
                for (int i = start; i <= end; i++)
                {
                    yield return i;
                }
            }

            var converter = new Umayadia.Kana.DefaultKanaConverter();

            foreach (int codePoint in codePoints)
            {
                string Q = '\u0022'.ToString();
                char c = (char)codePoint;
                string converted = converter.ToNarrow(c.ToString());
                if (converted == "\u0022")
                {
                    converted = "\\\"";
                }
                else if (converted == "\\")
                {
                    converted = "\\\\";
                }

                writer.WriteLine($"Assert.AreEqual(KanaConverter.ToNarrow({Q}{c}{Q}), {Q}{converted}{Q}); // U+{codePoint:X4}");
            }
        }
    }
}
