﻿#pragma checksum "..\..\..\Forme\FrmKorisnik.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "99F10868B5C375F6F82550D092BC64B61D08F236A4DEC706B20EAF375BA6A775"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfBanka.Forme;


namespace WpfBanka.Forme {
    
    
    /// <summary>
    /// FrmKorisnik
    /// </summary>
    public partial class FrmKorisnik : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Forme\FrmKorisnik.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtImeKorisnika;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Forme\FrmKorisnik.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrezimeKorisnika;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Forme\FrmKorisnik.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtJMBGKorisnika;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Forme\FrmKorisnik.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAdresaKorisnika;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Forme\FrmKorisnik.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtKontaktKorisnika;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Forme\FrmKorisnik.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Forme\FrmKorisnik.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOtkazi;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfBanka;component/forme/frmkorisnik.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forme\FrmKorisnik.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtImeKorisnika = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtPrezimeKorisnika = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtJMBGKorisnika = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtAdresaKorisnika = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtKontaktKorisnika = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnSacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Forme\FrmKorisnik.xaml"
            this.btnSacuvaj.Click += new System.Windows.RoutedEventHandler(this.btnSačuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnOtkazi = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Forme\FrmKorisnik.xaml"
            this.btnOtkazi.Click += new System.Windows.RoutedEventHandler(this.btnOtkaži_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
