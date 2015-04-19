using System.Text.RegularExpressions;
using PostalCodes.GenericPostalCodes;

namespace PostalCodes
{
    internal partial class BYPostalCode : AlphaNumericPostalCode
    {
        public BYPostalCode(string postalCode) : this(postalCode, " -", true) {}

        public BYPostalCode(string postalCode, string redundantCharacters, bool allowConvertToShort) : base(_formats, redundantCharacters, postalCode, allowConvertToShort) 
        {
            _countryName = "BY";
        }
        
        protected override PostalCode CreatePostalCode(string code, bool allowConvertToShort)
        {
            return new BYPostalCode(code, " -", allowConvertToShort);
        }
        
        public override bool Equals (object obj)
        {
            var other = obj as BYPostalCode;
            if (other == null) 
            {
                return false;
            }

            return PostalCodeString.Equals (other.PostalCodeString);
        }

        public override int GetHashCode ()
        {
            return PostalCodeString.GetHashCode ();
        }

        private static PostalCodeFormat[] _formats = {
            new PostalCodeFormat {
                Name = "6-Digits - 999999",
                RegexDefault = new Regex("^[0-9]{6}$", RegexOptions.Compiled),
                OutputDefault = "xxxxxx",
                AutoConvertToShort = false,
                ShortExpansionAsLowestInRange = "0",
                ShortExpansionAsHighestInRange = "9",
                LeftPaddingCharacter = "0",
            }
        };
    }
}
