using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umayadia.Kana
{
    public enum umaStrConv
    {
        /// <summary>
        /// Converts Katakana characters in the string to Hiragana characters. This member is equivalent to the Visual Basic constant vbHiragana.
        /// </summary>
        Hiragana = 32,

        /// <summary>
        /// Converts Hiragana characters in the string to Katakana characters. This member is equivalent to the Visual Basic constant vbKatakana.
        /// </summary>
        Katakana = 16
       
        //LinguisticCasing = 1024,
        //Converts the string from file system rules for casing to linguistic rules. This member is equivalent to the Visual Basic constant vbLinguisticCasing.

        //Lowercase = 2,
        //Converts the string to lowercase characters. This member is equivalent to the Visual Basic constant vbLowerCase.

        //Narrow = 8,
        //Converts wide (double-byte) characters in the string to narrow (single-byte) characters. Applies to Asian locales. This member is equivalent to the Visual Basic constant vbNarrow.

        //None = 0,
        //Performs no conversion.

        //ProperCase = 3,
        //Converts the first letter of every word in the string to uppercase. This member is equivalent to the Visual Basic constant vbProperCase.

        //SimplifiedChinese = 256,
        //Converts the string to Simplified Chinese characters. This member is equivalent to the Visual Basic constant vbSimplifiedChinese.

        //TraditionalChinese = 512,
        //Converts the string to Traditional Chinese characters. This member is equivalent to the Visual Basic constant vbTraditionalChinese.

        //Uppercase = 1,
        //Converts the string to uppercase characters. This member is equivalent to the Visual Basic constant vbUpperCase.

        //Wide = 4
        //Converts narrow (single-byte) characters in the string to wide (double-byte) characters. Applies to Asian locales. This member is equivalent to the Visual Basic constant vbWide. The conversion may use Normalization Form C even if an input character is already full-width. For example, the string "は゛" (which is already full-width) is normalized to "ば". See Unicode normalization forms.
    }
}
