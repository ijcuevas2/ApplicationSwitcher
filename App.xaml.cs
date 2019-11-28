using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Runtime.InteropServices;


namespace ApplicationSwitcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /* Code to disable WinKey, Alt + Tab, Ctrl + Esc */
        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSSTRUCT
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr extra;
        }

        private delegate int LowLevelKeyboardProcDelegate(int nCode, int wParam, ref KBDLLHOOKSSTRUCT IParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProcDelegate Ipfn, IntPtr hMod, int dwThreadId);
        
        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hHook);

        [DllImport("user32.dll")]
        private static extern int CallNextHookEx(int hHook, int nCode, int wParam, ref KBDLLHOOKSSTRUCT IParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(IntPtr path);

        private IntPtr hHook;
        LowLevelKeyboardProcDelegate hookProc; // prevent gc?
        const int WH_KEYBOARD_LL = 13;

        private bool isWindowInFocus()
        {
            return MainWindow.IsHitTestVisible && MainWindow.IsActive;
        }

        public Boolean isKeyEquals(Key first, Key second)
        {
            return first == second;
        }

        private int LowLevelKeyboardProc(int nCode, int wParam, ref KBDLLHOOKSSTRUCT lParam)
        {
            if (!this.isWindowInFocus())
            {
                goto NextHook;
            }

            if (nCode >= 0)
            {
                bool isKeyDown = wParam == 256 || wParam == 260;
                bool isKeyUp = wParam == 257 || wParam == 261;
                if (isKeyDown)
                {
                    Key currentKey = KeyInterop.KeyFromVirtualKey(lParam.vkCode);
                    bool isShiftKey = (Keyboard.Modifiers & ModifierKeys.Shift) != 0;
                    bool isCtrlModifier = (Keyboard.Modifiers & ModifierKeys.Control) != 0;
                    bool isShiftModifier = (Keyboard.Modifiers & ModifierKeys.Shift) != 0;
                    bool isAltModifier = (Keyboard.Modifiers & ModifierKeys.Alt) != 0;

                    if (isCtrlModifier && isKeyEquals(currentKey, Key.A))
                    {
                        // textBoxElement.SelectAll();
                        goto NextHook;
                    }

                //    bool isAltTab = lParam.vkCode == 0x09 && lParam.flags == 32;
                //    if (isAltTab)
                //    {
                //        if (!this.IsVisible)
                //        {
                //            this.MainWindow_Show();
                //            return 1;
                //        }

                //        isKeyboardShortcut = true;
                //        if (isShiftKey)
                //        {
                //            Console.WriteLine("Keyboard Shortcut Decreasing Index");
                //            ProgramIndex--;
                //        }
                //        else
                //        {
                //            Console.WriteLine("Keyboard Shortcut Increasing Index");
                //            ProgramIndex++;
                //        }

                //        isKeyboardShortcut = false;
                //        return 1;
                //    }

                //    if (isKeyEquals(currentKey, Key.RightCtrl))
                //    {
                //        //System.Diagnostics.Debug.Print("_programIndex: {0}", _programIndex);
                //        //System.Diagnostics.Debug.Print("ProgramIndex: {0}", ProgramIndex);
                //        //System.Diagnostics.Debug.Print("SelectedIndex: {0}", programList.SelectedIndex);
                //        //System.Diagnostics.Debug.Print("SelectedItem: {0}", programList.SelectedItem);
                //        //System.Diagnostics.Debug.Print("CaretIndex: {0}", textBoxElement.CaretIndex);
                //        goto NextHook;
                //    }

                //    if (isKeyEquals(currentKey, Key.Back))
                //    {
                //        if (SelectedText.Length > 0)
                //        {
                //            SelectedText = "";
                //            goto NextHook;
                //        }

                //        if (CaretIndex < 2)
                //        {
                //            Text = Text.Substring(CaretIndex);
                //        }

                //        else
                //        {
                //            int prevCaretIndex = CaretIndex;
                //            int upperTarget = Math.Min(Text.Length, CaretIndex);
                //            Text = Text.Substring(0, CaretIndex - 1) + Text.Substring(upperTarget);
                //            CaretIndex = prevCaretIndex - 1;
                //        }

                //        goto NextHook;
                //    }

                //    if (isKeyEquals(currentKey, Key.Delete))
                //    {
                //        if (SelectedText.Length > 0)
                //        {
                //            SelectedText = "";
                //        }

                //        else
                //        {
                //            int prevCaretIndex = CaretIndex;
                //            int upperTarget = Math.Min(Text.Length, CaretIndex + 1);
                //            Text = Text.Substring(0, CaretIndex) + Text.Substring(upperTarget);
                //            CaretIndex = prevCaretIndex;
                //        }
                //    }

                //    if (isKeyEquals(currentKey, Key.Home))
                //    {
                //        CaretIndex = 0;
                //    }

                //    if (isKeyEquals(currentKey, Key.End))
                //    {
                //        CaretIndex = Text.Length;
                //    }

                //    if (isKeyEquals(currentKey, Key.PageUp))
                //    {
                //        textBoxElement.CaretIndex = 5;
                //    }

                //    // TODO: check for unnecessary decrementing or incrementing
                //    if (isKeyEquals(currentKey, Key.Left))
                //    {
                //        if (isShiftModifier)
                //        {
                //            if (isCtrlModifier)
                //            {
                //                textBoxElementSelection(0, CaretIndex);
                //            }

                //            else
                //            {
                //                SetTextSelection(false);
                //            }

                //            goto NextHook;
                //        }

                //        decrementCursorIndex();
                //        goto NextHook;
                //    }

                //    if (isKeyEquals(currentKey, Key.Right))
                //    {

                //        //System.Diagnostics.Debug.Print("SelectedText Update");
                //        if (isShiftModifier)
                //        {
                //            //System.Diagnostics.Debug.Print("CtrlModifier SelectedText Update");
                //            if (isCtrlModifier)
                //            {
                //                CaretIndex += SelectedText.Length;
                //                textBoxElementSelection(CaretIndex, Text.Length - CaretIndex);
                //            }

                //            else
                //            {
                //                SetTextSelection(true);
                //            }

                //            goto NextHook;
                //        }

                //        incrementCursorIndex();
                //    }

                //    // TODO: Refactor this section
                //    if (isKeyEquals(currentKey, Key.Space))
                //    {
                //        if (Text.Length == 0)
                //        {
                //            goto NextHook;
                //        }

                //        string currChar = " ";
                //        textBoxElement.AppendText(currChar);
                //    }

                //    if (isAlphaNumericKeyPress(currentKey))
                //    {
                //        setTextBoxVisible();

                //        char currChar = currentKey.ToString()[0];

                //        if (!isShiftKey)
                //        {
                //            currChar = Char.ToLower(currChar);
                //        }

                //        string currString = currChar.ToString();
                //        int currIndex = CaretIndex;
                //        string targetText = Text.Insert(CaretIndex, currString);
                //        //System.Diagnostics.Debug.Print("targetText: {0}", targetText);
                //        Text = targetText;
                //        CaretIndex = currIndex + 1;

                //        // NOTE: this is the fix
                //        goto NextHook;
                //    }

                //    if (isKeyEquals(currentKey, Key.Up))
                //    {
                //        ProgramIndex--;
                //    }

                //    if (isKeyEquals(currentKey, Key.Down))
                //    {
                //        ProgramIndex++;
                //    }

                //    if (isKeyEquals(currentKey, Key.Enter))
                //    {
                //        navigateToProgram();
                //    }


                }

                //if (isKeyUp)
                //{
                //    bool isAlt = lParam.vkCode == 0xA4 || lParam.vkCode == 0xA5;

                //    // NOTE: Be Careful
                //    if (isAlt)
                //    {
                //        System.Diagnostics.Debug.WriteLine("MainWindow_Hide");
                //        navigateToProgram();
                //    }

                //    if ((Keyboard.IsKeyUp(Key.LeftShift) || Keyboard.IsKeyUp(Key.RightShift))
                //        && !Keyboard.IsKeyDown(Key.LeftShift) && !Keyboard.IsKeyDown(Key.RightShift))
                //    {
                //        selectionPivot = null;
                //    }
                //}
            }

            NextHook:
            return CallNextHookEx(0, nCode, wParam, ref lParam);
        }
    }
}
