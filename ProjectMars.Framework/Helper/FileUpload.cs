using System;
using System.Collections.Generic;
using System.Text;
using AutoIt;

namespace ProjectMars.Framework.Helper
{
    public class FileUpload
    {
        public static void uploadFileUsingAutoIT(string fileName)
        {
            Console.WriteLine("File upload path: " + fileName);
            // Upload file
            //AutoIt autoIt = new AutoIt();
            AutoItX.WinWait("Open");
            AutoItX.WinActivate("Open");
            AutoItX.WinWaitActive("Open");
            AutoItX.ControlFocus("Open", "", "Edit1");
            AutoItX.ControlSetText("Open", "", "Edit1", fileName);
            AutoItX.ControlClick("Open", "", "Button1");
        }
    }
}
