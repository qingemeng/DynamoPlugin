﻿// (C) Copyright 2015 by  
//
using System;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;

// This line is not mandatory, but improves loading performances
[assembly: CommandClass(typeof(DynPlugin.MyCommands))]

namespace DynPlugin
{

    // This class is instantiated by AutoCAD for each document when
    // a command is called by the user the first time in the context
    // of a given document. In other words, non static data in this class
    // is implicitly per-document!
    public class MyCommands
    {
        // The CommandMethod attribute can be applied to any public  member 
        // function of any public class.
        // The function should take no arguments and return nothing.
        // If the method is an intance member then the enclosing class is 
        // intantiated for each document. If the member is a static member then
        // the enclosing class is NOT intantiated.
        //
        // NOTE: CommandMethod has overloads where you can provide helpid and
        // context menu.
        private ButtonWindow _btnWnd = null;
        // Modal Command with localized name
        [CommandMethod("ShowButtonGroup", "ShowButton", "ShowButton", CommandFlags.Modal)]
        public void MyCommand() // This method can have any name
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            if (acDoc == null)
                return;
            _btnWnd = new ButtonWindow();
            _btnWnd.Show();
            Application.MainWindow.Focus();
        }
        internal static void launchCommand()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            acDoc.SendStringToExecute("._point 1,1,1 ", true, false, false);
            acDoc.SendStringToExecute("._zoom _all ", true, false, false);
        }
    }
}
