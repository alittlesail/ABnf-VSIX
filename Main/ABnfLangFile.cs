
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ALittle
{
    public class ABnfLangFile : ABnfFileInfo
    {
        public ABnfLangFile(string full_path, ABnf abnf, string text) : base(full_path, abnf, text) { }

        // 规则名映射规则内容
        internal Dictionary<string, HashSet<ABnfElement>> m_rule = new Dictionary<string, HashSet<ABnfElement>>();
        // 获取规则
        internal Dictionary<string, HashSet<ABnfNodeElement>> m_index = new Dictionary<string, HashSet<ABnfNodeElement>>();

        public Dictionary<string, HashSet<ABnfElement>> GetRuleSet() { return m_rule; }

        // 更新分析内容
        public override void UpdateAnalysis()
        {
            m_root = null;
            m_rule.Clear();
            if (m_abnf == null) return;

            m_root = m_abnf.Analysis(this);
            if (m_root == null) return;

            m_index.Clear();
            CollectIndex(m_root);
            CollectRule();
        }

        public override void UpdateError()
        {
            if (m_root == null) return;

            CollectError(m_root);
            AnalysisError(m_root);
        }

        public void CollectIndex(ABnfNodeElement node)
        {
            if (node.GetNodeType() == "Id")
            {
                var value = node.GetElementText();
                HashSet<ABnfNodeElement> set;
                if (!m_index.TryGetValue(value, out set))
                {
                    set = new HashSet<ABnfNodeElement>();
                    m_index.Add(value, set);
                }
                set.Add(node as ABnfNodeElement);
            }

            foreach (var child in node.GetChilds())
            {
                if (child is ABnfNodeElement)
                    CollectIndex(child as ABnfNodeElement);
            }
        }

        // 收集规则ID
        public void CollectRule()
        {
            foreach (var element in m_root.GetChilds())
            {
                if (element.GetNodeType() != "Expression") continue;


                var node = element as ABnfNodeElement;
                ABnfElement id = null;
                ABnfElement value = null;
                foreach (var child in node.GetChilds())
                {
                    if (child.GetNodeType() == "Id")
                        id = child;
                    else if (child.GetNodeType() == "Node")
                        value = child;
                }
                if (id == null) continue;
                if (value == null) continue;
                string id_value = id.GetElementText();

                HashSet<ABnfElement> rule_set;
                if (!m_rule.TryGetValue(id_value, out rule_set))
                {
                    rule_set = new HashSet<ABnfElement>();
                    m_rule.Add(id_value, rule_set);
                }
                rule_set.Add(element);
            }
        }

        class CollectCompileInfo
        {
            // 0 表示没有，1表示一个，大于1表示多个
            public Dictionary<string, int> id_map = new Dictionary<string, int>(); 
            public int has_string = 0;
            public int has_regex = 0;
            public int has_key = 0;

            public void CopyFrom(CollectCompileInfo info)
            {
                foreach (var pair in info.id_map)
                    id_map.Add(pair.Key, pair.Value);
                has_string = info.has_string;
                has_regex = info.has_regex;
                has_key = info.has_key;
            }
        }

        // 生成文件
        public override bool CompileDocument()
        {
            if (HasError())
            {
                MessageBox.Show("请修正错误后再进行编译");
                return true;
            }

            var project_info = GetProjectInfo();
            if (project_info == null)
            {
                MessageBox.Show("请将当前文件放入工程后再进行编译");
                return true;
            }

            string language_name = Path.GetFileNameWithoutExtension(GetFullPath());

            string path = project_info.GetProjectPath();
            if (!path.EndsWith("/") && !path.EndsWith("\\"))
                path += "\\";
            path += "Generate";
            if (Directory.Exists(path)) DeleteFolder(path);
            if (Directory.CreateDirectory(path) == null)
            {
                MessageBox.Show("目标目录创建失败:" + path);
                return true;
            }

            string add_new_buffer = "";
            foreach (var rule in m_rule)
            {
                ABnfElement element = null;
                foreach (var e in rule.Value)
                {
                    if (element != null)
                    {
                        MessageBox.Show(rule.Key + " 的元素对象有" + rule.Value.Count + "个");
                        return true;
                    }

                    element = e;
                }
                if (element == null)
                {
                    MessageBox.Show(rule.Key + " 的元素对象有" + rule.Value.Count + "个");
                    return true;
                }

                var node = element as ABnfNodeElement;
                if (node == null)
                {
                    MessageBox.Show(rule.Key + "不是ABnfNodeElement类型");
                    return true;
                }

                ABnfNodeElement value = null;
                foreach (var child in node.GetChilds())
                {
                    if (child.GetNodeType() == "Node" && child is ABnfNodeElement)
                        value = child as ABnfNodeElement;
                }
                if (value == null)
                {
                    MessageBox.Show(rule.Key + "不是ABnfNodeElement类型");
                    return true;
                }

                CollectCompileInfo info = new CollectCompileInfo();
                CollectCompile(value, info, false);

                // 这里开始生成
                string buffer = Properties.Resources.ABnfElementTemplate;

                // 替换协议名字
                buffer = buffer.Replace("@@LANGUAGE@@", language_name);
                buffer = buffer.Replace("@@NAME@@", rule.Key);

                add_new_buffer += "            m_create_map[\"" + rule.Key + "\"] = (factory, file, line, col, offset, type) => { return new " + language_name + rule.Key + "Element(factory, file, line, col, offset, type); };\n";

                string get_child_buffer = "";
                foreach (var id_pair in info.id_map)
                {
                    if (id_pair.Value == 1)
                        get_child_buffer += Properties.Resources.ABnfGetChildTemplate.Replace("@@LANGUAGE@@", language_name).Replace("@@NAME@@", id_pair.Key);
                    else if (id_pair.Value > 1)
                        get_child_buffer += Properties.Resources.ABnfGetChildListTemplate.Replace("@@LANGUAGE@@", language_name).Replace("@@NAME@@", id_pair.Key);
                }

                if (info.has_key == 1)
                    get_child_buffer += Properties.Resources.ABnfGetChildTemplate.Replace("@@LANGUAGE@@", language_name).Replace("@@NAME@@", "Key");
                else if (info.has_key > 1)
                    get_child_buffer += Properties.Resources.ABnfGetChildListTemplate.Replace("@@LANGUAGE@@", language_name).Replace("@@NAME@@", "Key");

                if (info.has_string == 1)
                    get_child_buffer += Properties.Resources.ABnfGetChildTemplate.Replace("@@LANGUAGE@@", language_name).Replace("@@NAME@@", "String");
                else if (info.has_string > 1)
                    get_child_buffer += Properties.Resources.ABnfGetChildListTemplate.Replace("@@LANGUAGE@@", language_name).Replace("@@NAME@@", "String");

                if (info.has_regex == 1)
                    get_child_buffer += Properties.Resources.ABnfGetChildTemplate.Replace("@@LANGUAGE@@", language_name).Replace("@@NAME@@", "Regex");
                else if (info.has_regex > 1)
                    get_child_buffer += Properties.Resources.ABnfGetChildListTemplate.Replace("@@LANGUAGE@@", language_name).Replace("@@NAME@@", "Regex");

                buffer = buffer.Replace("@@ELEMENT_GET_CHILD@@", get_child_buffer);
                string file_path = path + "\\" + language_name + rule.Key + "Element.cs";
                try
                {
                    File.WriteAllText(file_path, buffer);
                }
                catch (System.Exception)
                {
                    MessageBox.Show(file_path + " 生成失败");
                    return true;
                }
            }

            {
                // 生成KeyElement
                string buffer = Properties.Resources.ABnfKeyElementTemplate.Replace("@@LANGUAGE@@", language_name);
                string file_path = path + "\\" + language_name + "KeyElement.cs";
                try
                {
                    File.WriteAllText(file_path, buffer);
                }
                catch (System.Exception)
                {
                    MessageBox.Show(file_path + " 生成失败");
                    return true;
                }
            }

            {
                // 生成StringElement
                string buffer = Properties.Resources.ABnfStringElementTemplate.Replace("@@LANGUAGE@@", language_name);
                string file_path = path + "\\" + language_name + "StringElement.cs";
                try
                {
                    File.WriteAllText(file_path, buffer);
                }
                catch (System.Exception)
                {
                    MessageBox.Show(file_path + " 生成失败");
                    return true;
                }
            }

            {
                // 生成RegexElement
                string buffer = Properties.Resources.ABnfRegexElementTemplate.Replace("@@LANGUAGE@@", language_name);
                string file_path = path + "\\" + language_name + "RegexElement.cs";
                try
                {
                    File.WriteAllText(file_path, buffer);
                }
                catch (System.Exception)
                {
                    MessageBox.Show(file_path + " 生成失败");
                    return true;
                }
            }

            {
                // 生成Factory
                string buffer = Properties.Resources.ABnfFactoryTemplate.Replace("@@LANGUAGE@@", language_name).Replace("@@ELEMENT_ADD_CREATE@@", add_new_buffer);
                string file_path = path + "\\" + language_name + "Factory.cs";
                try
                {
                    File.WriteAllText(file_path, buffer);
                }
                catch (System.Exception)
                {
                    MessageBox.Show(file_path + " 生成失败");
                    return true;
                }
            }

            MessageBox.Show("生成成功");
            return true;
        }

        private void CollectCompile(ABnfElement element, CollectCompileInfo info, bool multi)
        {
            if (element.GetNodeType() == "List")
            {
                var node = element as ABnfNodeElement;
                if (node == null) return;

                var leaf_or_group = new CollectCompileInfo();
                leaf_or_group.CopyFrom(info);

                List<CollectCompileInfo> option_list = new List<CollectCompileInfo>();
                option_list.Add(leaf_or_group);
                foreach (var child in node.GetChilds())
                {
                    if (child.GetNodeType() == "Option")
                    {
                        CollectCompileInfo option = new CollectCompileInfo();
                        option.CopyFrom(info);
                        CollectCompile(child, option, multi);
                        option_list.Add(option);
                    }
                    else
                    {
                        CollectCompile(child, leaf_or_group, multi);
                    }
                }

                foreach (var option in option_list)
                {
                    if (option.has_string > info.has_string)
                        info.has_string = option.has_string;
                    if (option.has_key > info.has_key)
                        info.has_key = option.has_key;
                    if (option.has_regex > info.has_regex)
                        info.has_regex = option.has_regex;

                    foreach (var pair in option.id_map)
                    {
                        if (info.id_map.TryGetValue(pair.Key, out int value))
                        {
                            if (pair.Value > value)
                            {
                                info.id_map.Remove(pair.Key);
                                info.id_map.Add(pair.Key, pair.Value);
                            }   
                        }
                        else
                        {
                            info.id_map.Add(pair.Key, pair.Value);
                        }
                    }
                }
            }
            else if (element.GetNodeType() == "Option"
                || element.GetNodeType() == "Node")
            {
                var node = element as ABnfNodeElement;
                if (node == null) return;

                foreach (var child in node.GetChilds())
                    CollectCompile(child, info, multi);
            }
            else if (element.GetNodeType() == "Group"
                || element.GetNodeType() == "Leaf")
            {
                var node = element as ABnfNodeElement;
                if (node == null) return;

                if (multi == false)
                {
                    ABnfElement tail_node = null;
                    foreach (var child in node.GetChilds())
                    {
                        if (child.GetNodeType() == "NodeTail")
                            tail_node = child;
                    }

                    if (tail_node != null)
                    {
                        var tail_value = tail_node.GetElementText();
                        multi = tail_value.StartsWith("+") || tail_value.StartsWith("*");
                    }
                }

                foreach (var child in node.GetChilds())
                    CollectCompile(child, info, multi);
            }
            else if (element.GetNodeType() == "Id")
            {
                int cur_count = 0;
                if (!info.id_map.TryGetValue(element.GetElementText(), out cur_count))
                    cur_count = 0;
                info.id_map[element.GetElementText()] = cur_count + (multi ? 2 : 1);
                return;
            }
            else if (element.GetNodeType() == "String")
            {
                info.has_string = info.has_string + (multi ? 2 : 1);
            }
            else if (element.GetNodeType() == "Key")
            {
                info.has_key = info.has_key + (multi ? 2 : 1);
            }
            else if (element.GetNodeType() == "Regex")
            {
                info.has_regex = info.has_regex + (multi ? 2 : 1);
            }
        }

        public static void DeleteFolder(string path)
        {
            foreach (string name in Directory.GetFileSystemEntries(path))
            {
                if (File.Exists(name))
                {
                    FileInfo fi = new FileInfo(name);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(name);     //删除文件   
                }
                else
                    DeleteFolder(name);    //删除文件夹
            }
            Directory.Delete(path);    //删除空文件夹
        }
    }
}
