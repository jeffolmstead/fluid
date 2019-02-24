using Microsoft.Extensions.Primitives;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Fluid.Ast
{
    public class TextStatement : Statement
    {
        private readonly StringSegment _segment;

        public TextStatement(string text)
        {
            _segment = new StringSegment(text);
        }

        public TextStatement(StringSegment segment)
        {
            _segment = segment;
        }

        public bool IsNullOrWhiteSpace()
        {
            return StringSegment.IsNullOrEmpty(_segment);
        }

        public override ValueTask<Completion> WriteToAsync(TextWriter writer, TextEncoder encoder, TemplateContext context)
        {
            // The Text fragments are not encoded, but kept as-is

            for (var i = 0; i < _segment.Length; i++)
            {
                writer.Write(_segment[i]);
            }

            return Normal;
        }

        public override string ToString()
        {
            return _segment.Value;
        }
    }
}
