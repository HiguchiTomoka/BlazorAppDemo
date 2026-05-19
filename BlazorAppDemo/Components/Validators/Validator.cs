using System.Text.RegularExpressions;

namespace BlazorAppDemo.Components.Validators
{
    /// <summary>
    /// チェック処理まとめ
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// nullブランクチェック
        /// true:null or ブランクである
        /// false:null or ブランクでない
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrBlankValidate(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return true;
            }

            if (string.IsNullOrEmpty(str))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 半角文字チェック
        /// true:半角文字である
        /// false:半角文字でない
        /// </summary>
        /// <returns></returns>
        public static bool IsIsOnlyHalfWidthChar(string str)
        {
            if (Regex.IsMatch(str, @"^[ -~｡-ﾟ]*$"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 半角英数字チェック
        /// true:半角英数字である
        /// false:半角英数字でない
        /// </summary>
        /// <returns></returns>
        public static bool IsOnlyAlphanumeric(string str)
        {
            if (Regex.IsMatch(str, @"^[0-9a-zA-Z]+$"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 半角数字チェック
        /// true:半角数字である
        /// false:半角数字でない
        /// </summary>
        /// <returns></returns>
        public static bool IsOnlyNumeric(string str)
        {
            if (Regex.IsMatch(str, @"^[0-9]+$"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// メールアドレス形式チェック
        /// true:メールアドレスの形式である
        /// false:メールアドレスの形式ではない
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsMailAddress(string str)
        {
            string mailAddressPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (Regex.IsMatch(str, mailAddressPattern))
            {
                return true;
            }
            return false;
        }
    }
       
}