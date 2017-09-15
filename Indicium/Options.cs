using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json;

namespace Indicium
{
    public class SettingsJson
    {
        public Theme Color { get; set; }
    }

    public static class Options
    {
        internal static Color ForegroundColor = Color.MediumOrchid;
        internal static Color ForegroundAccentColor = Color.DarkOrchid;

        internal readonly static string ThemeTag = "themeable";
        readonly static string SettingsFile = Application.StartupPath + "\\Indicium.json";

        internal static SettingsJson CurrentOptions = new SettingsJson();
        private static SettingsJson Flag = new SettingsJson();

        internal static IEnumerable<Control> GetSelfAndChildrenRecursive(Control parent)
        {
            List<Control> controls = new List<Control>();

            foreach (Control child in parent.Controls)
            {
                controls.AddRange(GetSelfAndChildrenRecursive(child));
            }

            controls.Add(parent);
            return controls;
        }

        internal static void ApplyTheme(Form f, List<TreeView> views = null)
        {
            switch (CurrentOptions.Color)
            {
                case Theme.Caramel:
                    SetTheme(f, Color.DarkOrange, Color.Chocolate, views);
                    break;
                case Theme.Lime:
                    SetTheme(f, Color.LimeGreen, Color.ForestGreen, views);
                    break;
                case Theme.Magma:
                    SetTheme(f, Color.Tomato, Color.Red, views);
                    break;
                case Theme.Minimal:
                    SetTheme(f, Color.Gray, Color.DimGray, views);
                    break;
                case Theme.Ocean:
                    SetTheme(f, Color.DodgerBlue, Color.RoyalBlue, views);
                    break;
                case Theme.Zerg:
                    SetTheme(f, Color.MediumOrchid, Color.DarkOrchid, views);
                    break;
            }
        }
        
        private static void SetTheme(Form f, Color c1, Color c2, List<TreeView> views = null)
        {
            ForegroundColor = c1;
            ForegroundAccentColor = c2;

            GetSelfAndChildrenRecursive(f).OfType<Button>().ToList().ForEach(b => b.BackColor = c1);
            GetSelfAndChildrenRecursive(f).OfType<Button>().ToList().ForEach(b => b.FlatAppearance.BorderColor = c1);
            GetSelfAndChildrenRecursive(f).OfType<Button>().ToList().ForEach(b => b.FlatAppearance.MouseDownBackColor = c2);
            GetSelfAndChildrenRecursive(f).OfType<Button>().ToList().ForEach(b => b.FlatAppearance.MouseOverBackColor = c2);

            foreach (Label tmp in GetSelfAndChildrenRecursive(f).OfType<Label>().ToList())
            {
                if ((string)tmp.Tag == ThemeTag)
                {
                    tmp.ForeColor = c1;
                }
            }
            foreach (LinkLabel tmp in GetSelfAndChildrenRecursive(f).OfType<LinkLabel>().ToList())
            {
                if ((string)tmp.Tag == ThemeTag)
                {
                    tmp.LinkColor = c1;
                    tmp.VisitedLinkColor = c1;
                    tmp.ActiveLinkColor = c2;
                }
            }
            if (views != null)
            {
                foreach (TreeView v in views)
                {
                    foreach (TreeNode tmp in v.Nodes)
                    {
                        if ((string)tmp.Tag == ThemeTag)
                        {
                            tmp.ForeColor = c1;
                        }

                        foreach (TreeNode tmp2 in tmp.Nodes)
                        {
                            if ((string)tmp2.Tag == ThemeTag)
                            {
                                tmp2.ForeColor = c1;
                            }
                        }
                    }
                }
            }
        }

        internal static void SaveSettings()
        {
            if (File.Exists(SettingsFile))
            {
                if (Flag.Color != CurrentOptions.Color)
                {
                    using (FileStream fs = File.Open(SettingsFile, FileMode.OpenOrCreate))
                    using (StreamWriter sw = new StreamWriter(fs))
                    using (JsonWriter jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Formatting.Indented;

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(jw, CurrentOptions);
                    }
                }
                else
                {
                    // no changes have been made, no need to save
                }
            }
        }

        internal static void LoadSettings()
        {
            if (!File.Exists(SettingsFile))
            {
                CurrentOptions.Color = Theme.Zerg;

                using (FileStream fs = File.Open(SettingsFile, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(fs))
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;

                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jw, CurrentOptions);
                }
            }
            else
            {
                CurrentOptions = JsonConvert.DeserializeObject<SettingsJson>(File.ReadAllText(SettingsFile));

                // initialize flag
                Flag.Color = CurrentOptions.Color;
            }
        }
    }
}
