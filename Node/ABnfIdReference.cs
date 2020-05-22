
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Adornments;
using Microsoft.VisualStudio.Text.Tagging;
using System.Collections.Generic;

namespace ALittle
{
    public class ABnfIdReference : ABnfCommonReference
    {
        public ABnfIdReference(ABnfElement element) : base(element) { }

        public override string QueryQuickInfo()
        {
            ABnfLangFile file = m_element.GetFile() as ABnfLangFile;

            HashSet<ABnfElement> rule_set;
            file.GetRuleSet().TryGetValue(m_element.GetElementText(), out rule_set);
            if (rule_set == null) return null;

            List<string> content_list = new List<string>();
            foreach (var rule in rule_set)
                content_list.Add(rule.GetElementText());
            return string.Join("\n", content_list);
        }
        public override bool QueryCompletion(int offset, List<ALanguageCompletionInfo> list)
        {
            ABnfLangFile file = m_element.GetFile() as ABnfLangFile;

            var value = m_element.GetElementText();
            foreach (var name in file.GetRuleSet().Keys)
            {
                if (name.StartsWith(value))
                    list.Add(new ALanguageCompletionInfo(name, null));
            }
            return true;
        }

        public override ABnfGuessError CheckError()
        {
            ABnfLangFile file = m_element.GetFile() as ABnfLangFile;

            var text = m_element.GetElementText();

            HashSet<ABnfElement> rule_set;
            file.m_rule.TryGetValue(text, out rule_set);
            if (rule_set == null)
            {
                var parent = m_element.GetParent();
                if (parent == null || parent.GetNodeType() != "Expression")
                {
                    return new ABnfGuessError(m_element, "未知类型");
                }
            }
            else if (rule_set.Count > 1)
            {
                return new ABnfGuessError(m_element, "重复定义");
            }

            if (text.Length != 0 && char.IsDigit(text[0]))
            {
                return new ABnfGuessError(m_element, "规则名不能已数字开头");
            }

            return null;
        }

        public override bool PeekHighlightWord()
        {
            return true;
        }

        public override void QueryHighlightWordTag(List<ALanguageHighlightWordInfo> list)
        {
            ABnfLangFile file = m_element.GetFile() as ABnfLangFile;

            var value = m_element.GetElementText();

            file.m_index.TryGetValue(value, out HashSet<ABnfNodeElement>  set);
            if (set == null) return;

            foreach (var element in set)
            {
                var info = new ALanguageHighlightWordInfo();
                info.start = element.GetStart();
                info.end = element.GetEnd();
                list.Add(info);
            }
        }

        public override ABnfElement GotoDefinition()
        {
            ABnfLangFile file = m_element.GetFile() as ABnfLangFile;

            HashSet<ABnfElement> rule;
            if (!file.GetRuleSet().TryGetValue(m_element.GetElementText(), out rule)) return null;

            foreach (ABnfElement e in rule) return e;
            return null;
        }
    }
}

