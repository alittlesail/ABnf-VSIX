
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace ALittle
{
    internal static class ABnfClassificationTypeDefinition
    {
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("ABnfKeyWord")]
        internal static ClassificationTypeDefinition ABNFKEYWORD = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("ABnfId")]
        internal static ClassificationTypeDefinition ABNFID = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("ABnfLineComment")]
        internal static ClassificationTypeDefinition ABNFLINECOMMENT = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("ABnfBlockComment")]
        internal static ClassificationTypeDefinition ABNFBLOCKCOMMENT = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("ABnfKey")]
        internal static ClassificationTypeDefinition ABNFKEY = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("ABnfString")]
        internal static ClassificationTypeDefinition ABNFSTRING = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("ABnfRegex")]
        internal static ClassificationTypeDefinition ABNFREGEX = null;
    }
}
