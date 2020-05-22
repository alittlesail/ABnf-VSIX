
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Adornments;
using Microsoft.VisualStudio.Text.Tagging;
using System.Collections.Generic;

namespace ALittle
{
    public class ABnfStringReference : ABnfCommonReference
    {
        public ABnfStringReference(ABnfElement element) : base(element) { }

        public override ABnfGuessError CheckError()
        {
            if (m_element.GetLength() <= 2)
                return new ABnfGuessError(m_element, "关键字内容不能为空");
            return null;
        }
    }
}

