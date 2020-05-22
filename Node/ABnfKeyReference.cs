
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Adornments;
using Microsoft.VisualStudio.Text.Tagging;
using System.Collections.Generic;

namespace ALittle
{
    public class ABnfKeyReference : ABnfCommonReference
    {
        public ABnfKeyReference(ABnfElement element) : base(element) { }

        public override ABnfGuessError CheckError()
        {
            if (m_element.GetLength() <= 2)
                return new ABnfGuessError(m_element, "关键字内容不能为空");
            return null;
        }

        public override string QueryQuickInfo()
        {
            return "关键字：任意正则表达式遇到关键字，即使匹配成功也算失败，保证关键字高的解析优先级";
        }
    }
}

