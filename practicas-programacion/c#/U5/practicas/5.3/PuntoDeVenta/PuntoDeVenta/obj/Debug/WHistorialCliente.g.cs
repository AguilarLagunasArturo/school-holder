﻿#pragma checksum "..\..\WHistorialCliente.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A514105F029B55C1218C70F2F7E4E5A7884722022EB24641C5A02A765D517193"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using PuntoDeVenta;
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


namespace PuntoDeVenta {
    
    
    /// <summary>
    /// WHistorialCliente
    /// </summary>
    public partial class WHistorialCliente : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\WHistorialCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgGenero;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\WHistorialCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelCliente;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\WHistorialCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelPresupuesto;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\WHistorialCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelCambio;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\WHistorialCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scrollProductos;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\WHistorialCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAceptar;
        
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
            System.Uri resourceLocater = new System.Uri("/PuntoDeVenta;component/whistorialcliente.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WHistorialCliente.xaml"
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
            this.imgGenero = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.labelCliente = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.labelPresupuesto = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.labelCambio = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.scrollProductos = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 6:
            this.buttonAceptar = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\WHistorialCliente.xaml"
            this.buttonAceptar.Click += new System.Windows.RoutedEventHandler(this.buttonAceptar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
