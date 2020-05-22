
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Adornments;
using Microsoft.VisualStudio.Text.Tagging;
using System.Collections.Generic;

namespace ALittle
{
    public class ABnfNodeReference : ABnfCommonReference
    {
        public ABnfNodeReference(ABnfElement element) : base(element) { }

        public override ABnfGuessError CheckError()
        {
            var parent = m_element.GetParent() as ABnfNodeElement;
            if (parent == null) return null;

            foreach (var child in parent.GetChilds())
            {
                if (child.GetNodeType() == "Id" && child.GetElementText() == "Root")
                    return null;
            }

            return CheckElementError(m_element);
        }

        private ABnfGuessError CheckElementError(ABnfElement element)
        {
            if (element.GetNodeType() == "List")
            {
                var node = element as ABnfNodeElement;
                if (node == null) return null;

                bool has_child = false;
                foreach (var child in node.GetChilds())
                {
                    if (child.GetNodeType() == "Option")
                    {
                        var error = CheckElementError(child);
                        if (error != null) return error;
                    }
                    else
                    {
                        var error = CheckElementError(child);
                        if (error == null)
                        {
                            has_child = true;
                            break;
                        }
                            
                    }
                }
                if (!has_child)
                    return new ABnfGuessError(element, "该规则不能保证一定会有子节点");
            }
            else if (element.GetNodeType() == "Option"
                || element.GetNodeType() == "Node")
            {
                var node = element as ABnfNodeElement;
                if (node == null) return null;

                foreach (var child in node.GetChilds())
                {
                    var error = CheckElementError(child);
                    if (error != null) return error;
                }   
            }
            else if (element.GetNodeType() == "Group"
                || element.GetNodeType() == "Leaf")
            {
                var node = element as ABnfNodeElement;
                if (node == null) return null;

                ABnfElement tail_node = null;
                foreach (var child in node.GetChilds())
                {
                    if (child.GetNodeType() == "NodeTail")
                        tail_node = child;
                }

                if (tail_node != null && (tail_node.GetElementText() == "*" | tail_node.GetElementText() == "?"))
                    return new ABnfGuessError(element, "该规则不能保证一定会有子节点");

                foreach (var child in node.GetChilds())
                {
                    var error = CheckElementError(child);
                    if (error != null) return error;
                }   
            }

            return null;
        }
    }
}

