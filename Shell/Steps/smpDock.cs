using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using WeifenLuo.WinFormsUI.Docking;

using Infrastructure.Library.Utility;

using IronPython;
using IronPython.Hosting;
using IronPython.Modules;
using Microsoft.Scripting.Hosting;

namespace Shell.Steps
{
    [SmartPart]
    public partial class smpDock : UserControl
    {
        bool runOnceMore = false;
        ShellForm app;
        public smpDock(ShellForm form)
        {
            app = form;
            InitializeComponent();

            //
            //foreach (Control ctl in this.DockArea.Controls)            
            //{
            //    //if (ctl is WeifenLuo.WinFormsUI.Docking.DockWindow)                
            //    //{
            //        ctl.BackColor = Color.White;
            //        //mdi = (WeifenLuo.WinFormsUI.Docking.DockWindow)ctl;
            //        //mdi.BackColor=Color.White;
            //    //}            
            //}
            
            //
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();

            scriptEngine = Python.CreateEngine();
            scope = scriptEngine.CreateScope();
            scope.SetVariable("dockPanel", DockArea);
            scope.SetVariable("App", this.app);
            scope.SetVariable("Ver", ((string)(configurationAppSettings.GetValue("Version", typeof(string)))));
         
       
            //scriptEngine.SetVariable(scope, "dockPanel", DockArea);
            //scriptEngine.SetVariable(scope, "App", this.app);
            //scriptEngine.SetVariable(scope, "Ver", ((string)(configurationAppSettings.GetValue("Version", typeof(string)))));

        }

        #region HotKey
        private void RegHotKey()
        {
            //Hotkey hotkeyEsc;
            //hotkeyEsc = new Hotkey(this.Handle);
            //int iEsc = hotkeyEsc.RegisterHotkey(System.Windows.Forms.Keys.Escape, Hotkey.KeyFlags.MOD_EMPTY);//Define the fast key( ESC) 
            //Hotkey.HotKeyDic.Add(iEsc, Keys.Escape);
            //hotkeyEsc.OnHotkey += new HotkeyEventHandler(OnHotkey);

            Hotkey hotkeyF1;
            hotkeyF1 = new Hotkey(this.Handle);
            int iF1 = hotkeyF1.RegisterHotkey(System.Windows.Forms.Keys.F1, Hotkey.KeyFlags.MOD_EMPTY);//Define the fast key( F1) 
            Hotkey.HotKeyDic.Add(iF1, Keys.F1);
            hotkeyF1.OnHotkey += new HotkeyEventHandler(OnHotkey);

            Hotkey hotkeyF2;
            hotkeyF2 = new Hotkey(this.Handle);
            int iF2 = hotkeyF2.RegisterHotkey(System.Windows.Forms.Keys.F2, Hotkey.KeyFlags.MOD_EMPTY);//Define the fast key( F2) 
            Hotkey.HotKeyDic.Add(iF2, Keys.F2);
            hotkeyF2.OnHotkey += new HotkeyEventHandler(OnHotkey);

            Hotkey hotkeyF3;
            hotkeyF3 = new Hotkey(this.Handle);
            int iF3 = hotkeyF3.RegisterHotkey(System.Windows.Forms.Keys.F3, Hotkey.KeyFlags.MOD_EMPTY);//Define the fast key( F3) 
            Hotkey.HotKeyDic.Add(iF3, Keys.F3);
            hotkeyF3.OnHotkey += new HotkeyEventHandler(OnHotkey);

            Hotkey hotkeyF4;
            hotkeyF4 = new Hotkey(this.Handle);
            int iF4 = hotkeyF4.RegisterHotkey(System.Windows.Forms.Keys.F4, Hotkey.KeyFlags.MOD_EMPTY);//Define the fast key( F4) 
            Hotkey.HotKeyDic.Add(iF4, Keys.F4);
            hotkeyF4.OnHotkey += new HotkeyEventHandler(OnHotkey);

            Hotkey hotkeyF5;
            hotkeyF5 = new Hotkey(this.Handle);
            int iF5 = hotkeyF5.RegisterHotkey(System.Windows.Forms.Keys.F5, Hotkey.KeyFlags.MOD_EMPTY);//Define the fast key( F5) 
            Hotkey.HotKeyDic.Add(iF5, Keys.F5);
            hotkeyF5.OnHotkey += new HotkeyEventHandler(OnHotkey);

            Hotkey hotkeyF6;
            hotkeyF6 = new Hotkey(this.Handle);
            int iF6 = hotkeyF6.RegisterHotkey(System.Windows.Forms.Keys.F6, Hotkey.KeyFlags.MOD_EMPTY);//Define the fast key( F6) 
            Hotkey.HotKeyDic.Add(iF6, Keys.F6);
            hotkeyF6.OnHotkey += new HotkeyEventHandler(OnHotkey);

            Hotkey hotkeyF7;
            hotkeyF7 = new Hotkey(this.Handle);
            int iF7 = hotkeyF7.RegisterHotkey(System.Windows.Forms.Keys.F7, Hotkey.KeyFlags.MOD_EMPTY);//Define the fast key( F7) 
            Hotkey.HotKeyDic.Add(iF7, Keys.F7);
            hotkeyF7.OnHotkey += new HotkeyEventHandler(OnHotkey);

            Hotkey hotkeyF8;
            hotkeyF8 = new Hotkey(this.Handle);
            int iF8 = hotkeyF8.RegisterHotkey(System.Windows.Forms.Keys.F8, Hotkey.KeyFlags.MOD_EMPTY);//Define the fast key( F8) 
            Hotkey.HotKeyDic.Add(iF8, Keys.F8);
            hotkeyF8.OnHotkey += new HotkeyEventHandler(OnHotkey);

            Hotkey hotkeyF9;
            hotkeyF9 = new Hotkey(this.Handle);
            int iF9 = hotkeyF9.RegisterHotkey(System.Windows.Forms.Keys.F9, Hotkey.KeyFlags.MOD_EMPTY);//Define the fast key( F9) 
            Hotkey.HotKeyDic.Add(iF9, Keys.F9);
            hotkeyF9.OnHotkey += new HotkeyEventHandler(OnHotkey);

            Hotkey hotkeyF10;
            hotkeyF10 = new Hotkey(this.Handle);
            int iF10 = hotkeyF10.RegisterHotkey(System.Windows.Forms.Keys.F10, Hotkey.KeyFlags.MOD_EMPTY);//Define the fast key( F10) 
            Hotkey.HotKeyDic.Add(iF10, Keys.F10);
            hotkeyF10.OnHotkey += new HotkeyEventHandler(OnHotkey);
        }

