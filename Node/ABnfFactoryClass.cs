
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;

namespace ALittle
{
    // 对象工厂
    public class ABnfFactoryClass : ABnfFactory
    {
        public override ABnfReference CreateReference(ABnfElement element)
        {
            if (element.GetNodeType() == "Id")
                return new ABnfIdReference(element);
            else if (element.GetNodeType() == "Regex")
                return new ABnfRegexReference(element);
            else if (element.GetNodeType() == "Key")
                return new ABnfKeyReference(element);
            else if (element.GetNodeType() == "String")
                return new ABnfStringReference(element);
            else if (element.GetNodeType() == "Node")
                return new ABnfNodeReference(element);
            return new ABnfCommonReference(element);
        }

        public override TextMarkerTag CreateTextMarkerTag()
        {
            return new ABnfHighlightWordTag();
        }

        public override string GetDotExt() { return ".abnf"; }

        public override byte[] LoadABnf() { return Properties.Resources.ABnf; }

        public override ABnfFile CreateABnfFile(string full_path, ABnf abnf, string text)
        {
            return new ABnfLangFile(full_path, abnf, text);
        }

        public override FileItem CreateFileItem(ProjectInfo project, ABnf abnf, string full_path, uint item_id, ABnfFile file)
        {
            return null;
        }
    }
}

