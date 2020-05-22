
using Microsoft.VisualStudio.Text.Classification;

namespace ALittle
{
    public class ABnfCommonReference : ABnfReference
    {
        protected ABnfElement m_element;
        public ABnfCommonReference(ABnfElement element)
        {
            m_element = element;
        }

        public override string QueryClassificationTag(out bool blur)
        {
            blur = false;

            var type = m_element.GetNodeType();
            if (type == "Id")
            {
                var text = m_element.GetElementText();
                if (text == "Root" || text == "LineComment" || text == "BlockComment")
                    return "ABnfKeyWord";
                else
                    return "ABnfId";
            }
            else if (type == "LineComment" || type == "BlockComment" || type == "Key" || type == "String" || type == "Regex")
                return "ABnf" + type;
            return null;
        }
    }
}

