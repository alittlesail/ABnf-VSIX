﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ALittle.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ALittle.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   重写当前线程的 CurrentUICulture 属性
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找 System.Byte[] 类型的本地化资源。
        /// </summary>
        internal static byte[] ABnf {
            get {
                object obj = ResourceManager.GetObject("ABnf", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   查找类似 
        ///using Microsoft.VisualStudio.Language.Intellisense;
        ///using Microsoft.VisualStudio.Text;
        ///using Microsoft.VisualStudio.Text.Adornments;
        ///using Microsoft.VisualStudio.Text.Classification;
        ///using Microsoft.VisualStudio.Text.Tagging;
        ///using System.Collections.Generic;
        ///
        ///namespace ALittle
        ///{
        ///	public class @@LANGUAGE@@@@NAME@@Element : ABnfNodeElement
        ///	{
        ///		public @@LANGUAGE@@@@NAME@@Element(ABnfFactory factory, ABnfFile file, int line, int col, int offset, string type)
        ///            : base(factory, file, lin [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string ABnfElementTemplate {
            get {
                return ResourceManager.GetString("ABnfElementTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 
        ///using Microsoft.VisualStudio.Language.Intellisense;
        ///using Microsoft.VisualStudio.Shell.Interop;
        ///using Microsoft.VisualStudio.Text.Tagging;
        ///using System;
        ///using System.Collections.Generic;
        ///using System.Text.RegularExpressions;
        ///
        ///namespace ALittle
        ///{
        ///    public class @@LANGUAGE@@Factory : ABnfFactory
        ///    {   
        ///        Dictionary&lt;string, Func&lt;ABnfFactory, ABnfFile, int, int, int, string, ABnfNodeElement&gt;&gt; m_create_map = new Dictionary&lt;string, Func&lt;ABnfFactory, ABnfFile, int, int, int, string, ABnfNode [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string ABnfFactoryTemplate {
            get {
                return ResourceManager.GetString("ABnfFactoryTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似         List&lt;@@LANGUAGE@@@@NAME@@Element&gt; m_list_@@NAME@@ = null;
        ///        public List&lt;@@LANGUAGE@@@@NAME@@Element&gt; Get@@NAME@@List()
        ///        {
        ///            var list = new List&lt;@@LANGUAGE@@@@NAME@@Element&gt;();
        ///            if (m_list_@@NAME@@ == null)
        ///            {
        ///                m_list_@@NAME@@ = new List&lt;@@LANGUAGE@@@@NAME@@Element&gt;();
        ///                foreach (var child in m_childs)
        ///                {
        ///                    if (child is @@LANGUAGE@@@@NAME@@Element)
        ///                        m_list_@@NAME [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string ABnfGetChildListTemplate {
            get {
                return ResourceManager.GetString("ABnfGetChildListTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似         private bool m_flag_@@NAME@@ = false;
        ///        private @@LANGUAGE@@@@NAME@@Element m_cache_@@NAME@@ = null;
        ///        public @@LANGUAGE@@@@NAME@@Element Get@@NAME@@()
        ///        {
        ///            if (m_flag_@@NAME@@) return m_cache_@@NAME@@;
        ///            m_flag_@@NAME@@ = true;
        ///            foreach (var child in m_childs)
        ///            {
        ///                if (child is @@LANGUAGE@@@@NAME@@Element)
        ///                {
        ///                    m_cache_@@NAME@@ = child as @@LANGUAGE@@@@NAME@@Element;
        ///               [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string ABnfGetChildTemplate {
            get {
                return ResourceManager.GetString("ABnfGetChildTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 
        ///using Microsoft.VisualStudio.Language.Intellisense;
        ///using Microsoft.VisualStudio.Text;
        ///using Microsoft.VisualStudio.Text.Adornments;
        ///using Microsoft.VisualStudio.Text.Classification;
        ///using Microsoft.VisualStudio.Text.Tagging;
        ///using System.Collections.Generic;
        ///
        ///namespace ALittle
        ///{
        ///	public class @@LANGUAGE@@KeyElement : ABnfKeyElement
        ///	{
        ///		public @@LANGUAGE@@KeyElement(ABnfFactory factory, ABnfFile file, int line, int col, int offset, string type)
        ///            : base(factory, file, line, col, off [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string ABnfKeyElementTemplate {
            get {
                return ResourceManager.GetString("ABnfKeyElementTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 
        ///using Microsoft.VisualStudio.Language.Intellisense;
        ///using Microsoft.VisualStudio.Text;
        ///using Microsoft.VisualStudio.Text.Adornments;
        ///using Microsoft.VisualStudio.Text.Classification;
        ///using Microsoft.VisualStudio.Text.Tagging;
        ///using System.Collections.Generic;
        ///using System.Text.RegularExpressions;
        ///
        ///namespace ALittle
        ///{
        ///	public class @@LANGUAGE@@RegexElement : ABnfRegexElement
        ///	{
        ///		public @@LANGUAGE@@RegexElement(ABnfFactory factory, ABnfFile file, int line, int col, int offset, string type, Rege [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string ABnfRegexElementTemplate {
            get {
                return ResourceManager.GetString("ABnfRegexElementTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 
        ///using Microsoft.VisualStudio.Language.Intellisense;
        ///using Microsoft.VisualStudio.Text;
        ///using Microsoft.VisualStudio.Text.Adornments;
        ///using Microsoft.VisualStudio.Text.Classification;
        ///using Microsoft.VisualStudio.Text.Tagging;
        ///using System.Collections.Generic;
        ///
        ///namespace ALittle
        ///{
        ///	public class @@LANGUAGE@@StringElement : ABnfStringElement
        ///	{
        ///		public @@LANGUAGE@@StringElement(ABnfFactory factory, ABnfFile file, int line, int col, int offset, string type)
        ///            : base(factory, file, line, [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string ABnfStringElementTemplate {
            get {
                return ResourceManager.GetString("ABnfStringElementTemplate", resourceCulture);
            }
        }
    }
}
