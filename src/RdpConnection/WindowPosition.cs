using System;
using System.Linq;

namespace RdpConnection
{
    /// <summary>
    /// Represents the position of a window.
    /// </summary>
    /// <remarks>
    /// <see href="https://learn.microsoft.com/ko-kr/windows/win32/api/winuser/ns-winuser-windowpos"/>
    /// </remarks>
    public sealed class WindowPosition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowPosition"/> class.
        /// </summary>
        /// <param name="winposstrExpression">Represents the position of a window as a string. (Handle, Window State, Left, Top, Right, Bottom)</param>
        public WindowPosition(string winposstrExpression)
        {
            if (string.IsNullOrWhiteSpace(winposstrExpression))
                return;

            var array = winposstrExpression
                .Split(Constants.CommaSeparator, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim());

            int handle, windowState, left, top, right, bottom;

            if (int.TryParse(array.ElementAtOrDefault(0) ?? "0", out handle))
                Handle = handle;
            if (int.TryParse(array.ElementAtOrDefault(1) ?? "0", out windowState))
                WindowState = (SetWindowPositionFlags)windowState;
            if (int.TryParse(array.ElementAtOrDefault(2) ?? "0", out left))
                Left = left;
            if (int.TryParse(array.ElementAtOrDefault(3) ?? "0", out top))
                Top = top;
            if (int.TryParse(array.ElementAtOrDefault(4) ?? "0", out right))
                Right = right;
            if (int.TryParse(array.ElementAtOrDefault(5) ?? "0", out bottom))
                Bottom = bottom;
        }

        /// <summary>
        /// Handle of the window.
        /// </summary>
        public int Handle { get; set; } = 0;

        /// <summary>
        /// State of the window.
        /// </summary>
        public SetWindowPositionFlags WindowState { get; set; } = default;

        /// <summary>
        /// Left position of the window.
        /// </summary>
        public int Left { get; set; } = 0;

        /// <summary>
        /// Top position of the window.
        /// </summary>
        public int Top { get; set; } = 0;

        /// <summary>
        /// Right position of the window.
        /// </summary>
        public int Right { get; set; } = 0;

        /// <summary>
        /// Bottom position of the window.
        /// </summary>
        public int Bottom { get; set; } = 0;

        /// <summary>
        /// Converts the value of this instance to a <see cref="string"/>.
        /// </summary>
        /// <returns>
        /// String representation of the window position. (Handle, Window State, Left, Top, Right, Bottom)
        /// </returns>
        public override string ToString()
            => $"{Handle},{(int)WindowState},{Left},{Top},{Right},{Bottom}";
    }
}
