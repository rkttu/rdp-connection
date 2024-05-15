using System;
using System.Linq;

namespace RdpConnection
{
    // https://learn.microsoft.com/ko-kr/windows/win32/api/winuser/ns-winuser-windowpos
    public sealed class WindowPosition
    {
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

        public int Handle { get; set; } = 0;
        public SetWindowPositionFlags WindowState { get; set; } = default(SetWindowPositionFlags);
        public int Left { get; set; } = 0;
        public int Top { get; set; } = 0;
        public int Right { get; set; } = 0;
        public int Bottom { get; set; } = 0;

        public override string ToString()
            => $"{Handle},{(int)WindowState},{Left},{Top},{Right},{Bottom}";
    }
}
