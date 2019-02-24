using Microsoft.Extensions.Primitives;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Fluid.Ast
{
    public class CommentStatement : Statement
    {
        private readonly StringSegment _segment;
        private string _text;

        public CommentStatement(StringSegment segment)
        {
            _segment = segment;
        }

        public string Text => _text = _text ?? _segment.Value;

        public override ValueTask<Completion> WriteToAsync(TextWriter writer, TextEncoder encoder, TemplateContext context)
        {
            return Normal;
        }
    }
}
