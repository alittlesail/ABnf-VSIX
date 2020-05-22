
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text.Tagging;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Utilities;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Classification;
using System.Windows.Media;
using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell.Interop;

namespace ALittle
{
    // 文件绑定
    public class ABnfContentTypeDefinition
    {
        [Export]
        [Name("abnf")]
        [BaseDefinition("code")]
        internal static ContentTypeDefinition ABnfContentType = null;

        [Export]
        [FileExtension(".abnf")]
        [ContentType("abnf")]
        internal static FileExtensionToContentTypeDefinition ABnfFileType = null;
    }

    // 编辑器管理
    [Export(typeof(IVsTextViewCreationListener))]
    [ContentType("abnf")]
    [TextViewRole(PredefinedTextViewRoles.Interactive)]
    public class ABnfVsTextViewCreationListener : ALanguageVsTextViewCreationListener
    {
        public ABnfVsTextViewCreationListener()
        {
            m_factory = new ABnfFactoryClass();
        }
    }

    // 预测列表
    [Export(typeof(ICompletionSourceProvider))]
    [ContentType("abnf")]
    [Name("ABnfCompletionSourceProvider")]
    public sealed class ABnfCompletionSourceProvider : ALanguageCompletionSourceProvider { }

    // 控制器
    [Export(typeof(IIntellisenseControllerProvider))]
    [Name("ABnfControllerProvider")]
    [ContentType("abnf")]
    public class ABnfControllerProvider : ALanguageControllerProvider { }

    [Export(typeof(IQuickInfoSourceProvider))]
    [ContentType("abnf")]
    [Name("ABnfQuickInfoSourceProvider")]
    public class ABnfQuickInfoSourceProvider : ALanguageQuickInfoSourceProvider { }

    // 配色
    [Export(typeof(IViewTaggerProvider))]
    [ContentType("abnf")]
    [TagType(typeof(ClassificationTag))]
    public class ABnfClassifierProvider : ALanguageClassifierProvider { public ABnfClassifierProvider() : base("ABnfGotoDefinition") { } }
    
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "ABnfGotoDefinition")]
    [Name("ABnfGotoDefinition")]
    [Order(After = Priority.High)]
    public class ABnfGotoDefinitionClassificationFormatDefinition : ClassificationFormatDefinition
    {
        public ABnfGotoDefinitionClassificationFormatDefinition()
        {
            this.DisplayName = "ABnfGotoDefinition";
            this.TextDecorations = System.Windows.TextDecorations.Underline;
            this.ForegroundColor = Colors.Blue;
        }
    }

    public class ABnfClassificationDefinition
    {
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("ABnfGotoDefinition")]
        internal static ClassificationTypeDefinition ABNFGOTODEFINITION = null;
    }

    // 缩进
    [Export(typeof(ISmartIndentProvider))]
    [ContentType("abnf")]
    public class ABnfSmartIndentProvider : ALanguageSmartIndentProvider { }

    // 错误元素提示
    [Export(typeof(IViewTaggerProvider))]
    [ContentType("abnf")]
    [TagType(typeof(IErrorTag))]
    public class ABnfErrorTaggerProvider : ALanguageErrorTaggerProvider { }

    // 高亮元素提示
    [Export(typeof(IViewTaggerProvider))]
    [ContentType("abnf")]
    [TagType(typeof(TextMarkerTag))]
    public class ABnfHighlightWordTaggerProvider : ALanguageHighlightWordTaggerProvider { }

    [Export(typeof(EditorFormatDefinition))]
    [Name("ABnfHighlightWordFormatDefinition")]
    [UserVisible(true)]
    public class ABnfHighlightWordFormatDefinition : MarkerFormatDefinition
    {
        public ABnfHighlightWordFormatDefinition()
        {
            BackgroundColor = Colors.LightBlue;
            DisplayName = "ABnfHighlightWordFormatDefinition";
        }
    }

    public class ABnfHighlightWordTag : TextMarkerTag
    {
        public ABnfHighlightWordTag() : base("ABnfHighlightWordFormatDefinition") { }
    }

    // 鼠标按键处理
    [Export(typeof(IMouseProcessorProvider))]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    [TextViewRole(PredefinedTextViewRoles.EmbeddedPeekTextView)]
    [ContentType("abnf")]
    [Name("ABnfGoToDefinitionMouseHandlerProvider")]
    [Order(Before = "WordSelection")]
    public class ABnfGoToDefinitionMouseHandlerProvider : ALanguageGoToDefinitionMouseHandlerProvider { }

    // 键盘按键处理
    [Export(typeof(IKeyProcessorProvider))]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    [TextViewRole(PredefinedTextViewRoles.EmbeddedPeekTextView)]
    [ContentType("abnf")]
    [Name("ABnfGoToDefinitionKeyProcessorProvider")]
    [Order(Before = "VisualStudioKeyboardProcessor")]
    public class ABnfGoToDefinitionKeyProcessorProvider : ALanguageGoToDefinitionKeyProcessorProvider { }
}

