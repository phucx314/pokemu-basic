using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Domain.Common.Constants
{
    public static class RegexConstants
    {
        /// <summary>
        /// Regex pattern for password validation
        /// Phải dài 8 - 30 ký tự, chứa cả chữ và số (ko có dấu cách). Có thể chứa các ký tự đặc biệt (@$!%*?&#) nhưng không bắt buộc
        /// </summary>
        public const string PasswordPattern = @"^(?=.*[a-zA-Z])(?=.*\d)[A-Za-z\d@$!%*?&#_-]{8,30}$";

        /// <summary>
        /// Regex pattern for name validation
        /// Allows letters, numbers, apostrophe ('). Length: 1 - 150
        /// \p{L} là một "Unicode Property". Nó đại diện cho bất kỳ loại ký tự chữ nào từ bất kỳ ngôn ngữ nào trên thế giới (L là viết tắt của Letter).
        /// Nó sẽ tự động khớp với các ký tự như â, ư, ô của tiếng Việt, 김 của tiếng Hàn, 字 của tiếng Trung, カ của tiếng Nhật, Ł của tiếng Ba Lan, Я của tiếng Nga... và tất cả các ngôn ngữ khác.
        /// </summary>
        public const string NamePattern = @"^[\p{L}0-9' ]{1,150}$"; // cần handle nốt tiếng Ả Rập -> để sau

        /// <summary>
        /// Regex pattern for username validation
        /// Allow lowercases and numbers only, length: 8 - 100
        /// </summary>
        public const string UsernamePattern = @"^[a-z0-9]{8,100}$";
    }
}
