
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Adornments;
using Microsoft.VisualStudio.Text.Tagging;
using System.Collections.Generic;

namespace ALittle
{
    public class ABnfRegexReference : ABnfCommonReference
    {
        public ABnfRegexReference(ABnfElement element) : base(element) { }

        public override ABnfGuessError CheckError()
        {
            var text = m_element.GetElementString();
            if (!text.StartsWith("\\A"))
                return new ABnfGuessError(m_element, "必须使用\\A规则的正则表达式，可以大大提高解析效率");
            return null;
        }

        public override string QueryQuickInfo()
        {
            var parent = m_element.GetParent();
            if (parent != null && parent.GetNodeType() == "Expression")
                return "下一个字符预测，如果预测失败则跳过该规则，提高解析效率";

            return "正则表达式匹配";
        }
    }
}

