using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text.Formatting;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Utilities;
using Microsoft.VisualStudio.Text.Editor;
using System.Reflection;
using System.IO;

namespace BraceLineShrinker
{
    [Export(typeof(ILineTransformSourceProvider))]
    [ContentType("CSharp")]
    [ContentType("C/C++")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    public class BraceLineTransformSourceProvider : ILineTransformSourceProvider
    {
        public ILineTransformSource Create(Microsoft.VisualStudio.Text.Editor.IWpfTextView textView)
        {
            return new BraceLineTransformSource();
        }
    }
    
    public class BraceLineTransformSource : ILineTransformSource
    {
        /// <summary>
        /// Scale factor of brace lines. Expose for another extension to change it if needed.
        /// </summary>
        public static double BraceLineScale { get; set; }

        const string settingsFilename = @"BraceLineScale.txt";
        Regex braceMatchExpression = new Regex(@"^(((\{\s*)+)|((\}\s*)+)|((\{\s*)+(\}\s*)+));?$");

        static BraceLineTransformSource()
        {
            // Try reading scale factor from settings file (just a text file in the same directory as this assembly that contains a single string that can be converted to a double).
            try
            {
                string settingsFilePath = string.Format("{0}\\{1}", 
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    settingsFilename);
                BraceLineScale = double.Parse(File.ReadAllText(settingsFilePath).Trim());
                if (BraceLineScale <= 0 || BraceLineScale > 100 || double.IsNaN(BraceLineScale))
                {
                    throw new InvalidOperationException();
                }
            }
            catch
            {
                // Set default scale
                BraceLineScale = 0.3;
            }
        }

        public LineTransform  GetLineTransform(ITextViewLine line, double yPosition, Microsoft.VisualStudio.Text.Editor.ViewRelativePosition placement)
        {
            if (braceMatchExpression.IsMatch(line.Extent.GetText().Trim()))
            {
                return new LineTransform(BraceLineScale);
            }
            else
            {
                return line.DefaultLineTransform;
            }
        }
    }
}