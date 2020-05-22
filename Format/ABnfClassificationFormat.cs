
using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace ALittle
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "ABnfKeyWord")]
    [Name("ABnfKeyWord")]
    //this should be visible to the end user
    [UserVisible(false)]
    //set the priority to be after the default classifiers
    [Order(Before = Priority.Default)]
    internal sealed class ABnfKeyWordClassificationFormatDefinition : ClassificationFormatDefinition
    {
        public ABnfKeyWordClassificationFormatDefinition()
        {
            DisplayName = "ABnfKeyWord";
            ForegroundColor = Colors.Blue;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "ABnfId")]
    [Name("ABnfId")]
    //this should be visible to the end user
    [UserVisible(false)]
    //set the priority to be after the default classifiers
    [Order(Before = Priority.Default)]
    internal sealed class ABnfIdClassificationFormatDefinition : ClassificationFormatDefinition
    {
        public ABnfIdClassificationFormatDefinition()
        {
            DisplayName = "ABnfId"; 
            ForegroundColor = Colors.Navy;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "ABnfLineComment")]
    [Name("ABnfLineComment")]
    //this should be visible to the end user
    [UserVisible(false)]
    //set the priority to be after the default classifiers
    [Order(Before = Priority.Default)]
    internal sealed class ABnfLineCommentClassificationFormatDefinition : ClassificationFormatDefinition
    {
        public ABnfLineCommentClassificationFormatDefinition()
        {
            DisplayName = "ABnfLineComment"; 
            ForegroundColor = Colors.Green;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "ABnfBlockComment")]
    [Name("ABnfBlockComment")]
    //this should be visible to the end user
    [UserVisible(false)]
    //set the priority to be after the default classifiers
    [Order(Before = Priority.Default)]
    internal sealed class ABnfBlockCommentClassificationFormatDefinition : ClassificationFormatDefinition
    {
        public ABnfBlockCommentClassificationFormatDefinition()
        {
            DisplayName = "ABnfBlockComment"; 
            ForegroundColor = Colors.Green;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "ABnfKey")]
    [Name("ABnfKey")]
    //this should be visible to the end user
    [UserVisible(false)]
    //set the priority to be after the default classifiers
    [Order(Before = Priority.Default)]
    internal sealed class ABnfKeyClassificationFormatDefinition : ClassificationFormatDefinition
    {
        public ABnfKeyClassificationFormatDefinition()
        {
            DisplayName = "ABnfKey";
            var color = new Color();
            color.A = 0xFF;
            color.R = 0x21;
            color.G = 0x6F;
            color.B = 0x85;
            ForegroundColor = color;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "ABnfString")]
    [Name("ABnfString")]
    //this should be visible to the end user
    [UserVisible(false)]
    //set the priority to be after the default classifiers
    [Order(Before = Priority.Default)]
    internal sealed class ABnfStringClassificationFormatDefinition : ClassificationFormatDefinition
    {
        public ABnfStringClassificationFormatDefinition()
        {
            DisplayName = "ABnfString"; 
            ForegroundColor = Colors.Red;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "ABnfRegex")]
    [Name("ABnfRegex")]
    //this should be visible to the end user
    [UserVisible(false)]
    //set the priority to be after the default classifiers
    [Order(Before = Priority.Default)]
    internal sealed class ABnfRegexCommentClassificationFormatDefinition : ClassificationFormatDefinition
    {
        public ABnfRegexCommentClassificationFormatDefinition()
        {
            DisplayName = "ABnfRegex"; 
            ForegroundColor = Colors.DarkRed;
        }
    }
}