        private void OnHotkey(int HotkeyID)
        {
            if (Hotkey.HotKeyDic.ContainsKey(HotkeyID))
            {
                foreach (DockContent d in DockArea.Contents)
                {
                    if (d.IsActivated)
                    {
                        d.OnHotKey(Hotkey.HotKeyDic[HotkeyID]);
                        return;
                    }
                }
            }
        }

        #endregion

        //PythonEngine scriptEngine = new PythonEngine();
        ScriptEngine scriptEngine = null;
        ScriptScope scope = null;

        Explorer _MenuTree;
        //FEG.MES.FEIS feis;

        public bool RunScript(string script)
        {
            //scriptEngine.Execute(script);
            scriptEngine.Execute(script, scope);
            return true;
        }

        public void Clear()
        {
            List<Infrastructure.BaseForm> ary = new List<Infrastructure.BaseForm>();
            foreach (var i in DockArea.Contents)
            {
                Infrastructure.BaseForm b = i as Infrastructure.BaseForm;
                if (b != null)
                    //((Infrastructure.BaseForm)i).Close();
                    ary.Add((Infrastructure.BaseForm)i);
            }
            Infrastructure.BaseForm[] forms = ary.ToArray();
            foreach (var j in forms)
                j.Close();
        }

        public void Load()
        {
            if (!runOnceMore)
            {
                runOnceMore = true;

                RegHotKey();

                //scriptEngine.DefaultModule.Globals["dockPanel"] = DockArea;
                //scriptEngine.DefaultModule.Globals["App"] = this.app;

                _MenuTree = new Explorer();
                _MenuTree.Show(DockArea, DockState.DockLeftAutoHide);

                //feis = new FEG.MES.FEIS();
                //feis.Show(DockArea);
            }

            _MenuTree.LoadTree();
            Infrastructure.CmdBridge.RunCode("880");
        }
    }
}
